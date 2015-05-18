
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
using Haytham.ExtData;	//change @PJ

namespace Haytham_Client
{
    public partial class Form1 : Form
    {
        private IPAddress serverip;

        public Form1()
        {
            InitializeComponent();

            Icon ico = new Icon(Properties.Resources.Untitled_2, 64, 64);
            this.Icon = ico;

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

            ClientStatus.client = new TcpClient();
            ClientStatus.serverip = IPAddress.Parse(textBox1.Text); ;



            try
            {
                ClientStatus.client.Connect(ClientStatus.serverip, 50000);
            }
            catch (Exception ee)
            {
                MessageBox.Show("Server not found\r\n" + "Check the server IP again!");
                return;
            }





            Form_monitor form_monitor;

                ClientStatus.Connect();
                form_monitor = new Form_monitor(this);
                form_monitor.Show();
                this.Hide();







        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                button1_Click(sender, e);
        }

     
        private void form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Environment.Exit(System.Environment.ExitCode);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }








  


    }
}
