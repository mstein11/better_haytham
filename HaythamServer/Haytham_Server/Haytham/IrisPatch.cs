
//<copyright file="IrisPatch.cs" company="ITU">
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
using System.Drawing;
using Emgu.CV.Structure;
using Emgu.CV;

namespace Haytham
{
    public class IrisPatch
    {
        private Image<Bgr, Byte> PPreviousInputimg;
        private Image<Bgr, Byte> PreviousInputimg;
        private Image<Bgr, Byte> _ForShow;
        private bool _show;

        private Image<Gray, float> velx;//= new Image<Gray, float>();
        private Image<Gray, float> vely;// = new Image<Gray, float>();

        public Point PPROI_center;


        public Point _ROI_center;
        private Size _ROI_size;
        private Size _winSize;

        public bool patchAccepted;
        public int vectorFieldX;
        public int vectorFieldY;
        public PointF[][] vectorField;// ;

        public int[][] DirectionField;// ;
        public int[] Histogram = new int[9];// ;
        public PointF AverageVelocityVector = new PointF();
        public float AverageVelocityAmount = new float();
        public int Direction = new int();//Only for drawing
        public double meanColor = new int();
        //...............................

        public float  median = 0;

        public byte[] Status;
        public float[] TrackError;


        public void process5(Image<Bgr, Byte> Inputimg, Point ROI_center, Size ROI_size, Size winSize, Image<Bgr, Byte> ForShow, bool show, string HV)
        {


            SetImgROI(Inputimg, ROI_center, ROI_size);


            velx = new Image<Gray, float>(Inputimg.Width, Inputimg.Height);
            vely = new Image<Gray, float>(Inputimg.Width, Inputimg.Height);

            Image<Gray, byte> CurrentImage = new Image<Gray, byte>(Inputimg.Bitmap);
            meanColor = CurrentImage.GetAverage().Intensity;// Can be used on RGB images???

            if (PreviousInputimg != null)
            {

                SetImgROI(PreviousInputimg, _ROI_center, ROI_size);//TODO:  Actually we should use ppROISize for ROI in the ppimage and then should be scaled to the new size



                Image<Gray, byte> PreviousImage = new Image<Gray, byte>(PreviousInputimg.Bitmap);


                vectorFieldX = (int)Math.Round((double)CurrentImage.Width / winSize.Width);
                vectorFieldY = (int)Math.Round((double)CurrentImage.Height / winSize.Height);

                // Emgu.CV.OpticalFlow.LK(PreviousImage, CurrentImage, winSize, velx, vely);

                PointF[] ActualFeature;
                PointF[] secondPos = new PointF[vectorFieldX];

                ActualFeature = new PointF[vectorFieldX * vectorFieldY];
                List<PointF> psList = new List<PointF>();
                for (int i = 0; i < vectorFieldX; i++)
                {

                    for (int j = 0; j < vectorFieldY; j++)
                    {

                        psList.Add(new PointF(i * winSize.Width, j * winSize.Height));

                    }

                }
                ActualFeature = psList.ToArray();
                secondPos = ActualFeature;


                PreviousImage._EqualizeHist();
                CurrentImage._EqualizeHist();



                if (PreviousImage.Width == CurrentImage.Width & PreviousImage.Height == CurrentImage.Height)
                    Emgu.CV.OpticalFlow.PyrLK(PreviousImage, CurrentImage, ActualFeature, new Size(19,19), 1, new MCvTermCriteria(2), out secondPos, out Status, out TrackError);


                vectorField = new PointF[vectorFieldX][];
                DirectionField = new int[vectorFieldX][];

                AverageVelocityVector.X = 0;
                AverageVelocityVector.Y = 0;
                //float[] med = new float[vectorFieldX * vectorFieldY];



                        float factor =3f;
                Histogram = new int[9];
                //ImageProcessing_Emgu EmgImgProcssing = new ImageProcessing_Emgu();

                //calculate the median of vectors
                //for (int i = 0; i < ActualFeature.Count(); i++)
                //{
                //    if (Status[i] == 1)
                //    {
                //        float velx_float = (secondPos[i].X - ActualFeature[i].X) * factor;
                //        float vely_float = (secondPos[i].Y - ActualFeature[i].Y) * factor;
                //        med[i] = (float)(Math.Sqrt((velx_float * velx_float) + (vely_float * vely_float)));
                //    }
                
                //}

                //median = EmgImgProcssing.FindMedian(med);
                //med = new float[vectorFieldX * vectorFieldY];



                int coni = 0;
                for (int i = 0; i < vectorFieldX; i++)
                {
                    vectorField[i] = new PointF[vectorFieldY];
                    DirectionField[i] = new int[vectorFieldY];

                    for (int j = 0; j < vectorFieldY; j++)
                    {

                        float velx_float = (secondPos[coni].X - ActualFeature[coni].X) * factor;
                        float vely_float = (secondPos[coni].Y - ActualFeature[coni].Y) * factor;
                       // float temp=(float)(Math.Sqrt((velx_float * velx_float) + (vely_float * vely_float)));


                       // if (Status!=null && Status[coni] == 1)//&& temp < (15 * median)
                        {

                            //med[coni] = temp;
                            AverageVelocityVector.X += velx_float;
                            AverageVelocityVector.Y += vely_float;
                            #region Draw
                            if (ForShow != null & show)
                            {
                                SetImgROI(ForShow, ROI_center, ROI_size);


                                LineSegment2D ci = new LineSegment2D(new Point(i * winSize.Width, j * winSize.Height), new Point((int)((i * winSize.Width) + velx_float), (int)((j * winSize.Height) + vely_float)));
                                ForShow.Draw(ci, new Bgr(Color.Yellow), 1);
                                LineSegment2D ci0 = new LineSegment2D(new Point(i * winSize.Width, j * winSize.Height), new Point((int)((i * winSize.Width)), (int)((j * winSize.Height))));
                                ForShow.Draw(ci0, new Bgr(Color.Red), 1);

                                //Cross2DF cr = new Cross2DF(new PointF(i * winSize.Width, j * winSize.Height), 1, 1);
                                //ForShow.Draw(cr, new Bgr(Color.Red), 1);

                                CvInvoke.cvResetImageROI(ForShow);
                            }
                            #endregion Draw


                            DirectionField[i][j] = GetDirection(velx_float, -vely_float);
                            vectorField[i][j] = new PointF(velx_float, -vely_float);
                            Histogram[DirectionField[i][j]]++; 
                            coni++;
                        }
                      
                    }
                }



              //  median = EmgImgProcssing.FindMedian(med);//final median

                AverageVelocityVector.X /= coni;
                AverageVelocityVector.Y /= coni;

                if (HV == "H") AverageVelocityVector.Y = 0;
                if (HV == "V") AverageVelocityVector.X = 0;


                AverageVelocityAmount = (float)(Math.Sqrt((AverageVelocityVector.X * AverageVelocityVector.X) + (AverageVelocityVector.Y * AverageVelocityVector.Y)));




                CvInvoke.cvResetImageROI(PreviousInputimg);
                CvInvoke.cvResetImageROI(Inputimg);
            }






            if (PreviousInputimg!=null )
            {
                PPreviousInputimg = new Image<Bgr, Byte>(PreviousInputimg.Width, PreviousInputimg.Height);
                CvInvoke.cvCopy(PreviousInputimg.Ptr, PPreviousInputimg.Ptr, new IntPtr());

                PPROI_center = _ROI_center;


            }

            PreviousInputimg = new Image<Bgr, Byte>(Inputimg.Width, Inputimg.Height);
            CvInvoke.cvCopy(Inputimg.Ptr, PreviousInputimg.Ptr, new IntPtr());



            _ROI_center = ROI_center;
            _ROI_size = ROI_size;
            _winSize = winSize;
            _ForShow = ForShow;
            _show = show;
        }


        private void SetImgROI(Image<Bgr, Byte> Inputimg, Point ROI_center, Size ROI_size)
        {
            try
            {
                Point ROI_Corner = new Point(ROI_center.X - ROI_size.Width / 2, ROI_center.Y - ROI_size.Height / 2);
                Rectangle ROI_Rect = new Rectangle(ROI_Corner, ROI_size);
                CvInvoke.cvSetImageROI(Inputimg, ROI_Rect);
            }
            catch (Exception ee)
            { }
        }
        public int GetDirection(float Vx, float Vy)
        {
            int num = 0;



            if (Vx == 0 & Vy == 0)
            { }
            else
            {
                double angle = Math.Round(GetAngleOnDegree(Vx, Vy), 2);

                if ((angle >= 0 & angle < 22.5) | (angle > 337.5 & angle <= 360))
                {
                    num = 3;
                }

                if ((angle >= 22.5 & angle <= 67.5))
                {
                    num = 2;
                }

                if ((angle > 67.5 & angle < 112.5))
                {
                    num = 1;
                }

                if ((angle >= 112.5 & angle <= 157.5))
                {
                    num = 8;
                }
                if ((angle > 157.5 & angle < 202.5))
                {
                    num = 7;
                }
                if ((angle >= 202.5 & angle <= 247.5))
                {
                    num = 6;
                }
                if ((angle > 247.5 & angle < 292.5))
                {
                    num = 5;
                }
                if ((angle >= 292.5 & angle <= 337.5))
                {
                    num = 4;
                }
            }
            return num;
        }
        public double GetAngleOnDegree(float Vx, float Vy)
        {

            double angle = 0;

            if (Vx == 0 & Vy > 0)
            {
                angle = 90;
            }
            if (Vx > 0 & Vy == 0)
            {
                angle = 0;
            }
            if (Vx == 0 & Vy < 0)
            {
                angle = 270;
            }
            if (Vx < 0 & Vy == 0)
            {
                angle = 180;
            }

            if (Vx > 0 & Vy > 0)
            {
                angle = Math.Atan(Math.Abs(Vy) / Math.Abs(Vx)) * (180 / Math.PI);
            }
            if (Vx < 0 & Vy > 0)
            {
                angle = 180 - Math.Atan(Math.Abs(Vy) / Math.Abs(Vx)) * (180 / Math.PI);
            }
            if (Vx < 0 & Vy < 0)
            {
                angle = Math.Atan(Math.Abs(Vy) / Math.Abs(Vx)) * (180 / Math.PI) + 180;
            }
            if (Vx > 0 & Vy < 0)
            {
                angle = 360 - Math.Atan(Math.Abs(Vy) / Math.Abs(Vx)) * (180 / Math.PI);
            }

            return angle;
        }
        public void Draw(string a)
        {
            if (_show && _ForShow != null)
            {
                LineSegment2D ci = new LineSegment2D();
                Cross2DF cr = new Cross2DF();

                switch (a)
                {
                    case "Average":


                        int ii = vectorFieldX / 2;
                        int jj = vectorFieldY / 2;


                        SetImgROI(_ForShow, _ROI_center, _ROI_size);
                        cr = new Cross2DF(new PointF(ii * _winSize.Width, jj * _winSize.Height), 2, 2);
                        _ForShow.Draw(cr, new Bgr(Color.Red), 5);

                        float vecval = 20;
                        if (Direction == 1) { ci = new LineSegment2D(new Point(ii * _winSize.Width, jj * _winSize.Height), new Point((int)((ii * _winSize.Width) + 0), (int)((jj * _winSize.Height) - vecval))); }
                        if (Direction == 2) { ci = new LineSegment2D(new Point(ii * _winSize.Width, jj * _winSize.Height), new Point((int)((ii * _winSize.Width) + vecval), (int)((jj * _winSize.Height) - vecval))); }
                        if (Direction == 3) { ci = new LineSegment2D(new Point(ii * _winSize.Width, jj * _winSize.Height), new Point((int)((ii * _winSize.Width) + vecval), (int)((jj * _winSize.Height) + 0))); }
                        if (Direction == 4) { ci = new LineSegment2D(new Point(ii * _winSize.Width, jj * _winSize.Height), new Point((int)((ii * _winSize.Width) + vecval), (int)((jj * _winSize.Height) + vecval))); }
                        if (Direction == 5) { ci = new LineSegment2D(new Point(ii * _winSize.Width, jj * _winSize.Height), new Point((int)((ii * _winSize.Width) + 0), (int)((jj * _winSize.Height) + vecval))); }
                        if (Direction == 6) { ci = new LineSegment2D(new Point(ii * _winSize.Width, jj * _winSize.Height), new Point((int)((ii * _winSize.Width) - vecval), (int)((jj * _winSize.Height) + vecval))); }
                        if (Direction == 7) { ci = new LineSegment2D(new Point(ii * _winSize.Width, jj * _winSize.Height), new Point((int)((ii * _winSize.Width) - vecval), (int)((jj * _winSize.Height) + 0))); }
                        if (Direction == 8) { ci = new LineSegment2D(new Point(ii * _winSize.Width, jj * _winSize.Height), new Point((int)((ii * _winSize.Width) - vecval), (int)((jj * _winSize.Height) - vecval))); }

                        _ForShow.Draw(ci, new Bgr(Color.Blue), 2);
                        CvInvoke.cvResetImageROI(_ForShow);


                        break;
                    case "Rejected":


                        int iii = vectorFieldX / 2;
                        int jjj = vectorFieldY / 2;


                        SetImgROI(_ForShow, _ROI_center, _ROI_size);
                        cr = new Cross2DF(new PointF(iii * _winSize.Width, jjj * _winSize.Height), 1, 1);
                        _ForShow.Draw(cr, new Bgr(Color.Red), 20);
                        CvInvoke.cvResetImageROI(_ForShow);

                        break;
                }
            }
        }

    }
}
