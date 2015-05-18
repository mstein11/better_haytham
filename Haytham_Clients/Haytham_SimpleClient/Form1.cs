

//<copyright file="Server.cs" company="ITU">
//This file is part of Haytham 
//Copyright (C) 2012 Diako Mardanbegi
//------------------------------------------------------------------------
//For a simple TCP/IP connection with Haytham server and getting the gaze data:
// 1- Use the port 50000
// 2- Define a thread for Reading/Writing to make the connection seperate from the rest of your program
// 3- After the first connection send some information (2 strings and 2 integers) to the server as below:
//writer.Write("Monitor");//type
//writer.Write("?");//name

// 4- Then read a string which is the name of your client defined by the server that you can use it later for reconnection:
//clientName = reader.ReadString();//get approved name
// 5- After that send two strings to the server as below:     
//writer.Write("Status_Gaze");
//writer.Write("True");
// 6- Now you should be able to get the gaze data from the server continuously in three different steps, one string and two integers
//  "cursor" 
//  xCoordinate
//  yCoordinate

// The gaze data only be sent to the clinet when the eye tracker is calibrated and the screen detection is enabled in the server.


// ------------------------------------------------------------------------
//This program is free software: you can redistribute it and/or modify
//it under the terms of the GNU General Public License as published by
//the Free Software Foundation, either version 3 of the License, or
//(at your option) any later version.

//This program is distributed in the hope that it will be useful,
//but WITHOUT ANY WARRANTY; without even the implied warranty of
//MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//GNU General Public License for more details.

//You should have received a copy of the GNU General Public License
//along with this program.  If not, see <http://www.gnu.org/licenses/>.

// @PJ: changes made bz Peter Jurnecka, ijurnecka@fit.vutbr.cz
// ------------------------------------------------------------------------
// </copyright>
// <author>Diako Mardanbegi</author>
// <email>dima@itu.dk</email>


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
using System.IO;

using System.Threading;
using Haytham.ExtData;	//change @PJ



namespace Haytham_SimpleClient
{
    public partial class Form1 : Form
    {
        private Point gazePoint;

        private Point ScreenTopLeft;
        private Size Screensize;

        private int ScreenWidth;
        private int ScreenHeight;

        private Thread inputoutputThread; // Thread for receiving data from server
        private IPAddress serverip;

        private TcpClient client = new TcpClient();  // client to establish connection
        private BinaryWriter writer; // facilitates writing to the stream
        private BinaryReader reader; // facilitates reading from the strea  
        private NetworkStream stream; // network data stream

        private string clientName;



        public Form1()
        {
            InitializeComponent();

            ScreenTopLeft.X = Screen.FromHandle(this.Handle).Bounds.Left;
            ScreenTopLeft.Y = Screen.FromHandle(this.Handle).Bounds.Top;
            Screensize.Width = Screen.FromHandle(this.Handle).Bounds.Width;
            Screensize.Height = Screen.FromHandle(this.Handle).Bounds.Height;

            //@PJ
            //start server search task using haytham extData client		
            System.Threading.Tasks.Task.Factory.StartNew(() =>
            {
                //find haytham hosts on network					
                Uri hostUri = Client.getActiveHosts().FirstOrDefault();
                while (hostUri == null)
                {
                    System.Threading.Thread.Sleep(5000);	//wait 5 seconds before next try
                    hostUri = Client.getActiveHosts().FirstOrDefault(); // it has 2seconds timeout
                }

                //show IPv4 address if exists
                var server = Dns.GetHostAddresses(hostUri.DnsSafeHost).Where(adr => adr.AddressFamily == AddressFamily.InterNetwork).FirstOrDefault();
                if (server != null)
                {
                    this.serverip = server;
                    showIp();
                }
            });

        }

        private void showIp()
        {
            if (this.textBox1.InvokeRequired)
                Invoke((Action)this.showIp);
            else
                this.textBox1.Text = this.serverip.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Visible = false;

            client = new TcpClient();
            serverip = IPAddress.Parse(textBox1.Text); ;
            ScreenHeight = Screen.FromHandle(this.Handle).Bounds.Height;
            ScreenWidth = Screen.FromHandle(this.Handle).Bounds.Width;


            // Connect to the server

            try
            {
                client.Connect(serverip, 50000);
            }
            catch (Exception ee)
            {
                MessageBox.Show("Server not found\r\n" + "Check the server IP again!");
                return;
            }


            stream = client.GetStream();
            writer = new BinaryWriter(stream);
            reader = new BinaryReader(stream);


            //send name and type
            writer.Write("Monitor");//type
            writer.Write("?");//name

            clientName = reader.ReadString();//get approved name

            if (client.Connected)
            {

                writer.Write("Status_Gaze");
                writer.Write("True");
                writer.Write("Status_Commands");
                writer.Write("True");

                writer.Write("Size"); writer.Write(ScreenWidth); writer.Write(ScreenHeight);
            }

            DisplayMessage("Connection successful\r\n", textBox2);

            DisplayMessage("Your name is " + clientName + "\r\n", textBox2);


            // start a new thread for sending and receiving messages
            inputoutputThread = new Thread(new ThreadStart(Run));
            inputoutputThread.Start();


        }
        public void Run()
        {

            try
            {
                // receive messages that is sent to client
                while (true)
                {
                    string msg = reader.ReadString();
                    ProcessMessage(msg);

                }
            } // end try
            catch (IOException)
            {
                DisplayMessage("Connection failed\r\n", textBox2);

                DisplayMessage("Waiting for connection...\r\n", textBox2);

                Reconnect("Monitor");

                DisplayMessage("Connection successful\r\n", textBox2);
                Run();
            } // end catch


        }
        private void ProcessMessage(string msg)
        {
            string[] msgArray = ConvertMsgToArray(msg);

            if (msg.StartsWith("Gaze"))
            {


                gazePoint.X = int.Parse(msgArray[0]);


                gazePoint.Y = int.Parse(msgArray[1]);

                gazePoint = Point.Add(gazePoint, new Size(ScreenTopLeft));

                DisplayMessage("(" + gazePoint.X + "," + gazePoint.Y + ")", gXY);

            }
            else if (msg.StartsWith("Commands"))
            {
                DisplayMessage("gesture: " + msgArray[3].ToString(), textBox3);
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



        public void Reconnect(string type)
        {
            bool connected = false;

            do
            {
                try
                {
                    client = new TcpClient();

                    client.Connect(serverip, 50000);
                    stream = client.GetStream();
                    writer = new BinaryWriter(stream);
                    reader = new BinaryReader(stream);

                    //send name and type
                    writer.Write(type);//type
                    writer.Write(clientName);//name

                    clientName = reader.ReadString();//get approved name

                    connected = true;
                    if (client.Connected)
                    {

                        writer.Write("Status_Gaze");
                        writer.Write("True");
                        writer.Write("Size"); writer.Write(ScreenWidth); writer.Write(ScreenHeight);
                    }
                } // end try
                catch (Exception)
                {

                }
            }
            while ((!connected & clientName != "PauseReconnect"));
            if (clientName == "PauseReconnect")
            {
                client.Close();
                inputoutputThread.Abort();
            }

        }


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            clientName = "PauseReconnect";
            client.Close();

            System.Environment.Exit(System.Environment.ExitCode);
        }

        // delegate that allows method DisplayMessage to be called
        // in the thread that creates and maintains the GUI
        private delegate void DisplayDelegate(string message, Control control);
        // method DisplayMessage sets displayTextBox's Text property
        // in a thread-safe manner
        public void DisplayMessage(string message, Control control)
        {
            try
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
                    control.Text = message;

                    ((TextBox)control).SelectionStart = control.Text.Length;
                    ((TextBox)control).ScrollToCaret();
                    //textBox1.SelectionStart = textBox1.Text.Length;
                    //textBox1.ScrollToCaret();


                }
            }
            catch (Exception e) { }

        }

        private void gXY_TextChanged(object sender, EventArgs e)
        {

        }// end method DisplayMessage

    }
}
