

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
namespace Haytham_Client
{
    public partial class AnimatedCursor : Form
    {
        private class PointerImage
        {
            public string name;
            public Image FullImage;
            public int frameCount;
            public int frameWidth_Orginal;
            public int frameHeight_Orginal;
            public int frameWidth_Scaled;
            public int frameHeight_Scaled;
            public int frameWidth_Max;
            public int frameHeight_Max;

            public float RotVelocity;
            public float Rotation;
            public float ScaleVelocity;
            public Boolean ScaleIncreasing = true;
            public float ScaleMin;
            public float ScaleMax;
            public float Scale;


        }


        PointerImage pointerImage = new PointerImage();
        Point oldPoint = new Point(0, 0);

        bool haveHandle = false;
        public Timer timerSpeed = new Timer();
        int frame = 0;

        public AnimatedCursor()
        {
            InitializeComponent();

            Icon ico = new Icon(Properties.Resources.Untitled_2, 64, 64);
            this.Icon = ico;

            this.TopMost = true;

            pointerImage.name = "Cursor_5";
            GetPointerImage(pointerImage);

            frame = 0;

            timerSpeed.Interval = 50;
            timerSpeed.Enabled = true;
            timerSpeed.Tick += new EventHandler(timerSpeed_Tick);

            this.DoubleClick += new EventHandler(Form2_DoubleClick);

        }

        #region Override

        protected override void OnClosing(CancelEventArgs e)
        {
            e.Cancel = true;
            base.OnClosing(e);
            haveHandle = false;
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            InitializeStyles();
            base.OnHandleCreated(e);
            haveHandle = true;
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cParms = base.CreateParams;
                cParms.ExStyle |= 0x00080000; // WS_EX_LAYERED
                return cParms;
            }
        }

        #endregion

        private void InitializeStyles()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            UpdateStyles();
        }

        void timerSpeed_Tick(object sender, EventArgs e)
        {


            pointerImage.Rotation += pointerImage.RotVelocity;
            pointerImage.Rotation = pointerImage.Rotation % 360;
            //a == <bool condition> ? <true value> : <false value>;

            pointerImage.Scale = pointerImage.ScaleIncreasing ? pointerImage.Scale + pointerImage.ScaleVelocity : pointerImage.Scale - pointerImage.ScaleVelocity;
            pointerImage.Scale = pointerImage.Scale >= pointerImage.ScaleMax ? pointerImage.ScaleMax : pointerImage.Scale;
            pointerImage.Scale = pointerImage.Scale <= pointerImage.ScaleMin ? pointerImage.ScaleMin : pointerImage.Scale;

            if (pointerImage.ScaleIncreasing)
            {
                if (pointerImage.Scale >= pointerImage.ScaleMax) pointerImage.ScaleIncreasing = false;
            }
            else
            {
                if (pointerImage.Scale <= pointerImage.ScaleMin) pointerImage.ScaleIncreasing = true;
            }


            pointerImage.frameWidth_Scaled = (int)(pointerImage.frameWidth_Orginal * pointerImage.Scale);
            pointerImage.frameHeight_Scaled = (int)(pointerImage.frameHeight_Orginal * pointerImage.Scale);

            Bitmap temp = FrameImage;
            SetBits(temp);


            Point coor = new Point(0, 0);
            coor= Point.Add(ClientStatus.gazePoint, new Size(ClientStatus.ScreenTopLeft));

            this.Left = coor.X - temp.Width / 2;// (int)left;
            this.Top = coor.Y - temp.Height / 2;// (int)top;          




            frame++;
            if (frame >= pointerImage.frameCount) frame = 0;

        }

        private void GetPointerImage(PointerImage pointerImage)
        {

            switch (pointerImage.name)
            {
                case "Cursor_1":
                    pointerImage.FullImage = Properties.Resources.Cursor_1;
                    pointerImage.frameCount = 1;
                    pointerImage.RotVelocity = 10;
                    pointerImage.ScaleVelocity = 0.1f;
                    pointerImage.ScaleMax = 1.5f;
                    pointerImage.Scale = 1;
                    pointerImage.ScaleMin = 0.5f;
                    break;
                case "Cursor_2":
                    pointerImage.FullImage = Properties.Resources.Cursor_2;
                    pointerImage.frameCount = 1;
                    pointerImage.RotVelocity = 10;
                    pointerImage.ScaleVelocity = 0.1f;
                    pointerImage.ScaleMax = 1.5f;
                    pointerImage.Scale = 1;
                    pointerImage.ScaleMin = 0.5f;
                    break;

                case "Cursor_4":
                    pointerImage.FullImage = Properties.Resources.Cursor_4;
                    pointerImage.frameCount = 1;
                    pointerImage.RotVelocity = 2;
                    pointerImage.ScaleVelocity = 0.01f;
                    pointerImage.ScaleMax = 0.7f;
                    pointerImage.Scale = 0.7f;
                    pointerImage.ScaleMin = 0.5f;
                    break;
                case "Cursor_5":
                    pointerImage.FullImage = Properties.Resources.Cursor_5;
                    pointerImage.frameCount = 1;
                    pointerImage.RotVelocity = 10;
                    pointerImage.ScaleVelocity = 0.1f;
                    pointerImage.ScaleMax = 1.5f;
                    pointerImage.Scale = 1;
                    pointerImage.ScaleMin = 0.5f;
                    break;
                case "Cursor_6":
                    pointerImage.FullImage = Properties.Resources.Cursor_6;
                    pointerImage.frameCount = 1;
                    pointerImage.RotVelocity = 8;
                    pointerImage.ScaleVelocity = 0.00f;
                    pointerImage.ScaleMax = 2f;
                    pointerImage.Scale = 1f;
                    pointerImage.ScaleMin = 0.5f;
                    break;

            }


            pointerImage.Rotation = 0;
            pointerImage.frameWidth_Orginal = pointerImage.FullImage.Width / pointerImage.frameCount;
            pointerImage.frameHeight_Orginal = pointerImage.FullImage.Height;
            pointerImage.frameWidth_Scaled = pointerImage.frameWidth_Orginal;
            pointerImage.frameHeight_Scaled = pointerImage.frameHeight_Orginal;
            pointerImage.frameWidth_Max = (int)(1.1 * pointerImage.ScaleMax * pointerImage.frameWidth_Orginal);
            pointerImage.frameHeight_Max = (int)(1.1 * pointerImage.ScaleMax * pointerImage.frameHeight_Orginal);

        }

        public Bitmap FrameImage
        {
            get
            {

                Bitmap bitmap = new Bitmap(pointerImage.frameWidth_Max, pointerImage.frameHeight_Max);
                Graphics g = Graphics.FromImage(bitmap);

                switch (pointerImage.name)
                {
                    case "Cursor_1":

                        g.RotateTransform(pointerImage.Rotation, MatrixOrder.Append);
                        g.TranslateTransform(pointerImage.frameWidth_Max / 2, pointerImage.frameHeight_Max / 2, MatrixOrder.Append);
                        g.DrawImage(pointerImage.FullImage, new Rectangle(-pointerImage.frameWidth_Scaled / 2, -pointerImage.frameHeight_Scaled / 2, pointerImage.frameWidth_Scaled, pointerImage.frameHeight_Scaled), new Rectangle(pointerImage.frameWidth_Orginal * frame, 0, pointerImage.frameWidth_Orginal, pointerImage.frameHeight_Orginal), GraphicsUnit.Pixel);

                        //---------------------------------------------
                        g.ResetTransform();
                        g.RotateTransform(-2 * pointerImage.Rotation, MatrixOrder.Append);
                        g.TranslateTransform(pointerImage.frameWidth_Max / 2, pointerImage.frameHeight_Max / 2, MatrixOrder.Append);
                        g.DrawImage(pointerImage.FullImage, new Rectangle(-pointerImage.frameWidth_Scaled / 2, -pointerImage.frameHeight_Scaled / 2, pointerImage.frameWidth_Scaled, pointerImage.frameHeight_Scaled), new Rectangle(pointerImage.frameWidth_Orginal * frame, 0, pointerImage.frameWidth_Orginal, pointerImage.frameHeight_Orginal), GraphicsUnit.Pixel);
                        break;
                    case "Cursor_2":
                        
                        g.RotateTransform(pointerImage.Rotation, MatrixOrder.Append);
                        g.TranslateTransform(pointerImage.frameWidth_Max / 2, pointerImage.frameHeight_Max / 2, MatrixOrder.Append);
                        g.DrawImage(pointerImage.FullImage, new Rectangle(-pointerImage.frameWidth_Scaled / 2, -pointerImage.frameHeight_Scaled / 2, pointerImage.frameWidth_Scaled, pointerImage.frameHeight_Scaled), new Rectangle(pointerImage.frameWidth_Orginal * frame, 0, pointerImage.frameWidth_Orginal, pointerImage.frameHeight_Orginal), GraphicsUnit.Pixel);

                        //---------------------------------------------
                        g.ResetTransform();
                        g.RotateTransform(-2 * pointerImage.Rotation, MatrixOrder.Append);
                        g.TranslateTransform(pointerImage.frameWidth_Max / 2, pointerImage.frameHeight_Max / 2, MatrixOrder.Append);
                        g.DrawImage(pointerImage.FullImage, new Rectangle(-pointerImage.frameWidth_Scaled / 2, -pointerImage.frameHeight_Scaled / 2, pointerImage.frameWidth_Scaled, pointerImage.frameHeight_Scaled), new Rectangle(pointerImage.frameWidth_Orginal * frame, 0, pointerImage.frameWidth_Orginal, pointerImage.frameHeight_Orginal), GraphicsUnit.Pixel);
                        break;



                    case "Cursor_4":
                        g.TranslateTransform(pointerImage.frameWidth_Max / 2, pointerImage.frameHeight_Max / 2, MatrixOrder.Append);
                        g.DrawImage(pointerImage.FullImage, new Rectangle(-pointerImage.frameWidth_Orginal / 2, -pointerImage.frameHeight_Orginal / 2, pointerImage.frameWidth_Orginal, pointerImage.frameHeight_Orginal), new Rectangle(pointerImage.frameWidth_Orginal * frame, 0, pointerImage.frameWidth_Orginal, pointerImage.frameHeight_Orginal), GraphicsUnit.Pixel);
                        //---------------------------------------------
                        g.DrawImage(pointerImage.FullImage, new Rectangle(-pointerImage.frameWidth_Scaled / 2, -pointerImage.frameHeight_Scaled / 2, pointerImage.frameWidth_Scaled, pointerImage.frameHeight_Scaled), new Rectangle(pointerImage.frameWidth_Orginal * frame, 0, pointerImage.frameWidth_Orginal, pointerImage.frameHeight_Orginal), GraphicsUnit.Pixel);
                        //---------------------------------------------

                        g.ResetTransform();
                        g.RotateTransform(pointerImage.Rotation, MatrixOrder.Append);
                        g.TranslateTransform(pointerImage.frameWidth_Max / 2, pointerImage.frameHeight_Max / 2, MatrixOrder.Append);
                        g.DrawImage(Properties.Resources.Cursor_5, new Rectangle(-pointerImage.frameWidth_Orginal / 2, -pointerImage.frameHeight_Orginal / 2, pointerImage.frameWidth_Orginal, pointerImage.frameHeight_Orginal), new Rectangle(pointerImage.frameWidth_Orginal * frame, 0, pointerImage.frameWidth_Orginal, pointerImage.frameHeight_Orginal), GraphicsUnit.Pixel);


                        break;
                    case "Cursor_5":

                        g.RotateTransform(pointerImage.Rotation, MatrixOrder.Append);
                        g.TranslateTransform(pointerImage.frameWidth_Max / 2, pointerImage.frameHeight_Max / 2, MatrixOrder.Append);
                        g.DrawImage(pointerImage.FullImage, new Rectangle(-pointerImage.frameWidth_Scaled / 2, -pointerImage.frameHeight_Scaled / 2, pointerImage.frameWidth_Scaled, pointerImage.frameHeight_Scaled), new Rectangle(pointerImage.frameWidth_Orginal * frame, 0, pointerImage.frameWidth_Orginal, pointerImage.frameHeight_Orginal), GraphicsUnit.Pixel);

                        //---------------------------------------------
                        g.ResetTransform();
                        g.RotateTransform(-2 * pointerImage.Rotation, MatrixOrder.Append);
                        g.TranslateTransform(pointerImage.frameWidth_Max / 2, pointerImage.frameHeight_Max / 2, MatrixOrder.Append);
                        g.DrawImage(pointerImage.FullImage, new Rectangle(-pointerImage.frameWidth_Scaled / 2, -pointerImage.frameHeight_Scaled / 2, pointerImage.frameWidth_Scaled, pointerImage.frameHeight_Scaled), new Rectangle(pointerImage.frameWidth_Orginal * frame, 0, pointerImage.frameWidth_Orginal, pointerImage.frameHeight_Orginal), GraphicsUnit.Pixel);
                        break;
                    case "Cursor_6":

                        g.RotateTransform(pointerImage.Rotation, MatrixOrder.Append);
                        g.TranslateTransform(pointerImage.frameWidth_Max / 2, pointerImage.frameHeight_Max / 2, MatrixOrder.Append);
                        g.DrawImage(pointerImage.FullImage, new Rectangle(-pointerImage.frameWidth_Scaled / 2, -pointerImage.frameHeight_Scaled / 2, pointerImage.frameWidth_Scaled, pointerImage.frameHeight_Scaled), new Rectangle(pointerImage.frameWidth_Orginal * frame, 0, pointerImage.frameWidth_Orginal, pointerImage.frameHeight_Orginal), GraphicsUnit.Pixel);

                        break;
                }

                return bitmap;
            }
        }

        void Form2_DoubleClick(object sender, EventArgs e)
        {
            timerSpeed.Enabled = false;
            this.Dispose();
        }

        public void SetBits(Bitmap bitmap)
        {
            //this.TopMost = true;
            if (!haveHandle) return;

            if (!Bitmap.IsCanonicalPixelFormat(bitmap.PixelFormat) || !Bitmap.IsAlphaPixelFormat(bitmap.PixelFormat))
                throw new ApplicationException("The picture must be 32bit picture with alpha channel.");

            IntPtr oldBits = IntPtr.Zero;
            IntPtr screenDC = Win32.GetDC(IntPtr.Zero);
            IntPtr hBitmap = IntPtr.Zero;
            IntPtr memDc = Win32.CreateCompatibleDC(screenDC);

            try
            {
                Win32.Point topLoc = new Win32.Point(Left, Top);
                Win32.Size bitMapSize = new Win32.Size(bitmap.Width, bitmap.Height);
                Win32.BLENDFUNCTION blendFunc = new Win32.BLENDFUNCTION();
                Win32.Point srcLoc = new Win32.Point(0, 0);

                hBitmap = bitmap.GetHbitmap(Color.FromArgb(0));
                oldBits = Win32.SelectObject(memDc, hBitmap);

                blendFunc.BlendOp = Win32.AC_SRC_OVER;
                blendFunc.SourceConstantAlpha = 255;
                blendFunc.AlphaFormat = Win32.AC_SRC_ALPHA;
                blendFunc.BlendFlags = 0;

                Win32.UpdateLayeredWindow(Handle, screenDC, ref topLoc, ref bitMapSize, memDc, ref srcLoc, 0, ref blendFunc, Win32.ULW_ALPHA);
            }
            finally
            {
                if (hBitmap != IntPtr.Zero)
                {
                    Win32.SelectObject(memDc, oldBits);
                    Win32.DeleteObject(hBitmap);
                }
                Win32.ReleaseDC(IntPtr.Zero, screenDC);
                Win32.DeleteDC(memDc);
            }
        }

        private void AnimatedCursor_FormClosing(object sender, FormClosingEventArgs e)
        {
            timerSpeed.Enabled = false;

        }
    }
}