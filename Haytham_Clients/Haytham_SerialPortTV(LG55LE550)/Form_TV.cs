using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;
using System.IO.Ports;

namespace Haytham_Client
{
    public partial class Form_TV : Form
    {
        //Client
        private Form1 form1;

        private int GazedZone;
        private int Volume;//the range of the TV volume is [0,64]
        //tv
        private string strBuffer = string.Empty;
        private bool Mute = false;


        public Form_TV(Form1 frm)
        {
            form1 = frm;
            InitializeComponent();


            Icon ico = new Icon(Properties.Resources.Untitled_2, 64, 64);
            this.Icon = ico;
            ClientStatus.Gaze = true;
            ClientStatus.Commands = true;
            ClientStatus.ScreenHeight = Screen.FromHandle(this.Handle).Bounds.Height;
            ClientStatus.ScreenWidth = Screen.FromHandle(this.Handle).Bounds.Width;
            ClientStatus.ScreenTopLeft.X = 0;
            ClientStatus.ScreenTopLeft.Y = 0;
            ClientStatus.UpdateServer();
            PortLG.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(PortLG_DataReceived);

        }


        void PortLG_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {

            SerialPort sp = sender as SerialPort;
            string data = sp.ReadExisting();
            DisplayMessage(data + "\r\n", txtDebug);

        }

        public void Form_TV_Load(object sender, EventArgs e)
        {

            // MessageBox.Show(clientName);
            this.Text += "_" + ClientStatus.clientName;
            DisplayMessage("Connection successful\r\n", textBox1);

            DisplayMessage("Your name is " + ClientStatus.clientName + "\r\n", textBox1);

            // start a new thread for sending and receiving messages
            ClientStatus.inputoutputThread = new Thread(new ThreadStart(Run));
            ClientStatus.inputoutputThread.Start();

            //serial port
            string[] theSerialPortNames = System.IO.Ports.SerialPort.GetPortNames();
            foreach (string port in theSerialPortNames)
            {
                cboPorts.Items.Add(port);
            }


        }

        private void Form_TV_FormClosing(object sender, FormClosingEventArgs e)
        {
            ClientStatus.clientName = "PauseReconnect";
            ClientStatus.inputoutputThread.Abort();
            ClientStatus.client.Close();

            form1.Show();

        }//end Form_monitor_FormClosing
        public void Run()
        {
            try
            {


                while (true)
                {
                    // receive messages that is sent to client
                    string msg = ClientStatus.reader.ReadString();
                    ProcessMessage(msg);

                }
            } // end try
            catch (IOException)
            {

                Reconnect();
            } // end catch


        }

        private void ProcessMessage(string msg)
        {
            string[] msgArray = ConvertMsgToArray(msg);

            if (msg.StartsWith("Gaze|"))
            {

                ClientStatus.gazePoint.X = int.Parse(msgArray[0]);
                ClientStatus.gazePoint.Y = int.Parse(msgArray[1]);

               GazedZone= DetermineGazedZone(ClientStatus.gazePoint);
            }
            else if (msg.StartsWith("Commands|"))
            {


                int X = int.Parse(msgArray[0]);
                int Y = int.Parse(msgArray[1]);
                PerformCommand(msgArray[3], new Point(X, Y));


            }

            else if (msg.StartsWith("Volume|"))
            {

               


                //disable volume when gaze is outside the volume zone(top right area of the screen)
                if (GazedZone != 4 && GazedZone != 5 && GazedZone != 9 && GazedZone != 10) ClientStatus.Volume = false;

                if (ClientStatus.Volume)
                {
 //DisplayMessage(msg + "\r\n", textBox1);
                    if (msgArray[1] == "Up") setVolume(msgArray[0]);
                    else if (msgArray[1] == "Down") setVolume("-" + msgArray[0]);
                }
            }

        }
        private void setVolume(string command)
        {
            Volume += 2 * Convert.ToInt32(command);



            if (Volume < 0)  Volume = 0; 
            else if (Volume > 64) Volume = 64;


            SendCommand("kf 00 " + Volume.ToString());
        
        
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

        /// <summary>
        /// The screen is devided into a grid of 4*5 areas, numbered from 1 to 20 from topleft to downright.
        /// </summary>
        /// <param name="pnt"></param>
        /// <returns></returns>
        private int DetermineGazedZone(Point pnt)
        {
            //normalizedPoint
            PointF np = new PointF((float)pnt.X / (float)ClientStatus.ScreenWidth, (float)pnt.Y / (float)ClientStatus.ScreenHeight);
            int zone = 0;

            if (np.X < (1.0 / 5.0) && np.Y < (1.0 / 4.0)) zone = 1;
            else if (np.X > (1.0 / 5.0) && np.X < (2.0 / 5.0) && np.Y < (1.0 / 4.0)) zone = 2;
            else if (np.X > (2.0 / 5.0) && np.X < (3.0 / 5.0) && np.Y < (1.0 / 4.0)) zone = 3;
            else if (np.X > (3.0 / 5.0) && np.X < (4.0 / 5.0) && np.Y < (1.0 / 4.0)) zone = 4;
            else if (np.X > (4.0 / 5.0) && np.X < (5.0 / 5.0) && np.Y < (1.0 / 4.0)) zone = 5;

            else if (np.X < (1.0 / 5.0) && np.Y > (1.0 / 4.0) && np.Y < (2.0 / 4.0)) zone = 6;
            else if (np.X > (1.0 / 5.0) && np.X < (2.0 / 5.0) && np.Y > (1.0 / 4.0) && np.Y < (2.0 / 4.0)) zone = 7;
            else if (np.X > (2.0 / 5.0) && np.X < (3.0 / 5.0) && np.Y > (1.0 / 4.0) && np.Y < (2.0 / 4.0)) zone = 8;
            else if (np.X > (3.0 / 5.0) && np.X < (4.0 / 5.0) && np.Y > (1.0 / 4.0) && np.Y < (2.0 / 4.0)) zone = 9;
            else if (np.X > (4.0 / 5.0) && np.X < (5.0 / 5.0) && np.Y > (1.0 / 4.0) && np.Y < (2.0 / 4.0)) zone = 10;

            else if (np.X < (1.0 / 5.0) && np.Y > (2.0 / 4.0) && np.Y < (3.0 / 4.0)) zone = 11;
            else if (np.X > (1.0 / 5.0) && np.X < (2.0 / 5.0) && np.Y > (2.0 / 4.0) && np.Y < (3.0 / 4.0)) zone = 12;
            else if (np.X > (2.0 / 5.0) && np.X < (3.0 / 5.0) && np.Y > (2.0 / 4.0) && np.Y < (3.0 / 4.0)) zone = 13;
            else if (np.X > (3.0 / 5.0) && np.X < (4.0 / 5.0) && np.Y > (2.0 / 4.0) && np.Y < (3.0 / 4.0)) zone = 14;
            else if (np.X > (4.0 / 5.0) && np.X < (5.0 / 5.0) && np.Y > (2.0 / 4.0) && np.Y < (3.0 / 4.0)) zone = 15;

            else if (np.X < (1.0 / 5.0) &&  np.Y > (3.0 / 4.0)) zone = 16;
            else if (np.X > (1.0 / 5.0) && np.X < (2.0 / 5.0) && np.Y > (3.0 / 4.0)) zone = 17;
            else if (np.X > (2.0 / 5.0) && np.X < (3.0 / 5.0) && np.Y > (3.0 / 4.0)) zone = 18;
            else if (np.X > (3.0 / 5.0) && np.X < (4.0 / 5.0) && np.Y > (3.0 / 4.0)) zone = 19;
            else if (np.X > (4.0 / 5.0) && np.X < (5.0 / 5.0) && np.Y > (3.0 / 4.0)) zone = 20;

          //  DisplayMessage(zone +"\r\n", textBox1);

            return zone;
        }

        private void PerformCommand(string command, Point p)
        {

            ///use this variable for the gestures that have gaze point in their command 
            ///for the other gestures like TR,Blink ... just use the global variable GazedZone
            int zoneBeforeGesture = DetermineGazedZone(p);


            switch (command)
            {
                case "TR":
                    if (GazedZone == 4 || GazedZone == 5 || GazedZone == 9 || GazedZone == 10)
                    {
                        ClientStatus.Volume = true;
                    }

                    break;
                case "R_L"://
                    SendCommand("mc 00 06");
                    break;
                case "L_R"://
                    SendCommand("mc 00 07");
                    break;
                case "U_D"://
                    SendCommand("mc 00 40");
                    break;
                case "D_U"://
                    SendCommand("mc 00 41");
                    break;

                case "R_R"://Change Channel
                    SendCommand("mc 00 00");
                    break;
                case "L_L"://Change Channel
                    SendCommand("mc 00 01");
                    break;

                case "TL":// menu
                    SendCommand("mc 00 43");
                    break;

                case "Custom1":// on
                    ClientStatus.Commands = true;
                    SendCommand("ka 00 01");
                    break;
                case "Custom2":// off
                              //  ClientStatus.Commands = false;
            SendCommand("ka 00 00");
                    break;


                case "Blink":
                    SendCommand("mc 00 44");

                    break;



            }
        }

        private void Reconnect()
        {

            DisplayMessage("Waiting for connection...\r\n", textBox1);

            ClientStatus.Reconnect();
            DisplayMessage("Connection successful\r\n", textBox1);
            Run();

        }


        // delegate that allows method DisplayMessage to be called
        // in the thread that creates and maintains the GUI
        private delegate void DisplayDelegate(string message, Control control);
        // method DisplayMessage sets displayTextBox's Text property
        // in a thread-safe manner
        private void DisplayMessage(string message, Control control)
        {
            // if modifying displayTextBox is not thread safe
            if (control.InvokeRequired)
            {
                // use inherited method Invoke to execute DisplayMessage
                // via a delegate
                Invoke(new DisplayDelegate(DisplayMessage),
                new object[] { message, control });
            } // end if
            else // OK to modify displayTextBox in current thread
            {
                control.Text += message;

                ((TextBox)control).SelectionStart = control.Text.Length;
                ((TextBox)control).ScrollToCaret();
                //textBox1.SelectionStart = textBox1.Text.Length;
                //textBox1.ScrollToCaret();

            }

        }// end method DisplayMessage

        public void SendCommand(string Command)
        {
            if(PortLG.IsOpen )
            PortLG.WriteLine(Command);
        }

        private void btnSendToServer_Click(object sender, EventArgs e)
        {
            ClientStatus.writer.Write(txtMsgToSend.Text);
            txtMsgToSend.Text = "";

        }

        private void txtMsgToSend_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ClientStatus.writer.Write(txtMsgToSend.Text);
                txtMsgToSend.Text = "";
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                //ClientStatus.Commands = true;
                //ClientStatus.Blink = true;


                PortLG.PortName = cboPorts.Text;
                PortLG.Open();
                btnStart.Enabled = false;
                btnStop.Enabled = true;
                Panel2.Enabled = true;
                fraLGControl.Enabled = true;
                SendCommand("ka 00 01");

            }
            catch (Exception)
            { }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            ClientStatus.Commands = false;
            SendCommand("ka 00 00");

            PortLG.Close();
            btnStart.Enabled = true;
            btnStop.Enabled = false;
            Panel2.Enabled = false;

            fraLGControl.Enabled = false;

        }

        private void btn_09_Click(object sender, EventArgs e)
        {
            if (Mute)
            {
                Mute = false;
                SendCommand("ke 00 01");
            }
            else
            {
                Mute = true;
                SendCommand("ke 00 00");

            }
        }

        private void btn_53_Click(object sender, EventArgs e)
        {
            SendCommand("mc 00 53");

        }

        private void btn_1A_Click(object sender, EventArgs e)
        {
            SendCommand("mc 00 1A");

        }

        private void btn_02_Click(object sender, EventArgs e)
        {
            SendCommand("mc 00 02");

        }

        private void btn_00_Click(object sender, EventArgs e)
        {
            SendCommand("mc 00 00");

        }

        private void btn_03_Click(object sender, EventArgs e)
        {
            SendCommand("mc 00 03");

        }

        private void btn_01_Click(object sender, EventArgs e)
        {
            SendCommand("mc 00 01");

        }

        private void btn_43_Click(object sender, EventArgs e)
        {
            SendCommand("mc 00 43");

        }

        private void btn_45_Click(object sender, EventArgs e)
        {
            SendCommand("mc 00 45");

        }

        private void btn_40_Click(object sender, EventArgs e)
        {

            SendCommand("mc 00 40");

        }

        private void btn_07_Click(object sender, EventArgs e)
        {
            SendCommand("mc 00 07");

        }

        private void btn_44_Click(object sender, EventArgs e)
        {
            SendCommand("mc 00 44");

        }

        private void btn_06_Click(object sender, EventArgs e)
        {
            SendCommand("mc 00 06");

        }

        private void btn_41_Click(object sender, EventArgs e)
        {
            SendCommand("mc 00 41");

        }

        private void btn_28_Click(object sender, EventArgs e)
        {
            SendCommand("mc 00 28");

        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            
            helpForm frm = new helpForm();
             frm.ShowDialog();
        }


    }
}
