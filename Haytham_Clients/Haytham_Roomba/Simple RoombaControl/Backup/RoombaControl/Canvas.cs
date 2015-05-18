using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RoombaControl
{
    public partial class Canvas : UserControl
    {
        public int roombaAngle = 90;
        private Point roombaPosition;
        public int angleFactor = 300;
        private float scaleX=0.5f;
        private float scaleY=0.5f;
        private List<Point> trail = new List<Point>();
        private int roombaSize = 150;
        
        public Canvas()
        {
            InitializeComponent();
            roombaPosition.X = 100;
            roombaPosition.Y = 100;
        }

        private void Canvas_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            

            if (!DesignMode)
            {
                DrawFrame(g);
                DrawInfoText(g);
                DrawTrail(g);
                DrawRoomba(g);
            }
            else
            {
                DrawFrame(g);
            }
        }

        private void DrawTrail(Graphics g)
        {
            g.ResetTransform();
            // center picture on origin
            g.TranslateTransform((float)(roombaSize / -2), (float)(roombaSize / -2), MatrixOrder.Append);
            ApplyScrollAndZoom(g);
            Brush brush = new SolidBrush (Color.Gray);
            foreach (Point p in trail)
            {
                g.FillEllipse(brush, p.X , p.Y , roombaSize, roombaSize);
            }
        }

        private void DrawInfoText(Graphics g)
        {
            Brush bh = new SolidBrush(Color.Black);
            Font ft = new Font("Verdana", 10);
            g.DrawString("Angle: " + roombaAngle + "    Pos  : " + roombaPosition, ft, bh, 10f, 10f);
        }

        private void DrawFrame(Graphics g)
        {
            Pen pn = new Pen(Color.Blue);
            g.DrawRectangle(pn, 0, 0, Width - 1, Height - 1);
        }

        private void DrawRoomba(Graphics g)
        {
            Bitmap curBitmap = new Bitmap(@"roomba_s.png");


            g.ResetTransform();
            // center picture on origin
            g.TranslateTransform((float)(roombaSize / -2), (float)(roombaSize / -2), MatrixOrder.Append);
            // rotate picture
            g.RotateTransform(roombaAngle - 90, MatrixOrder.Append);
            // apply position
            g.TranslateTransform((float)(roombaPosition.X ), (float)(roombaPosition.Y ), MatrixOrder.Append);
            

            ApplyScrollAndZoom(g);
            
            // Draw image
            g.DrawImage(curBitmap, 0, 0, roombaSize, roombaSize);

            curBitmap.Dispose();
        }

        private void ApplyScrollAndZoom(Graphics g)
        {
            // position picture at its x,y
            g.TranslateTransform((float)(roombaPosition.X *-1), (float)(roombaPosition.Y *-1), MatrixOrder.Append);
            // apply zoom factor
            g.ScaleTransform(scaleX, scaleY, MatrixOrder.Append);
            // scroll
            g.TranslateTransform((float)(Width / 2), (float)(Height / 2), MatrixOrder.Append);
            
        }

        public void moveRoomba (int distance)
        {
            if (distance != 0)
            {
                roombaPosition.X += (int)(distance * 3 * Math.Cos(((double)roombaAngle) * Math.PI / 180));
                roombaPosition.Y += (int)(distance * 3 * Math.Sin(((double)roombaAngle) * Math.PI / 180));
                trail.Add(new Point(roombaPosition.X, roombaPosition.Y));
                Invalidate();
            }
        }

        public void rotateRoomba(int angle)
        {
            roombaAngle -= (angle * angleFactor) / 100 ;
            roombaAngle %= 360;
            if (roombaAngle < 0) roombaAngle = 360 + roombaAngle;
            Invalidate();
        }

        public void setScale(float scale)
        {
            scaleX = scale;
            scaleY = scale;
            Invalidate();
        }
        
        public void ClearTrail () 
        {
            trail = new List<Point>();
        }

    }
}
