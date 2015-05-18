
//<copyright file="MainForm.cs" company="ITU">
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
// <modifiedby>Camilo Rodegheri</modifiedby>
// <email>camilo.rodegheri@gmail.com</email>


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using System.Diagnostics;
using System.Threading;
using System.Reflection;
using Emgu.CV.Structure;
using Emgu.CV;
using System.Windows.Forms.DataVisualization.Charting;


//using ;

namespace Haytham
{

    public partial class MainForm : Form
    {
        public Forms.qrCode IPform = new Forms.qrCode();
        //gesture tab
        private PictureBox[] headGesturePictures;
        private Button[] headGestureButtons;

        //
        private Dictionary<string, System.Windows.Forms.Button> btnClients = new Dictionary<string, Button>();
        private Dictionary<string, System.Windows.Forms.Label> lblClients = new Dictionary<string, Label>();
        private Dictionary<string, System.Windows.Forms.TextBox> txtClients = new Dictionary<string, TextBox>();
        private Dictionary<string, System.Windows.Forms.RadioButton> radClients = new Dictionary<string, RadioButton>();

        private Dictionary<int, string> ClientsPos = new Dictionary<int, string>();


        public MainForm()
        {
            InitializeComponent();

            // update control style
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.DoubleBuffer | ControlStyles.UserPaint, true);

            METState.Current.METCoreObject.SendToForm = new _SendToForm(UpdateControl);


            Icon ico = new Icon(Properties.Resources.Untitled_1, 64, 64);
            this.Icon = ico;


            ///Set the METState.Current.RemoteOrHeadMount 
            firstForm firstform = new firstForm(); ;
            firstform.ShowDialog();
            //
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

            METState.Current.test = trackBarTest.Value;//for test
            //-------------------------------------------------------------
            //groupBox_imgEye.AutoSize = true;
            //groupBox_imgScene.AutoSize = true;

            //groupBox13.Height = splitContainer1.Panel2.Height;
            splitContainer1.Panel2.AutoScroll = true;

            splitContainer1.Panel2.VerticalScroll.Visible = true;
            splitContainer1.Panel2.HorizontalScroll.Visible = true;
            splitContainer1.Panel1.HorizontalScroll.Minimum = 0;
            splitContainer1.Panel1.VerticalScroll.Minimum = 0;


            groupBox14.Size = new Size(panel6.Width, splitContainer1.Panel2.Height - panel6.Height);
            groupBox14.AutoSize = true;


            ///------------------------------------------------------------------
            if (METState.Current.remoteOrMobile == METState.RemoteOrMobile.MobileEyeTracking)
            {
                gbCalibrationRemote.Visible = false;
                gbCalibrationGlass.Visible = false;
                tabControl1.TabPages.Remove(this.tabPage_Glass);

            }
            else if (METState.Current.remoteOrMobile == METState.RemoteOrMobile.RemoteEyeTracking)
            {
                tabControl1.TabPages.Remove(this.tabPage_Glass);
                gbSceneCameraDevice.Visible = false;
                gbStartBoth.Visible = false;

                tabControl1.TabPages.Remove(this.tabPage_Scene);
                gbCalibrationHM.Visible = false;
                gbCalibrationGlass.Visible = false;

                groupBox_imgScene.Visible = false;
                imSceneProcessed.Visible = false;
                comboBox_SceneTimer.Visible = false;
                radioButtonAutoActivation.Visible = false;
                checkBox3.Visible = false;
            }
            else if (METState.Current.remoteOrMobile == METState.RemoteOrMobile.GoogleGalss)
            {

                gbSceneCameraDevice.Visible = false;
                gbStartBoth.Visible = false;

                tabControl1.TabPages.Remove(this.tabPage_Scene);
                tabControl1.TabPages.Remove(this.tabPage_ExtData);

                gbCalibrationHM.Visible = false;
                gbCalibrationRemote.Visible = false;

                //groupBox_imgScene.Visible = false;
                imSceneProcessed.Visible = false;
                comboBox_SceneTimer.Visible = false;
                radioButtonAutoActivation.Visible = false;
                checkBox3.Visible = false;




            }


            //..............



            METState.Current.eye.headGesture.Gesture += new HeadGesture.GestureHandler(this.gestureIcons);
            METState.Current.eye.Gesture += new Eye.GestureHandler(this.gestureIcons);
            //Gesture tab
            METState.Current.ShowOpticalFlow = checkEditShowOpticalFlow.Checked;

            METState.Current.headRollGestures = checkBox2.Checked;

            headGesturePictures = new PictureBox[50];
            headGestureButtons = new Button[4];

            METState.Current.eye.headGesture.setGestureDic();

            pbUp1.Tag = "U_D";
            pbRight1.Tag = "R_L";
            pbDown1.Tag = "D_U";
            pbLeft1.Tag = "L_R";

            pbUpRight1.Tag = "UR_DL";
            pbUpLeft1.Tag = "UL_DR";
            pbDownLeft1.Tag = "DL_UR";
            pbDownRight1.Tag = "DR_UL";

            pbUp2.Tag = "U_U";
            pbRight2.Tag = "R_R";
            pbDown2.Tag = "D_D";
            pbLeft2.Tag = "L_L";

            pbUpRight2.Tag = "UR_UR";
            pbUpLeft2.Tag = "UL_UL";
            pbDownLeft2.Tag = "DL_DL";
            pbDownRight2.Tag = "DR_DR";

            pbTRight.Tag = "TR";
            pbTLeft.Tag = "TL";


            headGesturePictures[0] = pbUp1;
            headGesturePictures[1] = pbRight1;
            headGesturePictures[2] = pbDown1;
            headGesturePictures[3] = pbLeft1;

            headGesturePictures[4] = pbUpRight1;
            headGesturePictures[5] = pbUpLeft1;
            headGesturePictures[6] = pbDownRight1;
            headGesturePictures[7] = pbDownLeft1;

            headGesturePictures[8] = pbUp2;
            headGesturePictures[9] = pbRight2;
            headGesturePictures[10] = pbDown2;
            headGesturePictures[11] = pbLeft2;

            headGesturePictures[12] = pbUpRight2;
            headGesturePictures[13] = pbUpLeft2;
            headGesturePictures[14] = pbDownLeft2;
            headGesturePictures[15] = pbDownRight2;

            headGesturePictures[16] = pbTRight;
            headGesturePictures[17] = pbTLeft;


            headGestureButtons[0] = btn_Custom1;
            headGestureButtons[1] = btn_Custom2;
            headGestureButtons[2] = btn_Custom3;
            headGestureButtons[3] = btn_Custom4;

            ResetImages();

            //

            METState.Current.showScreen = cbShowScreen.Checked;
            METState.Current.showEdges = cbShowEdges.Checked;


            METState.Current.showIris = cbShowIris.Checked;
            METState.Current.showPupil = cbShowPupil.Checked;
            METState.Current.showGlint = cbShowGlint.Checked;

            METState.Current.sceneCameraUnDistortion = cbSceneUnDistortion.Checked;

            METState.Current.eye_VFlip = cb_eye_VFlip.Checked;
            METState.Current.scene_VFlip = cb_scene_VFlip.Checked;

            // Cursor.Show();


            METState.Current.GazeSmoother = cbGazeSmoothing.Checked;


            //if (rdOnlyPupil.Checked) METState.Current.calibration_eyeFeature = METState.Calibration_EyeFeature.Pupil;
            //if (rbPupilGlint.Checked) METState.Current.calibration_eyeFeature = METState.Calibration_EyeFeature.PupilGlintVector;

            if (rbPupilGlint.Checked) METState.Current.calibration_eyeFeature = METState.Calibration_EyeFeature.PupilGlintVector;
            else if (rdOnlyPupil.Checked) METState.Current.calibration_eyeFeature = METState.Calibration_EyeFeature.Pupil;
            else if (rbGlint.Checked) METState.Current.calibration_eyeFeature = METState.Calibration_EyeFeature.Glint;

            METState.Current.glintThreshold = trackBarThresholdGlint.Value;

            METState.Current.PupilThreshold = trackBarThresholdEye.Value;
            METState.Current.DilateErode = cbDilateErode.Checked;

            METState.Current.detectPupil = cbPupilDetection.Checked;
            METState.Current.detectGlint = cbGlintDetection.Checked;

            METState.Current.RemoveGlint = cbRemoveGlint.Checked;

            METState.Current.ShowGaze = cbShowGaze.Checked;

            //METState.Current.monitor = new RectangleDetection();

            METState.Current.monitor.rectangleMinSize = trackBarControl3.Value;
            METState.Current.monitor.BThreshold = trackBarB.Value;
            METState.Current.monitor.GThreshold = trackBarG.Value;



            METState.Current.enablePlot = cbPlot.Checked;
            METState.Current.IrisDiameter = trackBarControl2.Value;

            METState.Current.monitor.Real_Rectangle_W = 1440;//1920;// 1280;//;//Default
            METState.Current.monitor.Real_Rectangle_H = 900;//1080;//2024;//;//Default

            cmbDeviceEye.Text = "Loading ...";
            cmbDeviceScene.Text = "Loading ...";
            cmbDevice_Update(true, true);

            //Adaptive Threshold
            //          pupil
            METState.Current.PAdaptive = cbPA.Checked;
            trackBarPAConstant.Enabled = cbPA.Checked;
            trackBarThresholdEye.Enabled = cbPM.Checked;

            METState.Current.PAdaptive_blockSize = trackBarPABlockSize.Value % 2 != 0 ? trackBarPABlockSize.Value : trackBarPABlockSize.Value + 1;
            METState.Current.PAdaptive_Constant = trackBarPAConstant.Value;
            METState.Current.PAdaptive_type = rbPMean.Checked ? Emgu.CV.CvEnum.ADAPTIVE_THRESHOLD_TYPE.CV_ADAPTIVE_THRESH_MEAN_C : Emgu.CV.CvEnum.ADAPTIVE_THRESHOLD_TYPE.CV_ADAPTIVE_THRESH_GAUSSIAN_C;
            //          glint
            METState.Current.PAdaptive = cbGA.Checked;
            trackBarGAConstant.Enabled = cbGA.Checked;
            trackBarThresholdGlint.Enabled = cbGM.Checked;

            METState.Current.GAdaptive_blockSize = trackBarGABlockSize.Value % 2 != 0 ? trackBarGABlockSize.Value : trackBarGABlockSize.Value + 1;
            METState.Current.GAdaptive_Constant = trackBarGAConstant.Value - trackBarGAConstant.Maximum / 2;
            METState.Current.GAdaptive_type = rbGMean.Checked ? Emgu.CV.CvEnum.ADAPTIVE_THRESHOLD_TYPE.CV_ADAPTIVE_THRESH_MEAN_C : Emgu.CV.CvEnum.ADAPTIVE_THRESHOLD_TYPE.CV_ADAPTIVE_THRESH_GAUSSIAN_C;
            //  METState.Current.PAdaptive_new = checkBox5.Checked;

            //imEye.SizeMode = PictureBoxSizeMode.AutoSize;
            //imScene.SizeMode = PictureBoxSizeMode.AutoSize;
            //imSceneProcessed.SizeMode = PictureBoxSizeMode.AutoSize;
            //imEyeTest.SizeMode = PictureBoxSizeMode.AutoSize;

            METState.Current.EyeForExport = checkBox1.Checked;
            METState.Current.SceneForExport = checkBox3.Checked;




            //Glass
            Type t = typeof(myGlass.MessageType);
            //METState.Current.commands = t.GetProperties(System.Reflection.BindingFlags.Instance)
            //     .ToDictionary(prop => prop.Name, prop => (int)prop.GetValue(t, null));

            var properties = t.GetFields();
            Console.WriteLine("properties found: " + properties.Count());

            foreach (var item in properties)
            {
                string name = item.Name;
                int val = (int)item.GetValue(null);
                if (name.StartsWith("toGLASS")) METState.Current.commands.Add(name, val);
            }

            foreach (KeyValuePair<string, int> pair in METState.Current.commands)
            {

                lbCommandsToGlass.Items.Add(pair.Key);

            }


            METState.Current.GlassServer = new myGlass.Server(this);


        }



        private void gestureIcons(object sender, HeadGestureEventArgs e)
        {


            foreach (PictureBox pb in headGesturePictures)
            {
                if ((pb != null) && (string)pb.Tag == e.Gesture)
                {
                    //load image from the resources
                    //pb.Image = new Bitmap(Assembly.GetExecutingAssembly().GetManifestResourceStream(getResourceName(e.Gesture, true)));
                    pb.BackColor = Color.Pink;
                    if (METState.Current.TextFileDataExport != null) METState.Current.TextFileDataExport.temp3 = e.Gesture;
                }
            }
            foreach (Button btn in headGestureButtons)
            {
                if ((string)btn.Tag == e.Gesture)
                {

                    btn.BackColor = Color.Pink;

                    if (METState.Current.TextFileDataExport != null) METState.Current.TextFileDataExport.temp3 = e.Gesture;
                }
            }

            if ((string)btnBlink.Tag == e.Gesture)
            {
                btnBlink.BackColor = Color.Pink;

                if (METState.Current.TextFileDataExport != null) METState.Current.TextFileDataExport.temp1 = "1";
            }
            if ((string)btnDbBlink.Tag == e.Gesture)
            {
                btnDbBlink.BackColor = Color.Pink;

                if (METState.Current.TextFileDataExport != null) METState.Current.TextFileDataExport.temp2 = "1";
            }



            //send for Clients



            AForge.Point gaze = e.HasBegining ? METState.Current.METCoreObject.GetClientGazeBeforeGesture() : new AForge.Point(0, 0);

            int index = 0;
            bool found = false;
            string gazedMarker = METState.Current.visualMarker.GetGazedMarkerBeforeGesture(out index, out found);
            METState.Current.server.Send("Commands", new string[] { ((int)gaze.X).ToString(), ((int)gaze.Y).ToString(), gazedMarker, e.Gesture });


            UpdateControl("", "timerReset");
        }

        private void timerReset_Tick(object sender, EventArgs e)
        {
            //resets images to normal
            ResetImages();
            timerReset.Stop();
        }
        private void ResetImages()
        {
            foreach (PictureBox pb in headGesturePictures)
            {
                if (pb != null)
                {
                    // pb.Image = new Bitmap(Assembly.GetExecutingAssembly().GetManifestResourceStream(                      getResourceName((string)pb.Tag, false)));
                    pb.BackColor = Color.White;
                }
            }
            foreach (Button btn in headGestureButtons)
            {

                btn.BackColor = Color.White;

            }
            btnBlink.BackColor = Color.White;
            btnDbBlink.BackColor = Color.White;
        }
        //Build full name of the resource
        private string getResourceName(string gestureName, bool activeImage)
        {
            string active = "";
            if (activeImage)
                active = "a";

            return "Haytham.Resources." + gestureName + active + ".png";
        }
        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing && (components != null))
                {
                    components.Dispose();
                }
                base.Dispose(disposing);
            }
            catch (Exception error)
            {
                // System.Windows.Forms.MessageBox.Show(error.ToString()); 
                // METState.Current.ErrorSound.Play();
            }
        }

        //...................................................................
        private void CreateClientControl(string clientName)
        {
            AddControls(clientName);
            ShowControls(clientName);
        }
        private void HighLight_Client(string clientName)
        {
            foreach (KeyValuePair<string, Label> kvp in lblClients)
            {
                if (kvp.Key == clientName)
                {
                    kvp.Value.BackColor = Color.Chartreuse;
                }
                else
                {
                    kvp.Value.BackColor = Color.Transparent;
                }
            }
            // if (lblClients.ContainsKey(clientName) == true)

        }
        private int GetPosForClient()
        {
            int n = 1;
            int i = 1;

            for (i = 1; i <= ClientsPos.Count(); i++)
            {
                if (ClientsPos.ContainsKey(i) != true)
                {

                    n = i;
                    break;
                }

            }

            if (ClientsPos.Count() + 1 == i & n == 1) n = i;


            return n;
        }
        // Function to create Control array
        // 'anyControl' is type of control, 'cNumber' is number of control
        private void AddControls(string clientName)
        {

            if (btnClients.ContainsKey(clientName) != true)
            {

                lblClients.Add(clientName, new Label());
                txtClients.Add(clientName, new TextBox());
                btnClients.Add(clientName, new Button());
                radClients.Add(clientName, new RadioButton());

                int tg;
                tg = GetPosForClient();
                ClientsPos.Add(tg, clientName);
                lblClients[clientName].Tag = tg;
                txtClients[clientName].Tag = tg;
                btnClients[clientName].Tag = tg;
                radClients[clientName].Tag = tg;

            }



        }
        private void RemoveControls(string clientName)
        {

            if (btnClients.ContainsKey(clientName))
            {
                panelClients.Controls.Remove(btnClients[clientName]);

                panelClients.Controls.Remove(lblClients[clientName]);

                panelClients.Controls.Remove(txtClients[clientName]);
                panelClients.Controls.Remove(radClients[clientName]);

                ClientsPos.Remove((int)(btnClients[clientName].Tag));
                lblClients.Remove(clientName);
                txtClients.Remove(clientName);
                btnClients.Remove(clientName);
                if (radClients[clientName].Checked)
                {
                    METState.Current.server.activeScreen = "";
                    METState.Current.server.ForcedActiveScreen = "";
                    radioButtonAutoActivation.Checked = true;
                };
                radClients.Remove(clientName);
            }
        }
        private void ShowControls(string clientName)
        {
            int xPos = 10;//distance from left and right eadge & between controls
            int yPos = 10;//vertical distance between controls

            int w = panelClients.Width;//220
            int h = 24;
            int top0 = radioButtonAutoActivation.Top + radioButtonAutoActivation.Height;//distance from top eadge


            //lbl
            lblClients[clientName].AutoSize = true;
            // lblClients[clientName].Width = w - radioButtonAutoActivation.Width;
            lblClients[clientName].Height = h;
            lblClients[clientName].TextAlign = ContentAlignment.MiddleLeft;
            lblClients[clientName].BorderStyle = System.Windows.Forms.BorderStyle.None;
            lblClients[clientName].Text = clientName;

            lblClients[clientName].Left = xPos;
            lblClients[clientName].Top = ((int)(lblClients[clientName].Tag) - 1) * 2 * h + yPos + top0;

            panelClients.Controls.Add(lblClients[clientName]);

            //rad
            radClients[clientName].AutoSize = true;
            // radClients[clientName].Width = w / 3;
            radClients[clientName].Height = h;
            radClients[clientName].Text = "Active";

            radClients[clientName].Left = radioButtonAutoActivation.Left;// xPos + 2 * w / 3;
            radClients[clientName].Top = lblClients[clientName].Top;

            panelClients.Controls.Add(radClients[clientName]);
            radClients[clientName].Visible = clientName.StartsWith("Monitor") | clientName.StartsWith("TV") ? true : false;
            radClients[clientName].CheckedChanged += new System.EventHandler(Click_radClients);

            //txt
            txtClients[clientName].Width = 3 * (w - 3 * xPos) / 5;
            txtClients[clientName].Height = h;
            txtClients[clientName].BackColor = System.Drawing.SystemColors.Info;
            txtClients[clientName].Text = "";

            txtClients[clientName].Left = xPos;
            txtClients[clientName].Top = radClients[clientName].Top + radClients[clientName].Height;

            panelClients.Controls.Add(txtClients[clientName]);
            txtClients[clientName].KeyDown += new System.Windows.Forms.KeyEventHandler(KeyDown_txtClients);//// the Event 

            //btn
            btnClients[clientName].Width = 2 * (w - 3 * xPos) / 5; ;
            btnClients[clientName].Height = h;
            btnClients[clientName].Text = "send";

            btnClients[clientName].Left = txtClients[clientName].Left + txtClients[clientName].Width + xPos;
            btnClients[clientName].Top = radClients[clientName].Top + radClients[clientName].Height;

            panelClients.Controls.Add(btnClients[clientName]);

            btnClients[clientName].Click += new System.EventHandler(Click_btnClients);//// the Event of click Button



        }
        public void Click_btnClients(Object sender, System.EventArgs e)
        {
            //System.Windows.Forms.MessageBox.Show("send to " +  ((System.Windows.Forms.Button)sender).Tag.ToString());
            int tg = (int)(((System.Windows.Forms.Button)sender).Tag);
            string cName = ClientsPos[tg];

            SendTextToClient(cName);

        }
        public void Click_radClients(Object sender, System.EventArgs e)
        {
            //System.Windows.Forms.MessageBox.Show("send to " +  ((System.Windows.Forms.Button)sender).Tag.ToString());
            int tg = (int)(((System.Windows.Forms.RadioButton)sender).Tag);
            string cName = ClientsPos[tg];
            //  if (radClients[cName].Checked) radClients[cName].Checked = false; ;

            METState.Current.server.ForcedActiveScreen = radClients[cName].Checked ? cName : "";
            METState.Current.server.activeScreen = METState.Current.server.ForcedActiveScreen;


        }
        public void KeyDown_txtClients(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                int tg = (int)(((System.Windows.Forms.TextBox)sender).Tag);

                string cName = ClientsPos[tg];
                SendTextToClient(cName);
            }


        }
        public void SendTextToClient(string cName)
        {
            METState.Current.server.Send(cName, txtClients[cName].Text);




            METState.Current.METCoreObject.SendToForm("\r\n To " + cName + ": " + txtClients[cName].Text + "\r\n", "TextBoxServer");
            txtClients[cName].Text = "";

        }


        //.......................................................................


        private void cmbDevice_Update(bool eye, bool scene)
        {

            System.Threading.Tasks.Task.Factory.StartNew(() =>
                {
                    var find = new VideoSource.FindCamera();
                    find.Search();
                    var devices = find.DeviceList.ToArray();

                    this.Invoke((MethodInvoker)delegate
                    {
                        if (eye)
                        {
                            var eyeSelDvc = cmbDeviceEye.SelectedItem;
                            cmbDeviceEye.BeginUpdate();
                            cmbDeviceEye.Items.Clear();

                            cmbDeviceCapabilityEye.Items.Clear();
                            cmbDeviceCapabilityEye.Text = "";

                            cmbDeviceEye.Items.AddRange(devices);
                            cmbDeviceEye.EndUpdate();
                            cmbDeviceEye.SelectedItem = eyeSelDvc;

                        }
                        if (scene)
                        {
                            var SelDvc = cmbDeviceScene.SelectedItem;
                            cmbDeviceScene.BeginUpdate();
                            cmbDeviceScene.Items.Clear();
                            cmbDeviceCapabilityScene.Items.Clear();
                            cmbDeviceCapabilityScene.Text = "";
                            cmbDeviceScene.Items.AddRange(devices);
                            cmbDeviceScene.EndUpdate();
                            cmbDeviceScene.SelectedItem = SelDvc;

                        }

                        if (eye & scene)
                        {
                            switch (devices.Count())
                            {
                                case 0:
                                    break;

                                case 1:
                                    cmbDeviceEye.SelectedIndex = 0;
                                    cmbDeviceScene.SelectedIndex = 0;
                                    break;

                                case 2:
                                    cmbDeviceEye.SelectedIndex = 1;
                                    cmbDeviceScene.SelectedIndex = 0;
                                    break;

                                default:
                                    //IN 2TA Jabeja MItoonan beshan
                                    cmbDeviceEye.SelectedIndex = 1;
                                    cmbDeviceScene.SelectedIndex = 0;
                                    break;
                            }
                        }
                    });
                });
        }


        private void cmbDeviceEye_SelectedIndexChanged(object sender, EventArgs e)
        {
            var dev = cmbDeviceEye.SelectedItem as VideoSource.IVideoSource;
            if (dev == null) return;

            var cmbCap = this.cmbDeviceCapabilityEye;
            cmbCap.BeginUpdate();
            cmbCap.Items.Clear();
            cmbCap.Items.AddRange(dev.Capabilities.ToArray());
            if (cmbCap.Items.Count > 0)
                cmbCap.SelectedIndex = 0;
            cmbCap.EndUpdate();

            this.btnSettingsEye.Visible = dev.HasSettings;

        }
        private void cmbDeviceScene_SelectedIndexChanged(object sender, EventArgs e)
        {
            var dev = cmbDeviceScene.SelectedItem as VideoSource.IVideoSource;
            if (dev == null) return;

            var cmbCap = this.cmbDeviceCapabilityScene;
            cmbCap.BeginUpdate();
            cmbCap.Items.Clear();
            cmbCap.Items.AddRange(dev.Capabilities.ToArray());
            if (cmbCap.Items.Count > 0)
                cmbCap.SelectedIndex = 0;
            cmbCap.EndUpdate();

            this.btnSettingsScene.Visible = dev.HasSettings;
        }

        private void imScene_MouseClick(object sender, MouseEventArgs e)
        {
            if (METState.Current.remoteOrMobile == METState.RemoteOrMobile.GoogleGalss)
            {
                if (e.Button == MouseButtons.Left)
                {
                    if (METState.Current.EyeToScene_Mapping.Calibrated == false)//not to do one point calibration during the main calibration
                    {
                        switch (METState.Current.EyeToScene_Mapping.CalibrationType)
                        {
                            case Calibration.calibration_type.calib_Polynomial:

                                METState.Current.EyeToScene_Mapping.GazeErrorX = 0;
                                METState.Current.EyeToScene_Mapping.GazeErrorY = 0;

                                if (METState.Current.EyeToScene_Mapping.CalibrationTarget < 9 & btnCalibration_Polynomial.Enabled == false)
                                {

                                    METState.Current.EyeToScene_Mapping.ScenePoints.Add(new AForge.Point(e.X, e.Y));
                                    METState.Current.EyeToScene_Mapping.Destination[0, METState.Current.EyeToScene_Mapping.CalibrationTarget] = e.X;///METState.Current.Kw_SceneImg;
                                    METState.Current.EyeToScene_Mapping.Destination[1, METState.Current.EyeToScene_Mapping.CalibrationTarget] = e.Y;///METState.Current.Kh_SceneImg;

                                    METState.Current.EyeToScene_Mapping.Source[0, METState.Current.EyeToScene_Mapping.CalibrationTarget] = METState.Current.eyeFeature.X;
                                    METState.Current.EyeToScene_Mapping.Source[1, METState.Current.EyeToScene_Mapping.CalibrationTarget] = METState.Current.eyeFeature.Y;


                                    METState.Current.EyeToScene_Mapping.CalibrationTarget++;

                                    if (METState.Current.EyeToScene_Mapping.CalibrationTarget == 9)
                                    {

                                        METState.Current.EyeToScene_Mapping.CalibrationTarget = 0;
                                        METState.Current.EyeToScene_Mapping.Calibrate();


                                        METState.Current.EyeToScene_Mapping.Calibrated = true;
                                        btnCalibration_Polynomial.Enabled = true;

                                        lbl_calibration.Visible = false;
                                    }
                                }
                                break;
                            case Calibration.calibration_type.calib_Homography:
                                if (METState.Current.EyeToScene_Mapping.CalibrationTarget < 4 & btnCalibration_Homography.Enabled == false)
                                {

                                    METState.Current.EyeToScene_Mapping.ScenePoints.Add(new AForge.Point(e.X, e.Y));
                                    METState.Current.EyeToScene_Mapping.Destination[0, METState.Current.EyeToScene_Mapping.CalibrationTarget] = e.X;///METState.Current.Kw_SceneImg;
                                    METState.Current.EyeToScene_Mapping.Destination[1, METState.Current.EyeToScene_Mapping.CalibrationTarget] = e.Y;///METState.Current.Kh_SceneImg;

                                    METState.Current.EyeToScene_Mapping.Source[0, METState.Current.EyeToScene_Mapping.CalibrationTarget] = METState.Current.eyeFeature.X;
                                    METState.Current.EyeToScene_Mapping.Source[1, METState.Current.EyeToScene_Mapping.CalibrationTarget] = METState.Current.eyeFeature.Y;


                                    METState.Current.EyeToScene_Mapping.CalibrationTarget++;

                                    if (METState.Current.EyeToScene_Mapping.CalibrationTarget == 4)
                                    {

                                        METState.Current.EyeToScene_Mapping.CalibrationTarget = 0;
                                        METState.Current.EyeToScene_Mapping.Calibrate();


                                        METState.Current.EyeToScene_Mapping.Calibrated = true;
                                        btnCalibration_Homography.Enabled = true;
                                        lbl_calibration.Visible = false;
                                    }
                                }
                                break;
                        }
                    }
                    else
                    {
                        AForge.Point Gaze = METState.Current.EyeToScene_Mapping.Map(METState.Current.eyeFeature.X, METState.Current.eyeFeature.Y, e.X, e.Y);

                        METState.Current.EyeToScene_Mapping.GazeErrorX = Gaze.X;// / METState.Current.Kw_SceneImg);
                        METState.Current.EyeToScene_Mapping.GazeErrorY = Gaze.Y;// / METState.Current.Kh_SceneImg);

                    }
                }
            }

            else if (METState.Current.remoteOrMobile == METState.RemoteOrMobile.MobileEyeTracking)
            {
                if (e.Button == MouseButtons.Left)
                {
                    if (METState.Current.EyeToScene_Mapping.Calibrated == false)//not to do one point calibration during the main calibration
                    {
                        switch (METState.Current.EyeToScene_Mapping.CalibrationType)
                        {
                            case Calibration.calibration_type.calib_Polynomial:

                                METState.Current.EyeToScene_Mapping.GazeErrorX = 0;
                                METState.Current.EyeToScene_Mapping.GazeErrorY = 0;

                                if (METState.Current.EyeToScene_Mapping.CalibrationTarget < 9 & btnCalibration_Polynomial.Enabled == false)
                                {

                                    METState.Current.EyeToScene_Mapping.ScenePoints.Add(new AForge.Point(e.X, e.Y));
                                    METState.Current.EyeToScene_Mapping.Destination[0, METState.Current.EyeToScene_Mapping.CalibrationTarget] = e.X;///METState.Current.Kw_SceneImg;
                                    METState.Current.EyeToScene_Mapping.Destination[1, METState.Current.EyeToScene_Mapping.CalibrationTarget] = e.Y;///METState.Current.Kh_SceneImg;

                                    METState.Current.EyeToScene_Mapping.Source[0, METState.Current.EyeToScene_Mapping.CalibrationTarget] = METState.Current.eyeFeature.X;
                                    METState.Current.EyeToScene_Mapping.Source[1, METState.Current.EyeToScene_Mapping.CalibrationTarget] = METState.Current.eyeFeature.Y;


                                    METState.Current.EyeToScene_Mapping.CalibrationTarget++;

                                    if (METState.Current.EyeToScene_Mapping.CalibrationTarget == 9)
                                    {

                                        METState.Current.EyeToScene_Mapping.CalibrationTarget = 0;
                                        METState.Current.EyeToScene_Mapping.Calibrate();


                                        METState.Current.EyeToScene_Mapping.Calibrated = true;
                                        btnCalibration_Polynomial.Enabled = true;

                                        lbl_calibration.Visible = false;
                                    }
                                }
                                break;
                            case Calibration.calibration_type.calib_Homography:
                                if (METState.Current.EyeToScene_Mapping.CalibrationTarget < 4 & btnCalibration_Homography.Enabled == false)
                                {

                                    METState.Current.EyeToScene_Mapping.ScenePoints.Add(new AForge.Point(e.X, e.Y));
                                    METState.Current.EyeToScene_Mapping.Destination[0, METState.Current.EyeToScene_Mapping.CalibrationTarget] = e.X;///METState.Current.Kw_SceneImg;
                                    METState.Current.EyeToScene_Mapping.Destination[1, METState.Current.EyeToScene_Mapping.CalibrationTarget] = e.Y;///METState.Current.Kh_SceneImg;

                                    METState.Current.EyeToScene_Mapping.Source[0, METState.Current.EyeToScene_Mapping.CalibrationTarget] = METState.Current.eyeFeature.X;
                                    METState.Current.EyeToScene_Mapping.Source[1, METState.Current.EyeToScene_Mapping.CalibrationTarget] = METState.Current.eyeFeature.Y;


                                    METState.Current.EyeToScene_Mapping.CalibrationTarget++;

                                    if (METState.Current.EyeToScene_Mapping.CalibrationTarget == 4)
                                    {

                                        METState.Current.EyeToScene_Mapping.CalibrationTarget = 0;
                                        METState.Current.EyeToScene_Mapping.Calibrate();


                                        METState.Current.EyeToScene_Mapping.Calibrated = true;
                                        btnCalibration_Homography.Enabled = true;
                                        lbl_calibration.Visible = false;
                                    }
                                }
                                break;
                        }
                    }
                    else
                    {
                        AForge.Point Gaze = METState.Current.EyeToScene_Mapping.Map(METState.Current.eyeFeature.X, METState.Current.eyeFeature.Y, e.X, e.Y);

                        METState.Current.EyeToScene_Mapping.GazeErrorX = Gaze.X;// / METState.Current.Kw_SceneImg);
                        METState.Current.EyeToScene_Mapping.GazeErrorY = Gaze.Y;// / METState.Current.Kh_SceneImg);

                    }
                }
            }
        }
        private void trackBarG_ValueChanged(object sender, EventArgs e)
        {
            METState.Current.monitor.GThreshold = trackBarG.Value;
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            METState.Current.GlassServer.Close();
            METState.Current.server.Close();
            Thread.Sleep(10);
            // METState.Current.server = null;

        }
        private void lbCommandsToGlass_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            METState.Current.GlassServer.Send(
                (int)(METState.Current.commands[(string)lbCommandsToGlass.SelectedItem]));
        }
        Point p_mouse = new Point(0, 0);
        private void pictureBox2_MouseMove(object sender, MouseEventArgs e)
        {
            SizeF s = new SizeF(pictureBox2.Width, pictureBox2.Height);
            Point coord = new Point((int)(e.Location.X * (double)myGlass.constants.display_W / s.Width), (int)(e.Location.Y * (double)myGlass.constants.display_H / s.Height));

            if (p_mouse != coord)
            {
                //Console.WriteLine(METState.Current.GlassServer.client.socketStream.);

                if (METState.Current.GlassServer.gazeStream_RGT == myGlass.Server.GazeStream.RGT) METState.Current.GlassServer.Send(myGlass.MessageType.toGLASS_GAZE_RGT, coord);
                if (METState.Current.GlassServer.gazeStream_HMGT == myGlass.Server.GazeStream.HMGT) METState.Current.GlassServer.Send(myGlass.MessageType.toGLASS_GAZE_HMGT, coord);



                p_mouse = new Point(coord.X, coord.Y);



            }
        }
        private void cbRemoveGlint_CheckedChanged(object sender, EventArgs e)
        {

            METState.Current.RemoveGlint = cbRemoveGlint.Checked;

        }

        private void radioButtonAutoActivation_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonAutoActivation.Checked) METState.Current.server.ForcedActiveScreen = "";
        }


        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            METState.Current.enablePlot = cbPlot.Checked;
        }



        private void button1_Click_2(object sender, EventArgs e)
        {
            METState.Current.METCoreObject.SaveCameraCalibrationData();

        }



        private void trackBarControl4_ValueChanged(object sender, EventArgs e)
        {
            METState.Current.PAdaptive_blockSize = trackBarPABlockSize.Value % 2 != 0 ? trackBarPABlockSize.Value : trackBarPABlockSize.Value + 1;

        }


        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            METState.Current.PAdaptive_type = Emgu.CV.CvEnum.ADAPTIVE_THRESHOLD_TYPE.CV_ADAPTIVE_THRESH_MEAN_C;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            METState.Current.PAdaptive_type = Emgu.CV.CvEnum.ADAPTIVE_THRESHOLD_TYPE.CV_ADAPTIVE_THRESH_GAUSSIAN_C;

        }


        private void rbGMean_CheckedChanged(object sender, EventArgs e)
        {
            METState.Current.GAdaptive_type = Emgu.CV.CvEnum.ADAPTIVE_THRESHOLD_TYPE.CV_ADAPTIVE_THRESH_MEAN_C;

        }

        private void rbGGaussian_CheckedChanged(object sender, EventArgs e)
        {
            METState.Current.GAdaptive_type = Emgu.CV.CvEnum.ADAPTIVE_THRESHOLD_TYPE.CV_ADAPTIVE_THRESH_GAUSSIAN_C;

        }

        private void trackBarGABlockSize_ValueChanged(object sender, EventArgs e)
        {
            METState.Current.GAdaptive_blockSize = trackBarGABlockSize.Value % 2 != 0 ? trackBarGABlockSize.Value : trackBarGABlockSize.Value + 1;

        }


        private void cbGazeSmoothing_CheckedChanged(object sender, EventArgs e)
        {
            METState.Current.GazeSmoother = cbGazeSmoothing.Checked;

        }



        private void trackBarControl3_MouseEnter(object sender, EventArgs e)
        {
            METState.Current.showScreenSize = true;
        }
        private void trackBarControl3_MouseLeave(object sender, EventArgs e)
        {
            METState.Current.showScreenSize = false;

        }


        private void btnEyeStart_Click(object sender, EventArgs e)
        {
            if (btnStartEye.Text == "Start")
            {
                btnStartEye.Text = "Stop";

                var camOld = METState.Current.EyeCamera;
                if (camOld != null && camOld.IsRunning)
                    camOld.Stop();
                var cam = cmbDeviceEye.SelectedItem as VideoSource.IVideoSource;
                cam.SelectedCap = (VideoSource.DeviceCapabilityInfo)cmbDeviceCapabilityEye.SelectedItem;
                METState.Current.EyeCamera = cam;

                METState.Current.EyeCamera.NewFrame += new AForge.Video.NewFrameEventHandler(METState.Current.METCoreObject.EyeFrameCaptured);

                METState.Current.METCoreObject.TrackerEventEye += new TrackerEventHandler(imEyeUpdate);
                METState.Current.camera1Acquired = new AutoResetEvent(false);

                cam.Start();
                startBoothVideos.Enabled = false;
            }
            else
            {
                //stop video
                btnStartEye.Text = "Start";
                METState.Current.METCoreObject.TrackerEventEye -= new TrackerEventHandler(imEyeUpdate);

                var camOld = METState.Current.EyeCamera;
                if (camOld.IsRunning)
                    camOld.Stop();

                imEye.Image = null;
                imEye.Size = System.Drawing.Size.Empty;
                bFirstFrameEye = false;

                startBoothVideos.Enabled = true;
            }
        }


        private void btnEyeSettingClick(object sender, EventArgs e)
        {
            var src = (cmbDeviceEye.SelectedItem as VideoSource.IVideoSource);
            if (src != null && src.HasSettings)
                src.ShowSettings();
        }
        private void btnSceneSetting_Click(object sender, EventArgs e)
        {
            var src = (cmbDeviceScene.SelectedItem as VideoSource.IVideoSource);
            if (src != null && src.HasSettings)
                src.ShowSettings();
        }

        private void btnSceneStart_Click(object sender, EventArgs e)
        {

            if (btnStartScene.Text == "Start")
            {
                btnStartScene.Text = "Stop";

                var camOld = METState.Current.SceneCamera;
                if (camOld != null && camOld.IsRunning)
                    camOld.Stop();
                var cam = cmbDeviceScene.SelectedItem as VideoSource.IVideoSource;
                cam.SelectedCap = (VideoSource.DeviceCapabilityInfo)cmbDeviceCapabilityScene.SelectedItem;
                METState.Current.SceneCamera = cam;

                METState.Current.SceneCamera.NewFrame += new AForge.Video.NewFrameEventHandler(METState.Current.METCoreObject.SceneFrameCaptured);

                METState.Current.METCoreObject.TrackerEventScene += new TrackerEventHandler(imSceneUpdate);

                #region IDONT know
                if (METState.Current.METCoreObject.LoadCameraCalibrationData())
                {
                    #region Find Intrinsic & Extrinsic Camera Parameters

                    try
                    {
                        for (int i = 0; i < METState.Current.cameraCalibrationSamples; i++)
                            METState.Current.extrinsic_param[i] = new ExtrinsicCameraParameters();

                        if (cam is VideoSource.AforgeVideoSource || cam is VideoSource.FileVideoSource)
                        {
                            var cAF = cam as VideoSource.IVideoSource;

                            CameraCalibration.CalibrateCamera(METState.Current.object_points, METState.Current.image_points,
                                new Size(cAF.VideoSize.Width, cAF.VideoSize.Height),
                                METState.Current.intrinsic_param, Emgu.CV.CvEnum.CALIB_TYPE.DEFAULT, out  METState.Current.extrinsic_param);
                        }
                        //METState.Current.sceneCameraUnDistortion = true;
                        //cbSceneUnDistortion.Checked = true;

                        METState.Current.sceneCameraCalibrating = false;
                    }


                    #endregion Find Intrinsic & Extrinsic Camera Parameters

                    catch (Exception er)
                    {
                        System.Windows.Forms.MessageBox.Show(er.Message.ToString());
                    }

                }
                #endregion

                cam.Start();
                startBoothVideos.Enabled = false;
            }
            else
            {
                //stop video
                btnStartScene.Text = "Start";
                METState.Current.METCoreObject.TrackerEventScene -= new TrackerEventHandler(imSceneUpdate);

                var camOld = METState.Current.SceneCamera;
                if (camOld.IsRunning)
                    camOld.Stop();

                bFirstFrameScene = false;
                bFirstFrameSceneProcessed = false;

                imScene.Image = null;
                imScene.Size = Size.Empty;
                imSceneProcessed.Image = null;
                imSceneProcessed.Size = Size.Empty;

                //panelImScene.Width = 0;
                startBoothVideos.Enabled = true;
            }

        }



        private void button1_Click_5(object sender, EventArgs e)
        {
            if (btnStartEye.Text == "Start" & btnStartScene.Text == "Start")
            {
                btnEyeStart_Click(sender, e);
                btnSceneStart_Click(sender, e);
            }
        }

        private void transparentTrackBar1_ValueChanged(object sender, EventArgs e)
        {
            METState.Current.IrisDiameter = trackBarControl2.Value;

        }

        private void checkBox2_CheckedChanged_2(object sender, EventArgs e)
        {
            cbShowIris.BackColor = cbShowIris.Checked ? Color.Yellow : Color.Transparent;
            METState.Current.showIris = cbShowIris.Checked;

        }

        private void checkBox2_CheckedChanged_3(object sender, EventArgs e)
        {
            METState.Current.detectPupil = cbPupilDetection.Checked;
            METState.Current.firstPupilDetection = cbPupilDetection.Checked;

        }

        private void checkBox2_CheckedChanged_4(object sender, EventArgs e)
        {
            cbShowPupil.BackColor = cbShowPupil.Checked ? Color.Yellow : Color.Transparent;

            METState.Current.showPupil = cbShowPupil.Checked;

        }



        private void radioButton1_CheckedChanged_1(object sender, EventArgs e)
        {
            METState.Current.PAdaptive = true;
            trackBarPAConstant.Enabled = cbPA.Checked;

        }

        private void radioButton2_CheckedChanged_1(object sender, EventArgs e)
        {
            METState.Current.PAdaptive = false;
            trackBarThresholdEye.Enabled = cbPM.Checked;

        }



        private void transparentTrackBar1_ValueChanged_1(object sender, EventArgs e)
        {
            METState.Current.PupilThreshold = trackBarThresholdEye.Value;

        }

        private void transparentTrackBar1_ValueChanged_2(object sender, EventArgs e)
        {
            METState.Current.PAdaptive_Constant = trackBarPAConstant.Value;

        }



        private void checkBox2_CheckedChanged_6(object sender, EventArgs e)
        {
            METState.Current.DilateErode = cbDilateErode.Checked;

        }

        private void checkBox3_CheckedChanged_1(object sender, EventArgs e)
        {
            METState.Current.RemoveGlint = cbRemoveGlint.Checked;

        }

        private void checkBox2_CheckedChanged_7(object sender, EventArgs e)
        {
            METState.Current.detectGlint = cbGlintDetection.Checked;

            if (METState.Current.detectGlint) rbPupilGlint.Checked = true;
            else rdOnlyPupil.Checked = true;

            if (rbPupilGlint.Checked) METState.Current.calibration_eyeFeature = METState.Calibration_EyeFeature.PupilGlintVector;
            else if (rdOnlyPupil.Checked) METState.Current.calibration_eyeFeature = METState.Calibration_EyeFeature.Pupil;
            else if (rbGlint.Checked) METState.Current.calibration_eyeFeature = METState.Calibration_EyeFeature.Glint;

        }

        private void checkBox2_CheckedChanged_8(object sender, EventArgs e)
        {
            cbShowGlint.BackColor = cbShowGlint.Checked ? Color.Yellow : Color.Transparent;

            METState.Current.showGlint = cbShowGlint.Checked;

        }

        private void radioButton2_CheckedChanged_2(object sender, EventArgs e)
        {
            METState.Current.GAdaptive = true;
            trackBarGAConstant.Enabled = cbGA.Checked;

        }

        private void radioButton1_CheckedChanged_2(object sender, EventArgs e)
        {
            METState.Current.GAdaptive = false;
            trackBarThresholdGlint.Enabled = cbGM.Checked;

        }

        private void transparentTrackBar2_ValueChanged(object sender, EventArgs e)
        {
            METState.Current.glintThreshold = trackBarThresholdGlint.Value;

        }

        private void transparentTrackBar1_ValueChanged_3(object sender, EventArgs e)
        {
            METState.Current.GAdaptive_Constant = trackBarGAConstant.Value - trackBarGAConstant.Maximum / 2;

        }



        private void radioButton2_CheckedChanged_3(object sender, EventArgs e)
        {
            METState.Current.PAdaptive_type = Emgu.CV.CvEnum.ADAPTIVE_THRESHOLD_TYPE.CV_ADAPTIVE_THRESH_MEAN_C;

        }

        private void radioButton1_CheckedChanged_3(object sender, EventArgs e)
        {
            METState.Current.PAdaptive_type = Emgu.CV.CvEnum.ADAPTIVE_THRESHOLD_TYPE.CV_ADAPTIVE_THRESH_GAUSSIAN_C;

        }

        private void trackBarPABlockSize_ValueChanged(object sender, EventArgs e)
        {
            METState.Current.PAdaptive_blockSize = trackBarPABlockSize.Value % 2 != 0 ? trackBarPABlockSize.Value : trackBarPABlockSize.Value + 1;

        }

        private void radioButton2_CheckedChanged_4(object sender, EventArgs e)
        {
            METState.Current.GAdaptive_type = Emgu.CV.CvEnum.ADAPTIVE_THRESHOLD_TYPE.CV_ADAPTIVE_THRESH_MEAN_C;

        }

        private void radioButton1_CheckedChanged_4(object sender, EventArgs e)
        {
            METState.Current.GAdaptive_type = Emgu.CV.CvEnum.ADAPTIVE_THRESHOLD_TYPE.CV_ADAPTIVE_THRESH_GAUSSIAN_C;

        }

        private void transparentTrackBar1_ValueChanged_4(object sender, EventArgs e)
        {
            METState.Current.GAdaptive_blockSize = trackBarGABlockSize.Value % 2 != 0 ? trackBarGABlockSize.Value : trackBarGABlockSize.Value + 1;

        }



        private void checkBox2_CheckedChanged_10(object sender, EventArgs e)
        {
            cbShowScreen.BackColor = cbShowScreen.Checked ? Color.Yellow : Color.Transparent;

            METState.Current.showScreen = cbShowScreen.Checked;

        }

        private void transparentTrackBar1_ValueChanged_5(object sender, EventArgs e)
        {
            METState.Current.monitor.BThreshold = trackBarB.Value;

        }

        private void transparentTrackBar2_ValueChanged_1(object sender, EventArgs e)
        {
            METState.Current.monitor.GThreshold = trackBarG.Value;

        }

        private void transparentTrackBar3_ValueChanged(object sender, EventArgs e)
        {
            METState.Current.monitor.rectangleMinSize = trackBarControl3.Value;

        }

        private void checkBox2_CheckedChanged_11(object sender, EventArgs e)
        {
            METState.Current.sceneCameraUnDistortion = cbSceneUnDistortion.Checked;

        }

        private void button1_Click_6(object sender, EventArgs e)
        {

            imSceneProcessed.SizeMode = PictureBoxSizeMode.AutoSize;
            #region camera calibration
            try
            {

                if (!METState.Current.sceneCameraCalibrating)
                {
                    //Set Variables
                    METState.Current.sceneCameraUnDistortion = false;
                    cbSceneUnDistortion.Checked = false;

                    METState.Current.sceneCameraCalibrating = true;
                    METState.Current.cameraCalibrationSamplesCount = 0;
                    METState.Current.object_points = new MCvPoint3D32f[METState.Current.cameraCalibrationSamples][];
                    METState.Current.image_points = new PointF[METState.Current.cameraCalibrationSamples][];
                    METState.Current.corners = new PointF[] { };
                    METState.Current.intrinsic_param = new IntrinsicCameraParameters();
                    METState.Current.extrinsic_param = new ExtrinsicCameraParameters[METState.Current.cameraCalibrationSamples];
                    btnSceneCameraCalibration.Text = string.Format("Grab ChessBoard {0}/{1}", 1, METState.Current.cameraCalibrationSamples);
                }
                else
                {
                    Image<Gray, Byte> GrayImg = METState.Current.SceneImageOrginal.Convert<Gray, Byte>();// EmgImgProcssing.BGRtoGray(e.image);

                    METState.Current.corners = Emgu.CV.CameraCalibration.FindChessboardCorners(GrayImg,
                           new Size(METState.Current.ChessBoard_W, METState.Current.ChessBoard_H),
                     Emgu.CV.CvEnum.CALIB_CB_TYPE.ADAPTIVE_THRESH | Emgu.CV.CvEnum.CALIB_CB_TYPE.DEFAULT);
                    //Emgu.CV.CvEnum.CALIB_CB_TYPE.ADAPTIVE_THRESH | Emgu.CV.CvEnum.CALIB_CB_TYPE.NORMALIZE_IMAGE | Emgu.CV.CvEnum.CALIB_CB_TYPE.FILTER_QUADS


                    Emgu.CV.CameraCalibration.DrawChessboardCorners(GrayImg, new Size(METState.Current.ChessBoard_W, METState.Current.ChessBoard_H), METState.Current.corners);

                    METState.Current.SceneImageProcessed = new Image<Bgr, byte>(GrayImg.Bitmap);

                    GrayImg.FindCornerSubPix(new PointF[][] { METState.Current.corners }, new Size(5, 5), new Size(-1, -1), new MCvTermCriteria(0.05));

                    if (METState.Current.corners.Length == METState.Current.ChessBoard_W * METState.Current.ChessBoard_H)
                    {
                        METState.Current.object_points[METState.Current.cameraCalibrationSamplesCount] = new MCvPoint3D32f[54];
                        for (int j = 0; j < METState.Current.ChessBoard_W * METState.Current.ChessBoard_H; j++)
                        {
                            METState.Current.image_points[METState.Current.cameraCalibrationSamplesCount] = METState.Current.corners;
                            //....Later
                            METState.Current.object_points[METState.Current.cameraCalibrationSamplesCount][j].x = j / METState.Current.ChessBoard_W;
                            METState.Current.object_points[METState.Current.cameraCalibrationSamplesCount][j].y = j % METState.Current.ChessBoard_W;
                            METState.Current.object_points[METState.Current.cameraCalibrationSamplesCount][j].z = 0.0f;
                        }
                        METState.Current.cameraCalibrationSamplesCount++;
                        btnSceneCameraCalibration.Text = string.Format("Grab ChessBoard {0}/{1}", METState.Current.cameraCalibrationSamplesCount, METState.Current.cameraCalibrationSamples);

                    }
                    if (METState.Current.cameraCalibrationSamplesCount == METState.Current.cameraCalibrationSamples)//Samples collected
                    {

                        // MessageBox.Show(METState.Current.cameraCalibrationSamplesCount.ToString() + " chessboard founded");

                        #region Find Intrinsic & Extrinsic Camera Parameters

                        for (int i = 0; i < METState.Current.cameraCalibrationSamples; i++)
                            METState.Current.extrinsic_param[i] = new ExtrinsicCameraParameters();

                        CameraCalibration.CalibrateCamera(METState.Current.object_points, METState.Current.image_points, new Size(GrayImg.Width, GrayImg.Height), METState.Current.intrinsic_param, Emgu.CV.CvEnum.CALIB_TYPE.DEFAULT, out  METState.Current.extrinsic_param);

                        #endregion Find Intrinsic & Extrinsic Camera Parameters

                        METState.Current.sceneCameraUnDistortion = true;
                        cbSceneUnDistortion.Checked = true;

                        METState.Current.sceneCameraCalibrating = false;
                        btnSceneCameraCalibration.Text = "Camera Calibration";
                        METState.Current.SceneImageProcessed = null;

                        METState.Current.METCoreObject.SaveCameraCalibrationData();

                    }
                }
            }
            catch (Exception er)
            {
                // System.Windows.Forms.MessageBox.Show(er.Message.ToString());
                System.Windows.Forms.MessageBox.Show("Corners not detected!");


            }
            #endregion camera calibration
        }



        private void radioButton2_CheckedChanged_5(object sender, EventArgs e)
        {
            if (rdOnlyPupil.Checked) METState.Current.calibration_eyeFeature = METState.Calibration_EyeFeature.Pupil;

        }

        private void radioButton1_CheckedChanged_5(object sender, EventArgs e)
        {
            if (rbPupilGlint.Checked) METState.Current.calibration_eyeFeature = METState.Calibration_EyeFeature.PupilGlintVector;

        }

        private void button1_Click_7(object sender, EventArgs e)
        {
            lbl_calibration.Text = "Click on 9 points in the scene image while the user is looking at the corresponding points in the field of view";
            lbl_calibration.Visible = true;

            METState.Current.EyeToScene_Mapping.ScenePoints = new List<AForge.Point>();
            METState.Current.EyeToScene_Mapping.GazeErrorX = 0;
            METState.Current.EyeToScene_Mapping.GazeErrorY = 0;

            METState.Current.EyeToScene_Mapping.CalibrationTarget = 0;
            METState.Current.EyeToScene_Mapping.Calibrated = false;// ta click rooye scene noghtegiri shavad na eslah
            METState.Current.EyeToScene_Mapping.CalibrationType = Calibration.calibration_type.calib_Polynomial;




            btnCalibration_Polynomial.Enabled = false;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            lbl_calibration.Text = "Click on 4 points in the scene image while the user is looking at the corresponding points in the field of view";
            lbl_calibration.Visible = true;

            METState.Current.EyeToScene_Mapping.ScenePoints = new List<AForge.Point>();
            METState.Current.EyeToScene_Mapping.GazeErrorX = 0;
            METState.Current.EyeToScene_Mapping.GazeErrorY = 0;


            METState.Current.EyeToScene_Mapping.CalibrationTarget = 0;
            METState.Current.EyeToScene_Mapping.Calibrated = false;// ta click rooye scene noghtegiri shavad na eslah

            METState.Current.EyeToScene_Mapping.CalibrationType = Calibration.calibration_type.calib_Homography;
            btnCalibration_Homography.Enabled = false;
        }

        private void checkBox2_CheckedChanged_13(object sender, EventArgs e)
        {
            METState.Current.GazeSmoother = cbGazeSmoothing.Checked;

        }



        private void cbShowGaze_CheckedChanged_2(object sender, EventArgs e)
        {
            cbShowGaze.BackColor = cbShowGaze.Checked ? Color.Yellow : Color.Transparent;
            METState.Current.ShowGaze = cbShowGaze.Checked;

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }


        private void checkBox2_CheckedChanged_14(object sender, EventArgs e)
        {
            METState.Current.enablePlot = cbPlot.Checked;

        }






        private void cbShowEdges_CheckedChanged(object sender, EventArgs e)
        {
            cbShowEdges.BackColor = cbShowEdges.Checked ? Color.Yellow : Color.Transparent;

            METState.Current.showEdges = cbShowEdges.Checked;
        }


        //.......................................................................Updating the Form.......................................................................

        public void UpdateControl(object message, string controlName)
        {
            string s = "";
            if (METState.Current.TimerEnable == true)
            {
                switch (controlName)
                {

                    case "textBoxTimerEye":
                        if (comboBox_EyeTimer.InvokeRequired)
                        {
                            Invoke(new _SendToForm(UpdateControl), new object[] { message, "textBoxTimerEye" });
                        }
                        else
                        {

                            comboBox_EyeTimer.Items.Clear();
                            foreach (KeyValuePair<string, object> kvp in METState.Current.ProcessTimeEyeBranch.TimerResults.Reverse())
                            {
                                if (kvp.Key == "Total")
                                {
                                    // comboBox_EyeTimer.Items.Add("Eye: " + kvp.Value.ToString() + " ms");// kvp.Key +
                                    // comboBox_EyeTimer.SelectedIndex = 0;
                                    comboBox_EyeTimer.Text = "Eye: " + kvp.Value.ToString() + " ms";
                                }
                                else
                                {
                                    comboBox_EyeTimer.Items.Add(kvp.Key + ": " + kvp.Value.ToString() + " ms");

                                }
                            }

                        }
                        break;
                    case "textBoxTimerScene":
                        if (comboBox_SceneTimer.InvokeRequired)
                        {
                            Invoke(new _SendToForm(UpdateControl), new object[] { message, "textBoxTimerScene" });
                        }
                        else
                        {
                            comboBox_SceneTimer.Items.Clear();

                            foreach (KeyValuePair<string, object> kvp in METState.Current.ProcessTimeSceneBranch.TimerResults.Reverse())
                            {
                                if (kvp.Key == "Total")
                                {
                                    //Undistortion was in another thread and was not in the total loop
                                    if (METState.Current.ProcessTimeSceneBranch.TimerResults.ContainsKey("UnDistortion"))
                                    {
                                        // comboBox_SceneTimer.Items.Add("Scene: " + ((double)kvp.Value + (double)METState.Current.ProcessTimeSceneBranch.TimerResults["UnDistortion"]).ToString() + " ms");// kvp.Key +
                                        // comboBox_SceneTimer.SelectedIndex = 0;
                                        comboBox_SceneTimer.Text = "Scene: " + ((double)kvp.Value + (double)METState.Current.ProcessTimeSceneBranch.TimerResults["UnDistortion"]).ToString() + " ms";
                                    }
                                    else
                                    {
                                        comboBox_SceneTimer.Items.Add("Scene: " + kvp.Value.ToString() + " ms");// kvp.Key +
                                        comboBox_SceneTimer.SelectedIndex = 0;
                                    }
                                }
                                else
                                {
                                    comboBox_SceneTimer.Items.Add(kvp.Key + ": " + kvp.Value.ToString() + " ms");
                                }
                            }
                        }
                        break;



                }
            }
            Func<int> del;
            switch (controlName)
            {

                case "Update Glass Picturebox":

                    try
                    {
                        //imScene.Image = null;
                        _bitmapPicturebox2 = (Bitmap)imScene.Image;//(Image)METState.Current.GlassServer.client.bitmap.Clone();  
                        pictureBox2.Invalidate();
                    }
                    catch (Exception e)
                    {

                    }

                    break;
             
                case "progressbar":

                    del = delegate()
                    {
                        progressBar1.Value = (int)message;
                        return 0;
                    };
                    Invoke(del);
                    break;
                case "imScene":

                    del = delegate()
                    {
                        if ((Image)message != null)
                        {
                            imScene.Width = ((Image)message).Width;
                            imScene.Height = ((Image)message).Height;
                            imScene.Image = (Image)((Image)message).Clone();
                        }
                        else { imScene.Image = null; }
                        return 0;
                    };
                    Invoke(del);
                    break;

                case "tbOutput":
                    if (tbOutput.InvokeRequired)
                    {
                        Invoke(new _SendToForm(UpdateControl), new object[] { message, "tbOutput" });
                    }
                    else
                    {
                        tbOutput.AppendText((string)message + System.Environment.NewLine);


                    }
                    break;


                case "IPform":
                    if (IPform.InvokeRequired)
                    {
                        Invoke(new _SendToForm(UpdateControl), new object[] { message, "IPform" });
                    }
                    else
                    {
                        IPform.Hide();


                    }
                    break;


                case "Custom1":
                    if (btn_Custom1.InvokeRequired)
                    {
                        Invoke(new _SendToForm(UpdateControl), new object[] { message, "Custom1" });
                    }
                    else
                    {
                        prg_Custom1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
                        prg_Custom1.Value = 100;
                        btn_Custom1.Text = (string)message;


                    }
                    break;

                case "Custom2":
                    if (btn_Custom2.InvokeRequired)
                    {
                        Invoke(new _SendToForm(UpdateControl), new object[] { message, "Custom2" });
                    }
                    else
                    {
                        prg_Custom2.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
                        prg_Custom2.Value = 100;
                        btn_Custom2.Text = (string)message;


                    }
                    break;

                case "Custom3":
                    if (btn_Custom3.InvokeRequired)
                    {
                        Invoke(new _SendToForm(UpdateControl), new object[] { message, "Custom3" });
                    }
                    else
                    {
                        prg_Custom3.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
                        prg_Custom3.Value = 100;
                        btn_Custom3.Text = (string)message;


                    }
                    break;

                case "Custom4":
                    if (btn_Custom4.InvokeRequired)
                    {
                        Invoke(new _SendToForm(UpdateControl), new object[] { message, "Custom4" });
                    }
                    else
                    {
                        prg_Custom4.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
                        prg_Custom4.Value = 100;
                        btn_Custom4.Text = (string)message;


                    }
                    break;
                case "timerReset":
                    if (lblIP.InvokeRequired)
                    {
                        Invoke(new _SendToForm(UpdateControl), new object[] { message, "timerReset" });
                    }
                    else
                    {
                        timerReset.Start();
                    }
                    break;


                case "lblIP":
                    if (lblIP.InvokeRequired)
                    {
                        Invoke(new _SendToForm(UpdateControl), new object[] { message, "lblIP" });
                    }
                    else
                    {


                        lblIP.Text = message.ToString();
                        // lblIP.Text ="Server IP : ***.***.***.***";

                    }
                    break;
                case "lblPC":
                    if (lblPupilCenter.InvokeRequired)
                    {
                        Invoke(new _SendToForm(UpdateControl), new object[] { message, "lblPC" });
                    }
                    else
                    {
                        if (message != "NoPupil")
                        {
                            AForge.Point p = (AForge.Point)message;
                            lblPupilCenter.Text = "pupil: (" + ((int)p.X).ToString() + "," + ((int)p.Y).ToString() + ")";
                        }
                        else lblPupilCenter.Text = message.ToString();
                    }
                    break;
                case "lblGC"://test
                    if (lblGlintCenter.InvokeRequired)
                    {
                        Invoke(new _SendToForm(UpdateControl), new object[] { message, "lblGC" });
                    }
                    else
                    {
                        if (message != "NoGlint")
                        {
                            AForge.Point p = (AForge.Point)message;
                            lblGlintCenter.Text = "glint: (" + ((int)p.X).ToString() + "," + ((int)p.Y).ToString() + ")";
                        }
                        else lblGlintCenter.Text = message.ToString();

                    }
                    break;

                case "UnDistortion":
                    if (cbSceneUnDistortion.InvokeRequired)
                    {
                        Invoke(new _SendToForm(UpdateControl), new object[] { message, "UnDistortion" });
                    }
                    else
                    {
                        METState.Current.sceneCameraUnDistortion = (bool)message;
                        cbSceneUnDistortion.Checked = (bool)message;
                    }
                    break;

                case "PupilThreshold":
                    if (trackBarThresholdEye.InvokeRequired)
                    {
                        Invoke(new _SendToForm(UpdateControl), new object[] { message, "PupilThreshold" });
                    }
                    else
                    {
                        trackBarThresholdEye.Value = (int)message;
                    }
                    break;

                case "Chart1":
                    if (chart1.InvokeRequired)
                    {
                        Invoke(new _SendToForm(UpdateControl), new object[] { message, "Chart1" });
                    }
                    else
                    {
                        // chart1.Series[0].Points.AddY (message);
                        chart1.Series[0].Points.AddXY(DateTime.Now, message);

                        // Adjust Y & X axis scale
                        chart1.ResetAutoValues();

                        // Keep a constant number of points by removing them from the left
                        while (chart1.Series[0].Points.Count > METState.Current.numberOfPointsInChart)
                        {
                            // Remove data points on the left side
                            while (chart1.Series[0].Points.Count > METState.Current.numberOfPointsAfterRemoval)
                            {
                                chart1.Series[0].Points.RemoveAt(0);
                            }

                        }

                        // Invalidate chart
                        chart1.Invalidate();

                    }

                    break;
                case "Chart2":
                    if (chart2.InvokeRequired)
                    {
                        Invoke(new _SendToForm(UpdateControl), new object[] { message, "Chart2" });
                    }
                    else
                    {
                        // chart1.Series[0].Points.AddY (message);
                        chart2.Series[0].Points.AddXY(DateTime.Now, message);

                        // Adjust Y & X axis scale
                        chart2.ResetAutoValues();

                        // Keep a constant number of points by removing them from the left
                        while (chart2.Series[0].Points.Count > METState.Current.numberOfPointsInChart)
                        {
                            // Remove data points on the left side
                            while (chart2.Series[0].Points.Count > METState.Current.numberOfPointsAfterRemoval)
                            {
                                chart2.Series[0].Points.RemoveAt(0);
                            }

                        }

                        // Invalidate chart
                        chart2.Invalidate();

                    }

                    break;
                case "Chart3":
                    if (chart3.InvokeRequired)
                    {
                        Invoke(new _SendToForm(UpdateControl), new object[] { message, "Chart3" });
                    }
                    else
                    {


                        // Set auto minimum and maximum values.
                        chart3.ChartAreas["ChartArea1"].AxisY.Minimum = (int)(METState.Current.MinPupilScale * METState.Current.IrisDiameter);
                        //  chart3.ChartAreas["ChartArea1"].AxisY.Maximum = (int)(METState.Current.MaxPupilScale * METState.Current.IrisDiameter);


                        // chart1.Series[0].Points.AddY (message);
                        chart3.Series[0].Points.AddXY(DateTime.Now, message);

                        // Adjust Y & X axis scale
                        chart3.ResetAutoValues();

                        // Keep a constant number of points by removing them from the left
                        while (chart3.Series[0].Points.Count > METState.Current.numberOfPointsInChart)
                        {
                            // Remove data points on the left side
                            while (chart3.Series[0].Points.Count > METState.Current.numberOfPointsAfterRemoval)
                            {
                                chart3.Series[0].Points.RemoveAt(0);
                            }

                        }

                        // Invalidate chart
                        chart3.Invalidate();

                    }

                    break;

                case "chartTest":
                    if (chartTest.InvokeRequired)
                    {
                        Invoke(new _SendToForm(UpdateControl), new object[] { message, "chartTest" });
                    }
                    else
                    {


                        // Set auto minimum and maximum values.
                        chartTest.ChartAreas["ChartArea1"].AxisY.Minimum = 0;
                        chartTest.ChartAreas["ChartArea1"].AxisY.Maximum = 50;


                        // chart1.Series[0].Points.AddY (message);
                        chartTest.Series[0].Points.AddXY(DateTime.Now, message);

                        // Adjust Y & X axis scale
                        chartTest.ResetAutoValues();

                        // Keep a constant number of points by removing them from the left
                        while (chartTest.Series[0].Points.Count > METState.Current.numberOfPointsInChart)
                        {
                            // Remove data points on the left side
                            while (chartTest.Series[0].Points.Count > METState.Current.numberOfPointsAfterRemoval)
                            {
                                chartTest.Series[0].Points.RemoveAt(0);
                            }

                        }

                        // Invalidate chart
                        chartTest.Invalidate();

                    }

                    break;

                case "TextBoxServer":

                    if (TextBoxServer.InvokeRequired)
                    {
                        Invoke(new _SendToForm(UpdateControl), new object[] { message, "TextBoxServer" });
                    }
                    else
                    {

                        TextBoxServer.Text += (string)message;
                        TextBoxServer.SelectionStart = TextBoxServer.Text.Length;
                        TextBoxServer.ScrollToCaret();

                    }


                    break;
                case "PanelClients_Add":

                    if (panelClients.InvokeRequired)
                    {
                        Invoke(new _SendToForm(UpdateControl), new object[] { message, "PanelClients_Add" });
                    }
                    else
                    {


                        CreateClientControl((string)message);
                    }


                    break;
                case "PanelClients_Remove":

                    if (panelClients.InvokeRequired)
                    {
                        Invoke(new _SendToForm(UpdateControl), new object[] { message, "PanelClients_Remove" });
                    }
                    else
                    {
                        RemoveControls((string)message);






                    }


                    break;
                case "ActiveMonitor_Highlight":

                    if (TextBoxServer.InvokeRequired)
                    {
                        Invoke(new _SendToForm(UpdateControl), new object[] { message, "ActiveMonitor_Highlight" });
                    }
                    else
                    {
                        HighLight_Client((string)message);

                    }

                    break;

            }

        }

        bool bFirstFrameEye = false;
        private Bitmap _bitmapimEye;
        public void imEyeUpdate(object sender, METEventArg eventArgs)
        {

            if (btnStartEye.Text == "Stop")//METState.Current.EyeCamera.IsRunning == true &&
            {
                _bitmapimEye = (Bitmap)METState.Current.EyeImageForShow.Bitmap.Clone();

                if (!bFirstFrameEye)
                {
                    imEye.Invoke(
                        (MethodInvoker)delegate
                        {
                            groupBox_imgEye.Width = _bitmapimEye.Width;
                            imEye.Width = _bitmapimEye.Width;
                            imEye.Height = _bitmapimEye.Height;
                        });

                    bFirstFrameEye = true;
                }

                imEye.Invalidate();

                //pictureBox1.Invalidate();
                // imEye.Image = METState.Current.EyeImageForShow;
                // imEyeTest.Image = METState.Current.EyeImageTest;

            }

        }

        bool bFirstFrameScene = false, bFirstFrameSceneProcessed = false;
        private Bitmap _bitmapimScene, _bitmapimSceneProcessed;
        public void imSceneUpdate(object sender, METEventArg eventArgs)
        {

            if (btnStartScene.Text == "Stop")
            {
                _bitmapimScene = (Bitmap)METState.Current.SceneImageForShow.Bitmap.Clone();

                if (!bFirstFrameScene)
                {
                    imScene.Invoke(
                        (MethodInvoker)delegate
                        {
                            //groupBox_imgScene.Width = _bitmapimScene.Width;
                            imScene.Width = _bitmapimScene.Width;
                            imScene.Height = _bitmapimScene.Height;
                        });

                    bFirstFrameScene = true;
                }

                imScene.Invalidate();

                if (METState.Current.SceneImageProcessed != null)
                {
                    _bitmapimSceneProcessed = (Bitmap)METState.Current.SceneImageProcessed.Bitmap.Clone();

                    if (!bFirstFrameSceneProcessed)
                    {
                        imScene.Invoke(
                            (MethodInvoker)delegate
                            {
                                //panelImScene.Width = groupBox_imgScene.Width;// _bitmapimSceneProcessed.Width / 2;
                                imSceneProcessed.Width = _bitmapimSceneProcessed.Width;

                                imSceneProcessed.Height = _bitmapimSceneProcessed.Height;
                            });

                        bFirstFrameSceneProcessed = true;
                    }

                    imSceneProcessed.Invalidate();
                }

                //imScene.Image = METState.Current.SceneImageForShow;
                //imSceneProcessed.Image = METState.Current.SceneImageProcessed;

            }


        }

        private void cb_eye_VFlip_CheckedChanged(object sender, EventArgs e)
        {
            METState.Current.eye_VFlip = cb_eye_VFlip.Checked;

        }

        private void cb_scene_VFlip_CheckedChanged(object sender, EventArgs e)
        {
            METState.Current.scene_VFlip = cb_scene_VFlip.Checked;

        }

        private void cmbDeviceEye_DropDown(object sender, EventArgs e)
        {
            cmbDevice_Update(true, false);

        }

        private void cmbDeviceScene_DropDown(object sender, EventArgs e)
        {
            cmbDevice_Update(false, true);

        }

        private void button1_Click(object sender, EventArgs e)
        {


            // MessageBox.Show("Click on 4 points in the scene image while the user is looking at the corresponding points in the field of view.");


            METState.Current.EyeToRemoteDisplay_Mapping.GazeErrorX = 0;
            METState.Current.EyeToRemoteDisplay_Mapping.GazeErrorY = 0;


            METState.Current.EyeToRemoteDisplay_Mapping.CalibrationTarget = 0;
            METState.Current.EyeToRemoteDisplay_Mapping.Calibrated = false;

            METState.Current.EyeToRemoteDisplay_Mapping.CalibrationType = Calibration.calibration_type.calib_Homography;

            ///Set the METState.Current.RemoteOrHeadMount 
            Rectangle rect = new Rectangle(Screen.FromHandle(this.Handle).Bounds.Left, Screen.FromHandle(this.Handle).Bounds.Top, Screen.FromHandle(this.Handle).Bounds.Width, Screen.FromHandle(this.Handle).Bounds.Height);

            METState.Current.remoteCalibration = new RemoteCalibration(2, 2, rect); ;

            METState.Current.server.Send("Commands", new string[] { "CalibrationFinished" });

        }


        private void button2_Click_2(object sender, EventArgs e)
        {


            // MessageBox.Show("Click on 4 points in the scene image while the user is looking at the corresponding points in the field of view.");


            METState.Current.EyeToRemoteDisplay_Mapping.GazeErrorX = 0;
            METState.Current.EyeToRemoteDisplay_Mapping.GazeErrorY = 0;


            METState.Current.EyeToRemoteDisplay_Mapping.CalibrationTarget = 0;
            METState.Current.EyeToRemoteDisplay_Mapping.Calibrated = false;

            METState.Current.EyeToRemoteDisplay_Mapping.CalibrationType = Calibration.calibration_type.calib_Polynomial;

            ///Set the METState.Current.RemoteOrHeadMount 
            Rectangle rect = new Rectangle(Screen.FromHandle(this.Handle).Bounds.Left, Screen.FromHandle(this.Handle).Bounds.Top, Screen.FromHandle(this.Handle).Bounds.Width, Screen.FromHandle(this.Handle).Bounds.Height);

            METState.Current.remoteCalibration = new RemoteCalibration(3, 3, rect);

            METState.Current.server.Send("Commands", new string[] { "CalibrationFinished" });
        }

        private void checkEditShowOpticalFlow_CheckedChanged(object sender, EventArgs e)
        {
            checkEditShowOpticalFlow.BackColor = checkEditShowOpticalFlow.Checked ? Color.Yellow : Color.Transparent;

            METState.Current.ShowOpticalFlow = checkEditShowOpticalFlow.Checked;
        }


        private void checkBox2_CheckedChanged_5(object sender, EventArgs e)
        {
            METState.Current.headRollGestures = checkBox2.Checked;
        }

        private void radioButton4D_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton4D_CheckedChanged_1(object sender, EventArgs e)
        {
            METState.Current.HowManyDirections4OR8 = 4;
            bool vis = false;
            pbUpRight1.Visible = vis;
            pbUpRight2.Visible = vis;
            pbUpLeft1.Visible = vis;
            pbUpLeft2.Visible = vis;
            pbDownRight1.Visible = vis;
            pbDownRight2.Visible = vis;
            pbDownLeft1.Visible = vis;
            pbDownLeft2.Visible = vis;



        }

        private void radioButton8D_CheckedChanged(object sender, EventArgs e)
        {
            METState.Current.HowManyDirections4OR8 = 8;
            bool vis = true;
            pbUpRight1.Visible = vis;
            pbUpRight2.Visible = vis;
            pbUpLeft1.Visible = vis;
            pbUpLeft2.Visible = vis;
            pbDownRight1.Visible = vis;
            pbDownRight2.Visible = vis;
            pbDownLeft1.Visible = vis;
            pbDownLeft2.Visible = vis;
        }



        private void trackBarTest_ValueChanged(object sender, EventArgs e)
        {

            METState.Current.test = trackBarTest.Value;

        }

        private void comboBox_SceneTimer_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btn_Record_Click(object sender, EventArgs e)
        {

            #region Export
            if (METState.Current.SceneIsRecording == false & METState.Current.EyeIsRecording == false)// Record
            {

                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "AVI File|*.avi|All File|*.*";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    #region SetRecord

                    string dir = saveFileDialog.FileName;
                    int extesion_index = dir.IndexOf(".avi");
                    string newdir;
                    newdir = dir.Substring(0, extesion_index) + "_eye.avi";
                    bool codecOK = true;
                    try
                    {
                        if (((METState.Current.SceneCamera != null && METState.Current.SceneCamera.IsRunning)) && METState.Current.SceneForExport)
                        {

                            int SceneW = METState.Current.SceneImageOrginal.Width;
                            int SceneH = METState.Current.SceneImageOrginal.Height;
                            METState.Current.SceneVideoWriter = new Emgu.CV.VideoWriter(dir, -1, 15, SceneW, SceneH, true);//15?? it dependes on fps of the videos 

                            METState.Current.SceneVideoWriterFrameNumber = 0;
                        }

                        if (((METState.Current.EyeCamera != null && METState.Current.EyeCamera.IsRunning)) && METState.Current.EyeForExport)
                        {
                            int EyeW = METState.Current.EyeImageOrginal.Width;
                            int EyeH = METState.Current.EyeImageOrginal.Height;

                            METState.Current.EyeVideoWriter = new Emgu.CV.VideoWriter(newdir, -1, 15, EyeW, EyeH, true);
                            METState.Current.EyeVideoWriterFrameNumber = 0;
                        }
                    }
                    catch (Exception eee)//codec problem
                    {
                        System.Windows.Forms.MessageBox.Show("Codec Problem!");

                        codecOK = false;
                    }

                    if (codecOK)
                    {
                        // TextFile
                        METState.Current.DataHandler.OpenLog(dir + ".obd.csv");

                        string textdir = dir.Substring(0, extesion_index);
                        METState.Current.TextFileDataExport = new TextFile(textdir);
                        string GazeDataLine = "Pupil Center X , Pupil Center Y , Glint Center X , Glint Center Y , Pupil Diameter , Blink , DbBlink , HeadGesture , GazeX , GazeY , Time";
                        if (METState.Current.TextFileDataExport != null) METState.Current.TextFileDataExport.WriteLine(GazeDataLine);



                    #endregion SetRecord



                        #region RedFrame
                        Bgr color = new Bgr(System.Drawing.Color.Red);



                        if (((METState.Current.EyeCamera != null && METState.Current.EyeCamera.IsRunning)) && METState.Current.EyeForExport)
                        {
                            Image<Bgr, Byte> EyeRED = new Image<Bgr, byte>(METState.Current.EyeImageOrginal.Width, METState.Current.EyeImageOrginal.Height, color);

                            METState.Current.EyeVideoWriter.WriteFrame<Bgr, Byte>(EyeRED);
                            METState.Current.EyeIsRecording = true;
                        }

                        if ((METState.Current.SceneCamera != null && METState.Current.SceneCamera.IsRunning) && METState.Current.SceneForExport)
                        {
                            Image<Bgr, Byte> SceneRED = new Image<Bgr, byte>(METState.Current.SceneImageOrginal.Width, METState.Current.SceneImageOrginal.Height, color);
                            METState.Current.SceneVideoWriter.WriteFrame<Bgr, Byte>(SceneRED);
                            METState.Current.SceneIsRecording = true;

                        }
                        #endregion RedFrame

                        if (METState.Current.SceneIsRecording | METState.Current.EyeIsRecording)
                        {
                            btn_Record.Text = "Recording..." + "\r\n" + "Click to Stop";// "Recording. Click to Stop";

                            btn_RecordProgress.Style = System.Windows.Forms.ProgressBarStyle.Marquee;


                        }
                    }
                }




            }
            else//Stop
            {
                Bgr color = new Bgr(System.Drawing.Color.Red);
                if (METState.Current.SceneIsRecording)
                {
                    METState.Current.SceneIsRecording = false;
                    Image<Bgr, Byte> SceneRED = new Image<Bgr, byte>(METState.Current.SceneImageOrginal.Width, METState.Current.SceneImageOrginal.Height, color);
                    METState.Current.SceneVideoWriter.WriteFrame<Bgr, Byte>(SceneRED);
                    METState.Current.SceneVideoWriter.Dispose();
                }
                if (METState.Current.EyeIsRecording)
                {
                    METState.Current.EyeIsRecording = false;
                    Image<Bgr, Byte> EyeRED = new Image<Bgr, byte>(METState.Current.EyeImageOrginal.Width, METState.Current.EyeImageOrginal.Height, color);
                    METState.Current.EyeVideoWriter.WriteFrame<Bgr, Byte>(EyeRED);
                    METState.Current.EyeVideoWriter.Dispose();
                }

                METState.Current.DataHandler.CloseLog();

                METState.Current.TextFileDataExport.CloseFile();
                METState.Current.TextFileDataExport = null;
                btn_Record.Text = "Export";



                btn_RecordProgress.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
                btn_RecordProgress.Value = 0;


            }
            #endregion Export
        }

        private void btn_Custom1_Click(object sender, EventArgs e)
        {
            prg_Custom1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            METState.Current.eye.headGesture.gestureSequenceLinear.Clear();
            METState.Current.gestureRecording = btn_Custom1.Tag.ToString();
        }

        private void btn_Custom2_Click(object sender, EventArgs e)
        {
            prg_Custom2.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            METState.Current.eye.headGesture.gestureSequenceLinear.Clear();
            METState.Current.gestureRecording = btn_Custom2.Tag.ToString();


        }

        private void btn_Custom3_Click(object sender, EventArgs e)
        {
            prg_Custom3.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            METState.Current.eye.headGesture.gestureSequenceLinear.Clear();
            METState.Current.gestureRecording = btn_Custom3.Tag.ToString();


        }

        private void btn_Custom4_Click(object sender, EventArgs e)
        {
            prg_Custom4.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            METState.Current.eye.headGesture.gestureSequenceLinear.Clear();
            METState.Current.gestureRecording = btn_Custom4.Tag.ToString();


        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            METState.Current.SceneForExport = checkBox3.Checked;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            METState.Current.EyeForExport = checkBox1.Checked;
        }

        String tempPreToolTipTxt = "";
        private void imScene_MouseMove(object sender, MouseEventArgs e)
        {
          

        }

        private Bitmap _bitmapPicturebox2;
        private void Picturebox2_Paint(object sender, PaintEventArgs e)
        {


            if (_bitmapPicturebox2 != null)
            {
                e.Graphics.DrawImage(_bitmapPicturebox2, 0, 0, pictureBox2.Width, pictureBox2.Height);
            }
            if (METState.Current.remoteOrMobile == METState.RemoteOrMobile.GoogleGalss)
            {
                Func<int> del = delegate()
                {

                    if (METState.Current.EyeToRemoteDisplay_Mapping.Calibrated == true)
                    {



                        try
                        {

                            SizeF s = new SizeF(pictureBox2.Width, pictureBox2.Height);
                            Point coord = new Point((int)(METState.Current.Gaze_RGT.X * s.Width / (double)myGlass.constants.display_W), (int)(METState.Current.Gaze_RGT.Y * s.Height / (double)myGlass.constants.display_H));

                            e.Graphics.DrawEllipse(new Pen(Color.Red, 2f), coord.X, coord.Y, 3, 3);

                        }
                        catch (Exception ex)
                        {

                        }
                    }
                    return 0;
                };
                Invoke(del);
            }


        }

        private void imEye_Paint(object sender, PaintEventArgs e)
        {
            if (_bitmapimEye != null)
            {
                e.Graphics.DrawImage(_bitmapimEye, 0, 0, _bitmapimEye.Width, _bitmapimEye.Height);
            }
        }

        private void imScene_Paint(object sender, PaintEventArgs e)
        {
            if (METState.Current.remoteOrMobile == METState.RemoteOrMobile.GoogleGalss)
            {
            //    Func<int> del = delegate()
            //    {

            //        if (METState.Current.EyeToScene_Mapping.Calibrated == true)
            //        {



            //            try
            //            {


            //                SizeF s = new SizeF(imScene.Width, imScene.Height);
            //              //  METState.Current.Gaze_HMGT = METState.Current.EyeToScene_Mapping.Map(METState.Current.eyeFeature.X,
            //                //    METState.Current.eyeFeature.Y, METState.Current.EyeToScene_Mapping.GazeErrorX, METState.Current.EyeToScene_Mapping.GazeErrorY);

            //                //Point coord = new Point(
            //                //    (int)
            //                //    (METState.Current.Gaze_HMGT.X * s.Width / (double)METState.Current.GlassFrontView_Resolution.Width),
            //                //    (int)
            //                //    (METState.Current.Gaze_HMGT.Y * s.Height / (double)METState.Current.GlassFrontView_Resolution.Height));



            //                Point coord = new Point(
            //                    (int)
            //                    (METState.Current.Gaze_HMGT.X),
            //                    (int)
            //                    (METState.Current.Gaze_HMGT.Y));


            //                e.Graphics.DrawEllipse(new Pen(Color.Red, 2f), coord.X, coord.Y, 3, 3);

            //            }
            //            catch (Exception ex)
            //            {

            //            }
            //        }
            //        return 0;
            //    };
            //    Invoke(del);
            }
            else if (_bitmapimScene != null)
            {
                e.Graphics.DrawImage(_bitmapimScene, 0, 0, _bitmapimScene.Width, _bitmapimScene.Height);
            }
        }

        private void imSceneProcessed_Paint(object sender, PaintEventArgs e)
        {
            if (_bitmapimSceneProcessed != null)
            {
                e.Graphics.DrawImage(_bitmapimSceneProcessed, 0, 0, _bitmapimSceneProcessed.Width, _bitmapimSceneProcessed.Height);
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            METState.Current.DataHandler.IsEnabled = this.checkBox4.Checked;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            METState.Current.DataHandler.FontSize = (float)this.numericUpDown1.Value;
        }

        private void btn_CleanCache_Click(object sender, EventArgs e)
        {
            METState.Current.DataHandler.Clear();
        }

        private void rbGlint_CheckedChanged(object sender, EventArgs e)
        {
            if (rbGlint.Checked) METState.Current.calibration_eyeFeature = METState.Calibration_EyeFeature.Glint;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            METState.Current.GlassServer.gazeStream_RGT = myGlass.Server.GazeStream.NoStreaming;

            int n = Int32.Parse(((Button)sender).Tag.ToString());
            n = (int)Math.Sqrt(n);

            if (n == 2)
            {
                METState.Current.EyeToRemoteDisplay_Mapping.CalibrationType = Calibration.calibration_type.calib_Homography;

            }
            else if (n == 3)
            {
                METState.Current.EyeToRemoteDisplay_Mapping.CalibrationType = Calibration.calibration_type.calib_Polynomial;

            }

            METState.Current.GlassServer.Send(myGlass.MessageType.toGLASS_Calibrate_Display, new Point(-1, -1));//only show the msg to the user not the point
            Thread.Sleep(2000);//??


            METState.Current.EyeToRemoteDisplay_Mapping.GazeErrorX = 0;
            METState.Current.EyeToRemoteDisplay_Mapping.GazeErrorY = 0;


            METState.Current.EyeToRemoteDisplay_Mapping.CalibrationTarget = 0;
            METState.Current.EyeToRemoteDisplay_Mapping.Calibrated = false;



            ///Set the METState.Current.RemoteOrHeadMount 
            Rectangle rect = new Rectangle(0, 0, myGlass.constants.display_W, myGlass.constants.display_H);

            METState.Current.remoteCalibration = new RemoteCalibration(n, n, rect); ;

            //...Here you can send some commands to HMD if you want to show something there
            // METState.Current.remoteCalibration.ShowDialog();




            METState.Current.server.Send("Commands", new string[] { "CalibrationFinished" });

        }


        private void button5_Click(object sender, EventArgs e)
        {

            int n = Int32.Parse(((Button)sender).Tag.ToString());

            METState.Current.GlassServer.client.numberOfPictures = n;

            n = (int)Math.Sqrt(n);

            if (n == 2)
            {
                METState.Current.EyeToScene_Mapping.CalibrationType = Calibration.calibration_type.calib_Homography;

            }
            else if (n == 3)
            {
                METState.Current.EyeToScene_Mapping.CalibrationType = Calibration.calibration_type.calib_Polynomial;

            }

            METState.Current.EyeToScene_Mapping.ScenePoints = new List<AForge.Point>();
            METState.Current.EyeToScene_Mapping.GazeErrorX = 0;
            METState.Current.EyeToScene_Mapping.GazeErrorY = 0;


            METState.Current.EyeToScene_Mapping.CalibrationTarget = 0;
            METState.Current.EyeToScene_Mapping.Calibrated = false;// ta click rooye scene noghtegiri shavad na eslah

            METState.Current.GlassServer.Send(myGlass.MessageType.toGLASS_Calibrate_Scene, new Point(-1, -1));
            Thread.Sleep(2000);//??




        }

        private void button7_Click(object sender, EventArgs e)
        {



        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            try
            {
                METState.Current.METCoreObject.SendToForm(null, "imScene");
                Haytham.Glass.SceneImage test = new Haytham.Glass.SceneImage();
                Image img = Image.FromFile(@"ProImages\" + txtImageName.Text);// + ".jpg");

                //Point testPoint = test.getCalibrationTarget(img, -1, 1, false);
                Point testPoint = test.getCalibrationTarget(img, TrackBar1.Value, 1, false);

                METState.Current.METCoreObject.SendToForm(test.result_Image, "imScene");
                // METState.Current.METCoreObject.SendToForm(test.temp_Image, "imScene");



            }
            catch (Exception er)
            {
                Console.WriteLine("Image not found");
            }


        }


        private void pictureBox1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

            IPform.ShowDialog();
        }

        private void tabPage_Glass_Click(object sender, EventArgs e)
        {

        }

        private void txtImageName_TextChanged(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            METState.Current.GlassServer.gazeStream_RGT = myGlass.Server.GazeStream.NoStreaming;

            METState.Current.GlassServer.Send(myGlass.MessageType.toGLASS_LetsCorrectOffset);

        }

        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void pictureBox2_MouseClick(object sender, MouseEventArgs e)
        {
            if (METState.Current.remoteOrMobile == METState.RemoteOrMobile.GoogleGalss)
            {
                if (e.Button == MouseButtons.Right)
                {
                    if (METState.Current.EyeToRemoteDisplay_Mapping.Calibrated)
                    {
                        SizeF s = new SizeF(pictureBox2.Width, pictureBox2.Height);
                        Point coord = new Point((int)(e.X * (double)myGlass.constants.display_W / (double)s.Width), (int)(e.Y * (double)myGlass.constants.display_H / (double)s.Height));


                        AForge.Point Gaze = METState.Current.EyeToRemoteDisplay_Mapping.Map(METState.Current.eyeFeature.X, METState.Current.eyeFeature.Y, coord.X, coord.Y);

                        METState.Current.EyeToRemoteDisplay_Mapping.GazeErrorX = Gaze.X;// / METState.Current.Kw_SceneImg);
                        METState.Current.EyeToRemoteDisplay_Mapping.GazeErrorY = Gaze.Y;// / METState.Current.Kh_SceneImg);


                    }
                }
            }


        }












    }
}
