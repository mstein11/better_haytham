using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace RoombaControl
{
    public partial class Form1 : Form
    {

        

        delegate void LogCallback(string text, Color c);
        delegate void UpdateSensorDisplayDelegate(Sensors s);

        #region members

        Roomba roomba;
        bool textExpected = true;
        int speed = 50;
        bool sensorPolling = false;
        int sensorUpdateDelay;
        bool pollSensors = false;
        Thread sensorPollingThread;
        UpdateSensorDisplayDelegate UpdateSensorsDelegate;
        RoombaRecording rr;
        SensorPacketGroup currentSpg;
        private System.Object writeLock = new System.Object();

        #endregion

        #region init

        public Form1()
        {
            InitializeComponent();
            SetStyle(  ControlStyles.AllPaintingInWmPaint |
                            ControlStyles.UserPaint |
                            ControlStyles.DoubleBuffer, true);


            Roomba.SendToRoomba str = Write;
            roomba = new Roomba(str);
            portNametextBox.Text = "COM3";// Properties.Settings.Default.PortName;
            sensorUpdateDelay = 1000 / updateFreqTrackBar.Value;
            UpdateSensorsDelegate = new UpdateSensorDisplayDelegate(UpdateSensorDisplay);
            FillSensorGroupList();
        }

        private void AutoStart()
        {
            ConnectSynchronous();
            roomba.InitROI();
            roomba.Leds_Raw(80, 92, 124, 0);  // write rob
            sensorGroupList.SelectedItem = 3;
            updateFreqTrackBar.Value = 4;
            StartPollingSensors();

        }

        private void FillSensorGroupList()
        {
            foreach (SensorPacketGroup spg in Sensors.sp)
            {
                sensorGroupList.Items.Add(spg);
            }
        }




        private void ConnectAsync()
        {
            Thread t = new Thread(new ThreadStart(this.ConnectSynchronous));
            t.Start();
            connectButton.Enabled = false;
            disconnectButton.Enabled = true;
        }

        private void ConnectSynchronous()
        {
            try
            {
                serialPort.PortName = Properties.Settings.Default.PortName;
                serialPort.Open();
                Write("$$$");
                Write("U,115k,N\n");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot open " + serialPort.PortName + "\n" + ex);
            }

        }

        #endregion

        #region log

        private string FormatBytes(byte[] buffer, int offset, int count)
        {
            String s = "";
            for (int i = offset; i < count; i++)
            {
                s = s + buffer[i].ToString("d") + " ";
            }
            return s;
        }

        private void Log(byte[] buf, Color c)
        {
            String s = Environment.NewLine ;
            for (int i = 0; i < buf.Length; i++)
            {
                s = s + buf[i].ToString("d") + " ";
                if (i % 16 == 0)
                {
                    Log(s, c);
                    s = Environment.NewLine;
                }
            }
        }

        private void Log(string text)
        {
            Log(text, Color.Black);
        }
            
        private void Log(string text, Color c)
        {
            if (traceCheckBox.Checked)
            {
                // InvokeRequired required compares the thread ID of the
                // calling thread to the thread ID of the creating thread.
                // If these threads are different, it returns true.
                if (this.traceRichTextBox.InvokeRequired)
                {
                    LogCallback d = new LogCallback(Log);
                    try
                    {
                        this.Invoke(d, new object[] { text, c });
                    }
                    catch (ObjectDisposedException)
                    {
                    }
                }
                else
                {
                    int s = traceRichTextBox.SelectionStart;

                    traceRichTextBox.AppendText(text);
                    traceRichTextBox.Select(s, text.Length);
                    traceRichTextBox.SelectionColor = c;
                    traceRichTextBox.Select(traceRichTextBox.TextLength, 0);
                    traceRichTextBox.ScrollToCaret();
                }
            }
        }

        #endregion

        #region ReadWritePort

        private void Write(byte[] buffer, int offset, int count)
        {
            Log(FormatBytes(buffer, offset, count), Color.Purple);
            lock (writeLock)
            {
                try
                {
                    ExpectText(false);
                    serialPort.Write(buffer, offset, count);
                    Thread.Sleep(100);
                }
                catch (Exception)
                {
                    Log("Cannot write to port: " + serialPort.PortName);
                }
            }
        }

        private void ExpectText(bool p)
        {
            textExpected = p;
        }

        private void Write(string s)
        {

            lock (writeLock)
            {
                Log(s + Environment.NewLine, Color.Red);
                ExpectText(true);
                serialPort.Write(s);
                Thread.Sleep(100);
            }
        }

        private void serialPort_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            //textExpected = true;
            if (textExpected)
            {
                //read data waiting in the buffer
                string msg = serialPort.ReadExisting();
                Log(msg, Color.DarkBlue);
                //textExpected = false;
            }
            else  // read binary data
            {
                //Thread.Sleep(10); // wait for complete packet
                WaitForCompletePacket((currentSpg == null) ? 0 : currentSpg.numBytes);

                Log("Reading " + serialPort.BytesToRead + " bytes" + Environment.NewLine);
                byte[] buf = new byte[serialPort.BytesToRead];
                serialPort.Read(buf, 0, buf.Length);
                //Log(buf, Color.Chocolate);
                Sensors s = new Sensors(buf, roomba.lastPacketRequested());
                if (s.IsValid())
                {
                    Object[] args = new Object[] { s };
                    try
                    {
                        this.Invoke(UpdateSensorsDelegate, args);
                    }
                    catch (Exception)
                    {
                        //Log("\nException in delegete call\n", Color.Red);
                    }
                    //Log(".");
                    //Log(s.ToString(), Color.Chocolate);
                }
            }
        }

        private void WaitForCompletePacket(int numBytesExpected)
        {
            bool exit = false;
            int waitCount = 100; // times the wait below
            while (!exit)
            {
                if (serialPort.BytesToRead >= numBytesExpected) exit = true; // either correct packet, or we're lagging behind: read all
                else
                {
                    Thread.Sleep(1);
                    exit = (0 == waitCount--);
                }
            }
        }

        private byte[] getBytes(string s)
        {
            char[] delimit = new char[] { ' ' };
            String [] sa = s.Split(delimit);
            Byte[] ba = new byte[sa.Length];
            for (int i=0; i<sa.Length; i++)
            {
                ba[i] = Byte.Parse(sa[i]);
            }
            return ba;
        }

        #endregion

        #region SensorPolling


        private void SensorPollingThread()
        {
            while (sensorPolling)
            {
                textExpected = false;
                roomba.RequestSensorData(100);
                Thread.Sleep(500);
            }
        }

        private void UpdateSensorDisplay()
        {
            SensorPacketGroup spg = (SensorPacketGroup)sensorGroupList.SelectedItem;
            sensorTextBox.Clear();
            for (int i = 0; i < spg.numItems; i++)
            {
                sensorTextBox.AppendText(Sensors.sd[spg.offsetInSensorDesc + i].name + Environment.NewLine);
            }
        }

        private void UpdateSensorDisplay(Sensors s)
        {
            SensorPacketGroup spg = (SensorPacketGroup)sensorGroupList.SelectedItem;
            sensorTextBox.Clear();
            for (int i = 0; i < spg.numItems; i++)
            {
                sensorTextBox.AppendText(Sensors.sd[spg.offsetInSensorDesc + i].name + ": " + s.GetValue((Sensors.SensorID)(spg.offsetInSensorDesc + i)) + Environment.NewLine);
            }

            // drawing update
            canvas1.rotateRoomba(s.GetValue(Sensors.SensorID.Angle));
            canvas1.moveRoomba(s.GetValue(Sensors.SensorID.Distance));

        }

        private void StartPollingSensors()
        {
            pollSensors = true;
            sensorPollingThread = new Thread(new ThreadStart(PollSensors));
            sensorPollingThread.Start();
        }

        private void PollSensors()
        {
            while (pollSensors) {
                if (currentSpg != null) roomba.requestSensorPacket(currentSpg);
                // else MessageBox.Show("Select a sensor group first");
                Thread.Sleep(sensorUpdateDelay);
            }
        }

        #endregion

        #region UIhandling


        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void disconnectButton_Click(object sender, EventArgs e)
        {
            serialPort.Close();
            disconnectButton.Enabled = false;
            connectButton.Enabled = true;
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            roomba.InitROI();
            roomba.Leds_Raw(80, 92, 124, 0);  // write rob
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            byte[] buf = getBytes(OpcodesTextBox.Text);
            Write(buf, 0, buf.Length);
        }

        private void sendTextbutton_Click(object sender, EventArgs e)
        {
            Write(OpcodesTextBox.Text + ((addCRcheckBox.Checked) ? "\n" : ""));
        }



        private void fwdButton_MouseDown(object sender, MouseEventArgs e)
        {
            roomba.Drive_Direct(speed, speed);
        }

        private void fwdButton_Click(object sender, EventArgs e)
        {

        }

        private void fwdButton_MouseUp(object sender, MouseEventArgs e)
        {
            roomba.Drive_Direct(0, 0);
        }

        private void leftButton_MouseDown(object sender, MouseEventArgs e)
        {
            roomba.Drive_Direct(speed, speed * -1);
        }

        private void leftButton_MouseUp(object sender, MouseEventArgs e)
        {
            roomba.Drive_Direct(0, 0);
        }

        private void backButton_MouseDown(object sender, MouseEventArgs e)
        {
            roomba.Drive_Direct(speed * -1, speed * -1);
        }

        private void backButton_MouseUp(object sender, MouseEventArgs e)
        {
            roomba.Drive_Direct(0, 0);
        }

        private void rightButton_MouseDown(object sender, MouseEventArgs e)
        {
            roomba.Drive_Direct(speed * -1, speed);
        }

        private void rightButton_MouseUp(object sender, MouseEventArgs e)
        {
            roomba.Drive_Direct(0, 0);
        }


        private void speedTrackBar_Scroll(object sender, EventArgs e)
        {
            speedLabel.Text = (speedTrackBar.Value / 10).ToString() + " cm/s";
            speed = speedTrackBar.Value;
        }

        private void dockButton_Click(object sender, EventArgs e)
        {
            roomba.Dock();
        }

        private void sensorsButton_Click(object sender, EventArgs e)
        {
            if (sensorPolling)
            {
                sensorPolling = false;
            }
            else
            {
                sensorPolling = true;
                Thread t = new Thread(SensorPollingThread);
                t.Start();
            }


        }

        private void cleanButton_Click(object sender, EventArgs e)
        {
            roomba.Clean();
        }

        private void spotButton_Click(object sender, EventArgs e)
        {
            roomba.SpotClean();
        }

        private void recordButton_Click(object sender, EventArgs e)
        {
            if (roomba.IsRecording())
            {
                roomba.StopRecording(rr);
                recordButton.Text = "Record";
            }
            else  // start recording
            {
                rr = roomba.StartRecording();
                recordButton.Text = "Stop recording";
            }

        }

        private void replayButton_Click(object sender, EventArgs e)
        {
            if (!roomba.IsReplaying())
            {
                Log(rr.ToString(), Color.Peru);
                roomba.StartReplay(rr);
            }
            else
            {
                roomba.StopReplay(rr);
            }
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            roomba.DriveStop();
        }

        private void brushesButton_Click(object sender, EventArgs e)
        {
            if (roomba.AreBrushesOn())
            {
                roomba.StopBrush();
            }
            else
            {
                roomba.StartBrush();
            }
        }

        private void sensorGroupList_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentSpg = (SensorPacketGroup)sensorGroupList.SelectedItem;
            UpdateSensorDisplay();
        }

        private void streamButton_Click(object sender, EventArgs e)
        {
            if (!pollSensors)
            {
                StartPollingSensors();
            }
            else
            {
                pollSensors = false;
            }
        }
        private void updateFreqTrackBar_Scroll(object sender, EventArgs e)
        {
            sensorUpdateDelay = 1000 / updateFreqTrackBar.Value;
            updateFreqLabel.Text = updateFreqTrackBar.Value + " updates/s";
        }



        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            canvas1.Invalidate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            canvas1.roombaAngle = 90;
            canvas1.Invalidate();
        }

        //private void textBox1_TextChanged_1(object sender, EventArgs e)
        //{
        //    canvas1.angleFactor = Int32.Parse(textBox1.Text);
        //}

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Stop threads
            pollSensors = false;
            while (sensorPollingThread != null && sensorPollingThread.IsAlive)
            {
                Thread.Sleep(10);
                Application.DoEvents();
            }
            
        }

        private void zoomInButton_Click(object sender, EventArgs e)
        {
            if (zoomTrackBar.Value < zoomTrackBar.Maximum) zoomTrackBar.Value += 1;
            canvas1.setScale((float)zoomTrackBar.Value/100);
        }

        private void zoomOutButton_Click(object sender, EventArgs e)
        {
            if (zoomTrackBar.Value > zoomTrackBar.Minimum) zoomTrackBar.Value -= 1;
            canvas1.setScale((float)zoomTrackBar.Value / 100);
        }

        private void zoomTrackBar_Scroll(object sender, EventArgs e)
        {
            canvas1.setScale((float)zoomTrackBar.Value / 100);
        }

        private void traceCheckBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            AutoStart();
        }

        private void clearTrailButton_Click(object sender, EventArgs e)
        {
            canvas1.ClearTrail();
        }

        private void portNametextBox_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.PortName = portNametextBox.Text;
            Properties.Settings.Default.Save();
        }

        private void clearTraceButton_Click(object sender, EventArgs e)
        {
            traceRichTextBox.Clear();
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            ConnectAsync();
        }
        #endregion 

    }
}
