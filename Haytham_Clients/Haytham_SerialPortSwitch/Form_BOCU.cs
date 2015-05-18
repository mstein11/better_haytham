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
    public partial class Form_BOCU : Form
    {
        //Client
        private Form1 form1;

        private Dictionary<string, Device> Objects = new Dictionary<string, Device>();//("Marker_6_1",["lamp",true,"U_D","D_U"])
        System.Windows.Forms.Label[] lbls = new Label[10];
        System.Windows.Forms.TextBox[] txts = new TextBox[10];
        System.Windows.Forms.Panel[] pnls = new Panel[10];
        System.Windows.Forms.ComboBox[] cmbs = new ComboBox[20];
        public struct Device
        {
            public string name { get; set; }
            public bool OnOff { get; set; }
            public string OnCommand { get; set; }
            public string OffCommand { get; set; }
        }

        public Form_BOCU(Form1 frm)
        {
            form1 = frm;
            InitializeComponent();


            Icon ico = new Icon(Properties.Resources.Untitled_2, 64, 64);
            this.Icon = ico;
            PortBOCU.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(PortOB_DataReceived);

        }
        void PortOB_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {

        }

        public void Form_BOCU_Load(object sender, EventArgs e)
        {
            // groupBox1.Enabled = false;

            ClientStatus.Commands = true;
            ClientStatus.VisualMarker = true;

            lbls[0] = lbl_1;
            lbls[1] = lbl_2;
            lbls[2] = lbl_3;
            lbls[3] = lbl_4;
            lbls[4] = lbl_5;
            lbls[5] = lbl_6;
            lbls[6] = lbl_7;
            lbls[7] = lbl_8;
            lbls[8] = lbl_9;
            lbls[9] = lbl_10;

            txts[0] = txt1;
            txts[1] = txt2;
            txts[2] = txt3;
            txts[3] = txt4;
            txts[4] = txt5;
            txts[5] = txt6;
            txts[6] = txt7;
            txts[7] = txt8;
            txts[8] = txt9;
            txts[9] = txt10;

            pnls[0] = pnl_1;
            pnls[1] = pnl_2;
            pnls[2] = pnl_3;
            pnls[3] = pnl_4;
            pnls[4] = pnl_5;
            pnls[5] = pnl_6;
            pnls[6] = pnl_7;
            pnls[7] = pnl_8;
            pnls[8] = pnl_9;
            pnls[9] = pnl_10;

            cmbs[0] = Marker_6_1_ON;
            cmbs[1] = Marker_6_1_OFF;
            cmbs[2] = Marker_6_2_ON;
            cmbs[3] = Marker_6_2_OFF;
            cmbs[4] = Marker_6_3_ON;
            cmbs[5] = Marker_6_3_OFF;
            cmbs[6] = Marker_6_4_ON;
            cmbs[7] = Marker_6_4_OFF;
            cmbs[8] = Marker_6_5_ON;
            cmbs[9] = Marker_6_5_OFF;
            cmbs[10] = Marker_6_6_ON;
            cmbs[11] = Marker_6_6_OFF;
            cmbs[12] = Marker_6_7_ON;
            cmbs[13] = Marker_6_7_OFF;
            cmbs[14] = Marker_6_8_ON;
            cmbs[15] = Marker_6_8_OFF;
            cmbs[16] = Marker_6_9_ON;
            cmbs[17] = Marker_6_9_OFF;
            cmbs[18] = Marker_6_10_ON;
            cmbs[19] = Marker_6_10_OFF;

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


            Device temp=new Device();
            temp.name="";
            temp.OffCommand="";
            temp.OnCommand="";
            temp.OnOff=false;
            ClientStatus.userData.Clear();

            for (int i = 0; i < txts.Count(); i++)
            {
                ClientStatus.userData.Add(txts[i].Tag.ToString(), txts[i].Text);
                Objects.Add(txts[i].Tag.ToString(), temp);
            }
            ClientStatus.UpdateServer();





        


            this.Text += "_" + ClientStatus. clientName;
            ChangeForm("Connection successful\r\n", "textBox1");

            ChangeForm("Your name is " + ClientStatus.clientName + "\r\n", "textBox1");

            // start a new thread for sending and receiving messages
            ClientStatus.inputoutputThread  = new Thread(new ThreadStart(Run));
            ClientStatus.inputoutputThread.Start();

            //serial port
            string[] theSerialPortNames = System.IO.Ports.SerialPort.GetPortNames();
            foreach (string port in theSerialPortNames)
            {
                cboPorts.Items.Add(port);
            }
            try
            {
                PortBOCU.PortName = cboPorts.Text;
                // PortBOCU.Open();

            }
            catch (Exception)
            { }

        }

        private void Form_BOCU_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                PortBOCU.Close();

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
                    string msg = ClientStatus.reader.ReadString();
                    ProcessMessage(msg);

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

               if (Objects.ContainsKey(msgArray[2]))
                {
                if (Objects[msgArray[2]].OnCommand == msgArray[3]) OnOff(msgArray[2], true);
                else if (Objects[msgArray[2]].OffCommand == msgArray[3]) OnOff(msgArray[2], false);
              
                }

            }
            else if (msg.StartsWith("VisualMarker|"))
            {
                if (msgArray[0] == "IsLooking") ChangeForm(msgArray[1], "pnl");
              else if (msgArray[0] == "IsNotLooking") ChangeForm("", "resetpnl");
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
                case "resetpnl":
                    if (groupBox1.InvokeRequired) Invoke(new ChangeFormDelegate(ChangeForm), new object[] { message, control });

                    else // OK to modify displayTextBox in current thread
                    {
                        foreach (Panel pnl in pnls)
                        {
               
                                pnl.BackColor = DefaultBackColor ;

                           
                        }

                    }
                    break;
                case "pnl":
                    // if modifying displayTextBox is not thread safe
                    if (groupBox1.InvokeRequired) Invoke(new ChangeFormDelegate(ChangeForm), new object[] { message, control });

                    else // OK to modify displayTextBox in current thread
                    {

                        foreach (Panel pnl in pnls)
                        {
                            if ((string)(pnl.Tag.ToString()) == message)
                            {
                                pnl.BackColor = Color.Yellow;

                            }
                        }





                    }
                    break;
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
                case "txtDebug":
                    // if modifying displayTextBox is not thread safe
                    if (txtDebug.InvokeRequired) Invoke(new ChangeFormDelegate(ChangeForm), new object[] { message, control });

                    else // OK to modify displayTextBox in current thread
                    {
                        txtDebug.Text += message;

                        txtDebug.SelectionStart = txtDebug.Text.Length;
                        txtDebug.ScrollToCaret();
                    }
                    break;
                    

            }
        }



        public void SendCommand(string command)
        {

            PortBOCU.Open();

            PortBOCU.WriteLine((char)0 + (char)0 + command + (char)0 + (char)0);
            PortBOCU.WriteLine((char)0 + (char)0 + command + (char)0 + (char)0);
           // PortBOCU.WriteLine((char)0 + (char)0 + command + (char)0 + (char)0);
           // PortBOCU.WriteLine((char)0 + (char)0 + command + (char)0 + (char)0);
            //PortBOCU.WriteLine((char)0 + (char)0 + command + (char)0 + (char)0);
            Thread.Sleep(10);
            //PortBOCU.WriteLine((char)0 + (char)0 + command + (char)0 + (char)0);
            //PortBOCU.WriteLine((char)0 + (char)0 + command + (char)0 + (char)0);
            PortBOCU.WriteLine((char)0 + (char)0 + command + (char)0 + (char)0);
            PortBOCU.WriteLine((char)0 + (char)0 + command + (char)0 + (char)0);
            PortBOCU.WriteLine((char)0 + (char)0 + command + (char)0 + (char)0);

            PortBOCU.Close();

        }


        private void btnSendToServer_Click(object sender, EventArgs e)
        {
          ClientStatus.  writer.Write(txtMsgToSend.Text);
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
            if (btnStart.Text == "Open")
            {
                try
                {


                    PortBOCU.PortName = cboPorts.Text;
                    //PortBOCU.Open();
                    groupBox1.Enabled = true;
                    ClientStatus.Commands = true;
                    btnStart.Text = "Close";
                }
                catch (Exception)
                { }
            }
            else
            {
                try
                {
                   
                    // PortBOCU.Close();
                    groupBox1.Enabled = false;
                    ClientStatus.Commands = false;
                    btnStart.Text = "Open";
                }
                catch (Exception)
                { }
            }
        }

        private void lbl_Click(object sender, EventArgs e)
        {
            OnOff (((System.Windows.Forms.Label)sender).Tag.ToString());
   
        }
        private void OnOff(string tg,bool OnOrOFF)
        {
            try
            {



                int index = int.Parse(tg.Remove(0, 9)) - 1;

                string comd = "%$" + index.ToString();

                Device temp = Objects[tg];

                if (!OnOrOFF)//is On
                {
                    comd += "F";

                    SetColor(false, tg);
                    temp.OnOff = false;
                }
                else//is Off
                {
                    comd += "N";
                    SetColor(true, tg);
                    temp.OnOff = true;
                }
                SendCommand(comd);
                Objects[tg] = temp;
            }
            catch (Exception)
            { }
        }
        private void OnOff(string tg)
        {

            try
            {


                int index = int.Parse(tg.Remove(0,9)) - 1;

                string comd = "%$" + index.ToString();

                Device temp = Objects[tg];

                if (temp.OnOff)//is On
                {
                    comd += "F";

                    SetColor(false, tg);
                    temp.OnOff = false;
                }
                else//is Off
                {
                    comd += "N";
                    SetColor(true, tg);
                    temp.OnOff = true;
                }
                SendCommand(comd);
                Objects[tg] = temp;
            }
            catch (Exception)
            { }


             
        
        }
        private void SetColor(bool On, string channel)
        {
            foreach (Control c in lbls)
            {

                    if ((string)(c.Tag) == channel)
                    {        

                        c.BackColor = On ? Color.FromArgb(128, 255, 128) : Color.Pink ;
                    }
               
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            //update objects dic
             TextBox tb=(TextBox)sender;
             Device temp = Objects[tb.Tag.ToString()];
             temp.name = tb.Text ;
             Objects[tb.Tag.ToString()] = temp;


             ClientStatus.userData[tb.Tag.ToString()] = tb.Text;

             ClientStatus.sendUserData(tb.Tag.ToString());

        }

        private void cmb_SelectedIndexChanged(object sender, EventArgs e)
        {

            ComboBox cb = (ComboBox)sender;
            Device temp = Objects[cb.Tag.ToString()];
            if (cb.Name.Remove(0, (cb.Tag.ToString().Count()) + 1) == "ON") temp.OnCommand = cb.SelectedItem.ToString();
            else temp.OffCommand = cb.SelectedItem.ToString();
            Objects[cb.Tag.ToString()] = temp;


        }








    }
}
