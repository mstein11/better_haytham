using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;
using System.Threading;
using RoombaControl;

namespace Haytham_Client
{
    public partial class Form_Roomba : Form
    {

        bool followGaze;
        bool followGestures;
        public int noMarkerFrameCounter = 0;
        private Roomba roomba;
        private Form1 form1;
        private int angularSpeed = 140;
        private int speed = 300;
        private bool roombaIsMoving = false;
        private bool roombaIsRotating = false;


        System.Windows.Forms.ComboBox[] cmbs = new ComboBox[6];
        public Form_Roomba()
        {
            InitializeComponent();
        }


        public Form_Roomba(Form1 frm)
        {
            form1 = frm;
            InitializeComponent();


            Icon ico = new Icon(Properties.Resources.Untitled_2, 64, 64);
            this.Icon = ico;
            PortRoomba.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(PortRoomba_DataReceived);

        }
        void PortRoomba_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {

            SerialPort sp = sender as SerialPort;
            string data = sp.ReadExisting();
            // ChangeForm(data, "txtDebug");

        }
        public void Form_BOCU_Load(object sender, EventArgs e)
        {
            // groupBox1.Enabled = false;
            followGestures = true;
            ClientStatus.Commands = true;
            ClientStatus.VisualMarker = true;

            cmbs[0] = cmb_fwd;
            cmbs[1] = cmb_back;
            cmbs[2] = cmb_stop;
            cmbs[3] = cmb_left;
            cmbs[4] = cmb_right;
            cmbs[5] = cmb_clean;

          




            ClientStatus.userData.Clear();
            ClientStatus.userData.Add("Marker_6_11", "Roomba");
            ClientStatus.UpdateServer();








            this.Text += "_" + ClientStatus.clientName;
            ChangeForm("Connection successful\r\n", "textBox1");
            ChangeForm("Your name is " + ClientStatus.clientName + "\r\n", "textBox1");

            // start a new thread for sending and receiving messages
            ClientStatus.inputoutputThread = new Thread(new ThreadStart(Run));
            ClientStatus.inputoutputThread.Start();

            //serial port
            string[] theSerialPortNames = System.IO.Ports.SerialPort.GetPortNames();

            foreach (string port in theSerialPortNames)
            {
                cboPorts.Items.Add(port);
            }
            try
            {
                PortRoomba.PortName = cboPorts.Text;
                // PortBOCU.Open();

            }
            catch (Exception)
            { }
            foreach (ComboBox cmb in cmbs)
            {
                cmb.Text = "Select a command";
                cmb.Items.Add("Select a command");
                cmb.Items.Add("Blink");
                cmb.Items.Add("DbBlink");
                cmb.Items.Add("TR");
                cmb.Items.Add("TL");
                cmb.Items.Add("U_D");
                cmb.Items.Add("U_U");
                cmb.Items.Add("R_L");
                cmb.Items.Add("R_R");
                cmb.Items.Add("D_U");
                cmb.Items.Add("D_D");
                cmb.Items.Add("L_R");
                cmb.Items.Add("L_L");
                cmb.Items.Add("Custom1");
                cmb.Items.Add("Custom2");
                cmb.Items.Add("Custom3");
                cmb.Items.Add("Custom4");


            }
        }

        private void Form_Roomba_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                PortRoomba.Close();

            }
            catch (Exception)
            { }
            ClientStatus.clientName = "PauseReconnect";
            ClientStatus.inputoutputThread.Abort();
            ClientStatus.client.Close();

            form1.Show();

        }

        public void Run()
        {

            try
            {
                // receive messages that is sent to client
                while (true)
                {
                    if (roomba != null)
                    {
                        string msg = ClientStatus.reader.ReadString();
                        ProcessMessage(msg);
                    }

                }
            } // end try
            catch (IOException)
            {
                ChangeForm("Connection failed\r\n", "textBox1");

                Reconnect();
            } // end catch


        }

        private void ProcessMessage(string msg)
        {
            string[] msgArray = ConvertMsgToArray(msg);


            if (msg.StartsWith("Commands|"))
            {

                if (msgArray[2] == "Marker_6_11")
                {

                    foreach (ComboBox i in cmbs)
                    {
                        if (i != null && i.Tag != null && i.Tag.ToString() == msgArray[3])
                        {
                            PerformCommand((i.Name.ToString()).Remove(0, 4));
                            ChangeForm(msgArray[3], "textBox1");

                        }

                    }
                }

            }
            else if (msg.StartsWith("VisualMarker|"))
            {

  
                //stop Roomba when is not detected in the scene image (only in for the followgaze )
                if (msgArray[0] == "IsDetected")
                {
                    bool temp = false;
                    for (int i = 0; i < msgArray.Length; i++)
                    {
                        if (msgArray[i] == "Marker_6_11") temp = true;
                    }

                    if (temp) noMarkerFrameCounter = 0;
                    else if (!temp && noMarkerFrameCounter<5)noMarkerFrameCounter++;
                    else if (!temp)
                    {
                       if (roombaIsMoving | roombaIsRotating)
                       {
                           noMarkerFrameCounter = 0;
                        roombaIsMoving = false;
                        roombaIsRotating = false;

                        roomba.Drive_Direct(0, 0);
                       }
                    }


                }
                else if (msgArray[0] == "DistanceAngle"&& followGaze )
                {

                    for (int i = 0; i < msgArray.Length; i++)
                    {
                        if (msgArray[i] == "Marker_6_11")
                        {
                            ProcessGazeData(Convert.ToDouble( msgArray[i + 1]), Convert.ToInt32(msgArray[i + 2]));

                            break;
                        }
                    }

                }


            }

        }

        private void ProcessGazeData(double distance, int angle)
        {

           // ChangeForm(angle + "\r\n", "textBox1");
            if (distance > 0.5)
            {
                if (angle > 30) { if (roombaIsRotating != true)PerformCommand("right"); roombaIsRotating = true; roombaIsMoving = false; ChangeForm("Right\r\n", "textBox1"); }
                else if (angle < -30) { if (roombaIsRotating != true)PerformCommand("left"); roombaIsRotating = true; roombaIsMoving = false; ChangeForm("Left\r\n", "textBox1"); }
                else
                {
                    if (roombaIsRotating) { PerformCommand("stop"); roombaIsRotating = false; ChangeForm("stop\r\n", "textBox1"); }

                    if (!roombaIsMoving)
                    {
                        PerformCommand("fwd");
                        roombaIsMoving = true; ChangeForm("fwd\r\n", "textBox1"); 
                    }

                }
            }
            else { if (roombaIsMoving == true || roombaIsRotating == true)PerformCommand("stop"); roombaIsMoving = false; roombaIsRotating = false; }

        
        }


        private void PerformCommand(string command)
        {

            switch (command)
            {

                   
                   
                case "fwd":
                     roomba.Drive_Direct(speed, speed);
                    break;
                case "back":
                   roomba.Drive_Direct(speed * -1 * 2, speed * -1 * 2);
                    break;

                    
                case "right":
                   roomba.Drive_Direct(angularSpeed * -1, angularSpeed);
                    break;
                case "left":
                   roomba.Drive_Direct(angularSpeed, angularSpeed * -1);
                    break;
              
                  

                 case "stop":
                    roomba.DriveStop();   
                    break;   
        
                case "clean":
                    roomba.SpotClean();
                    break;
            }


        }
        private string[] ConvertMsgToArray(string msg)
        {
            //string temp = "";
            //List<string> msgArr = new List<string>();

            //for (int i = 0; i < msg.Length; i++)
            //{
            //	if (msg[i] == '|')
            //	{
            //		msgArr.Add(temp);
            //		temp = "";
            //	}
            //	else
            //	{
            //		temp += msg[i];

            //	}

            //}
            //msgArr.RemoveAt(0);//remove the keyword from the begining


            //@PJ same functionality
            var arr = msg.Split('|');
            var msgArr = arr.Skip(1).ToArray();	// skip first keyword

            return msgArr;

        }


        private void Reconnect()
        {

            ChangeForm("Waiting for connection...\r\n", "textBox1");
            ClientStatus.Reconnect();
            ChangeForm("Connection successful\r\n", "textBox1");
            Run();

        }


        // delegate that allows method DisplayMessage to be called
        // in the thread that creates and maintains the GUI
        private delegate void ChangeFormDelegate(string message, string control);
        // method DisplayMessage sets displayTextBox's Text property
        // in a thread-safe manner
        private void ChangeForm(string message, string control)
        {

            switch (control)
            {
                case "textBox1":
                    // if modifying displayTextBox is not thread safe
                    if (textBox1.InvokeRequired) Invoke(new ChangeFormDelegate(ChangeForm), new object[] { message, control });

                    else // OK to modify displayTextBox in current thread
                    {
                        textBox1.Text += message;

                        textBox1.SelectionStart = textBox1.Text.Length;
                        textBox1.ScrollToCaret();
                    }
                    break;





            }
        }
        private void cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cm = (ComboBox)sender;
            cm.Tag = cm.SelectedItem;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (btnStart.Text == "Open")
            {
                try
                {


                    PortRoomba.PortName = cboPorts.Text;

                    groupBox1.Enabled = true;
                    ClientStatus.Commands = true;
                    btnStart.Text = "Close";
                    AutoStart();
                }
                catch (Exception)
                { }
            }
            else
            {
                try
                {
                    roomba.DriveStop();
                    PortRoomba.Close();

                    groupBox1.Enabled = false;
                    ClientStatus.Commands = false;
                    btnStart.Text = "Open";
                }
                catch (Exception)
                { }
            }
        }

        private void AutoStart()
        {
            Roomba.SendToRoomba str = PortRoomba.Write;
            roomba = new Roomba(str);

            ConnectSynchronous();
            roomba.InitROI();
            roomba.Leds_Raw(80, 92, 124, 0);  // write rob
            //sensorGroupList.SelectedItem = 3;
            //updateFreqTrackBar.Value = 4;
            // StartPollingSensors();

        }
        private void ConnectSynchronous()
        {
            try
            {

                PortRoomba.Open();
                PortRoomba.Write("$$$");
                PortRoomba.Write("U,115k,N\n");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot open " + PortRoomba.PortName + "\n" + ex);
            }

        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

            if (radioButton_gaze.Checked)
            {
                followGaze = true;
                followGestures = false;
               // panel2.Enabled = false;
            }
            else
            {
                followGaze = false;
                followGestures = true;
               // panel2.Enabled = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ClientStatus.writer.Write(txtMsgToSend.Text);
            txtMsgToSend.Text = "";
        }



        private void fwd_MouseDown(object sender, MouseEventArgs e)
        {
            roomba.Drive_Direct(speed, speed);
        }


        private void left_MouseDown(object sender, MouseEventArgs e)
        {
            roomba.Drive_Direct(angularSpeed, angularSpeed * -1);
        }

        private void back_MouseDown(object sender, MouseEventArgs e)
        {
            roomba.Drive_Direct(speed * -1*2, speed * -1*2);
        }

        private void stop_MouseUp(object sender, MouseEventArgs e)
        {
            roomba.Drive_Direct(0, 0);
        }

        private void right_MouseDown(object sender, MouseEventArgs e)
        {
            roomba.Drive_Direct(angularSpeed * -1, angularSpeed);
        }

        private void stop_Click(object sender, EventArgs e)
        {

            roomba.DriveStop();

        }

        private void clean_Click(object sender, EventArgs e)
        {
            ///SPOT Mode (select models only) enables Roomba to perform a focused spot cleaning of an area up to 3 feet (about 1 meter) in diameter. Spot Mode is ideal for cleaning up dry spills and other messes, as well as for cleaning high-traffic areas. In Spot Mode, Roomba moves in a slow spiral pattern over the soiled area. If Roomba encounters a wall or other object while spot cleaning, it will intelligently keep cleaning in the focused area.
            roomba.SpotClean();
        }

        private void back_Click(object sender, EventArgs e)
        {

        }






    }
}
