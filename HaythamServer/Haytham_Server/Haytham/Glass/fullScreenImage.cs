using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using com.google.zxing.qrcode;
using com.google.zxing;
using com.google.zxing.common;
using System.Collections;
namespace myGlass
{
    public partial class fullScreenImage : Form
    {

        Bitmap image;
        public fullScreenImage(Bitmap img)
        {
            InitializeComponent();
            image = img;
        }

        private void qrCode_Load(object sender, EventArgs e)
        {
            pictureBox1.Size = new System.Drawing.Size(this.Width, this.Height);
            pictureBox1.Location = new Point(this.Width / 2 - pictureBox1.Width / 2, this.Height / 2 - pictureBox1.Height / 2);

         
            pictureBox1.Image = image;
        }

        private void qrCode_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {

                this.Hide();


            }
        }

  
    }
}
