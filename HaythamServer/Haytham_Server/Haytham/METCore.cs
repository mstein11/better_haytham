
//<copyright file="METCore.cs" company="ITU">
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
using System.Drawing.Imaging;
using System.Diagnostics;
using System.IO;
using AForge.Video.DirectShow;
using AForge.Video;

using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.Util;


namespace Haytham
{

	public class METCore
	{
		public _SendToForm SendToForm;

		public event TrackerEventHandler TrackerEventEye;
		public event TrackerEventHandler TrackerEventScene;
		public ImageProcessing_Emgu EmgImgProcssing = new ImageProcessing_Emgu();

		//for debug
        System.Drawing.Point pgaze = new System.Drawing.Point(0, 0);


		public void EyeFrameCaptured(object sender, NewFrameEventArgs eventArgs)
		{

			var TempImage = (Bitmap)eventArgs.Frame.Clone();

			METState.Current.EyeImageOrginal = new Image<Bgr, Byte>(TempImage);
			METState.Current.EyeImageForShow = new Image<Bgr, Byte>(TempImage);

			// METState.Current.EyeImageForShow._EqualizeHist();


			METEventArg metEventArg = new METEventArg();
			metEventArg.AdditionalArg = "Eye";
			metEventArg.image = new Image<Bgr, byte>((Bitmap)TempImage);

			if (METState.Current.eye_VFlip)
			{
				METState.Current.EyeImageOrginal = METState.Current.EyeImageOrginal.Flip(Emgu.CV.CvEnum.FLIP.VERTICAL);
				METState.Current.EyeImageForShow = METState.Current.EyeImageForShow.Flip(Emgu.CV.CvEnum.FLIP.VERTICAL);
				metEventArg.image = metEventArg.image.Flip(Emgu.CV.CvEnum.FLIP.VERTICAL);

			}

			OnTrackerEventEye(metEventArg);


		}
		public void SceneFrameCaptured(object sender, NewFrameEventArgs eventArgs)
		{

			System.Drawing.Bitmap TempImage;
			TempImage = (Bitmap)eventArgs.Frame.Clone();

			METState.Current.SceneImageForShow = new Image<Bgr, Byte>((Bitmap)TempImage);
			METState.Current.SceneImageOrginal = new Image<Bgr, Byte>((Bitmap)TempImage);
			if (METState.Current.scene_VFlip)
			{
				METState.Current.SceneImageForShow = METState.Current.SceneImageForShow.Flip(Emgu.CV.CvEnum.FLIP.VERTICAL);
				METState.Current.SceneImageOrginal = METState.Current.SceneImageOrginal.Flip(Emgu.CV.CvEnum.FLIP.VERTICAL);
                METState.Current.SceneImageForShow = METState.Current.SceneImageForShow.Flip(Emgu.CV.CvEnum.FLIP.HORIZONTAL);
                METState.Current.SceneImageOrginal = METState.Current.SceneImageOrginal.Flip(Emgu.CV.CvEnum.FLIP.HORIZONTAL);
			}
			# region Distortion
			if (METState.Current.sceneCameraUnDistortion)// && METState.Current.SceneVideoFile == null)
			{

				#region UnDistortion

				METState.Current.ProcessTimeSceneBranch.Timer("UnDistortion", "Start");

				Matrix<float> mapx = new Matrix<float>(new Size(TempImage.Width, TempImage.Height));
				Matrix<float> mapy = new Matrix<float>(new Size(TempImage.Width, TempImage.Height));

				METState.Current.intrinsic_param.InitUndistortMap(TempImage.Width, TempImage.Height, out mapx, out mapy);  //DA FINIRE



				// Image<Bgr, byte> img = chessboard.Clone();
				CvInvoke.cvRemap(METState.Current.SceneImageForShow.Ptr, METState.Current.SceneImageOrginal.Ptr, mapx.Ptr, mapy.Ptr, /*8*/(int)Emgu.CV.CvEnum.INTER.CV_INTER_LINEAR, new MCvScalar(0));

				METState.Current.ProcessTimeSceneBranch.Timer("UnDistortion", "Stop");

				#endregion UnDistortion
				METState.Current.SceneImageForShow = new Image<Bgr, Byte>(METState.Current.SceneImageOrginal.Bitmap);
			}
			# endregion Distortion

			METEventArg metEventArg = new METEventArg();
			metEventArg.AdditionalArg = "Scene";
			metEventArg.image = METState.Current.SceneImageOrginal;
			METState.Current.METCoreObject.OnTrackerEventScene(metEventArg);

		}


		public void MainMethodEye(object sender, METEventArg e)
		{

			METState.Current.ProcessTimeEyeBranch.Timer("Total", "Start");

			METState.Current.eye.eyeData_Shift();//Prepare eyeDataArray for new frame

			#region set pupil threshold first time
			//should be improved.................
			if (METState.Current.firstPupilDetection)
			{
				METState.Current.firstPupilDetection = false;
				Image<Gray, Byte> GrayImg = e.image.Convert<Gray, Byte>();
				// gather statistics
				AForge.Imaging.ImageStatistics stat = new AForge.Imaging.ImageStatistics(GrayImg.Bitmap);
				// get red channel's histogram
				AForge.Math.Histogram b = stat.Gray;
				// check mean value of red channel
				// Debug.WriteLine(b.Mean + "," + b.StdDev + "," + b.Min);
				//
				METState.Current.PupilThreshold = (int)b.Mean / 2;
				SendToForm(METState.Current.PupilThreshold, "PupilThreshold");

			}
			#endregion set pupil threshold first time

			#region find glint
			if (METState.Current.detectGlint)
			{
				METState.Current.ProcessTimeEyeBranch.Timer("Find Glint", "Start");
				if ((!METState.Current.detectPupil) | (METState.Current.detectPupil & METState.Current.eye.eyeData[1].pupilFound))
				{
					METState.Current.eye.FindGlint(e.image, METState.Current.glintThreshold);// Glintcenter=(0,0) if there is no glint
					// if (!METState.Current.detectPupil) EmgImgProcssing.DrawCircle(METState.Current.EyeImageForShow, METState.Current.EyeImageForShow.Width / 2, METState.Current.EyeImageForShow.Height / 2, (int)(METState.Current.IrisDiameter));
				}
				if (METState.Current.eye.eyeData[0].glintCenter != new AForge. Point(0, 0)) SendToForm(METState.Current.eye.eyeData[0].glintCenter, "lblGC");
				else SendToForm("NoGlint", "lblGC");

				METState.Current.ProcessTimeEyeBranch.Timer("Find Glint", "Stop");
			}
			#endregion find glint

			#region find pupil

			if (METState.Current.detectPupil)
			{


				METState.Current.ProcessTimeEyeBranch.Timer("Find Pupil", "Start");

				METState.Current.eye.FindPupil(e.image, METState.Current.PupilThreshold);

                //^^^^^^^^^^^^^^^^^^^^^^^^test

                //Image<Gray, Byte> testimg = new Image<Gray, Byte>(e.image.Bitmap);

               // METState.Current.METCoreObject.SendToForm(testimg.Bitmap, "imScene");
                //^^^^^^^^^^^^^^^^^^^^^^^^66


				#region Draw Iris
				if (METState.Current.showIris)
				{
					SizeF size = new SizeF((METState.Current.eye.GetPupilEllipseSizeMedian(10).Width / METState.Current.eye.GetPupilEllipseSizeMedian(10).Height) * (float)METState.Current.IrisDiameter, (float)METState.Current.IrisDiameter);
					if (size.Width == 0 | float.IsNaN(size.Width)) size = new SizeF((float)METState.Current.IrisDiameter, (float)METState.Current.IrisDiameter);//for the first frames where median is 0 or NoN


					if (METState.Current.eye.LargScan == false && METState.Current.eye.eyeData[0].pupilFound)
					{
						METState.Current.CounterBeforeDrawingIrisCircle = 0;
						Ellipse IrisEllipse = new Emgu.CV.Structure.Ellipse(new PointF(METState.Current.eye.eyeData[0].pupilCenter.X, METState.Current.eye.eyeData[0].pupilCenter.Y), size, METState.Current.eye.eyeData[0].pupilEllipse.MCvBox2D.angle - 90);
						EmgImgProcssing.DrawEllipse(METState.Current.EyeImageForShow, IrisEllipse, new Bgr(100, 100, 100));
					}
					else
					{
						#region wait
						bool wait = false;
						if (METState.Current.CounterBeforeDrawingIrisCircle < 10)
						{
							METState.Current.CounterBeforeDrawingIrisCircle++;
							wait = true;
						}

						#endregion wait

						if (!wait) EmgImgProcssing.DrawIrisCircle(METState.Current.EyeImageForShow, METState.Current.EyeImageForShow.Width / 2, METState.Current.EyeImageForShow.Height / 2, (int)(METState.Current.IrisDiameter));


					}

				}
				#endregion Draw Iris

				if (METState.Current.eye.eyeData[0].pupilFound) SendToForm(METState.Current.eye.eyeData[0].pupilCenter, "lblPC");
				else SendToForm("NoPupil", "lblPC");


				METState.Current.ProcessTimeEyeBranch.Timer("Find Pupil", "Stop");


				#region Plot graph
				//chart

				if (METState.Current.enablePlot)
				{

					METState.Current.ProcessTimeEyeBranch.Timer("Plot", "Start");
					if (METState.Current.eye.eyeData[0].pupilFound)
					{
						SendToForm(METState.Current.eye.eyeData[0].pupilCenter.X, "Chart1");
						SendToForm(METState.Current.eye.eyeData[0].pupilCenter.Y, "Chart2");
						SendToForm(METState.Current.eye.eyeData[0].pupilDiameter, "Chart3");

					}
					else
					{
						SendToForm(Double.NaN, "Chart1");
						SendToForm(Double.NaN, "Chart2");
						SendToForm(Double.NaN, "Chart3");

					}
					METState.Current.ProcessTimeEyeBranch.Timer("Plot", "Stop");
				}
				#endregion Plot

			}
			#endregion find pupil

			#region set data for mapping

			METState.Current.eyeFeature = METState.Current.eye.GetEyeFeature(METState.Current.eye.eyeData[0]);




			#endregion set data for mapping

			#region glint Drawing (injast chon mikham rooye drawing pupil biofte)

            if (METState.Current.detectGlint && METState.Current.eye.eyeData[0].glintCenter != new AForge.Point(0, 0))
			{
				if (METState.Current.showGlint)
				{
					try
					{
						CvInvoke.cvSetImageROI(METState.Current.EyeImageForShow, METState.Current.eye.glintROI);
						Image<Bgr, Byte> temp = EmgImgProcssing.ColoredMask((Bitmap)METState.Current.eye.glintBlob.image, METState.Current.EyeImageForShow, new Bgr(System.Drawing.Color.DarkBlue), false);
						CvInvoke.cvCopy(temp.Ptr, METState.Current.EyeImageForShow.Ptr, new IntPtr());
						CvInvoke.cvResetImageROI(METState.Current.EyeImageForShow);
					}
					catch (Exception err)
					{
						// System.Windows.Forms.MessageBox.Show(err.ToString());

					}


					#region draw circle around glint blobs

					//Point bc = new Point();
					//for (int i = 0; i < METState.Current.eye.glintBlob.blobs_Filtered.Count(); i++)
					//{
					//    bc = METState.Current.eye.correctGlintPoint(METState.Current.eye.glintBlob.blobs_Filtered[i].CenterOfGravity);
					//    EmgImgProcssing.DrawCircle(METState.Current.EyeImageForShow, bc.X, bc.Y, Color.Red);
					//}

					#endregion draw circle around glint blobs


					if (METState.Current.eye.eyeData[0].glintCenter.X != 0)//glint found
					{

						if (METState.Current.detectPupil & METState.Current.eye.eyeData[1].pupilFound)
                            EmgImgProcssing.DrawLine(METState.Current.EyeImageForShow, METState.Current.eye.eyeData[0].glintCenter, METState.Current.eye.eyeData[0].pupilCenter, System.Drawing.Color.Black);
						else if (!METState.Current.detectPupil)
                            EmgImgProcssing.DrawCross(METState.Current.EyeImageForShow, (int)METState.Current.eye.eyeData[0].glintCenter.X, (int)METState.Current.eye.eyeData[0].glintCenter.Y, System.Drawing.Color.Green);
					}
				}
			}

			#endregion glint  Drawing (injast chon mikham rooye drawing pupil biofte)

			if (METState.Current.headRollGestures & METState.Current.eye.eyeData[0].pupilFound)
			{
				METState.Current.eye.IrisOpticFlow(e.image);
			}

			#region Remote

			if (METState.Current.eye.eyeData[0].pupilFound)
			{

                if (METState.Current.EyeToRemoteDisplay_Mapping.Calibrated == true)
                {
                    METState.Current.Gaze_RGT = METState.Current.EyeToRemoteDisplay_Mapping.Map(METState.Current.eyeFeature.X, METState.Current.eyeFeature.Y, METState.Current.EyeToRemoteDisplay_Mapping.GazeErrorX, METState.Current.EyeToRemoteDisplay_Mapping.GazeErrorY);



                    METState.Current.Gaze_RGT = new AForge.Point((int)METState.Current.Gaze_RGT.X, (int)METState.Current.Gaze_RGT.Y);
                    METState.Current.Gaze_RGT = AForge.Point.Subtract(METState.Current.Gaze_RGT, new AForge.Point(METState.Current.remoteCalibration.PresentationScreen.Left, METState.Current.remoteCalibration.PresentationScreen.Top));

                    METState.Current.server.Send("Gaze", new string[] { ((int)METState.Current.Gaze_RGT.X).ToString(), ((int)METState.Current.Gaze_RGT.Y).ToString() });

                    if (METState.Current.GlassServer.gazeStream_RGT == myGlass.Server.GazeStream.RGT)
                    {
                      //  METState.Current.GlassServer.Send(myGlass.MessageType.toGLASS_GAZE_RGT , new Point((int)METState.Current.Gaze_RGT.X , (int)METState.Current.Gaze_RGT.Y));
                        METState.Current.GlassServer.SendGaze_via_UDP(myGlass.MessageType.toGLASS_GAZE_RGT, new Point((int)METState.Current.Gaze_RGT.X, (int)METState.Current.Gaze_RGT.Y));

                        METState.Current.METCoreObject.SendToForm("", "Update Glass Picturebox");
    
                     }
                }
                if (METState.Current.EyeToScene_Mapping.Calibrated == true)
                {
                    
                    CalculateGazeOnScene();
                    //
                    if (METState.Current.GlassServer.gazeStream_HMGT == myGlass.Server.GazeStream.HMGT) METState.Current.GlassServer.SendGaze_via_UDP(myGlass.MessageType.toGLASS_GAZE_HMGT, new Point((int)METState.Current.Gaze_HMGT.X, (int)METState.Current.Gaze_HMGT.Y));
                }
			}
			METState.Current.server.Send("Eye", new string[]
                                                {
                                                  METState.Current.eye.eyeData[0].time.Ticks.ToString(),
                                                  METState.Current.Gaze_RGT.X.ToString(), 
                                                  METState.Current.Gaze_RGT.Y.ToString(),
                                                  METState.Current.eye.eyeData[0].pupilDiameter.ToString(),
                                                  METState.Current.eye.eyeData[0].pupilFound.ToString(),
                                                  ((float)METState.Current.eye.eyeData[0].pupilCenter.X/METState.Current.EyeCamera.VideoSize.Width).ToString(),
                                                  ((float)METState.Current.eye.eyeData[0].pupilCenter.Y/METState.Current.EyeCamera.VideoSize.Height).ToString(),


                                                });



			#endregion Remote

			#region Record Eye Data
			if (METState.Current.EyeIsRecording == true)
			{
				METState.Current.ProcessTimeEyeBranch.Timer("Record Eye Data", "Start");


				METState.Current.EyeVideoWriterFrameNumber += 1;
				METState.Current.EyeVideoWriter.WriteFrame<Bgr, Byte>(METState.Current.EyeImageForShow);

				//text file
				if (METState.Current.TextFileDataExport != null)
				{
					string GazeDataLine =
					   METState.Current.eye.eyeData[0].pupilCenter.X
					   + "," + METState.Current.eye.eyeData[0].pupilCenter.Y
					   + "," + METState.Current.eye.eyeData[0].glintCenter.X
					   + "," + METState.Current.eye.eyeData[0].glintCenter.Y
					   + "," + METState.Current.eye.eyeData[0].pupilDiameter
					   + "," + METState.Current.TextFileDataExport.temp1
					   + "," + METState.Current.TextFileDataExport.temp2
					   + "," + METState.Current.TextFileDataExport.temp3
					   + "," + METState.Current.Gaze_RGT.X
					   + "," + METState.Current.Gaze_RGT.Y
					   + "," + DateTime.Now.ToString("hh.mm.ss.ffffff")
					   ;


					METState.Current.TextFileDataExport.WriteLine(GazeDataLine);
				}
				METState.Current.ProcessTimeEyeBranch.Timer("Record Eye Data", "Stop");

			}
			#endregion Record Eye Data

			METState.Current.ProcessTimeEyeBranch.Timer("Total", "Stop");
			SendToForm("", "textBoxTimerEye");//update the timer text box and show the ProcessTimeEyeBranch
			METState.Current.ProcessTimeEyeBranch.TimerResults.Clear();
		}












		public void MainMethodScene(object sender, METEventArg e)
		{
			METState.Current.ProcessTimeSceneBranch.Timer("Total", "Start");

			#region Gaze estimation on scene
			if (METState.Current.EyeToScene_Mapping.Calibrated == true) CalculateGazeOnScene();


            //send gaze in scene image anyway
            METState.Current.server.Send("GazeInScene", new string[] {
                          ((int)METState.Current.Gaze_HMGT.X).ToString(), 
                         ((int) METState.Current.Gaze_HMGT.Y).ToString(),



                        });
			#endregion Gaze estimation on scene


			if (METState.Current.server.DoWeNeedToDetectVisualMarker())
			{

				METState.Current.ProcessTimeSceneBranch.Timer("Marker Detection", "Start");

				METState.Current.visualMarker.DetectGlyph(e.image.Bitmap);
				METState.Current.visualMarker.VisualizeGlyph(METState.Current.SceneImageForShow.Bitmap, METState.Current.server.GetVisualMarkerNames());

				METState.Current.server.Send("VisualMarker", new string[] { "IsDetected", METState.Current.visualMarker.GetDetectedGlyphsString() });


				// if (METState.Current.EyeToScene_Mapping.Calibrated && METState.Current.eye.eyeData[0].pupilFound)
				{
					string GazedMarkerName = METState.Current.visualMarker.GetGazedGlyph(METState.Current.Gaze_HMGT, 2.2);
					if (GazedMarkerName != "") METState.Current.server.Send("VisualMarker", new string[] { "IsLooking", GazedMarkerName });
					else METState.Current.server.Send("VisualMarker", new string[] { "IsNotLooking" });


					METState.Current.server.Send("VisualMarker", new string[] { "DistanceAngle", METState.Current.visualMarker.GetDetectedGlyphsDistanceAngleString(METState.Current.Gaze_HMGT) });

					//METState.Current.server.Send("VisualMarker", new string[] { "DistanceAngle", METState.Current.visualMarker.GetDetectedGlyphsDistanceAngleString(METState.Current.debugPoint) });


				}



				METState.Current.ProcessTimeSceneBranch.Timer("Marker Detection", "Stop");
			}

			#region screen

			if ((METState.Current.server.CountMonitorClients() + METState.Current.server.CountTVClients()) > 0)
			{

				METState.Current.ProcessTimeSceneBranch.Timer("Screen Detection", "Start");
				bool detected = METState.Current.monitor.DetectRectangle(e.image);
				METState.Current.DAS.NoRectangle_FrameCounter = detected ? 0 : METState.Current.DAS.NoRectangle_FrameCounter + 1;

				METState.Current.ProcessTimeSceneBranch.Timer("Screen Detection", "Stop");

				#region only when screen found and screen is connected

				if (METState.Current.server.CountMonitorClients() != 0 || METState.Current.server.CountTVClients() != 0)
				{

					#region identification

					METState.Current.ProcessTimeSceneBranch.Timer("Screen identification", "Start");


					Size ROI_Size = new Size(METState.Current.monitor.RectangleCorners[1].X - METState.Current.monitor.RectangleCorners[0].X, METState.Current.monitor.RectangleCorners[2].Y - METState.Current.monitor.RectangleCorners[0].Y);

                    System.Drawing.Point ROI_Corner = new System.Drawing.Point(METState.Current.monitor.RectangleCorners[0].X, METState.Current.monitor.RectangleCorners[0].Y);

                    System.Drawing.Rectangle ROI_Rect = new System.Drawing.Rectangle(ROI_Corner, ROI_Size);

					METState.Current.DAS.Detect(e.image, ROI_Rect);

					if (detected && METState.Current.showScreen)
					{
						EmgImgProcssing.DrawRectangle(METState.Current.SceneImageForShow, METState.Current.monitor.RectangleCorners, 0, true, "Screen");//"Area = " + RectangleArea

					}

					METState.Current.ProcessTimeSceneBranch.Timer("Screen identification", "Stop");

					#endregion identification



					#region  Gaze

					if (detected && METState.Current.EyeToScene_Mapping.Calibrated && METState.Current.eye.eyeData[0].pupilFound  && METState.Current.monitor.IsGazeInsideRectangle());
					{
						///Gaze point in the computer screen. coordinates change from [0, screen.size(in pixles)] in each dimension
                        AForge.Point Screengaze = METState.Current.monitor.CalculateRectangleGazePoint(METState.Current.Gaze_HMGT, METState.Current.SceneToMonitor_Mapping);

						METState.Current.server.Send("Gaze", new string[] {
                          ((int)Screengaze.X).ToString(), 
                         ((int) Screengaze.Y).ToString(),
METState.Current.monitor.RectangleCorners[0].X.ToString(),
 METState.Current.monitor.RectangleCorners[0].Y.ToString(),
 METState.Current.monitor.RectangleCorners[1].X.ToString(),
 METState.Current.monitor.RectangleCorners[1].Y.ToString(),
 METState.Current.monitor.RectangleCorners[2].X.ToString(),
 METState.Current.monitor.RectangleCorners[2].Y.ToString(),
 METState.Current.monitor.RectangleCorners[3].X.ToString(),
  METState.Current.monitor.RectangleCorners[3].Y.ToString()

                        });


					}
                    

					#endregion  Gaze




				}
				#endregion only when screen found and screen is connected


			}
			#endregion screen

			//ext data
			#region Ext data handling
			if (METState.Current.DataHandler.IsEnabled)
				METState.Current.DataHandler.Draw(ref METState.Current.SceneImageForShow);
			#endregion Ext data handling

			#region Draw gaze cross on image
			if (METState.Current.ShowGaze) EmgImgProcssing.DrawCross(METState.Current.SceneImageForShow,
                Convert.ToInt32(METState.Current.Gaze_HMGT.X), Convert.ToInt32(METState.Current.Gaze_HMGT.Y), System.Drawing.Color.Red);
			#endregion Draw gaze cross on image

			#region Draw Calibration points
			if (METState.Current.EyeToScene_Mapping.CalibrationTarget != 0)
			{
				Graphics gr2 = Graphics.FromImage(METState.Current.SceneImageForShow.Bitmap);

				// Create a new pen.
                Pen pen = new Pen(System.Drawing.Color.Blue);

				// Set the pen's width.
				pen.Width = 2.0F;
				foreach (AForge.Point p in METState.Current.EyeToScene_Mapping.ScenePoints.ToArray())
				{
					gr2.DrawArc(pen, p.X - 5, p.Y - 5, 10, 10, 0, 360);
				}
				gr2.Dispose();
			}
			#endregion Draw correspoinding points

			#region  Gaze Point Optic Flow ///didn't work. but it was a good idea keep it in your mind


			//Point ROIc = new Point( METState.Current.Gaze.X, METState.Current.Gaze.Y);
			//Size ROIsize = new Size(50,50);
			//bool GazeOpticFlowReady =true;
			//Size winsize = new Size(5, 5);
			//if (ROIc.X -ROIsize.Width< 0) GazeOpticFlowReady = false;
			//if (ROIc.Y-ROIsize.Height < 0) GazeOpticFlowReady = false;
			//if (ROIc.X + ROIsize.Width  > img.Width ) GazeOpticFlowReady = false;
			//if (ROIc.Y + ROIsize.Height > img.Height) GazeOpticFlowReady = false;

			//if (GazeOpticFlowReady)
			//{
			//    GazePointOpticFlow.process(img, ROIc, ROIsize, winsize, METState.Current.SceneImageForShow, true, "",2);
			//    SendToForm(GazePointOpticFlow.AverageVelocityAmount.ToString(), "pbGazeOpticFlow");

			//    if (GazePointOpticFlow.AverageVelocityAmount > METState.Current.vel_GazeOpticThresh )
			//    {
			//        GazePointOpticFlow.Draw("Rejected");
			//        METState.Current.ErrorSound.Play();
			//    }
			//}
			#endregion

			#region Record Scene Data
			if (METState.Current.SceneIsRecording == true)
			{
				METState.Current.ProcessTimeSceneBranch.Timer("Record Scene Data", "Start");

				METState.Current.SceneVideoWriterFrameNumber += 1;
				METState.Current.SceneVideoWriter.WriteFrame<Bgr, Byte>(METState.Current.SceneImageForShow);

				METState.Current.DataHandler.WriteLog();

				//Capture frames
				// METState.Current.SceneImageForShow.Save(METState.Current.GazeData.filenamewithoutextension + "_" + METState.Current.SceneVideoWriterFrameNumber +".jpg");
				METState.Current.ProcessTimeSceneBranch.Timer("Record Scene Data", "Stop");

			}

			#endregion Record Scene Data

			METState.Current.ProcessTimeSceneBranch.Timer("Total", "Stop");
			SendToForm("", "textBoxTimerScene");
			METState.Current.ProcessTimeSceneBranch.TimerResults.Clear();
		}

		public void OnTrackerEventEye(METEventArg e)//protected virtual
		{
			if (TrackerEventEye != null)
			{
				MainMethodEye(this, e);
try
					{
                //if (METState.Current.syncCameras && (METState.Current.SceneCamera != null && METState.Current.SceneCamera.IsRunning))
                //{

					
                //        // METState.Current.camera1Acquired.WaitOne();
				

                //}
				TrackerEventEye(this, e);//Raise the event
                    }
catch (Exception err)
{ }
			}
		}
		public void OnTrackerEventScene(METEventArg e)//protected virtual
		{

			if (TrackerEventScene != null)
			{
				MainMethodScene(this, e);



				try
				{
					METState.Current.camera1Acquired.Set();
				}
				catch (Exception err)
				{ }
				TrackerEventScene(this, e);//Raise the event


			}
		}

		public void CalculateGazeOnScene()
		{
			//Point gaze = new Point();

			//if (METState.Current.MakeLinear == false) gaze = METState.Current.EyeToScene_Mapping.Map(METState.Current.pupil.eyeResult.X, METState.Current.pupil.eyeResult.Y, METState.Current.GazeErrorX, METState.Current.GazeErrorY);
            METState.Current.Gaze_HMGT = METState.Current.EyeToScene_Mapping.Map(METState.Current.eyeFeature.X, METState.Current.eyeFeature.Y, METState.Current.EyeToScene_Mapping.GazeErrorX, METState.Current.EyeToScene_Mapping.GazeErrorY);

			//METState.Current.Gaze.X = gaze.X;
			//METState.Current.Gaze.Y = gaze.Y;

		}

        public AForge.Point GetClientGazeBeforeGesture()
		{

            AForge.Point gaze = new AForge.Point(0, 0);

			if (METState.Current.remoteOrMobile == METState.RemoteOrMobile.RemoteEyeTracking)
			{
				int index = 0;
				bool found = false;
				Eye.EyeData eyedata = METState.Current.eye.GetEyeDataBeforeGesture(out index, out found);
				if (found)
				{
                    AForge.Point eyeFeature = METState.Current.eye.GetEyeFeature(eyedata);

					if (METState.Current.EyeToRemoteDisplay_Mapping.Calibrated)
                        gaze = METState.Current.EyeToRemoteDisplay_Mapping.Map(eyeFeature.X, eyeFeature.Y, METState.Current.EyeToRemoteDisplay_Mapping.GazeErrorX, METState.Current.EyeToRemoteDisplay_Mapping.GazeErrorY);
				}

			}
			else if (METState.Current.remoteOrMobile == METState.RemoteOrMobile.MobileEyeTracking)
			{
				int index = 0;
				bool found = false;
				gaze = METState.Current.monitor.GetGazeBeforeGesture(out index, out found);

			}

			return gaze;
		}

		public void SaveCameraCalibrationData()
		{
			#region Save Data
			//Intrinsic
			TextFile parms = new TextFile("SceneCameraParameters");

			parms.WriteLine("Intrinsic Parameters");



			for (int j = 0; j < METState.Current.intrinsic_param.IntrinsicMatrix.Width; j++)
			{
				for (int i = 0; i < METState.Current.intrinsic_param.IntrinsicMatrix.Height; i++)
				{
					if (i != 0) parms.Write(" , ");


					parms.Write(METState.Current.intrinsic_param.IntrinsicMatrix[i, j].ToString());
				}
				parms.WriteLine(" ");
			}


			//Extrinsic
			// parms.WriteLine("Intrinsic Parameters");
			//....

			parms.CloseFile();



			//Save Corners for the next time
			TextFile PointsData = new TextFile("CameraCalibrationData_image_points");

			PointsData.WriteLine("Camera Calibration Data image_points");

			for (int j = 0; j < METState.Current.image_points.GetLength(0); j++)
			{
				for (int i = 0; i < METState.Current.image_points[0].GetLength(0); i++)
				{

					PointsData.WriteLine(METState.Current.image_points[j][i].X.ToString());
					PointsData.WriteLine(METState.Current.image_points[j][i].Y.ToString());

				}
			}
			PointsData.WriteLine("End Of CameraCalibrationData_image_points");
			PointsData.CloseFile();

			PointsData = new TextFile("CameraCalibrationData_object_points");

			PointsData.WriteLine("Camera Calibration Data object_points");


			for (int j = 0; j < METState.Current.object_points.GetLength(0); j++)
			{
				for (int i = 0; i < METState.Current.object_points[0].GetLength(0); i++)
				{

					PointsData.WriteLine(METState.Current.object_points[j][i].x.ToString());
					PointsData.WriteLine(METState.Current.object_points[j][i].y.ToString());
					PointsData.WriteLine(METState.Current.object_points[j][i].z.ToString());

				}
			}
			PointsData.WriteLine("End Of CameraCalibrationData_object_points");

			PointsData.CloseFile();
			#endregion
		}
		public bool LoadCameraCalibrationData()
		{
			bool ok = true;

			#region Load SceneCameraParameters of last cameraCalibration time
			try
			{
				//Set Variables
				METState.Current.sceneCameraUnDistortion = false;
				SendToForm(false, "UnDistortion");

				METState.Current.sceneCameraCalibrating = true;
				METState.Current.cameraCalibrationSamplesCount = 0;
				METState.Current.corners = new PointF[METState.Current.ChessBoard_W * METState.Current.ChessBoard_H];
				METState.Current.intrinsic_param = new IntrinsicCameraParameters();
				METState.Current.extrinsic_param = new ExtrinsicCameraParameters[METState.Current.cameraCalibrationSamples];


				//Preparing the objects
				METState.Current.object_points = new MCvPoint3D32f[METState.Current.cameraCalibrationSamples][];
				METState.Current.image_points = new PointF[METState.Current.cameraCalibrationSamples][];


				for (int i = 0; i < 10; i++)
				{
					// for (int j = 0; j < METState.Current.ChessBoard_W* METState.Current.ChessBoard_H; j++)
					// {

					METState.Current.image_points[i] = new PointF[METState.Current.ChessBoard_W * METState.Current.ChessBoard_H];
					// }
					METState.Current.object_points[i] = new MCvPoint3D32f[METState.Current.ChessBoard_W * METState.Current.ChessBoard_H];

				}

				//Load Data
				StreamReader SW = new StreamReader("CameraCalibrationData_image_points.txt");
				string firstline = SW.ReadLine();
				for (int j = 0; j < METState.Current.cameraCalibrationSamples; j++)
				{
					for (int i = 0; i < METState.Current.ChessBoard_W * METState.Current.ChessBoard_H; i++)
					{

						METState.Current.image_points[j][i].X = float.Parse(SW.ReadLine());
						METState.Current.image_points[j][i].Y = float.Parse(SW.ReadLine());

					}
				}
				// System.Windows.Forms. MessageBox.Show(SW.ReadLine());
				SW.Close();

				SW = new StreamReader("CameraCalibrationData_object_points.txt");
				firstline = SW.ReadLine();
				for (int j = 0; j < METState.Current.cameraCalibrationSamples; j++)
				{
					for (int i = 0; i < METState.Current.ChessBoard_W * METState.Current.ChessBoard_H; i++)
					{

						METState.Current.object_points[j][i].x = float.Parse(SW.ReadLine());
						METState.Current.object_points[j][i].y = float.Parse(SW.ReadLine());
						METState.Current.object_points[j][i].z = float.Parse(SW.ReadLine());

					}
				}
				//  System.Windows.Forms.MessageBox.Show(SW.ReadLine());

				SW.Close();




			}
			catch (Exception er)
			{
				// System.Windows.Forms.MessageBox.Show(er.Message.ToString());

				ok = false;
			}

			#endregion Load SceneCameraParameters of last cameraCalibration time

			return ok;
		}

	}
}
