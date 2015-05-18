
//<copyright file="METState.cs" company="ITU">
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
using System.Collections;
using System.Drawing;
using System.Drawing.Imaging;
using System.Diagnostics;
using AForge.Video.DirectShow;
using AForge.Video;
using System.Threading;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.Util;
using AForge.Vision.GlyphRecognition;

namespace Haytham
{
    //delegates
    public delegate void TrackerEventHandler(object sender, METEventArg e);
    public delegate void _SendToForm(object message, string controlName);


    public sealed class METState
    {

        private static METState _Current = new METState();
        public static METState Current
        {
            get { return _Current; }
        }

        //Classes
        public METCore METCoreObject = new METCore();
        public Eye eye = new Eye();
        public Server server = new Server();
        public RectangleDetection monitor = new RectangleDetection();
        public DetectActiveScreen DAS = new DetectActiveScreen();

        public GlyphImageProcessor visualMarker = new GlyphImageProcessor(6);//Only use 6*6 known markers in your clients

        public Calibration EyeToScene_Mapping = new Calibration();
        public Calibration SceneToMonitor_Mapping = new Calibration();
        public Calibration EyeToRemoteDisplay_Mapping = new Calibration();

        public ProcessTime ProcessTimeEyeBranch = new ProcessTime();
        public ProcessTime ProcessTimeSceneBranch = new ProcessTime();
        
        public TextFile TextFileDataExport;

        //

        public enum RemoteOrMobile { RemoteEyeTracking, MobileEyeTracking, GoogleGalss};
        public RemoteOrMobile remoteOrMobile;

        //Cameras
        public Haytham.VideoSource.IVideoSource EyeCamera;
		public Haytham.VideoSource.IVideoSource SceneCamera;     

        public AutoResetEvent camera1Acquired = null;
        public bool eye_VFlip;
        public bool scene_VFlip;

        //Scene Camera Calibration
        public int cameraCalibrationSamples = 10;
        public int ChessBoard_W = 9;
        public int ChessBoard_H = 6;

        public int cameraCalibrationSamplesCount = 1000;
        public bool sceneCameraUnDistortion;
        public bool sceneCameraCalibrating;

        public PointF[] corners;
        public MCvPoint3D32f[][] object_points;
        public PointF[][] image_points;
        public IntrinsicCameraParameters intrinsic_param;
        public ExtrinsicCameraParameters[] extrinsic_param;


        //Images
        public Image<Bgr, Byte> EyeImageOrginal;
        public Image<Bgr, Byte> EyeImageForShow;
        public Image<Gray, Byte> EyeImageTest;
        public Image<Bgr, Byte> EyeImageFlowForShow;


        public Image<Bgr, Byte> SceneImageOrginal;
        public Image<Bgr, Byte> SceneImageForShow;
        public Image<Bgr, Byte> SceneImageProcessed;//Showing detected objects 

        //Recording
        public VideoWriter SceneVideoWriter;//Recording SceneImageForShow
        public long SceneVideoWriterFrameNumber;
        public VideoWriter EyeVideoWriter;//Recording EyeImageForShow
        public long EyeVideoWriterFrameNumber;

        public Boolean SceneIsRecording = false;
        public Boolean EyeIsRecording = false;


        public Boolean SceneForExport = false;
        public Boolean EyeForExport = false;

        //Pupil
        public Boolean detectPupil;
        public Boolean DilateErode;
        public int MaxPupilDiameter;
        public int MinPupilDiameter;
        public int PupilThreshold;

        public double MaxPupilScale = 0.9;
        public double MinPupilScale = 0.1;
        public bool firstPupilDetection = true;
        public int CounterBeforeDrawingIrisCircle ;
        public bool showPupil;
        //      Adaptive Threshold
        public bool PAdaptive = true;
        public int PAdaptive_Constant;
        public int PAdaptive_blockSize;
        public Emgu.CV.CvEnum.ADAPTIVE_THRESHOLD_TYPE PAdaptive_type;
       // public bool PAdaptive_new;


        //Glint
        public Boolean detectGlint;
        public Boolean RemoveGlint;
        public int glintThreshold;
        public bool showGlint;

        //      Adaptive Threshold
        public bool GAdaptive = true;
        public int GAdaptive_Constant;
        public int GAdaptive_blockSize;
        public Emgu.CV.CvEnum.ADAPTIVE_THRESHOLD_TYPE GAdaptive_type;


        //Iris
        public int IrisDiameter;

        public bool showIris;

        //Gesture
        public bool headRollGestures;
         public bool ShowOpticalFlow ;
         public string gestureRecording="";
         public bool IrisDiagonalPatches = true;
         public bool IrisStraightPatches = true;
         public int HowManyDirections4OR8 = 4;//8



        //Gaze
        public Boolean ShowGaze;
        public Boolean GazeSmoother = false;
        //public AForge.Point Gaze;

        public AForge.Point Gaze_RGT;
        public AForge.Point Gaze_HMGT;

        public AForge.Point Gaze_SnapShot_Glass;

        public int gazeMedian = 10;

        


        //calibration
        public enum Calibration_EyeFeature { Pupil, PupilGlintVector,Glint };
        public Calibration_EyeFeature calibration_eyeFeature;

        public AForge.Point eyeFeature;
        //remote
        public RemoteCalibration remoteCalibration;
        public cursor mCursor=new cursor();
        //public Size HMD_Resolution = new Size(640,480);

        //Chart
        //          Define some variables
        public bool enablePlot;
        public int numberOfPointsInChart = 200;
        public int numberOfPointsAfterRemoval = 200;



        //Scene

        public bool showScreenSize;
        public Size GlassFrontView_Resolution = new Size(0, 0);


        public Boolean showScreen ;
        public Boolean showEdges;
      

        //Server & Client
        public myGlass.Server GlassServer ;//= new myGlass.Server();
        public string ip="";

        //Others
        public int testslider = 1;
        public Boolean TimerEnable = true;

        public int  test = 0;


        //for debug
        public Point debugPoint=new Point(0,0);

		//extData
		public ExtDataHandler DataHandler = new ExtDataHandler();

        //

        public Dictionary<string, int> commands = new Dictionary<string, int>();
           

    }
}