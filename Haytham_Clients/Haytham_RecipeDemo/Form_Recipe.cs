using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Runtime.InteropServices;//for Dllimport
using System.IO;
namespace Haytham_Client
{
    public partial class Form_Recipe : Form
    {
        //**********Using event in user32 for sending button value****************//

        [DllImport("user32")]
        public static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);
        private const byte VK_MENU = 0x12;
        private const byte VK_TAB = 0x09;
        private const int KEYEVENTF_EXTENDEDKEY = 0x01;
        private const int KEYEVENTF_KEYUP = 0x02;

        //************************************************************************//
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);

        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
        private const int MOUSEEVENTF_RIGHTUP = 0x10;
        //************************************************************************//
        [DllImport("winmm.dll")]
        public static extern int waveOutGetVolume(IntPtr hwo, out uint dwVolume);

        [DllImport("winmm.dll")]
        public static extern int waveOutSetVolume(IntPtr hwo, uint dwVolume);
        //******************************************************

        public WMPLib.WindowsMediaPlayer wplayer = new WMPLib.WindowsMediaPlayer();
        Form1 form1;

        Form_Recognition frm_glyph;


        private int volume = 0;
        private int musicFile = 1;
        private int volume_dwelltime = 15;
        private int volume_dwelltime_Counter = 0;


        public Form_Recipe(Form1 frm)
        {






            form1 = frm;
            InitializeComponent();

            Icon ico = new Icon(Properties.Resources.Untitled_2, 64, 64);
            this.Icon = ico;


            ClientStatus.Gaze = true;
            ClientStatus.Commands = true;

            ClientStatus.ScreenHeight = Screen.FromHandle(this.Handle).Bounds.Height;
            ClientStatus.ScreenWidth = Screen.FromHandle(this.Handle).Bounds.Width;
            ClientStatus.ScreenTopLeft.X = Screen.FromHandle(this.Handle).Bounds.Left;
            ClientStatus.ScreenTopLeft.Y = Screen.FromHandle(this.Handle).Bounds.Top;
            ClientStatus.UpdateServer();



            this.WindowState = FormWindowState.Maximized;
            int W = ClientStatus.ScreenWidth;
            int H = ClientStatus.ScreenHeight;

            panel_Image.Location = new Point(35, 35);
            panel_Image.Width = 2 * W / 3;
            panel_Image.Height = H - 60;

            label3.Location = new Point(panel_Image.Width / 2 - label3.Width / 2, panel_Image.Height / 2 + 300);
            webBrowser1.Location = new Point(25, 25);
            webBrowser1.Width = panel_Image.Width - 50;
            webBrowser1.Height = panel_Image.Height - 50;

 
            Uri myUri = new Uri(Application.StartupPath + "/Resources/Recipe.swf");
            webBrowser1.Navigate(myUri);

            panel_Volume.Width = W / 3 - 100;
            panel_Volume.Height = H / 2 - 100;
            panel_Volume.Left = (panel_Image.Left + panel_Image.Width) + 25;
            panel_Volume.Top = H / 2 + 50;
            pictureBox1.Location = new Point(panel_Volume.Width / 2 - pictureBox1.Width / 2, panel_Volume.Height / 2 - pictureBox1.Height / 2);
            label1.Location = new Point(panel_Volume.Width / 2 - label1.Width / 2, panel_Volume.Height / 2 - label1.Height / 2 + 50);
            progressBar1.Height = panel_Volume.Height;
            progressBar1.Top = 0;

            panel_Music.Width = W / 3 - 100;
            panel_Music.Height = H / 2 - 100;
            panel_Music.Left = (panel_Image.Left + panel_Image.Width) + 25;
            panel_Music.Top = 50;


            wplayer = new WMPLib.WindowsMediaPlayer();

            wplayer.URL = string.Format("Resources\\Music ({0}).mp3", musicFile);
            wplayer.controls.play();


            btn_Next.BackColor = radioButton_Play.BackColor;// System.Drawing.Color.Aqua;
            btn_Previous.BackColor = radioButton_Play.BackColor;// System.Drawing.Color.Aqua;


            //volume
            progressBar1.Value = wplayer.settings.volume;



            System.Reflection.Assembly assembly = this.GetType().Assembly;


            Bitmap bmp = new Bitmap(assembly.GetManifestResourceStream("Haytham_Client.Resources.VolumeOff.png"));
            pictureBox1.Image = bmp;

           // Cursor.Hide();


        }

        private void Form_Recipe_Load(object sender, EventArgs e)
        {
            timerMakeFlashReady.Enabled = true;
            // start a new thread for sending and receiving messages
            ClientStatus.inputoutputThread = new Thread(new ThreadStart(Run));
            ClientStatus.inputoutputThread.Start();
            volume = progressBar1.Value;
            #region set frm_glyph
            Rectangle rect = new Rectangle(Screen.FromHandle(this.Handle).Bounds.Left, Screen.FromHandle(this.Handle).Bounds.Top, Screen.FromHandle(this.Handle).Bounds.Width, Screen.FromHandle(this.Handle).Bounds.Height);
            frm_glyph = new Form_Recognition(this, rect);
            frm_glyph.Show();
            frm_glyph.Hide();
            #endregion set frm_glyph

        }
        private void Form_Recipe_FormClosing(object sender, FormClosingEventArgs e)
        {
            EndTask();

        }
        private void EndTask()
        {

       


            wplayer.controls.stop();

            Cursor.Show();

            ClientStatus.clientName = "PauseReconnect";
            ClientStatus.inputoutputThread.Abort();
            ClientStatus.client.Close();

            form1.Show();

        }
        private void Reconnect()
        {

            ClientStatus.Reconnect();
            Run();

        }
        private string DetermineGazedZone(Point pnt)
        {

           // Point point = new Point(Cursor.Position.X, Cursor.Position.Y);
            pnt = Point.Subtract(pnt, new Size(ClientStatus.ScreenTopLeft));

            string zone = "";
            if (pnt.X < (2 * (this.Width / 3))) zone = "ImageZone";
            else if (pnt.X < this.Width & pnt.Y < (this.Height / 2)) zone = "MusicZone";
            else if (pnt.X < this.Width & pnt.Y > (this.Height / 2)) zone = "VolumeZone";
            enableZone(zone);

            return zone;
        }

     
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
                string zone = DetermineGazedZone(ClientStatus.gazePoint);

                ClientStatus.gazePoint.X = int.Parse(msgArray[0]);
                ClientStatus.gazePoint.Y = int.Parse(msgArray[1]);
                ClientStatus.gazePoint = Point.Add(ClientStatus.gazePoint, new Size(ClientStatus.ScreenTopLeft));

            }
            else if (msg.StartsWith("Commands|"))
            {


                    int X = int.Parse(msgArray[0]);
                    int Y = int.Parse(msgArray[1]);
                    PerformCommand(msgArray[3], new Point(X, Y));

              
            }
            else if (msg.StartsWith("Glyph|"))
            {




                if (msgArray[0] == "S")
                {

                    //frm_glyph.Show();
                    frm_glyph.DisplayImage(true);
                    // DisplayMessage("Show Glyph\r\n", textBox1);



                }
                else if (msgArray[0] == "H")
                {
                    try
                    {
                        frm_glyph.DisplayImage(false);
                        //  DisplayMessage("Hide Glyph\r\n", textBox1);
                    }
                    catch (Exception) { }

                }
            }
            else if (msg.StartsWith("Volume|"))
            {
                if (msgArray[1] == "Up" ) setVolume(msgArray[0]);
                else if ( msgArray[1] == "Down") setVolume("-"+ msgArray[0]);

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
        private void PerformCommand( string command, Point p)
        {
            string zone = DetermineGazedZone(ClientStatus.gazePoint);

            switch (zone)
            {
                case "ImageZone":


                    // Activate the image zone

                    switch (command)
                    {
                        // list of the key values http://msdn.microsoft.com/en-us/library/dd375731%28v=vs.85%29.aspx
                        case "R_L"://Right
                            keybd_event(0x27, 0, 0, 0);// key press event 
                            keybd_event(0x27, 0, KEYEVENTF_KEYUP, 0);// key release event 
                            break;



                        case "L_R"://Left
                            keybd_event(0x25, 0, 0, 0);// key press event 
                            keybd_event(0x25, 0, KEYEVENTF_KEYUP, 0);// key release event 
                            break;

                        //case "D_U"://Down
                        //    keybd_event(0x28, 0, 0, 0);// key press event 
                        //    keybd_event(0x28, 0, KEYEVENTF_KEYUP, 0);// key release event 
                        //    break;
                        //case "U_D"://Up
                        //    keybd_event(0x26, 0, 0, 0);// key press event 
                        //    keybd_event(0x26, 0, KEYEVENTF_KEYUP, 0);// key release event 
                        //    break;
                    }
                    break;
                case "VolumeZone":
                    #region volume



                    if (command.StartsWith("Blink") )
                    {
                        volume_dwelltime_Counter = 0;
                        volume_dwelltime = 0;
                        timer2.Enabled = false;
                        ClientStatus.Volume = false;
                        ControlForm("Disable", "pictureBox1");
                        ControlForm("x", "label1");

                    }



                   
                    #endregion volume
                    break;

                case "MusicZone":
                    // Activate the image zone

                    switch (command)
                    {
                        case "R_L"://Right
                            ControlForm("On", "btn_Next");
                            //Change music
                            wplayer.controls.stop();
                            musicFile = (musicFile + 1) < 5 ? musicFile + 1 : 1;


                            wplayer = new WMPLib.WindowsMediaPlayer();

                            wplayer.URL = string.Format("Resources\\Music ({0}).mp3", musicFile);
                            wplayer.controls.play();

                            Thread.Sleep(500);
                            ControlForm("Off", "btn_Next");

                            break;

                        case "L_R"://Left
                            ControlForm("On", "btn_Previous");
                            //Change music
                            wplayer.controls.stop();
                            musicFile = (musicFile - 1) > 0 ? musicFile - 1 : 4;

                            wplayer = new WMPLib.WindowsMediaPlayer();

                            wplayer.URL = string.Format("Resources\\Music ({0}).mp3", "Music (1)");

                            wplayer.controls.play();

                            Thread.Sleep(500);
                            ControlForm("Off", "btn_Previous");

                            break;

                        case "D_U"://Down
                            ControlForm("Checked", "radioButton_Play");

                            //Play music
                            wplayer.controls.play();



                            break;
                        case "U_D"://Up
                            ControlForm("Checked", "radioButton_Stop");
                            //Stop music
                            wplayer.controls.stop();
                            break;
                    }
                    break;
            }
        }


        private delegate void ControlFormDelegate(string message, string control);
        // method DisplayMessage sets displayTextBox's Text property
        // in a thread-safe manner
        private void ControlForm(string message, string control)
        {
            switch (control)
            {
                case "progressBar1":
                    // if modifying displayTextBox is not thread safe
                    if (progressBar1.InvokeRequired)
                    {
                        // use inherited method Invoke to execute DisplayMessage
                        // via a delegate
                        Invoke(new ControlFormDelegate(ControlForm), new object[] { message, control });
                    } // end if
                    else // OK to modify displayTextBox in current thread
                    {



                        progressBar1.Value = int.Parse(message);

                    }
                    break;
                case "label1":
                    // if modifying displayTextBox is not thread safe
                    if (label1.InvokeRequired)
                    {
                        // use inherited method Invoke to execute DisplayMessage
                        // via a delegate
                        Invoke(new ControlFormDelegate(ControlForm), new object[] { message, control });
                    } // end if
                    else // OK to modify displayTextBox in current thread
                    {



                        label1.Text = message;

                    }
                    break;
                case "pictureBox1":
                    // if modifying displayTextBox is not thread safe
                    if (pictureBox1.InvokeRequired)
                    {
                        // use inherited method Invoke to execute DisplayMessage
                        // via a delegate
                        Invoke(new ControlFormDelegate(ControlForm), new object[] { message, control });
                    } // end if
                    else // OK to modify displayTextBox in current thread
                    {
                        if (message.StartsWith("Enable"))
                        {
                            System.Reflection.Assembly assembly = this.GetType().Assembly;

                            assembly = this.GetType().Assembly;

                            Bitmap bmp = new Bitmap(assembly.GetManifestResourceStream("Haytham_Client.Resources.VolumeOn.png"));
                            pictureBox1.Image = bmp;

                        }
                        else if (message.StartsWith("Disable"))
                        {
                            System.Reflection.Assembly assembly = this.GetType().Assembly;

                            assembly = this.GetType().Assembly;

                            Bitmap bmp = new Bitmap(assembly.GetManifestResourceStream("Haytham_Client.Resources.VolumeOff.png"));
                            pictureBox1.Image = bmp;
                        }


                    }
                    break;
                case "btn_Next":
                    // if modifying displayTextBox is not thread safe
                    if (btn_Next.InvokeRequired)
                    {
                        // use inherited method Invoke to execute DisplayMessage
                        // via a delegate
                        Invoke(new ControlFormDelegate(ControlForm), new object[] { message, control });
                    } // end if
                    else // OK to modify displayTextBox in current thread
                    {


                        if (message.StartsWith("On") == true)
                        {
                            btn_Next.BackColor = System.Drawing.Color.Maroon;

                        }


                        if (message.StartsWith("Off") == true)
                        {
                            btn_Next.BackColor = radioButton_Play.BackColor;////SystemColors.Control;

                        }




                    }
                    break;
                case "btn_Previous":
                    // if modifying displayTextBox is not thread safe
                    if (btn_Previous.InvokeRequired)
                    {
                        // use inherited method Invoke to execute DisplayMessage
                        // via a delegate
                        Invoke(new ControlFormDelegate(ControlForm), new object[] { message, control });
                    } // end if
                    else // OK to modify displayTextBox in current thread
                    {


                        if (message.StartsWith("On") == true)
                        {
                            btn_Previous.BackColor = System.Drawing.Color.Maroon;

                        }


                        if (message.StartsWith("Off") == true)
                        {
                            btn_Previous.BackColor = radioButton_Play.BackColor;//;

                        }




                    }
                    break;
                case "radioButton_Play":
                    // if modifying displayTextBox is not thread safe
                    if (radioButton_Play.InvokeRequired)
                    {
                        // use inherited method Invoke to execute DisplayMessage
                        // via a delegate
                        Invoke(new ControlFormDelegate(ControlForm), new object[] { message, control });
                    } // end if
                    else // OK to modify displayTextBox in current thread
                    {


                        if (message.StartsWith("Checked") == true)
                        {
                            radioButton_Play.Checked = true;

                        }







                    }
                    break;
                case "radioButton_Stop":
                    // if modifying displayTextBox is not thread safe
                    if (radioButton_Stop.InvokeRequired)
                    {
                        // use inherited method Invoke to execute DisplayMessage
                        // via a delegate
                        Invoke(new ControlFormDelegate(ControlForm), new object[] { message, control });
                    } // end if
                    else // OK to modify displayTextBox in current thread
                    {


                        if (message.StartsWith("Checked") == true)
                        {
                            radioButton_Stop.Checked = true;

                        }
                    }
                    break;

                case "ImageZone":
                    // if modifying displayTextBox is not thread safe
                    if (panel_Image.InvokeRequired) Invoke(new ControlFormDelegate(ControlForm), new object[] { message, control });
                    else // OK to modify displayTextBox in current thread
                    {
                        if (panel_Image.BackColor != Color.SkyBlue)
                        {
                            volume_dwelltime_Counter = 0;
                            timer2.Enabled = false;
                             ClientStatus.Volume = false;  
                            ControlForm("Disable", "pictureBox1");
                            ControlForm("x", "label1");

                            panel_Music.Enabled = false;
                            panel_Volume.Enabled = false;
                            panel_Image.BackColor = Color.SkyBlue;
                            label3.Enabled = true;
                        }
                    }
                    break;
                case "MusicZone":
                    // if modifying displayTextBox is not thread safe
                    if (panel_Music.InvokeRequired) Invoke(new ControlFormDelegate(ControlForm), new object[] { message, control });
                    else // OK to modify displayTextBox in current thread
                    {
                        if (!panel_Music.Enabled)
                        {
                            volume_dwelltime_Counter = 0;
                            timer2.Enabled = false;

                            ClientStatus.Volume = false;   
                            ControlForm("Disable", "pictureBox1");
                            ControlForm("x", "label1");

                            panel_Music.Enabled = true;
                            panel_Volume.Enabled = false;
                            panel_Image.BackColor = radioButton_Play.BackColor;
                            label3.Enabled = false;

                        }
                    }
                    break;
                case "VolumeZone":
                    // if modifying displayTextBox is not thread safe
                    if (panel_Volume.InvokeRequired) Invoke(new ControlFormDelegate(ControlForm), new object[] { message, control });
                    else // OK to modify displayTextBox in current thread
                    {
                        if (timer2.Enabled != true)
                        {
                            timer2.Enabled = true;
                            volume_dwelltime_Counter = 0;
                        }
                        if (!panel_Volume.Enabled)
                        {


                            panel_Music.Enabled = false;
                            panel_Volume.Enabled = true;
                            panel_Image.BackColor = radioButton_Play.BackColor;
                            label3.Enabled = false;

                        }
                    }
                    break;
            }
        }// end method DrawaGauge



        private void setVolume(string command)
        {
            volume +=2* Convert.ToInt32 (command);



            if (volume < 0) { ControlForm("0", "progressBar1"); volume = 0; }
            else if (volume > 100) { ControlForm("100", "progressBar1"); volume = 100; }
            else ControlForm(volume.ToString(), "progressBar1");

            ControlForm(volume.ToString(), "label1");
            wplayer.settings.volume = volume;

        }



        

        private void webBrowser1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                EndTask();
                this.Dispose();
                this.Close();

                Cursor.Show();


            }
        }

        private void btn_Next_Click(object sender, EventArgs e)
        {

            wplayer.controls.stop();
            musicFile = (musicFile + 1) < 5 ? musicFile + 1 : 1;

            wplayer = new WMPLib.WindowsMediaPlayer();

            wplayer.URL = string.Format("Resources\\Music ({0}).mp3", musicFile);

            wplayer.controls.play();

        }

        private void btn_Previous_Click(object sender, EventArgs e)
        {
  

            wplayer.controls.stop();
            musicFile = (musicFile - 1) < 5 ? musicFile - 1 : 4;

            wplayer = new WMPLib.WindowsMediaPlayer();

            wplayer.URL = string.Format("Resources\\Music ({0}).mp3", musicFile);
            wplayer.controls.play();

        }

        private void radioButton_Stop_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_Stop.Checked) wplayer.controls.stop();

        }

        private void radioButton_Play_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_Play.Checked) wplayer.controls.play();

        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            // Cursor.Hide();
        }


        private void enableZone(string zone)
        {
            switch (zone)
            {
                case "ImageZone":
                    ControlForm("", "ImageZone");

                    break;
                case "MusicZone":
                    ControlForm("", "MusicZone");
                    break;
                case "VolumeZone":
                    ControlForm("", "VolumeZone");
                    break;
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (volume_dwelltime_Counter < volume_dwelltime) volume_dwelltime_Counter++;
            if (volume_dwelltime_Counter >= volume_dwelltime )
            {

               ClientStatus.Volume = true;
               ControlForm("Enable", "pictureBox1");
            }
        }

        private void Form_Recipe_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void timerMakeFlashReady_Tick(object sender, EventArgs e)
        {
            //click on the center of the image slides frame to make the flash ready
            Cursor.Position = Point.Add(new Point(webBrowser1.Left + webBrowser1.Width / 2, webBrowser1.Top + webBrowser1.Height / 2), new Size(ClientStatus.ScreenTopLeft));


            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, Cursor.Position.X, Cursor.Position.Y, 0, 0);

            timerMakeFlashReady.Enabled = false;
        }






    }
}

