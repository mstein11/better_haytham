
//<copyright file="RectangleDetection.cs" company="ITU">
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
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;//point
using Emgu.CV.Structure;
using Emgu.CV;

namespace Haytham
{
    public class RectangleDetection
    {
        public struct RectangleGazeData
        {
            public string tag { get; set; }
            public AForge.Point rectangleGaze { get; set; }
            // 
        }
        public ImageProcessing_Emgu EmgImgProcssing = new ImageProcessing_Emgu();


        public RectangleGazeData[] rectangleGazeData = new RectangleGazeData[500];

        public Point[] RectangleCorners = new Point[4];

        public double RectangleArea = 0;
        public int Real_Rectangle_W;
        public int Real_Rectangle_H;

        /// <summary>
        /// Adjust this default values 
        /// </summary>
        public int rectangleMinSize = 20;
        public int BThreshold = 70;
        public int GThreshold = 290;



        public Matrix<double> Homography = new Matrix<double>(3, 3);

        public Blob_Aforge RectangleBlob = null;



        public bool DetectRectangle(Image<Bgr, Byte> inputimg)
        {
            bool rectangleIsFound = false;

            #region Canny

            Image<Bgr, Byte> img = new Image<Bgr, byte>(inputimg.Bitmap);//??????????????????????????????????????????????????????????????mishe ba khatte oain edgham kard?



            //Convert the image to grayscale and filter out the noise
            Image<Gray, Byte> gray = img.Convert<Gray, Byte>();
            Gray cannyThreshold = new Gray(BThreshold);//Gray(180);
            Gray cannyThresholdLinking = new Gray(GThreshold);//Gray(120);

            METState.Current.ProcessTimeSceneBranch.Timer("cannyEdges", "Start");

            Image<Gray, Byte> cannyEdges = gray.PyrDown().Canny(cannyThreshold.Intensity, cannyThresholdLinking.Intensity).PyrUp().Dilate(1);//.Erode(1);//
            METState.Current.ProcessTimeSceneBranch.Timer("cannyEdges", "Stop");

            #endregion Canny




            #region Contour
            List<MCvBox2D> boxList = new List<MCvBox2D>(); //a box is a rotated rectangle
            double MinArea = ((double)rectangleMinSize / 100.0) * METState.Current.SceneImageOrginal.Width
                * ((double)rectangleMinSize / 100.0) * METState.Current.SceneImageOrginal.Height;



            METState.Current.ProcessTimeSceneBranch.Timer("Contours", "Start");

            using (MemStorage storage = new MemStorage()) //allocate storage for contour approximation


                for (Contour<Point> contours = cannyEdges.FindContours(
                      Emgu.CV.CvEnum.CHAIN_APPROX_METHOD.CV_CHAIN_APPROX_SIMPLE,
                      Emgu.CV.CvEnum.RETR_TYPE.CV_RETR_LIST,
                      storage);
                   contours != null;
                   contours = contours.HNext)
                {

                    Contour<Point> currentContour = contours.ApproxPoly(contours.Perimeter * 0.08, storage);//0.08 has been tested and works well with ...d, cannyThresholdLinking).PyrUp().Dilate(1)

                    if (currentContour.Total == 4 && currentContour.Area > MinArea) //selecting the bigest contour
                    {

                        rectangleIsFound = true;

                        MinArea = currentContour.Area;

                        RectangleArea = currentContour.Area;


                        #region determine if all the angles in the contour are within [80, 100] degree
                        // bool isRectangle = true;
                        //Point[] pts = currentContour.ToArray();
                        //LineSegment2D[] edges = PointCollection.PolyLine(pts, true);

                        //for (int i = 0; i < edges.Length; i++)
                        //{
                        //    double angle = Math.Abs(
                        //       edges[(i + 1) % edges.Length].GetExteriorAngleDegree(edges[i]));
                        //    if (angle < 80 || angle > 100)
                        //    {
                        //        isRectangle = false;
                        //        break;
                        //    }
                        //}
                        #endregion

                        for (int i = 0; i < 4; i++)
                        {
                            RectangleCorners[i].X = currentContour[i].X;
                            RectangleCorners[i].Y = currentContour[i].Y;

                        }
                    }


                }
            SortRectangleCorners();

            METState.Current.ProcessTimeSceneBranch.Timer("Contours", "Stop");

            #endregion Contour




            #region draw rectangles
            //Image<Bgr, Byte> RectangleImage = img.CopyBlank();

            //foreach (MCvBox2D box in boxList)
            //{
            //    RectangleImage.Draw(box, new Bgr(Color.DarkOrange), 2);


            //}
            //METState.Current.SceneImageForShow = METState.Current.SceneImageForShow.Add(RectangleImage);

            #endregion draw rectangles

            #region draw screen
            if (METState.Current.showEdges)
            {
                //  METState.Current.SceneImageProcessed = new Image<Bgr, byte>(cannyEdges.Bitmap);
                //  EmgImgProcssing.DrawRectangle(METState.Current.SceneImageProcessed, ScreenCorners, 0, true, "Area = " + RectangleArea);
                METState.Current.SceneImageForShow = METState.Current.SceneImageForShow.Or(new Image<Bgr, byte>(cannyEdges.Bitmap));
            }

            if (METState.Current.showScreen)
            {
                //show min size rect
                if (METState.Current.showScreenSize)
                {
                    AForge.Point RECTcenter = new AForge.Point(METState.Current.SceneImageForShow.Width / 2, METState.Current.SceneImageForShow.Height / 2);
                    SizeF RECTsize = new SizeF(((float)(rectangleMinSize) / 100.0f) * METState.Current.SceneImageForShow.Width, ((float)(rectangleMinSize) / 100.0f) * METState.Current.SceneImageForShow.Height);
                    EmgImgProcssing.DrawRectangle(METState.Current.SceneImageForShow, RECTcenter, RECTsize);
                }

                //Show found screen

            }

            #endregion draw Screen
            return rectangleIsFound;


        }


        public void rectangleGazeData_Shift()
        {

            for (int i = rectangleGazeData.Length - 1; i > 0; i--) { rectangleGazeData[i] = rectangleGazeData[i - 1]; }


        }

        public AForge.Point CalculateRectangleGazeMedian(int frames, int startFrom)
        {
            AForge.Point M = new AForge.Point();
            float[] Cx = new float[frames];
            float[] Cy = new float[frames];


            for (int i = 0; i < frames; i++)
            {
                Cx[i] = rectangleGazeData[startFrom + i].rectangleGaze.X;
                Cy[i] = rectangleGazeData[startFrom + i].rectangleGaze.Y;

            }

            M.X = (float)FindMedian(Cx);
            M.Y = (float)FindMedian(Cy);
            return M;
        }

        public static float FindMedian(float[] numbers)
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


        public void SortRectangleCorners()
        {
            // METState.Current.ProcessTimeSceneBranch.Timer("SortMonitorCorners", "Start");

            int Mean_X = 0;
            int Mean_Y = 0;
            Point[] SortedRectangleCorners = new Point[4];

            for (int i = 0; i < 4; i++)
            {
                Mean_X += RectangleCorners[i].X;
                Mean_Y += RectangleCorners[i].Y;

            }
            Mean_X /= 4;
            Mean_Y /= 4;

            //1    2
            //4    3
            for (int i = 0; i < 4; i++)
            {
                if (RectangleCorners[i].X < Mean_X & RectangleCorners[i].Y < Mean_Y) SortedRectangleCorners[0] = RectangleCorners[i];
                if (RectangleCorners[i].X > Mean_X & RectangleCorners[i].Y < Mean_Y) SortedRectangleCorners[1] = RectangleCorners[i];
                if (RectangleCorners[i].X > Mean_X & RectangleCorners[i].Y > Mean_Y) SortedRectangleCorners[2] = RectangleCorners[i];
                if (RectangleCorners[i].X < Mean_X & RectangleCorners[i].Y > Mean_Y) SortedRectangleCorners[3] = RectangleCorners[i];

            }

            RectangleCorners = SortedRectangleCorners;
            // METState.Current.ProcessTimeSceneBranch.Timer("SortMonitorCorners", "Stop");


        }

        public AForge.Point CalculateRectangleGazePoint(AForge.Point gaze, Calibration calibration)
        {

            // METState.Current.ProcessTimeSceneBranch.Timer("CalculateMonitorGazePoint", "Start");
            calibration.CalibrationType = Calibration.calibration_type.calib_Homography;

            // Matrix<double> src = new Matrix<double>(3, 4);
            //Matrix<double> dst = new Matrix<double>(3, 4);
            //if (ScreenCorners.Count() == 4)
            //{
            for (int i = 0; i < 4; i++)
            {

                calibration.Source[0, i] = RectangleCorners[i].X;
                calibration.Source[1, i] = RectangleCorners[i].Y;
                //METState.Current.SceneToMonitor_Mapping.Source[2, i] = 1;

            }

            //     1       2
            //     4       3

            calibration.Destination[0, 0] = 0;
            calibration.Destination[1, 0] = 0;
            // dst[2, 0] = 1;

            calibration.Destination[0, 1] = Real_Rectangle_W;
            calibration.Destination[1, 1] = 0;
            // dst[2, 1] = 1;

            calibration.Destination[0, 2] = Real_Rectangle_W;
            calibration.Destination[1, 2] = Real_Rectangle_H;
            //dst[2, 2] = 1;

            calibration.Destination[0, 3] = 0;
            calibration.Destination[1, 3] = Real_Rectangle_H;
            //dst[2, 3] = 1;

            calibration.Calibrate();


            #region test
            // test corners projection
            //for (int i = 0; i < 4; i++)
            //{
            //    src2[0, 0] =  ScreenCorners[i].X;
            //    src2[1, 0] =  ScreenCorners[i].Y;
            //    src2[2, 0] = 1;
            //    dst2 =  Homography * src2;
            //     ProjectedScreenCorners[i].X = (int)Convert.ChangeType(dst2[0, 0] / dst2[2, 0], typeof(int));
            //     ProjectedScreenCorners[i].Y = (int)Convert.ChangeType(dst2[1, 0] / dst2[2, 0], typeof(int));
            //}
            #endregion
            AForge.Point MonitorGaze;
            MonitorGaze = (calibration.Map(gaze.X, gaze.Y, 0, 0));//AForge.Point

            rectangleGazeData_Shift();

            rectangleGazeData[0].rectangleGaze = MonitorGaze;
            rectangleGazeData[0].tag = "";
            //SMOOTHing the gaze on screen. it is needed because the screen corners sometimes jump
            MonitorGaze = METState.Current.monitor.CalculateRectangleGazeMedian(5, 0);

            return MonitorGaze;
        }

        public AForge.Point GetGazeBeforeGesture(out int index, out bool found)
        {
            bool firstStop = true;
            AForge.Point g = new AForge.Point(0, 0);
            index = 0;
            found = false;
            for (int i = 0; i < rectangleGazeData.Count(); i++)
            {
                if (firstStop)
                {
                    if (rectangleGazeData[i].tag != HeadGesture.GestureBasicCharacters.NoMovement.ToString()) firstStop = false;
                }
                else
                {
                    if (rectangleGazeData[i].tag == HeadGesture.GestureBasicCharacters.NoMovement.ToString())
                    {
                        g = rectangleGazeData[i].rectangleGaze;
                        index = i;
                        found = true;
                        break;
                    }
                }
            }

            return g;


        }

        public bool IsGazeInsideRectangle()
        {

            SortRectangleCorners();

            // TODO: it is not a good way. make it more accurate
            bool itis = false;

            if ((RectangleCorners[0].X + RectangleCorners[3].X) / 2 < METState.Current.Gaze_HMGT.X &
                (RectangleCorners[1].X + RectangleCorners[2].X) / 2 > METState.Current.Gaze_HMGT.X &
                (RectangleCorners[2].Y + RectangleCorners[3].Y) / 2 > METState.Current.Gaze_HMGT.Y &
                (RectangleCorners[0].Y + RectangleCorners[1].Y) / 2 < METState.Current.Gaze_HMGT.Y)
                itis = true;

            return itis;

        }
    }
}
