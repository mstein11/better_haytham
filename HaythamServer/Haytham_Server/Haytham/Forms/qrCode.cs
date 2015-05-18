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
namespace Haytham.Forms
{
    public partial class qrCode : Form
    {
        

        public qrCode()
        {
            InitializeComponent();
        
        }

        private void qrCode_Load(object sender, EventArgs e)
        {
            pictureBox1.Size = new System.Drawing.Size(this.Width, this.Height);
            pictureBox1.Location = new Point(this.Width / 2 - pictureBox1.Width / 2, this.Height / 2 - pictureBox1.Height / 2);

            QRCodeWriter writer = new QRCodeWriter();
            Hashtable hints = new Hashtable();

            hints.Add(EncodeHintType.ERROR_CORRECTION, com.google.zxing.qrcode.decoder.ErrorCorrectionLevel.H);
            hints.Add("Version", "7");
            ByteMatrix byteIMGNew = writer.encode(METState.Current.ip, BarcodeFormat.QR_CODE, this.Height, this.Height, hints);
            sbyte[][] imgNew = byteIMGNew.Array;
            Bitmap bmp1 = new Bitmap(byteIMGNew.Width, byteIMGNew.Height);
            Graphics g1 = Graphics.FromImage(bmp1);
            g1.Clear(Color.White);
            for (int i = 0; i <= imgNew.Length - 1; i++)
            {
                for (int j = 0; j <= imgNew[i].Length - 1; j++)
                {
                    if (imgNew[j][i] == 0)
                    {
                        g1.FillRectangle(Brushes.Black, i, j, 1, 1);
                    }
                    else
                    {
                        g1.FillRectangle(Brushes.White, i, j, 1, 1);
                    }
                }
            }
           // bmp1.Save("D:\\QREncode.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
            pictureBox1.Image = bmp1;
        }

        private void qrCode_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {

                this.Hide();


            }
        }

        private void qrCode_FormClosing(object sender, FormClosingEventArgs e)
        {
         
            
        }
    }
}
