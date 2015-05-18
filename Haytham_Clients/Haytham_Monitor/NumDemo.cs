using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;

using System.Net;

namespace Haytham_Client
{
    public partial class NumDemo : Form
    {
        private Form_monitor form_monitor;


        public NumDemo(Form_monitor frm)
        {
       
                InitializeComponent();

                Icon ico = new Icon(Properties.Resources.Untitled_2, 64, 64);
                this.Icon = ico;

                form_monitor = frm;
                form_monitor.Hide();
                this.WindowState = FormWindowState.Maximized;
                int W = Screen.FromHandle(form_monitor.Handle).Bounds.Width;
                int H = Screen.FromHandle(form_monitor.Handle).Bounds.Height;


                if (W > H)
                {


                    Uri myUri= new Uri(Application.StartupPath + "/Images/mouseyo.swf");
                    webBrowser1.Navigate(myUri);

                    
                }
                else
                {

                    Uri myUri = new Uri(Application.StartupPath + "/Images/mouseyo_V.swf");
                    webBrowser1.Navigate(myUri);
                }

              




        }





        private void P1_FormClosing(object sender, FormClosingEventArgs e)
        {
            form_monitor. moveCursor = false;
             Cursor.Show();       
            form_monitor.Show();

        }


        private void webBrowser1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                form_monitor.moveCursor = false;
                 Cursor.Show();         
                form_monitor.Show(); ;
                form_monitor.frm_numDemo = null;
                this.Dispose();
                this.Close();


            }
        }







    }
}
