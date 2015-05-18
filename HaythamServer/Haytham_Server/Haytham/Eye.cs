
//<copyright file="Eye.cs" company="ITU">
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
//using AForge;
using AForge.Imaging;
using AForge.Math.Geometry;
namespace Haytham
{
    public class Eye
    {

        public struct EyeData
        {

            //
            // Summary:
            //     Gets or sets the captured time of this point.
            //
            // Returns:
            //     captured time of this point.
            public DateTime time { get; set; }
            public string tag { get; set; }

            //PUPIL
            public bool pupilFound { get; set; }
            public AForge.Point pupilCenter { get; set; }
            public Ellipse pupilEllipse { get; set; }

            public int pupilDiameter { get; set; }

            //GLINT
            public AForge.Point glintCenter { get; set; }

        }


        public EyeData[] eyeData = new EyeData[500];

        //Pupil

        private AForge.Point pupilBlobCenter;
        public Blob_Aforge PupilBlob = null;
        public Rectangle pupilROI;


        // Glint

        public int glintPyrLevel;
        public Rectangle glintROI;
        public Blob_Aforge glintBlob = null;

        //
        private ImageProcessing_Emgu EmgImgProcssing = new ImageProcessing_Emgu();

        public bool LargScan = true;


        //Gestures and Blink
        public bool Blink = false;
        public bool DoubleBlink = false;
        private bool CloseEye;
        private bool WaitForDoubleBlink;
        private int blinkcounter;
        private int doubleblinkWaitingTime_Counter;

        public HeadGesture headGesture = new HeadGesture();

        /// <summary>
        /// 123
        /// 4 5
        /// 678
        /// </summary>
        public IrisPatch[] irisPatches = new IrisPatch[9];

        //....................................................................................................

        public AForge.Point GetGlintCenterMedian(int frames)
        {
            AForge.Point M = new AForge.Point();
            float[] Cx = new float[frames];
            float[] Cy = new float[frames];


            for (int i = 0; i < frames; i++)
            {
                Cx[i] = eyeData[i].glintCenter.X;
                Cy[i] = eyeData[i].glintCenter.Y;

            }

            M.X = (float)EmgImgProcssing.FindMedian(Cx);
            M.Y = (float)EmgImgProcssing.FindMedian(Cy);
            return M;
        }
        public AForge.Point GetPupilCenterMedian(int frames)
        {
            AForge.Point M = new AForge.Point();
            float[] Cx = new float[frames];
            float[] Cy = new float[frames];


            for (int i = 0; i < frames; i++)
            {
                Cx[i] = eyeData[i].pupilCenter.X;
                Cy[i] = eyeData[i].pupilCenter.Y;

            }

            M.X = (float)EmgImgProcssing.FindMedian(Cx);
            M.Y = (float)EmgImgProcssing.FindMedian(Cy);
            return M;
        }
        public AForge.Point GetPupilGlintVectorMedian(int frames)
        {
            AForge.Point M = new AForge.Point();
            float[] Cx = new float[frames];
            float[] Cy = new float[frames];


            for (int i = 0; i < frames; i++)
            {
                Cx[i] = eyeData[i].glintCenter.X - eyeData[i].pupilCenter.X;
                Cy[i] = eyeData[i].glintCenter.Y - eyeData[i].pupilCenter.Y;

            }

            M.X = (float)EmgImgProcssing.FindMedian(Cx);
            M.Y = (float)EmgImgProcssing.FindMedian(Cy);
            return M;
        }
        public SizeF GetPupilEllipseSizeMedian(int frames)
        {
            SizeF M = new SizeF();
            float[] Cx = new float[frames];
            float[] Cy = new float[frames];


            for (int i = 0; i < frames; i++)
            {
                Cx[i] = (float)eyeData[i].pupilEllipse.MCvBox2D.size.Width;
                Cy[i] = (float)eyeData[i].pupilEllipse.MCvBox2D.size.Height;

            }

            M.Width = (float)EmgImgProcssing.FindMedian(Cx);
            M.Height = (float)EmgImgProcssing.FindMedian(Cy);
            return M;
        }


        public void FindGlint(Image<Bgr, Byte> inputimg, int threshold)
        {

            glintPyrLevel = 0;
            Image<Gray, Byte> GrayImg = new Image<Gray, byte>(inputimg.Bitmap );


            //rough determination of ROI (size of ROI may exceeds the size of the image no problem for cvSetImageROI)
            int d = (int)(METState.Current.IrisDiameter);
            if (METState.Current.detectPupil & eyeData[1].pupilFound)
            {
                glintROI = new Rectangle(
                    Math.Max( Convert.ToInt32 (eyeData[1].pupilCenter.X) - d / 2,0),
                      Math.Max(Convert.ToInt32(eyeData[1].pupilCenter.Y) - d / 2, 0),
                      Math.Min(d, GrayImg.Width ),
                      Math.Min(d, GrayImg.Height)

                    );
            }
            else
            {
                d = 1 * d;//a little bit larger
                glintROI = new Rectangle(inputimg.Width / 2 - d / 2, inputimg.Height / 2 - d / 2, d, d);
            }


            //Modify ROI, it's needed when ROI is not inside the image area
            


            CvInvoke.cvSetImageROI(GrayImg, glintROI);


            //ROI will be used later for drawing
            glintROI = new Rectangle(glintROI.X, glintROI.Y, GrayImg.Width, GrayImg.Height);



            

            for (int i = 0; i < glintPyrLevel; i++) GrayImg = GrayImg.PyrDown();





            if (METState.Current.GAdaptive) GrayImg = EmgImgProcssing.Filter_GlintAdaptiveThreshold(GrayImg, 255, false).Erode(1).Dilate(1);
            else GrayImg = EmgImgProcssing.Filter_Threshold(GrayImg, threshold, false);//.Erode(2).Dilate(2);//;

           // METState.Current.EyeImageTest = GrayImg;

           // GrayImg = GrayImg.Erode(1).Dilate(1);

           // GrayImg = GrayImg.Dilate(1).Erode(1);


            AForge.Point tempGlintCenter = new AForge.Point(0, 0);

            METState.Current.ProcessTimeEyeBranch.Timer("GlintBlob", "Start");
            glintBlob = new Blob_Aforge(GrayImg.Bitmap, 5, 30, 5, 30, 0.4, 10);
            METState.Current.ProcessTimeEyeBranch.Timer("GlintBlob", "Stop");


            glintPyrLevel++;
            #region filter blob
            if (glintBlob.blobs_Filtered.Count > 0)
            {

                glintBlob.SelectedBlob = glintBlob.blobs_Filtered[0];
                tempGlintCenter = CorrectGlintPoint(glintBlob.SelectedBlob.CenterOfGravity);

                if (glintBlob.blobs_Filtered.Count >= 2)
                {

                    List<Blob> temp = glintBlob.blobs_Filtered;

                  
                    List<double> dists = new List<double>();

                    foreach (AForge.Imaging.Blob blob in temp)
                    {

                        tempGlintCenter = CorrectGlintPoint(blob.CenterOfGravity);

                        double dist = Math.Sqrt((Math.Pow(tempGlintCenter.X - eyeData[1].pupilCenter.X, 2)) + (Math.Pow(tempGlintCenter.Y - eyeData[1].pupilCenter.Y, 2)));
                        dists.Add(dist);

                    }
                   int i= dists.IndexOf(dists.Min());
                    ////----------------------------------------------------This filter takes the one which is closer to the pupil 
                    glintBlob.SelectedBlob = temp[i];
                    tempGlintCenter = CorrectGlintPoint(glintBlob.SelectedBlob.CenterOfGravity);


                    ////----------------------------------------------------This filter takes the average of the two closest glint to the pupil
                    //dists.RemoveAt(i);
                    //temp.RemoveAt(i);
                    //i = dists.IndexOf(dists.Min());//this will select the second closest glint
                    //AForge.Point tempGlintCenter2 = CorrectGlintPoint(temp[i].CenterOfGravity);
                    //tempGlintCenter = new AForge.Point((tempGlintCenter.X + tempGlintCenter2.X) / 2, (tempGlintCenter.Y + tempGlintCenter2.Y) / 2);

                }
      


                #endregion filter blob

            

            }


            eyeData[0].glintCenter = tempGlintCenter;//(0,0) if there is no glint
            //CvInvoke.cvResetImageROI(GrayImg);


        }
        public AForge.Point CorrectGlintPoint(AForge.Point inp)
        {
            AForge.Point oup = new AForge.Point();

            oup.X = (float)inp.X * glintPyrLevel + glintROI.X;
            oup.Y = (float)inp.Y * glintPyrLevel + glintROI.Y;


            return oup;

        }

        public Eye()
        {
            for (int i = 0; i < 9; i++)
            {

                irisPatches[i] = new IrisPatch();

            }


        }
        public void FindPupil(Image<Bgr, Byte> inputimg, int threshold)
        {
            try
            {
                #region Find Pupil
                Image<Bgr, Byte> CropedInputimg = new Image<Bgr, byte>(inputimg.Bitmap);
                Image<Gray, Byte> temp = new Image<Gray, byte>(inputimg.Width, inputimg.Height);

              //  CropedInputimg = CropedInputimg.Erode(1).Dilate(1);

                SetPupilROI(CropedInputimg, true);
                SetPupilROI(METState.Current.EyeImageForShow, true);
                //if you want to reduce the size of the image e.g. PyrDown you should consider it for translation of the coordinates after blobDetection. 
                //Now I have assumed that translation is only ROI.corner and there is no *Factor

                #region Remove Glint



                if (!LargScan & METState.Current.RemoveGlint == true)
                {
                    METState.Current.ProcessTimeEyeBranch.Timer("GlintRemove", "Start");
                    Image<Gray, Byte> GlintMask = new Image<Gray, byte>(CropedInputimg.Width, CropedInputimg.Height);

                    CropedInputimg = CropedInputimg.PyrDown();
                    GlintMask = CropedInputimg.Convert<Gray, byte>();
                    GlintMask = EmgImgProcssing.Filter_Threshold(GlintMask, METState.Current.glintThreshold, false).Dilate(1);

                    if (METState.Current.RemoveGlint == true) CvInvoke.cvInpaint(CropedInputimg.Ptr, GlintMask.Ptr, CropedInputimg.Ptr, 3, Emgu.CV.CvEnum.INPAINT_TYPE.CV_INPAINT_NS);
                    CropedInputimg = CropedInputimg.PyrUp();

                    METState.Current.ProcessTimeEyeBranch.Timer("GlintRemove", "Stop");

                }

                #endregion Remove Glint

                #region Gray & ErodeDilate
                Image<Gray, Byte> GrayImg;

                if (METState.Current.DilateErode == true)
                {
                    // only when largescan=false
                    METState.Current.ProcessTimeEyeBranch.Timer("Fill Gaps", "Start");
                   // GrayImg = (LargScan == true) ? CropedInputimg.Convert<Gray, byte>() : CropedInputimg.Convert<Gray, byte>().Erode(4).Dilate(4);
                    GrayImg = CropedInputimg.Convert<Gray, byte>().Erode(4).Dilate(3);

                    METState.Current.ProcessTimeEyeBranch.Timer("Fill Gaps", "Stop");
                }
                else
                {

                    GrayImg = CropedInputimg.Convert<Gray, byte>();
                }
                #endregion Gray & ErodeDilate

               

               // METState.Current.ProcessTimeEyeBranch.Timer("Pupil Detection", "Start");
                #region Threshold

                int constant = -1;
                // if (!LargScan & METState.Current.PAdaptive_new) constant = PAConstantSet(GrayImg);
                //Debug.WriteLine(constant + "," + METState.Current.PAdaptive_Constant);

                if (METState.Current.PAdaptive) GrayImg = EmgImgProcssing.Filter_PupilAdaptiveThreshold(GrayImg, 255, true, constant);
                else GrayImg = EmgImgProcssing.Filter_Threshold(GrayImg, threshold, true);

                #endregion Threshold



                // GrayImg = GrayImg.Erode(3).Dilate(2);

                 GrayImg = GrayImg.Dilate(2).Erode(2);


                DetectPupilBlob(GrayImg, inputimg.Width, inputimg.Height);
               // METState.Current.ProcessTimeEyeBranch.Timer("Pupil Detection", "Stop");


                #region Show threshold mask
                if (METState.Current.showPupil)
                {
                    if (LargScan) CropedInputimg = EmgImgProcssing.ColoredMask((Bitmap)PupilBlob.image, CropedInputimg, new Bgr(System.Drawing.Color.Green), true);

                   // else CropedInputimg = EmgImgProcssing.ColoredMask((Bitmap)PupilBlob.image, CropedInputimg, new Bgr(System.Drawing.Color.Chartreuse), true);
                }
                #endregion Show threshold mask

                CvInvoke.cvCopy(CropedInputimg.Ptr, METState.Current.EyeImageForShow.Ptr, new IntPtr());

                CvInvoke.cvResetImageROI(METState.Current.EyeImageForShow);
                CvInvoke.cvResetImageROI(CropedInputimg);//??


                #endregion Find Pupil


                #region Ellipse Drawing and modifing
                if (eyeData[0].pupilFound)
                {
                 if (METState.Current.showPupil)
                   EmgImgProcssing.DrawEllipse(METState.Current.EyeImageForShow, eyeData[0].pupilEllipse, new Bgr(255, 255, 255));


              
                    //emgu ellipse bug: I need to modify it again after drawing. now ellipse box, verteces and angle is fine
                    eyeData[0].pupilEllipse = new Emgu.CV.Structure.Ellipse(eyeData[0].pupilEllipse.MCvBox2D.center, new SizeF(eyeData[0].pupilEllipse.MCvBox2D.size.Width, eyeData[0].pupilEllipse.MCvBox2D.size.Height), eyeData[0].pupilEllipse.MCvBox2D.angle - 90);
                    // EmgImgProcssing.DrawRectangle(METState.Current.EyeImageForShow, pupildata[0].pupilEllipse.MCvBox2D.GetVertices(), 0, false, "");
                    // EmgImgProcssing.DrawRectangle(METState.Current.EyeImageForShow, pupildata[0].pupilEllipse.MCvBox2D.center, pupildata[0].pupilEllipse.MCvBox2D.size);

                }
                #endregion Ellipse Drawing and modifing


                pupildata_Update(MeasureCenter(), MeasureDiameter());//MeasureDiameter should be after modification of ellipse



                blink(ref Blink, ref DoubleBlink);

           }
            catch (Exception error)
            {
                System.Windows.Forms.MessageBox.Show(error.ToString());
            }

            
        }
        public void DetectPupilBlob(Image<Gray, Byte> inputimg, int fullSizeImageW, int fullSizeImageH)
        {
            pupilBlobCenter = new AForge.Point(0, 0);

            //Blob_Aforge PupilBlob;
            //PupilBlob = new Blob_Aforge(inputimg.Bitmap,
            //   (int)(METState.Current.MinPupilDiameter),
            //   (int)(METState.Current.MaxPupilDiameter),
            //   (int)(METState.Current.MinPupilDiameter),
            //    (int)(METState.Current.MaxPupilDiameter),
            //    0.55, 2);//should be defined in each frame
            PupilBlob = new Blob_Aforge(inputimg.Bitmap,
   (int)(METState.Current.MinPupilScale * METState.Current.IrisDiameter),
   (int)(METState.Current.MaxPupilScale * METState.Current.IrisDiameter),
   (int)(METState.Current.MinPupilScale * METState.Current.IrisDiameter),
   (int)(METState.Current.MaxPupilScale * METState.Current.IrisDiameter),
    0.55, 4);//????????????????????????????????????????????????    ,2)


            if (PupilBlob.blobs_Filtered.Count == 0)//Pupil not found
            {
                eyeData[0].pupilFound = false;

            }
            else// Pupil found
            {
                METState.Current.eye.PupilBlob. SelectedBlob = PupilBlob.blobs_Filtered[0];

                #region distance from borders
                //if (PupilBlob.blobs_Filtered.Count == 1)
                //{
                //    double dist = Math.Sqrt((Math.Pow(PupilBlob.blobs_Filtered[0].CenterOfGravity.X - METState.Current.EyeImageOrginal.Width / 2, 2)) + (Math.Pow(PupilBlob.blobs_Filtered[0].CenterOfGravity.Y - METState.Current.EyeImageOrginal.Height / 2, 2)));
                //    if (dist > 0.850 * (METState.Current.EyeImageOrginal.Height / 2))
                //    {

                //        // PupilBlob.blobs_Filtered.Clear();
                //        // PupilBlob.SelectedBlob = null;
                //        _PupilBlobCenter.X = 0;
                //        _PupilBlobCenter.Y = 0;

                //    }

                //}
                #endregion filter by location


                #region distance from center
                if (PupilBlob.blobs_Filtered.Count > 1)//??????????????? mage nagofti faghat yedoone blob peida kon ... 0.55, 1);
                {
                    double minDis = 10000;

                    foreach (AForge.Imaging.Blob blob in PupilBlob.blobs_Filtered)
                    {
                        double dist = Math.Sqrt((Math.Pow(blob.CenterOfGravity.X - METState.Current.EyeImageOrginal.Width / 2, 2)) + (Math.Pow(blob.CenterOfGravity.Y - METState.Current.EyeImageOrginal.Height / 2, 2)));

                        if (dist < minDis)
                        {
                            PupilBlob.SelectedBlob = blob;
                            // border = PupilBlob.hulls[i];
                            minDis = dist;
                        }

                    }
                }

                #endregion distance from center



                //get SelectedBlob   
                pupilBlobCenter.X = (float)METState.Current.eye.PupilBlob.SelectedBlob.CenterOfGravity.X;
                pupilBlobCenter.Y = (float)METState.Current.eye.PupilBlob.SelectedBlob.CenterOfGravity.Y;

                //  pupildata[0].pupilFound = true;//.............2


                bool blobOnROIBorder;

                AForge.Point[] border = PupilBlob.GetBlobBorder(PupilBlob.SelectedBlob, pupilROI, new Size(fullSizeImageW, fullSizeImageH), out blobOnROIBorder);


                // pupildata[0].pupilEllipse = EmgImgProcssing.EllipseLeastSquareFitting(border);//.................2


                //...................................1
                //............................remove 2

                if (blobOnROIBorder)//
                {
                    eyeData[0].pupilFound = false;
                }
                else
                {
                    eyeData[0].pupilEllipse = EmgImgProcssing.EllipseLeastSquareFitting(border);
                    eyeData[0].pupilFound = true;

                }

            }

        }
        public int PAConstantSet(Image<Gray, Byte> inputimg)
        {
            int cons = -1;
            int t = 3;//tickness in pixel


            Rectangle ROI;
            AForge.Imaging.Filters.Crop filter;
            #region 4 ROIs



            ROI = new Rectangle(0, 0, inputimg.Width, t);
            filter = new AForge.Imaging.Filters.Crop(ROI);
            Image<Gray, Byte> up = new Image<Gray, Byte>(filter.Apply(inputimg.Bitmap));
            Image<Gray, Byte> up_temp = new Image<Gray, Byte>(filter.Apply(inputimg.Bitmap));

            ROI = new Rectangle(0, inputimg.Height - t, inputimg.Width, t);
            filter = new AForge.Imaging.Filters.Crop(ROI);
            Image<Gray, Byte> Down = new Image<Gray, Byte>(filter.Apply(inputimg.Bitmap));
            Image<Gray, Byte> Down_temp = new Image<Gray, Byte>(filter.Apply(inputimg.Bitmap));

            ROI = new Rectangle(inputimg.Width - t, t, t, inputimg.Height - t);
            filter = new AForge.Imaging.Filters.Crop(ROI);
            Image<Gray, Byte> Right = new Image<Gray, Byte>(filter.Apply(inputimg.Bitmap));
            Image<Gray, Byte> Right_temp = new Image<Gray, Byte>(filter.Apply(inputimg.Bitmap));




            ROI = new Rectangle(0, t, t, inputimg.Height - t);
            filter = new AForge.Imaging.Filters.Crop(ROI);
            Image<Gray, Byte> Left = new Image<Gray, Byte>(filter.Apply(inputimg.Bitmap));
            Image<Gray, Byte> Left_temp = new Image<Gray, Byte>(filter.Apply(inputimg.Bitmap));


            #endregion 4 ROIs

            #region threshold
            double av = 0;
            for (int i = 0; i < 60; i += 2)
            {

                CvInvoke.cvAdaptiveThreshold(up, up_temp, 255, METState.Current.PAdaptive_type, Emgu.CV.CvEnum.THRESH.CV_THRESH_BINARY_INV, METState.Current.PAdaptive_blockSize, i);
                CvInvoke.cvAdaptiveThreshold(Right, Right_temp, 255, METState.Current.PAdaptive_type, Emgu.CV.CvEnum.THRESH.CV_THRESH_BINARY_INV, METState.Current.PAdaptive_blockSize, i);
                CvInvoke.cvAdaptiveThreshold(Down, Down_temp, 255, METState.Current.PAdaptive_type, Emgu.CV.CvEnum.THRESH.CV_THRESH_BINARY_INV, METState.Current.PAdaptive_blockSize, i);
                CvInvoke.cvAdaptiveThreshold(Left, Left_temp, 255, METState.Current.PAdaptive_type, Emgu.CV.CvEnum.THRESH.CV_THRESH_BINARY_INV, METState.Current.PAdaptive_blockSize, i);

                av = up_temp.GetAverage().Intensity + Right_temp.GetAverage().Intensity + Down_temp.GetAverage().Intensity + Left_temp.GetAverage().Intensity;

                Debug.WriteLine(av + " up=" + up_temp.GetAverage().Intensity + " right=" + Right_temp.GetAverage().Intensity + " down=" + Down_temp.GetAverage().Intensity + " left=" + Left_temp.GetAverage().Intensity);

                // METState.Current.EyeImageForShow = new Image<Bgr,byte>(EmgImgProcssing.Filter_PupilAdaptiveThreshold(inputimg , 255, true, i).Bitmap );
                // METState.Current.EyeImageTest = up_temp.ConcateVertical(Left_temp).ConcateVertical(Down_temp).ConcateHorizontal(Right_temp);
                // METState.Current.METCoreObject.SendToForm("", "EyeImage");

                if (av < 5)//METState.Current.glintThreshold 
                {
                    cons = i;
                    break;
                }
            }
            #endregion threshold
            Debug.WriteLine(av);




            return cons;

        }
   
        public int MeasureDiameter()
        {
            int d = 0;
            if (eyeData[0].pupilFound)
            {
                //approximately
                //d = (int)(PupilBlob.SelectedBlob.Rectangle.Height);

                //large axis of ellipse
                d = (int)eyeData[0].pupilEllipse.MCvBox2D.size.Height;//after modifying the ellipse twice


            }
            return d;
        }

        public AForge.Point MeasureCenter()
        {
            AForge.Point c = new AForge.Point(0, 0);

            if (eyeData[0].pupilFound)
            {

                //Debug.WriteLine(pupilROI.X + "," + pupilROI.Y);
                c.X = pupilBlobCenter.X + pupilROI.X;
                c.Y = pupilBlobCenter.Y + pupilROI.Y;


            }

            return c;
        }

        public void eyeData_Shift()
        {

            for (int i = eyeData.Length - 1; i > 0; i--) { eyeData[i] = eyeData[i - 1]; }
            eyeData[0] = new EyeData();
            eyeData[0].time = DateTime.Now;

        }

        public void pupildata_Update(AForge.Point pupilCenter, int pupilDiameter)
        {


            eyeData[0].pupilCenter = pupilCenter;
            eyeData[0].pupilDiameter = pupilDiameter;
          
            //gesture
 
                headGesture.AddSegment(eyeData[1].pupilCenter, eyeData[0].pupilCenter);
   
        }

        /// <summary>
        /// Represents the method that will handle HeadGesture events.
        /// </summary>
        /// <param name="sender">The source of event.</param>
        /// <param name="start">A HeadGestureEventArgs that contains event data.</param>
        public delegate void GestureHandler(object sender, HeadGestureEventArgs e);

        /// <summary>
        /// Occurs whether valid head gesture is performed.
        /// </summary>
        public event GestureHandler Gesture;

        public void blink(ref bool Blink, ref bool DoubleBlink)
        {
           GestureHandler temp =Gesture;
           HeadGestureEventArgs args;

            Blink = false;
            DoubleBlink = false;


            int blinksensitivity = 70;//max time of closed eye to be considered as blink
            int doubleblinkWaitingTime = 20;



            if (eyeData[0].pupilFound)
            {
            # region eye is open................................................................


                # region just after opening the eye get blink or DbBlink

                if (CloseEye & blinkcounter < blinksensitivity & blinkcounter > 1)//last close was a real blink
                {

                   if (WaitForDoubleBlink)
                    {
                        if (doubleblinkWaitingTime_Counter < doubleblinkWaitingTime)
                        {
                            WaitForDoubleBlink = false;
                            DoubleBlink = true;
                            if (temp != null) { args = new HeadGestureEventArgs("DbBlink",false); temp(this, args); } 
                        }
                        else
                        {
                            WaitForDoubleBlink = false;
                            doubleblinkWaitingTime_Counter = 0;
                            Blink = true;
                            if (temp != null) { args = new HeadGestureEventArgs("Blink", false); temp(this, args); }
                        }
                    }
                    else
                    {
                        WaitForDoubleBlink = true;
                        doubleblinkWaitingTime_Counter = 0;

                    }
                    //Blink = true;

                }
                # endregion just after opening the eye get blink or DbBlink

                # region  Double Blink waiting time

                if (WaitForDoubleBlink)
                {
                    if (doubleblinkWaitingTime_Counter <= doubleblinkWaitingTime)
                    {
                        doubleblinkWaitingTime_Counter++;

                    }
                    else
                    {
                        doubleblinkWaitingTime_Counter = 0;
                        WaitForDoubleBlink = false;
                        Blink = true;
                        if (temp != null) { args = new HeadGestureEventArgs("Blink", false); temp(this, args); }

                    }
                }
                # endregion  Double Blink waiting time


                CloseEye = false;
                blinkcounter = 0;
            #  endregion eye is open................................................................
            }


            else
            {
               #region eye is close................................................................
             CloseEye = true;
                blinkcounter++;

                #region Use eye close

                #endregion  Use eye close

               #endregion eye is close................................................................
            }


            #region use Blink

            if (DoubleBlink)
            {
                /// Put your code here

            }
            else if (Blink)
            {
                /// Put your code here

            }
            #endregion use Blink

        }

        private void SetPupilROI(Image<Bgr, Byte> inputimg, bool ChangeWidthByDiameter)
        {


            double Factor = 2;//2
            int ROIWidth = 150;//???????????????????????????????????????????depends on resolution
            int W;
            int H;



            if (eyeData[1].pupilFound)//pupil was founded in previous frame
            {


                if (ChangeWidthByDiameter)
                {

                    W = (eyeData[1].pupilDiameter == 0) ? ROIWidth : (int)Math.Truncate(eyeData[1].pupilDiameter * Factor);
                    H = W;
                }
                else
                {
                    W = ROIWidth;
                    H = W;

                }
                pupilROI = new Rectangle((int)eyeData[1].pupilCenter.X - (W / 2), (int)eyeData[1].pupilCenter.Y - (H / 2), W, H);
                LargScan = false;

            }
            else
            {


                pupilROI = new Rectangle(0, 0, inputimg.Width, inputimg.Height);
                LargScan = true;

            }


            //size of ROI may exceeds the size of the image no problem for cvSetImageROI
            CvInvoke.cvSetImageROI(inputimg, pupilROI);
 
            //Modify ROI, it's needed when ROI was not inside the image area
            //ROI will be used later for drowing        
            pupilROI = new Rectangle(inputimg.ROI.Location.X, inputimg.ROI.Location.Y, inputimg.ROI.Width, inputimg.ROI.Height);
        }



        //.....................................................................IRIS
       
        public void IrisOpticFlow(Image<Bgr, Byte> inputimg)
        {
            

            METState.Current.ProcessTimeEyeBranch.Timer("Iris opticflow", "Start");
          
            Point ROIc = new Point(0, 0);
            Size ROIsize = new Size(0, 0);
            Size winsize = new Size(5,5);


            /// <summary>
            /// 1 2 3
            /// 4   5
            /// 6 7 8
            /// </summary>
            for (int i = 1; i < 9; i++)
            {

             
                    irisPatches[i].patchAccepted = false;

                    SetIrisPatchROI(i, ref ROIc, ref ROIsize);

                    irisPatches[i].patchAccepted = CheckIrisPatchROI(ROIc, ROIsize, new Size(inputimg.Width, inputimg.Height));

                    if ((METState.Current.IrisDiagonalPatches != true) & (i == 1 | i == 3 | i == 6 | i == 8)) irisPatches[i].patchAccepted = false;
                    if ((METState.Current.IrisStraightPatches != true) & (i == 2 | i == 4 | i == 5 | i == 7)) irisPatches[i].patchAccepted = false;

                    if ((irisPatches[i].patchAccepted & (i == 1 | i == 3 | i == 6 | i == 8)))
                    {
                        //double w = 0.5 * (ROIsize.Width);
                        //double h= 0.5 * (ROIsize.Height);
                        //ROIsize = new Size(Convert.ToInt32(w), Convert.ToInt32(h));

                        irisPatches[i].process5(inputimg, ROIc, ROIsize, winsize, METState.Current.EyeImageForShow, METState.Current.ShowOpticalFlow, "");
                    }
                    else if ((irisPatches[i].patchAccepted) & (i == 4 | i == 5))
                    {
                        irisPatches[i].process5(inputimg, ROIc, ROIsize, winsize, METState.Current.EyeImageForShow, METState.Current.ShowOpticalFlow, "V");
                    }
                    else  if ((irisPatches[i].patchAccepted) & (i == 2 | i == 7))
                    {
                        irisPatches[i].process5(inputimg, ROIc, ROIsize, winsize, METState.Current.EyeImageForShow, METState.Current.ShowOpticalFlow, "H");
                    }
                    
                    

                


            }


            METState.Current.ProcessTimeEyeBranch.Timer("Iris opticflow", "Stop");
            if (METState.Current.gestureRecording=="")    headGesture.AddSegment(irisPatches);

        }

        private void SetIrisPatchROI(int index, ref Point ROIc, ref Size ROIsize)
        {
            int offsetX;
            int offsetY;

            if (index == 1 | index == 3 | index == 8 | index == 6)
            {
                offsetX = METState.Current.eye.PupilBlob.SelectedBlob.Rectangle.Width / 2 - 5;
                offsetY = METState.Current.eye.PupilBlob.SelectedBlob.Rectangle.Height / 2 - 5;
                ROIsize.Width = 1 * ((METState.Current.IrisDiameter / 2) - offsetX) / 2;
                ROIsize.Height = 1 * ((METState.Current.IrisDiameter / 2) - offsetY) / 2;
            }
            else
            {
                offsetX = METState.Current.eye.PupilBlob.SelectedBlob.Rectangle.Width / 2 + 4;
                offsetY = METState.Current.eye.PupilBlob.SelectedBlob.Rectangle.Height / 2 + 4;
                ROIsize.Width = 2 * ((METState.Current.IrisDiameter / 2) - offsetX) / 3;
                ROIsize.Height = 2 * ((METState.Current.IrisDiameter / 2) - offsetY) / 3;
            }






            Point c = new Point((int)eyeData[0].pupilCenter.X, (int)eyeData[0].pupilCenter.Y);

            switch (index)
            {
                case 1:
                    ROIc.X = c.X - offsetX - ROIsize.Width / 2;
                    ROIc.Y = c.Y - offsetY - ROIsize.Height / 2;
                    break;
                case 2:
                    ROIc.X = c.X;
                    ROIc.Y = c.Y - offsetY - ROIsize.Height / 2;

                    break;
                case 3:
                    ROIc.X = c.X + offsetX + ROIsize.Width / 2;
                    ROIc.Y = c.Y - offsetY - ROIsize.Height / 2;

                    break;
                case 4:
                    ROIc.X = c.X - offsetX - ROIsize.Width / 2;
                    ROIc.Y = c.Y;

                    break;
                case 5:
                    ROIc.X = c.X + offsetX + ROIsize.Width / 2;
                    ROIc.Y = c.Y;

                    break;
                case 6:
                    ROIc.X = c.X - offsetX - ROIsize.Width / 2;
                    ROIc.Y = c.Y + offsetY + ROIsize.Height / 2;

                    break;
                case 7:
                    ROIc.X = c.X;
                    ROIc.Y = c.Y + offsetY + ROIsize.Height / 2;

                    break;
                case 8:
                    ROIc.X = c.X + offsetX + ROIsize.Width / 2;
                    ROIc.Y = c.Y + offsetY + ROIsize.Height / 2;

                    break;

            }
        }
        private bool CheckIrisPatchROI(Point ROIc, Size ROIsize, Size imgSize)
        {
            bool OK = true;

            if (ROIc.X - ROIsize.Width / 2 < 0) OK = false;
            if (ROIc.Y - ROIsize.Height / 2 < 0) OK = false;
            if (ROIc.X + ROIsize.Width / 2 > imgSize.Width) OK = false;
            if (ROIc.Y + ROIsize.Height / 2 > imgSize.Height) OK = false;


            return OK;
        }
        public AForge.Point GetEyeFeature(EyeData eyedata)
        {
            AForge.Point pnt = new AForge.Point(0, 0);

            if (METState.Current.calibration_eyeFeature == METState.Calibration_EyeFeature.Pupil)
            {

                pnt = eyedata.pupilCenter;
                if (METState.Current.GazeSmoother) pnt = GetPupilCenterMedian(METState.Current.gazeMedian);
            }
            else if (METState.Current.calibration_eyeFeature == METState.Calibration_EyeFeature.PupilGlintVector)
            {
                pnt.X = eyedata.glintCenter.X - eyedata.pupilCenter.X;
                pnt.Y = eyedata.glintCenter.Y - eyedata.pupilCenter.Y;
                if (METState.Current.GazeSmoother) pnt = GetPupilGlintVectorMedian(METState.Current.gazeMedian);
            }
            else if (METState.Current.calibration_eyeFeature == METState.Calibration_EyeFeature.Glint)
            {
                pnt.X = eyedata.glintCenter.X ;
                pnt.Y = eyedata.glintCenter.Y ;
                if (METState.Current.GazeSmoother) pnt = GetGlintCenterMedian(METState.Current.gazeMedian);

            }
            return pnt;
        
        }
        public EyeData GetEyeDataBeforeGesture(out int index,out bool found)
        {
            bool firstStop = true;
            EyeData data = new EyeData();
            index = 0;
            found = false;
            for (int i = 0; i < eyeData.Count(); i++)
            {
                if (firstStop)
                {
                    if (eyeData[i].tag != HeadGesture.GestureBasicCharacters.NoMovement.ToString()) firstStop = false;
                }
                else
                {
                    if (eyeData[i].tag == HeadGesture.GestureBasicCharacters.NoMovement.ToString() && eyeData[i].pupilFound)
                    {
                        data = eyeData[i];
                        index = i;
                        found = true;
                        break;
                    }
                }
            }
            
            return data;

        }
    }
}
