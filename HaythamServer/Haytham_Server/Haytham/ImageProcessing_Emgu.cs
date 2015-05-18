
//<copyright file="ImageProcessing_Emgu.cs" company="ITU">
//This file is part of Haytham 
//Copyright (C) 2012 Diako Mardanbegi
// ------------------------------------------------------------------------
//This program is free software: you can redistribute it and/or modify
//it under the terms of the GNU General Public License as published by
//the Free Software Foundation, either version 3 of the License, or
//(at your option) any later version.

//This program is distributed in the hope that it will be useful,
//but WITHOUT ANY WARRANTY; without even the implied warranty of
//MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//GNU General Public License for more details.

//You should have received a copy of the GNU General Public License
//along with this program.  If not, see <http://www.gnu.org/licenses/>.
// ------------------------------------------------------------------------
// </copyright>
// <author>Diako Mardanbegi</author>
// <email>dima@itu.dk</email>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Drawing;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Util;
namespace Haytham
{
    public class ImageProcessing_Emgu
    {

        public Image<Gray, Byte> Filter_Threshold(Image<Gray, Byte> inputimg, int threshold, bool inverse)
        {

            IntPtr grayimage = inputimg.Ptr;
            IntPtr processed_image;
            Image<Gray, Byte> imagetemp = inputimg.CopyBlank();
            processed_image = imagetemp.Ptr;
            if (inverse == false)
            {

                CvInvoke.cvThreshold(grayimage, processed_image, threshold, 255, THRESH.CV_THRESH_BINARY);
            }
            else
            {
                CvInvoke.cvThreshold(grayimage, processed_image, threshold, 255, THRESH.CV_THRESH_BINARY_INV);
            }
            imagetemp.Ptr = processed_image;
            return imagetemp;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="inputimg"></param>
        /// <param name="threshold"></param>
        /// <param name="inverse"></param>
        /// <param name="constant">-1 or constant param</param>
        /// <returns></returns>
        public Image<Gray, Byte> Filter_PupilAdaptiveThreshold(Image<Gray, Byte> inputimg, int threshold, bool inverse, int constant)
        {

            IntPtr grayimage = inputimg.Ptr;
            IntPtr processed_image;
            Image<Gray, Byte> imagetemp = inputimg.CopyBlank();
            processed_image = imagetemp.Ptr;
            if (constant == -1) constant = METState.Current.PAdaptive_Constant;

            if (inverse == false)
            {
                CvInvoke.cvAdaptiveThreshold(grayimage, processed_image, (double)threshold, METState.Current.PAdaptive_type, THRESH.CV_THRESH_BINARY, METState.Current.PAdaptive_blockSize, constant);
            }
            else
            {
                try{
 //                   CvInvoke.cvAdaptiveThreshold(grayimage, processed_image, (double)threshold, METState.Current.PAdaptive_type, THRESH.CV_THRESH_BINARY_INV, METState.Current.PAdaptive_blockSize, constant);
                    CvInvoke.cvAdaptiveThreshold(grayimage, processed_image, (double)threshold, METState.Current.PAdaptive_type, THRESH.CV_THRESH_BINARY_INV, 3, constant);
 
                }
                catch
                {
                    System.Windows.Forms.MessageBox.Show("" + METState.Current.PAdaptive_blockSize);
                }
            }
            imagetemp.Ptr = processed_image;
            return imagetemp;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="inputimg"></param>
        /// <param name="threshold"></param>
        /// <param name="inverse"></param>
        /// <param name="constant">-1 or constant param</param>
        /// <returns></returns>
        public Image<Gray, Byte> Filter_Threshold2(Image<Gray, Byte> inputimg, int threshold, bool inverse)
        {

            IntPtr grayimage = inputimg.Ptr;
            IntPtr processed_image;
            Image<Gray, Byte> imagetemp = inputimg.CopyBlank();
            processed_image = imagetemp.Ptr;

            if (inverse == false)
            {
                CvInvoke.cvThreshold(grayimage, processed_image, (double)threshold,255,  THRESH.CV_THRESH_BINARY | THRESH.CV_THRESH_OTSU);
            }
            else
            {
                CvInvoke.cvThreshold(grayimage, processed_image, (double)threshold,255, THRESH.CV_THRESH_BINARY_INV | THRESH.CV_THRESH_OTSU);
            }
            imagetemp.Ptr = processed_image;
            return imagetemp;
        }
        public Image<Gray, Byte> Filter_GlintAdaptiveThreshold(Image<Gray, Byte> inputimg, int threshold, bool inverse)
        {

            IntPtr grayimage = inputimg.Ptr;
            IntPtr processed_image;
            Image<Gray, Byte> imagetemp = inputimg.CopyBlank();
            processed_image = imagetemp.Ptr;
            if (inverse == false)
            {
                CvInvoke.cvAdaptiveThreshold(grayimage, processed_image, (double)threshold, METState.Current.GAdaptive_type, THRESH.CV_THRESH_BINARY, METState.Current.GAdaptive_blockSize, METState.Current.GAdaptive_Constant);
            }
            else
            {
                    CvInvoke.cvAdaptiveThreshold(grayimage, processed_image, (double)threshold, METState.Current.GAdaptive_type, THRESH.CV_THRESH_BINARY_INV, METState.Current.GAdaptive_blockSize, METState.Current.GAdaptive_Constant);
            }
            imagetemp.Ptr = processed_image;
            return imagetemp;
        }

        public Image<Gray, Byte> Filter_Sobel(Image<Gray, Byte> inputimg)
        {
            Image<Gray, float> sobelimg = inputimg.Sobel(1, 1, 1);//inputimg RGB ham mitavanad bashad
            Image<Gray, Byte> result = inputimg;
            result.ConvertFrom(sobelimg);
            return result;
        }

        public Image<Bgr, Byte> ColoredMask(Image<Gray, Byte> BlackWhiteImage, Image<Bgr, Byte> RGBImage, Bgr color)
        {
            Image<Bgr, Byte> temp = new Image<Bgr, Byte>(BlackWhiteImage.Bitmap);
            Image<Bgr, Byte> mask = new Image<Bgr, Byte>(temp.Width, temp.Height, color);
            temp = temp.And(mask);
            temp = temp.Add(RGBImage);
            return temp;
        }
        public Image<Bgr, Byte> ColoredMask(System.Drawing.Bitmap BlackWhiteImage, Image<Bgr, Byte> RGBImage, Bgr color, bool inverse)
        {

            Image<Bgr, Byte> temp = new Image<Bgr, Byte>(BlackWhiteImage);
            Image<Bgr, Byte> mask = new Image<Bgr, Byte>(temp.Width, temp.Height, color);
            if (temp.Width == RGBImage.Width )//sometimes are not the same size (I didn't find the reason) 
            {
                temp = temp.And(mask);

                try
                {
                    if (inverse)
                    {

                        temp = temp.Sub(RGBImage);
                        temp = temp.Or(RGBImage);
                    }
                    else
                    {

                        Image<Bgr, Byte> inver = new Image<Bgr, Byte>(BlackWhiteImage);

                        inver = inver.Xor(new Bgr(255, 255, 255));

                        inver = RGBImage.And(inver);

                        temp = temp.Sub(inver);
                        temp = temp.Or(inver);
                    }

                }
                catch (Exception e)
                {
                    System.Windows.Forms.MessageBox.Show(e.ToString());
                }
            }
            return temp;
        }


        public bool DrawIrisCircle(Image<Bgr, Byte> InputImage, int x, int y, int CircleDia)
        {
            if (x > 0 & x < InputImage.Width & y > 0 & y < InputImage.Height)
            {

                Graphics gr = Graphics.FromImage(InputImage.Bitmap);
                Rectangle rect = new Rectangle(0, 0, InputImage.Width, InputImage.Height);

                gr.DrawArc(Pens.Red, x - CircleDia / 2, y - CircleDia / 2, CircleDia, CircleDia, 0, 360);


                //test
                int temp = CircleDia;

                //min pupil size
                CircleDia = (int)(METState.Current.MinPupilScale * CircleDia);
                gr.DrawArc(Pens.Red, x - CircleDia / 2, y - CircleDia / 2, CircleDia, CircleDia, 0, 360);

                //max pupil size
                CircleDia = temp;
                CircleDia = (int)(METState.Current.MaxPupilScale * CircleDia);
                gr.DrawArc(Pens.Red, x - CircleDia / 2, y - CircleDia / 2, CircleDia, CircleDia, 0, 360);


                gr.Dispose();
                return true;
            }
            return false;
        }

        public bool DrawCircle(Image<Bgr, Byte> InputImage, int x, int y, Color color)
        {
            Graphics gr2 = Graphics.FromImage(InputImage.Bitmap);

            if (x > 0 & x < InputImage.Width & y > 0 & y < InputImage.Height)
            {
                
                // Create a new pen.
                Pen pen = new Pen(color);

                // Set the pen's width.
                pen.Width = 5.0F;

                // Set the LineJoin property.
                pen.LineJoin = System.Drawing.Drawing2D.LineJoin.MiterClipped;

                gr2.DrawArc(pen, x - 5, y - 5, 10, 10, 0, 360);
                gr2.Dispose();
                return true;
            }
            else
            {
                gr2.Dispose();
                return false;
            }
        }

        public bool DrawText(Image<Bgr, Byte> InputImage, int x, int y,String txt, Color color)
        {
            Graphics gr2 = Graphics.FromImage(InputImage.Bitmap);

               
            if (x > 0 & x < InputImage.Width & y > 0 & y < InputImage.Height)
            {
  
                var font = new Font("Arial", 50);
                var brush = new SolidBrush(color);

                gr2.DrawString(txt, font, brush, (float)x, (float)y);
                gr2.Dispose();
                return true;
            }
            else
            {
                gr2.Dispose();
                return false;
            }
        }
   
        public bool DrawLine(Image<Bgr, Byte> InputImage, AForge.Point p1, AForge.Point p2, Color color)
        {

            Graphics gr2 = Graphics.FromImage(InputImage.Bitmap);

            // Create a new pen.
            Pen pen = new Pen(color);

            // Set the pen's width.
            pen.Width = 1.0F;

            // Set the LineJoin property.
            pen.LineJoin = System.Drawing.Drawing2D.LineJoin.MiterClipped;


            gr2.DrawLine(pen, new Point((int)p1.X, (int)p1.Y), new Point((int)p2.X, (int)p2.Y));
            gr2.Dispose();
            return true;

        }
        public bool DrawCross(Image<Bgr, Byte> InputImage, int x, int y, Color color)
        {
            if (x > 0 & x < InputImage.Width & y > 0 & y < InputImage.Height)
            {				
                Graphics gr2 = Graphics.FromImage(InputImage.Bitmap);

                // Create a new pen.
                Pen pen = new Pen(color);

                // Set the pen's width.
                pen.Width = 2.0F;

                // Set the LineJoin property.
                pen.LineJoin = System.Drawing.Drawing2D.LineJoin.MiterClipped;


                gr2.DrawLine(pen, x, 0, x, InputImage.Height);
                gr2.DrawLine(pen, 0, y, InputImage.Width, y);

                gr2.Dispose();
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool DrawCross(Bitmap InputImage, int x, int y, Color color)
        {
            if (x > 0 & x < InputImage.Width & y > 0 & y < InputImage.Height)
            {
                Graphics gr2 = Graphics.FromImage(InputImage);

                // Create a new pen.
                Pen pen = new Pen(color);

                // Set the pen's width.
                pen.Width = 2.0F;

                // Set the LineJoin property.
                pen.LineJoin = System.Drawing.Drawing2D.LineJoin.MiterClipped;


                gr2.DrawLine(pen, x, 0, x, InputImage.Height);
                gr2.DrawLine(pen, 0, y, InputImage.Width, y);

                gr2.Dispose();
                return true;
            }
            else
            {
                return false;
            }
        }

        public void DrawRectangle(Image<Bgr, Byte> InputImage, Point[] corners, int expand, bool fill, string text)
        {
            Point[] ExpandedCorners = new Point[4];
            for (int i = 0; i < 4; i++)
            {
                ExpandedCorners[i].X = corners[i].X;
                ExpandedCorners[i].Y = corners[i].Y;

            }
            if (expand != 0)
            {
                ExpandedCorners[0].X = corners[0].X - expand;
                ExpandedCorners[1].X = corners[1].X + expand;
                ExpandedCorners[2].X = corners[2].X + expand;
                ExpandedCorners[3].X = corners[3].X - expand;
                ExpandedCorners[0].Y = corners[0].Y - expand;
                ExpandedCorners[1].Y = corners[1].Y - expand;
                ExpandedCorners[2].Y = corners[2].Y + expand;
                ExpandedCorners[3].Y = corners[3].Y + expand;
            }

            //if(corners.Count()==4)
            //{
            Graphics gr3 = Graphics.FromImage(InputImage.Bitmap);
            //gr3.DrawLine(Pens.Yellow, corners[3].X, corners[3].Y, corners[0].X,corners[0].Y);
            //gr3.DrawPolygon(Pens.Red, corners);

            Color c1 = Color.FromArgb(100, Color.Red);
            Color c2 = Color.FromArgb(255, Color.White);
            SolidBrush blueBrush = new SolidBrush(c1);
            Pen whiteBrush = new Pen(c2, 10);

            if (fill)
            {
                gr3.FillPolygon(blueBrush, ExpandedCorners);
            }
            else
            {
                gr3.DrawPolygon(whiteBrush, ExpandedCorners);
            }

            Point center = new Point();
            for (int i = 0; i < 4; i++)
            {
                center.X += ExpandedCorners[i].X;
                center.Y += ExpandedCorners[i].Y;
            }
            center.X /= 4;
            center.Y /= 4;

             Font defaultFont = new Font( FontFamily.GenericSerif, 15, FontStyle.Bold );
            Font fnt = new Font("Arial", 12);
            SizeF nameSize = gr3.MeasureString(text, defaultFont);

            gr3.DrawString(text, fnt, new SolidBrush(Color.Yellow), new Point(center.X - (int)nameSize.Width / 2, center.Y - (int)nameSize.Height / 2));
            gr3.Dispose();
            //gr3.DrawString("1 : (" + corners[0].X + "," + corners[0].Y + ")(" + METState.Current.monitor.ProjectedScreenCorners[0].X + "," + METState.Current.monitor.ProjectedScreenCorners[0].Y + ")", fnt, new SolidBrush(Color.Yellow), corners[0]);
            //gr3.DrawString("2 : (" + corners[1].X + "," + corners[1].Y + ")(" + METState.Current.monitor.ProjectedScreenCorners[1].X + "," + METState.Current.monitor.ProjectedScreenCorners[1].Y + ")", fnt, new SolidBrush(Color.Yellow), corners[1]);
            //gr3.DrawString("3 : (" + corners[2].X + "," + corners[2].Y + ")(" + METState.Current.monitor.ProjectedScreenCorners[2].X + "," + METState.Current.monitor.ProjectedScreenCorners[2].Y + ")", fnt, new SolidBrush(Color.Yellow), corners[2]);
            //gr3.DrawString("4 : (" + corners[3].X + "," + corners[3].Y + ")(" + METState.Current.monitor.ProjectedScreenCorners[3].X + "," + METState.Current.monitor.ProjectedScreenCorners[3].Y + ")", fnt, new SolidBrush(Color.Yellow), corners[3]);

            // }

        }
        public void DrawRectangle(Image<Bgr, Byte> InputImage, AForge.Point[] corners, int expand, bool fill, string text)
        {
            Point[] ExpandedCorners = new Point[4];
            for (int i = 0; i < 4; i++)
            {
                ExpandedCorners[i].X = (int)corners[i].X;
                ExpandedCorners[i].Y = (int)corners[i].Y;

            }
            if (expand != 0)
            {
                ExpandedCorners[0].X = (int)corners[0].X - expand;
                ExpandedCorners[1].X = (int)corners[1].X + expand;
                ExpandedCorners[2].X = (int)corners[2].X + expand;
                ExpandedCorners[3].X = (int)corners[3].X - expand;
                ExpandedCorners[0].Y = (int)corners[0].Y - expand;
                ExpandedCorners[1].Y = (int)corners[1].Y - expand;
                ExpandedCorners[2].Y = (int)corners[2].Y + expand;
                ExpandedCorners[3].Y = (int)corners[3].Y + expand;
            }

            //if(corners.Count()==4)
            //{
            Graphics gr3 = Graphics.FromImage(InputImage.Bitmap);
            //gr3.DrawLine(Pens.Yellow, corners[3].X, corners[3].Y, corners[0].X,corners[0].Y);
            //gr3.DrawPolygon(Pens.Red, corners);

            Color c1 = Color.FromArgb(100, Color.Red);
            Color c2 = Color.FromArgb(255, Color.White);
            SolidBrush blueBrush = new SolidBrush(c1);
            Pen whiteBrush = new Pen(c2, 2);

            if (fill)
            {
                gr3.FillPolygon(blueBrush, ExpandedCorners);
            }
            else
            {
                gr3.DrawPolygon(whiteBrush, ExpandedCorners);
            }

            Point center = new Point();
            for (int i = 0; i < 4; i++)
            {
                center.X += ExpandedCorners[i].X;
                center.Y += ExpandedCorners[i].Y;
            }
            center.X /= 4;
            center.Y /= 4;


            Font fnt = new Font("Arial", 12);
            gr3.DrawString(text, fnt, new SolidBrush(Color.Yellow), center);
            gr3.Dispose();
            //gr3.DrawString("1 : (" + corners[0].X + "," + corners[0].Y + ")(" + METState.Current.monitor.ProjectedScreenCorners[0].X + "," + METState.Current.monitor.ProjectedScreenCorners[0].Y + ")", fnt, new SolidBrush(Color.Yellow), corners[0]);
            //gr3.DrawString("2 : (" + corners[1].X + "," + corners[1].Y + ")(" + METState.Current.monitor.ProjectedScreenCorners[1].X + "," + METState.Current.monitor.ProjectedScreenCorners[1].Y + ")", fnt, new SolidBrush(Color.Yellow), corners[1]);
            //gr3.DrawString("3 : (" + corners[2].X + "," + corners[2].Y + ")(" + METState.Current.monitor.ProjectedScreenCorners[2].X + "," + METState.Current.monitor.ProjectedScreenCorners[2].Y + ")", fnt, new SolidBrush(Color.Yellow), corners[2]);
            //gr3.DrawString("4 : (" + corners[3].X + "," + corners[3].Y + ")(" + METState.Current.monitor.ProjectedScreenCorners[3].X + "," + METState.Current.monitor.ProjectedScreenCorners[3].Y + ")", fnt, new SolidBrush(Color.Yellow), corners[3]);
            // }

        }
        public void DrawRectangle(Image<Bgr, Byte> InputImage, AForge.Point center, SizeF size)
        {

            Graphics gr3 = Graphics.FromImage(InputImage.Bitmap);

            Color c1 = Color.FromArgb(100, Color.Red);
            SolidBrush blueBrush = new SolidBrush(c1);
            Pen Brush = new Pen(c1, 2);


            gr3.DrawRectangle(Brush, center.X - size.Width / 2, center.Y - size.Height / 2, size.Width, size.Height);



            gr3.Dispose();

        }

        public bool DrawMimMaxCircles(Image<Bgr, Byte> InputImage, int x, int y, int MinCircleDia, int MaxCircleDia)
        {
            if (x > 0 & x < InputImage.Width & y > 0 & y < InputImage.Height)
            {
                //Draw Min & Max
                Graphics gr = Graphics.FromImage(InputImage.Bitmap);
                Rectangle rect = new Rectangle(0, 0, InputImage.Width, InputImage.Height);
                //max
                gr.DrawArc(Pens.Red, x - MaxCircleDia / 2, y - MaxCircleDia / 2, MaxCircleDia, MaxCircleDia, 0, 360);
                //Min
                gr.DrawArc(Pens.Blue, x - MinCircleDia / 2, y - MinCircleDia / 2, MinCircleDia, MinCircleDia, 0, 360);

                // toolStripLabel_BlobCenter.Text = "Blob Center: (" + BigBlobX + "," + BigBlobY + ") ";
                // toolStripLabel_BlobFullness.Text = "Blob Fullness: " + Math.Round(Fulln, 1);
                // gr.DrawEllipse(new Pen(Color.Yellow, 3), new Rectangle(200, 100, 200, 200));								

                gr.Dispose();
                return true;
            }
            return false;
        }

        /// <summary>
        /// 
        /// Fit an ellipse to the points collection
        /// </summary>
        /// <param name="points">The points to be fitted</param>
        /// <returns>An ellipse</returns>
        public Ellipse EllipseLeastSquareFitting(AForge.Point[] points)
        {
            IntPtr seq = Marshal.AllocHGlobal(StructSize.MCvSeq);
            IntPtr block = Marshal.AllocHGlobal(StructSize.MCvSeqBlock);
            GCHandle handle = GCHandle.Alloc(points, GCHandleType.Pinned);
            CvInvoke.cvMakeSeqHeaderForArray(
               CvInvoke.CV_MAKETYPE((int)Emgu.CV.CvEnum.MAT_DEPTH.CV_32F, 2),
               StructSize.MCvSeq,
               StructSize.PointF,
               handle.AddrOfPinnedObject(),
               points.Length,
               seq,
               block);
            Ellipse e = new Ellipse(CvInvoke.cvFitEllipse2(seq));
            handle.Free();
            Marshal.FreeHGlobal(seq);
            Marshal.FreeHGlobal(block);

            //this version of Emgu Ellipse fitting has a bug and should be modified as below
            //and even after this modification, Box is smaller in a wrong angle
            Ellipse ModifiedEllipse = new Emgu.CV.Structure.Ellipse(e.MCvBox2D.center, new SizeF(e.MCvBox2D.size.Width, e.MCvBox2D.size.Height), e.MCvBox2D.angle - 90);

            return ModifiedEllipse;
        }
        public void DrawEllipse(Image<Bgr, Byte> InputImage, Ellipse ellipse, Bgr color)
        {

            InputImage.Draw(ellipse, color, 2);
        }
        public void DrawEllipse(Image<Gray, Byte> InputImage, Ellipse ellipse, Gray color)
        {

            InputImage.Draw(ellipse, color, 2);
        }
        public double FindMedian(int[] numbers)
        {

            //middle value has the middle value incase of an even number of elemenets,

            //the value returned by ceiling function

            //or Floor value incase of an odd array.

            double median = 0;

            int middleValue = 0;

            decimal half = 0;



            Array.Sort(numbers);

            half = (numbers.Length - 1) / 2;

            if (numbers.Length % 2 == 1)
            {

                median = numbers[Convert.ToInt32(Math.Ceiling(half))];
            }

            else
            {
                middleValue = Convert.ToInt32(Math.Floor(half));

                median = (double)(numbers[middleValue] + numbers[middleValue + 1]) / 2;
            }

            return median;

        }
        public float FindMedian(float[] numbers)
        {

            //middle value has the middle value incase of an even number of elemenets,

            //the value returned by ceiling function

            //or Floor value incase of an odd array.




            float median = 0;

            int middleValue = 0;

            decimal half = 0;



            Array.Sort(numbers);

            half = (numbers.Length - 1) / 2;

            if (numbers.Length % 2 == 1)
            {

                median = numbers[Convert.ToInt32(Math.Ceiling(half))];
            }

            else
            {
                middleValue = Convert.ToInt32(Math.Floor(half));

                median = (float)(numbers[middleValue] + numbers[middleValue + 1]) / 2;
            }

            return median;

        }
    }
}
