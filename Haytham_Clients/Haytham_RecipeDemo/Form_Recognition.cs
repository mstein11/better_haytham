using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Haytham_Client
{
    public partial class Form_Recognition : Form
    {
        private Form_Recipe Form_recipe;
        public int TimerCounter=0;
        public Form_Recognition(Form_Recipe frm, Rectangle rect)
        {
            InitializeComponent();

            Icon ico = new Icon(Properties.Resources.Untitled_2, 64, 64);
            this.Icon = ico;

            Form_recipe = frm;

            System.Reflection.Assembly assembly = this.GetType().Assembly;

   
            this.Left = rect.Left;
            this.Top = rect.Top;

            this.Width = rect.Width;
            this.Height = rect.Height;

            Bitmap bmp = new Bitmap(assembly.GetManifestResourceStream(string.Format("Haytham_Client.Resources.{0}.png", ClientStatus.clientIndex)));

            pictureBox1.Image = bmp;
           // this.Width = Screen.PrimaryScreen.Bounds.Width;
           // this.Height = Screen.PrimaryScreen.Bounds.Height;

            pictureBox1.Left = (this.Width - pictureBox1.Width) / 2;
            pictureBox1.Top = (this.Height - pictureBox1.Height) / 2;



            pictureBox1.Refresh();
        }




        // delegate that allows method DisplayMessage to be called
        // in the thread that creates and maintains the GUI
        private delegate void DisplayImageDelegate(bool show);
        // method DisplayMessage sets displayTextBox's Text property
        // in a thread-safe manner
        public void DisplayImage(bool show)
        {
            
                // if modifying displayTextBox is not thread safe
                if (this.InvokeRequired)
                {
                    // use inherited method Invoke to execute DisplayMessage
                    // via a delegate
                    Invoke(new DisplayImageDelegate(DisplayImage),
                    new object[] { show });
                } // end if
                else // OK to modify displayTextBox in current thread
                {

                    this.Visible = show;
                  //  this.Refresh();

                }
            
        }








    }
}
