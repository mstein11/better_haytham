using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;//for Dllimport
using System.Threading;


namespace Haytham_Client
{
    public partial class Form_monitor : Form
    {
        private ComboBox[] comboBoxes;

        public bool moveCursor = false;
        //**********Using event in user32 for sending button value****************//

        [DllImport("user32")]
        public static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);
        private const byte VK_MENU = 0x12;
        private const byte VK_TAB = 0x09;
        private const int KEYEVENTF_EXTENDEDKEY = 0x01;
        private const int KEYEVENTF_KEYUP = 0x02;

        #region keys
        //Symbolic
        //constant name 	Value
        //(hexadecimal) 	Keyboard (or mouse) equivalent
        //VK_LBUTTON 	01 	Left mouse button
        //VK_RBUTTON 	02 	Right mouse button
        //VK_CANCEL 	03 	Control-break processing
        //VK_MBUTTON 	04 	Middle mouse button (three-button mouse)
        //VK_BACK 	08 	BACKSPACE key
        //VK_TAB 	09 	TAB key
        //VK_CLEAR 	0C 	CLEAR key
        //VK_RETURN 	0D 	ENTER key
        //VK_SHIFT 	10 	SHIFT key
        //VK_CONTROL 	11 	CTRL key
        //VK_MENU 	12 	ALT key
        //VK_PAUSE 	13 	PAUSE key
        //VK_CAPITAL 	14 	CAPS LOCK key
        //VK_ESCAPE 	1B 	ESC key
        //VK_SPACE 	20 	SPACEBAR
        //VK_PRIOR 	21 	PAGE UP key
        //VK_NEXT 	22 	PAGE DOWN key
        //VK_END 	23 	END key
        //VK_HOME 	24 	HOME key
        //VK_LEFT 	25 	LEFT ARROW key
        //VK_UP 	26 	UP ARROW key
        //VK_RIGHT 	27 	RIGHT ARROW key
        //VK_DOWN 	28 	DOWN ARROW key
        //VK_SELECT 	29 	SELECT key
        //VK_PRINT 	2A 	PRINT key
        //VK_EXECUTE 	2B 	EXECUTE key
        //VK_SNAPSHOT 	2C 	PRINT SCREEN key
        //VK_INSERT 	2D 	INS key
        //VK_DELETE 	2E 	DEL key
        //VK_HELP 	2F 	HELP key
        //    30 	0 key
        //    31 	1 key
        //    32 	2 key
        //    33 	3 key
        //    34 	4 key
        //    35 	5 key
        //    36 	6 key
        //    37 	7 key
        //    38 	8 key
        //    39 	9 key
        //    41 	A key
        //    42 	B key
        //    43 	C key
        //    44 	D key
        //    45 	E key
        //    46 	F key
        //    47 	G key
        //    48 	H key
        //    49 	I key
        //    4A 	J key
        //    4B 	K key
        //    4C 	L key
        //    4D 	M key
        //    4E 	N key
        //    4F 	O key
        //    50 	P key
        //    51 	Q key
        //    52 	R key
        //    53 	S key
        //    54 	T key
        //    55 	U key
        //    56 	V key
        //    57 	W key
        //    58 	X key
        //    59 	Y key
        //    5A 	Z key
        //VK_NUMPAD0 	60 	Numeric keypad 0 key
        //VK_NUMPAD1 	61 	Numeric keypad 1 key
        //VK_NUMPAD2 	62 	Numeric keypad 2 key
        //VK_NUMPAD3 	63 	Numeric keypad 3 key
        //VK_NUMPAD4 	64 	Numeric keypad 4 key
        //VK_NUMPAD5 	65 	Numeric keypad 5 key
        //VK_NUMPAD6 	66 	Numeric keypad 6 key
        //VK_NUMPAD7 	67 	Numeric keypad 7 key
        //VK_NUMPAD8 	68 	Numeric keypad 8 key
        //VK_NUMPAD9 	69 	Numeric keypad 9 key
        //VK_SEPARATOR 	6C 	Separator key
        //VK_SUBTRACT 	6D 	Subtract key
        //VK_DECIMAL 	6E 	Decimal key
        //VK_DIVIDE 	6F 	Divide key
        //VK_F1 	70 	F1 key
        //VK_F2 	71 	F2 key
        //VK_F3 	72 	F3 key
        //VK_F4 	73 	F4 key
        //VK_F5 	74 	F5 key
        //VK_F6 	75 	F6 key
        //VK_F7 	76 	F7 key
        //VK_F8 	77 	F8 key
        //VK_F9 	78 	F9 key
        //VK_F10 	79 	F10 key
        //VK_F11 	7A 	F11 key
        //VK_F12 	7B 	F12 key
        //VK_F13 	7C 	F13 key
        //VK_F14 	7D 	F14 key
        //VK_F15 	7E 	F15 key
        //VK_F16 	7F 	F16 key
        //VK_F17 	80H 	F17 key
        //VK_F18 	81H 	F18 key
        //VK_F19 	82H 	F19 key
        //VK_F20 	83H 	F20 key
        //VK_F21 	84H 	F21 key
        //VK_F22 	85H 	F22 key
        //VK_F23 	86H 	F23 key
        //VK_F24 	87H 	F24 key
        //VK_NUMLOCK 	90 	NUM LOCK key
        //VK_SCROLL 	91 	SCROLL LOCK key
        //VK_LSHIFT 	A0 	Left SHIFT key
        //VK_RSHIFT 	A1 	Right SHIFT key
        //VK_LCONTROL 	A2 	Left CONTROL key
        //VK_RCONTROL 	A3 	Right CONTROL key
        //VK_LMENU 	A4 	Left MENU key
        //VK_RMENU 	A5 	Right MENU key
        //VK_PLAY 	FA 	Play key
        //VK_ZOOM 	FB 	Zoom key
        #endregion keys

        //************************************************************************//
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);

        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
        private const int MOUSEEVENTF_RIGHTUP = 0x10;
        //************************************************************************//

        Form1 frm1;
        public NumDemo frm_numDemo;
        Form_Recognition frm_glyph;
        AnimatedCursor mycursor;
        TextFile exportDataFile;


        public System.Windows.Forms.Timer timerExportData = new System.Windows.Forms.Timer();

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
                    control.Text += message;

                    ((TextBox)control).SelectionStart = control.Text.Length;
                    ((TextBox)control).ScrollToCaret();


                }
            }
            catch (Exception e) { }

        }// end method DisplayMessage


        public class myEventArg : EventArgs
        {

            private string command;
            private Point position;
            public myEventArg(string str, Point p)
            {
                command = str;
                position = p;
            }


            public string Command
            {
                get { return command; }
                // set { gesture = value; }
            }
            public Point Position
            {
                get { return position; }
                // set { gesture = value; }
            }
        }

        public delegate void CommandHandler(object sender, myEventArg e);

        public event CommandHandler commandHandler;


        public Form_monitor(Form1 frm)
        {

            frm1 = frm;
            InitializeComponent();

            Icon ico = new Icon(Properties.Resources.Untitled_2, 64, 64);
            this.Icon = ico;



            ClientStatus.Gaze = true;
            ClientStatus.Commands = true;
           ClientStatus. ScreenHeight = Screen.FromHandle(this.Handle).Bounds.Height;
           ClientStatus.ScreenWidth = Screen.FromHandle(this.Handle).Bounds.Width;
           ClientStatus.ScreenTopLeft.X = Screen.FromHandle(this.Handle).Bounds.Left;
           ClientStatus.ScreenTopLeft.Y = Screen.FromHandle(this.Handle).Bounds.Top;
           ClientStatus.UpdateServer();



        }

        public void Form_monitor_Load(object sender, EventArgs e)
        {

            commandHandler += new CommandHandler(this.GetCommand);

            this.Text += "_" + ClientStatus.clientName;
            DisplayMessage("Connection successful\r\n", textBox1);
            DisplayMessage("Your name is " + ClientStatus.clientName + "\r\n", textBox1);
            // start a new thread for sending and receiving messages
            ClientStatus.inputoutputThread = new Thread(new ThreadStart(Run));
            ClientStatus.inputoutputThread.Start();

            #region set frm_glyph
            Rectangle rect = new Rectangle(Screen.FromHandle(this.Handle).Bounds.Left, Screen.FromHandle(this.Handle).Bounds.Top, Screen.FromHandle(this.Handle).Bounds.Width, Screen.FromHandle(this.Handle).Bounds.Height);
            frm_glyph = new Form_Recognition(this, rect);
            frm_glyph.Show();
            frm_glyph.Hide();
            #endregion set frm_glyph

            mycursor = new AnimatedCursor();


            timerExportData.Tick += new EventHandler(timerExportData_Tick);

            if (checkBox_showGaze.Checked)mycursor.Show();

            comboBoxes = new ComboBox[8];
            comboBoxes[0] = cmb_RightClick;
            comboBoxes[1] = cmb_LeftClick;
            comboBoxes[2] = cmb_Enter;
            comboBoxes[3] = cmb_Space;
            comboBoxes[4] = cmb_ArrowUp;
            comboBoxes[5] = cmb_ArrowDown;
            comboBoxes[6] = cmb_ArrowLeft;
            comboBoxes[7] = cmb_ArrowRight;


            foreach(ComboBox cmb in comboBoxes )
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

        private void Form_monitor_FormClosing(object sender, FormClosingEventArgs e)
        {
            mycursor.timerSpeed.Stop();

            mycursor.Dispose();
            mycursor.Close() ;
            mycursor = null;
            moveCursor = false;

            if (timerExportData.Enabled) { timerExportData.Enabled = false; exportDataFile.CloseFile(); progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous; }

            ClientStatus.clientName = "PauseReconnect";
            ClientStatus.inputoutputThread.Abort();
            ClientStatus.client.Close();

            frm1.Show();

        }//end Form_monitor_FormClosing
   
        public void Run()
        {

            try
            {
                // receive messages that is sent to client
                while (true)
                {
                    string msg = ClientStatus.reader.ReadString();
                    ProcessMessage(msg);

               }
            } // end try
            catch (IOException)
            {
                DisplayMessage("Connection failed\r\n", textBox1);

                Reconnect();
            } // end catch


        }

        private void ProcessMessage(string msg)
       {
           string[] msgArray = ConvertMsgToArray(msg);

           if (msg.StartsWith ("Gaze|"))
           {

               ClientStatus.gazePoint.X = int.Parse(msgArray[0]);
               ClientStatus.gazePoint.Y = int.Parse(msgArray[1]);
               if (moveCursor) Cursor.Position = Point.Add(ClientStatus.gazePoint, new Size(ClientStatus.ScreenTopLeft));

           }
           else if (msg .StartsWith ("Commands|"))
           {

               CommandHandler temp = commandHandler;
               if (temp != null)
               {

                   int X = int.Parse(msgArray[0]);
                   int Y = int.Parse(msgArray[1]);
                   myEventArg args = new myEventArg(msgArray[3], new Point(X, Y));
                   temp(this, args);


               }
           }
           else if (msg .StartsWith ("Glyph|"))
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
        }

        private string[] ConvertMsgToArray(string msg)
        {

        //string temp = "";
        //    List<string> msgArr = new List<string>();

        //    for (int i = 0; i < msg.Length; i++)
        //    {
        //        if (msg[i] == '|')
        //        {
        //            msgArr.Add( temp);
        //            temp = "";
        //        }
        //        else
        //        {
        //            temp += msg[i];

        //        }

        //    }
        //    msgArr.RemoveAt(0);//remove the keyword from the begining

        //return msgArr.ToArray();

            //@PJ same functionality
            var arr = msg.Split('|');
            var msgArr = arr.Skip(1).ToArray();	// skip first keyword

            return msgArr;
        }

        private void GetCommand(object sender, myEventArg e)
        {
            foreach (ComboBox i in comboBoxes)
            {
                if (i != null && i.Tag != null && i.Tag.ToString() == e.Command)
                {
                    PerformCommand((i.Name.ToString()).Remove(0,4),e.Position  );
                    DisplayMessage(e.Command, textBox1);

                }

            }
        }
        private void PerformCommand(string command,Point position)
        {
            if(position.X!=0 && position.Y!=0)Cursor.Position = Point.Add(position, new Size(ClientStatus.ScreenTopLeft));

            switch (command)

            {       
                    
                case "RightClick":
                    
                    mouse_event(MOUSEEVENTF_RIGHTDOWN | MOUSEEVENTF_RIGHTUP, Cursor.Position.X, Cursor.Position.Y, 0,0);
                    break;
                case "LeftClick":
                    mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, Cursor.Position.X, Cursor.Position.Y, 0, 0);
                    break;
                case "Enter":
                    keybd_event(0x0D, 0, 0, 0);// key press event 
                    keybd_event(0x0D, 0, KEYEVENTF_KEYUP, 0);// key release event 
                    break;
                case "Space":
                    keybd_event(0x20, 0, 0, 0);// key press event 
                    keybd_event(0x20, 0, KEYEVENTF_KEYUP, 0);// key release event 
                    break;
                case "ArrowUp":
                                        keybd_event(0x26, 0, 0, 0);// key press event 
                    keybd_event(0x26, 0, KEYEVENTF_KEYUP, 0);// key release event 
                    break;
                case "ArrowDown":
                    keybd_event(0x28, 0, 0, 0);// key press event 
                    keybd_event(0x28, 0, KEYEVENTF_KEYUP, 0);// key release event 
                    break;
                case "ArrowLeft":
                                        keybd_event(0x25, 0, 0, 0);// key press event 
                    keybd_event(0x25, 0, KEYEVENTF_KEYUP, 0);// key release event 
                    break;
                case "ArrowRight":
                    keybd_event(0x27, 0, 0, 0);// key press event 
                    keybd_event(0x27, 0, KEYEVENTF_KEYUP, 0);// key release event 
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


        private void button1_Click(object sender, EventArgs e)
        {
            frm_numDemo = new NumDemo(this);
            frm_numDemo.Left = Screen.FromHandle(this.Handle).Bounds.Left;
            frm_numDemo.Top = Screen.FromHandle(this.Handle).Bounds.Top;

           moveCursor = true;
            Cursor.Hide();
            checkBox_showGaze.Checked = false;
            frm_numDemo.Show();
        }

        private void button3_Click(object sender, EventArgs e)
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


        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
           moveCursor = checkBox1.Checked;
        }

    

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
               
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "TEXT File|*.txt|All File|*.*";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string dir = saveFileDialog.FileName;

                    exportDataFile = new TextFile(dir);
                    timerExportData.Interval = 8;//125Hz;
                    timerExportData.Enabled = true;
                    progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
                }
            }
            else
            {
                timerExportData.Enabled = false;
                exportDataFile.CloseFile();
                progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            }
        }

        void timerExportData_Tick(object sender, EventArgs e)
        {
            //TODO: change to OGAMA Format
            Point ptn=new Point(0,0);
            ptn = Point.Subtract(Cursor.Position, new Size(ClientStatus.ScreenTopLeft));
            string DataLine = ClientStatus.gazePoint.X + "," + ClientStatus.gazePoint.Y + " " + ptn.X + "," + ptn.Y;
            if (exportDataFile != null) exportDataFile.WriteLine(DataLine);

        }

        private void checkBox_showGaze_CheckedChanged(object sender, EventArgs e)
        {
           if( checkBox_showGaze.Checked) mycursor.Show();
           else mycursor.Hide();
        }


        private void cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cm = (ComboBox)sender;
            cm.Tag = cm.SelectedItem;
        }



       
    }
}
