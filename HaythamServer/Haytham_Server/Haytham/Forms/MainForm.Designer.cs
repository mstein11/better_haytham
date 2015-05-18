namespace Haytham
{
    public partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;



        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title3 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title4 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage_Camera = new System.Windows.Forms.TabPage();
            this.gbStartBoth = new System.Windows.Forms.GroupBox();
            this.startBoothVideos = new System.Windows.Forms.Button();
            this.gbSceneCameraDevice = new System.Windows.Forms.GroupBox();
            this.cb_scene_VFlip = new System.Windows.Forms.CheckBox();
            this.btnSettingsScene = new System.Windows.Forms.Button();
            this.btnStartScene = new System.Windows.Forms.Button();
            this.cmbDeviceCapabilityScene = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbDeviceScene = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.gbEyeCameraDevice = new System.Windows.Forms.GroupBox();
            this.cb_eye_VFlip = new System.Windows.Forms.CheckBox();
            this.btnSettingsEye = new System.Windows.Forms.Button();
            this.btnStartEye = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbDeviceCapabilityEye = new System.Windows.Forms.ComboBox();
            this.cmbDeviceEye = new System.Windows.Forms.ComboBox();
            this.tabPage_Glass = new System.Windows.Forms.TabPage();
            this.button8 = new System.Windows.Forms.Button();
            this.txtImageName = new System.Windows.Forms.TextBox();
            this.button7 = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lbCommandsToGlass = new System.Windows.Forms.ListBox();
            this.tbOutput = new System.Windows.Forms.TextBox();
            this.tabPage_Eye = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.cbGM = new System.Windows.Forms.RadioButton();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.rbGGaussian = new System.Windows.Forms.RadioButton();
            this.rbGMean = new System.Windows.Forms.RadioButton();
            this.cbGA = new System.Windows.Forms.RadioButton();
            this.cbShowGlint = new System.Windows.Forms.CheckBox();
            this.cbGlintDetection = new System.Windows.Forms.CheckBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.cbPM = new System.Windows.Forms.RadioButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.rbPGaussian = new System.Windows.Forms.RadioButton();
            this.rbPMean = new System.Windows.Forms.RadioButton();
            this.cbPA = new System.Windows.Forms.RadioButton();
            this.cbRemoveGlint = new System.Windows.Forms.CheckBox();
            this.cbDilateErode = new System.Windows.Forms.CheckBox();
            this.cbShowPupil = new System.Windows.Forms.CheckBox();
            this.cbPupilDetection = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cbShowIris = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tabPage_Scene = new System.Windows.Forms.TabPage();
            this.label17 = new System.Windows.Forms.Label();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.btnSceneCameraCalibration = new System.Windows.Forms.Button();
            this.cbSceneUnDistortion = new System.Windows.Forms.CheckBox();
            this.cbShowGaze = new System.Windows.Forms.CheckBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.groupBox21 = new System.Windows.Forms.GroupBox();
            this.cbShowEdges = new System.Windows.Forms.CheckBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.cbShowScreen = new System.Windows.Forms.CheckBox();
            this.tabPage_Calibration = new System.Windows.Forms.TabPage();
            this.gbCalibrationGlass = new System.Windows.Forms.GroupBox();
            this.button9 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.gbCalibrationRemote = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.gbCalibrationHM = new System.Windows.Forms.GroupBox();
            this.lbl_calibration = new System.Windows.Forms.Label();
            this.btnCalibration_Homography = new System.Windows.Forms.Button();
            this.btnCalibration_Polynomial = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.rbGlint = new System.Windows.Forms.RadioButton();
            this.rbPupilGlint = new System.Windows.Forms.RadioButton();
            this.rdOnlyPupil = new System.Windows.Forms.RadioButton();
            this.cbGazeSmoothing = new System.Windows.Forms.CheckBox();
            this.tabPage_Data = new System.Windows.Forms.TabPage();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.chart3 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.cbPlot = new System.Windows.Forms.CheckBox();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.btn_RecordProgress = new System.Windows.Forms.ProgressBar();
            this.btn_Record = new System.Windows.Forms.Button();
            this.tabPage_Clients = new System.Windows.Forms.TabPage();
            this.panelClients = new System.Windows.Forms.GroupBox();
            this.radioButtonAutoActivation = new System.Windows.Forms.RadioButton();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.TextBoxServer = new System.Windows.Forms.TextBox();
            this.tabPage_Gesture = new System.Windows.Forms.TabPage();
            this.groupBox19 = new System.Windows.Forms.GroupBox();
            this.btn_Custom4 = new System.Windows.Forms.Button();
            this.prg_Custom4 = new System.Windows.Forms.ProgressBar();
            this.btn_Custom3 = new System.Windows.Forms.Button();
            this.prg_Custom3 = new System.Windows.Forms.ProgressBar();
            this.btn_Custom2 = new System.Windows.Forms.Button();
            this.prg_Custom2 = new System.Windows.Forms.ProgressBar();
            this.btn_Custom1 = new System.Windows.Forms.Button();
            this.prg_Custom1 = new System.Windows.Forms.ProgressBar();
            this.groupBox20 = new System.Windows.Forms.GroupBox();
            this.pbUpRight2 = new System.Windows.Forms.PictureBox();
            this.radioButton8D = new System.Windows.Forms.RadioButton();
            this.pbUp1 = new System.Windows.Forms.PictureBox();
            this.pbUpLeft2 = new System.Windows.Forms.PictureBox();
            this.pbUp2 = new System.Windows.Forms.PictureBox();
            this.radioButton4D = new System.Windows.Forms.RadioButton();
            this.pbUpRight1 = new System.Windows.Forms.PictureBox();
            this.pbRight1 = new System.Windows.Forms.PictureBox();
            this.pbUpLeft1 = new System.Windows.Forms.PictureBox();
            this.pbRight2 = new System.Windows.Forms.PictureBox();
            this.pbLeft2 = new System.Windows.Forms.PictureBox();
            this.pbDownRight1 = new System.Windows.Forms.PictureBox();
            this.pbLeft1 = new System.Windows.Forms.PictureBox();
            this.pbDownRight2 = new System.Windows.Forms.PictureBox();
            this.pbDownLeft2 = new System.Windows.Forms.PictureBox();
            this.pbDown1 = new System.Windows.Forms.PictureBox();
            this.pbDownLeft1 = new System.Windows.Forms.PictureBox();
            this.pbDown2 = new System.Windows.Forms.PictureBox();
            this.groupBox16 = new System.Windows.Forms.GroupBox();
            this.pbTRight = new System.Windows.Forms.PictureBox();
            this.pbTLeft = new System.Windows.Forms.PictureBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkEditShowOpticalFlow = new System.Windows.Forms.CheckBox();
            this.groupBox17 = new System.Windows.Forms.GroupBox();
            this.btnDbBlink = new System.Windows.Forms.Button();
            this.btnBlink = new System.Windows.Forms.Button();
            this.tabPage_ExtData = new System.Windows.Forms.TabPage();
            this.groupBox13 = new System.Windows.Forms.GroupBox();
            this.btn_CleanCache = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.groupBox14 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.groupBox_imgEye = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.imEye = new System.Windows.Forms.PictureBox();
            this.groupBox_imgScene = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.imSceneProcessed = new System.Windows.Forms.PictureBox();
            this.imScene = new System.Windows.Forms.PictureBox();
            this.groupBox18 = new System.Windows.Forms.GroupBox();
            this.trackBarTest = new System.Windows.Forms.TrackBar();
            this.chartTest = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.imEyeTest = new Emgu.CV.UI.ImageBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.splitter7 = new System.Windows.Forms.Splitter();
            this.lblIP = new System.Windows.Forms.TextBox();
            this.splitter6 = new System.Windows.Forms.Splitter();
            this.lblGlintCenter = new System.Windows.Forms.Label();
            this.splitter3 = new System.Windows.Forms.Splitter();
            this.lblPupilCenter = new System.Windows.Forms.Label();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.comboBox_SceneTimer = new System.Windows.Forms.ComboBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.comboBox_EyeTimer = new System.Windows.Forms.ComboBox();
            this.timerReset = new System.Windows.Forms.Timer(this.components);
            this.trackBarThresholdGlint = new Haytham.TransparentTrackBar();
            this.trackBarThresholdEye = new Haytham.TransparentTrackBar();
            this.trackBarControl3 = new Haytham.TransparentTrackBar();
            this.trackBarB = new Haytham.TransparentTrackBar();
            this.trackBarG = new Haytham.TransparentTrackBar();
            this.trackBarControl2 = new Haytham.TransparentTrackBar();
            this.trackBarPAConstant = new Haytham.TransparentTrackBar();
            this.trackBarPABlockSize = new Haytham.TransparentTrackBar();
            this.trackBarGAConstant = new Haytham.TransparentTrackBar();
            this.trackBarGABlockSize = new Haytham.TransparentTrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage_Camera.SuspendLayout();
            this.gbStartBoth.SuspendLayout();
            this.gbSceneCameraDevice.SuspendLayout();
            this.gbEyeCameraDevice.SuspendLayout();
            this.tabPage_Glass.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.tabPage_Eye.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tabPage_Scene.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox21.SuspendLayout();
            this.tabPage_Calibration.SuspendLayout();
            this.gbCalibrationGlass.SuspendLayout();
            this.gbCalibrationRemote.SuspendLayout();
            this.gbCalibrationHM.SuspendLayout();
            this.panel5.SuspendLayout();
            this.tabPage_Data.SuspendLayout();
            this.groupBox11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.groupBox10.SuspendLayout();
            this.tabPage_Clients.SuspendLayout();
            this.panelClients.SuspendLayout();
            this.groupBox12.SuspendLayout();
            this.tabPage_Gesture.SuspendLayout();
            this.groupBox19.SuspendLayout();
            this.groupBox20.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbUpRight2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbUp1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbUpLeft2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbUp2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbUpRight1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRight1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbUpLeft1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRight2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLeft2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDownRight1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLeft1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDownRight2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDownLeft2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDownLeft1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDown2)).BeginInit();
            this.groupBox16.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbTRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTLeft)).BeginInit();
            this.groupBox17.SuspendLayout();
            this.tabPage_ExtData.SuspendLayout();
            this.groupBox13.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.groupBox14.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupBox_imgEye.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imEye)).BeginInit();
            this.groupBox_imgScene.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imSceneProcessed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imScene)).BeginInit();
            this.groupBox18.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarTest)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartTest)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imEyeTest)).BeginInit();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarThresholdGlint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarThresholdEye)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarControl3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarPAConstant)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarPABlockSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarGAConstant)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarGABlockSize)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(2);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tabControl1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox14);
            this.splitContainer1.Panel2.Controls.Add(this.panel6);
            this.splitContainer1.Size = new System.Drawing.Size(1268, 668);
            this.splitContainer1.SplitterDistance = 367;
            this.splitContainer1.SplitterWidth = 3;
            this.splitContainer1.TabIndex = 43;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage_Camera);
            this.tabControl1.Controls.Add(this.tabPage_Glass);
            this.tabControl1.Controls.Add(this.tabPage_Eye);
            this.tabControl1.Controls.Add(this.tabPage_Scene);
            this.tabControl1.Controls.Add(this.tabPage_Calibration);
            this.tabControl1.Controls.Add(this.tabPage_Data);
            this.tabControl1.Controls.Add(this.tabPage_Clients);
            this.tabControl1.Controls.Add(this.tabPage_Gesture);
            this.tabControl1.Controls.Add(this.tabPage_ExtData);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(367, 668);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage_Camera
            // 
            this.tabPage_Camera.Controls.Add(this.gbStartBoth);
            this.tabPage_Camera.Controls.Add(this.gbSceneCameraDevice);
            this.tabPage_Camera.Controls.Add(this.gbEyeCameraDevice);
            this.tabPage_Camera.Location = new System.Drawing.Point(4, 40);
            this.tabPage_Camera.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage_Camera.Name = "tabPage_Camera";
            this.tabPage_Camera.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage_Camera.Size = new System.Drawing.Size(359, 624);
            this.tabPage_Camera.TabIndex = 0;
            this.tabPage_Camera.Text = "Camera";
            this.tabPage_Camera.UseVisualStyleBackColor = true;
            // 
            // gbStartBoth
            // 
            this.gbStartBoth.Controls.Add(this.startBoothVideos);
            this.gbStartBoth.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbStartBoth.Location = new System.Drawing.Point(2, 334);
            this.gbStartBoth.Margin = new System.Windows.Forms.Padding(2);
            this.gbStartBoth.Name = "gbStartBoth";
            this.gbStartBoth.Padding = new System.Windows.Forms.Padding(2);
            this.gbStartBoth.Size = new System.Drawing.Size(355, 69);
            this.gbStartBoth.TabIndex = 54;
            this.gbStartBoth.TabStop = false;
            // 
            // startBoothVideos
            // 
            this.startBoothVideos.Location = new System.Drawing.Point(49, 16);
            this.startBoothVideos.Margin = new System.Windows.Forms.Padding(2);
            this.startBoothVideos.Name = "startBoothVideos";
            this.startBoothVideos.Size = new System.Drawing.Size(115, 37);
            this.startBoothVideos.TabIndex = 55;
            this.startBoothVideos.Text = "Start Both";
            this.startBoothVideos.UseVisualStyleBackColor = true;
            this.startBoothVideos.Click += new System.EventHandler(this.button1_Click_5);
            // 
            // gbSceneCameraDevice
            // 
            this.gbSceneCameraDevice.Controls.Add(this.cb_scene_VFlip);
            this.gbSceneCameraDevice.Controls.Add(this.btnSettingsScene);
            this.gbSceneCameraDevice.Controls.Add(this.btnStartScene);
            this.gbSceneCameraDevice.Controls.Add(this.cmbDeviceCapabilityScene);
            this.gbSceneCameraDevice.Controls.Add(this.label6);
            this.gbSceneCameraDevice.Controls.Add(this.cmbDeviceScene);
            this.gbSceneCameraDevice.Controls.Add(this.label8);
            this.gbSceneCameraDevice.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbSceneCameraDevice.Location = new System.Drawing.Point(2, 168);
            this.gbSceneCameraDevice.Margin = new System.Windows.Forms.Padding(2);
            this.gbSceneCameraDevice.Name = "gbSceneCameraDevice";
            this.gbSceneCameraDevice.Padding = new System.Windows.Forms.Padding(2);
            this.gbSceneCameraDevice.Size = new System.Drawing.Size(355, 166);
            this.gbSceneCameraDevice.TabIndex = 52;
            this.gbSceneCameraDevice.TabStop = false;
            this.gbSceneCameraDevice.Text = "Scene Camera";
            // 
            // cb_scene_VFlip
            // 
            this.cb_scene_VFlip.AutoSize = true;
            this.cb_scene_VFlip.Location = new System.Drawing.Point(8, 136);
            this.cb_scene_VFlip.Margin = new System.Windows.Forms.Padding(2);
            this.cb_scene_VFlip.Name = "cb_scene_VFlip";
            this.cb_scene_VFlip.Size = new System.Drawing.Size(80, 17);
            this.cb_scene_VFlip.TabIndex = 57;
            this.cb_scene_VFlip.Text = "Flip Vertical";
            this.cb_scene_VFlip.UseVisualStyleBackColor = true;
            this.cb_scene_VFlip.CheckedChanged += new System.EventHandler(this.cb_scene_VFlip_CheckedChanged);
            // 
            // btnSettingsScene
            // 
            this.btnSettingsScene.Location = new System.Drawing.Point(8, 84);
            this.btnSettingsScene.Margin = new System.Windows.Forms.Padding(2);
            this.btnSettingsScene.Name = "btnSettingsScene";
            this.btnSettingsScene.Size = new System.Drawing.Size(84, 37);
            this.btnSettingsScene.TabIndex = 10;
            this.btnSettingsScene.Text = "Settings";
            this.btnSettingsScene.UseVisualStyleBackColor = true;
            this.btnSettingsScene.Click += new System.EventHandler(this.btnSceneSetting_Click);
            // 
            // btnStartScene
            // 
            this.btnStartScene.Location = new System.Drawing.Point(97, 84);
            this.btnStartScene.Margin = new System.Windows.Forms.Padding(2);
            this.btnStartScene.Name = "btnStartScene";
            this.btnStartScene.Size = new System.Drawing.Size(115, 37);
            this.btnStartScene.TabIndex = 9;
            this.btnStartScene.Text = "Start";
            this.btnStartScene.UseVisualStyleBackColor = true;
            this.btnStartScene.Click += new System.EventHandler(this.btnSceneStart_Click);
            // 
            // cmbDeviceCapabilityScene
            // 
            this.cmbDeviceCapabilityScene.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbDeviceCapabilityScene.FormattingEnabled = true;
            this.cmbDeviceCapabilityScene.Location = new System.Drawing.Point(59, 46);
            this.cmbDeviceCapabilityScene.Name = "cmbDeviceCapabilityScene";
            this.cmbDeviceCapabilityScene.Size = new System.Drawing.Size(287, 21);
            this.cmbDeviceCapabilityScene.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 52);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Resolution";
            // 
            // cmbDeviceScene
            // 
            this.cmbDeviceScene.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbDeviceScene.FormattingEnabled = true;
            this.cmbDeviceScene.Location = new System.Drawing.Point(49, 18);
            this.cmbDeviceScene.Name = "cmbDeviceScene";
            this.cmbDeviceScene.Size = new System.Drawing.Size(297, 21);
            this.cmbDeviceScene.TabIndex = 5;
            this.cmbDeviceScene.DropDown += new System.EventHandler(this.cmbDeviceScene_DropDown);
            this.cmbDeviceScene.SelectedIndexChanged += new System.EventHandler(this.cmbDeviceScene_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(2, 26);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Camera";
            // 
            // gbEyeCameraDevice
            // 
            this.gbEyeCameraDevice.Controls.Add(this.cb_eye_VFlip);
            this.gbEyeCameraDevice.Controls.Add(this.btnSettingsEye);
            this.gbEyeCameraDevice.Controls.Add(this.btnStartEye);
            this.gbEyeCameraDevice.Controls.Add(this.label5);
            this.gbEyeCameraDevice.Controls.Add(this.label1);
            this.gbEyeCameraDevice.Controls.Add(this.cmbDeviceCapabilityEye);
            this.gbEyeCameraDevice.Controls.Add(this.cmbDeviceEye);
            this.gbEyeCameraDevice.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbEyeCameraDevice.Location = new System.Drawing.Point(2, 2);
            this.gbEyeCameraDevice.Margin = new System.Windows.Forms.Padding(2);
            this.gbEyeCameraDevice.Name = "gbEyeCameraDevice";
            this.gbEyeCameraDevice.Padding = new System.Windows.Forms.Padding(2);
            this.gbEyeCameraDevice.Size = new System.Drawing.Size(355, 166);
            this.gbEyeCameraDevice.TabIndex = 51;
            this.gbEyeCameraDevice.TabStop = false;
            this.gbEyeCameraDevice.Text = "Eye Camera";
            // 
            // cb_eye_VFlip
            // 
            this.cb_eye_VFlip.AutoSize = true;
            this.cb_eye_VFlip.Location = new System.Drawing.Point(8, 133);
            this.cb_eye_VFlip.Margin = new System.Windows.Forms.Padding(2);
            this.cb_eye_VFlip.Name = "cb_eye_VFlip";
            this.cb_eye_VFlip.Size = new System.Drawing.Size(80, 17);
            this.cb_eye_VFlip.TabIndex = 57;
            this.cb_eye_VFlip.Text = "Flip Vertical";
            this.cb_eye_VFlip.UseVisualStyleBackColor = true;
            this.cb_eye_VFlip.CheckedChanged += new System.EventHandler(this.cb_eye_VFlip_CheckedChanged);
            // 
            // btnSettingsEye
            // 
            this.btnSettingsEye.Location = new System.Drawing.Point(8, 84);
            this.btnSettingsEye.Margin = new System.Windows.Forms.Padding(2);
            this.btnSettingsEye.Name = "btnSettingsEye";
            this.btnSettingsEye.Size = new System.Drawing.Size(84, 37);
            this.btnSettingsEye.TabIndex = 10;
            this.btnSettingsEye.Text = "Settings";
            this.btnSettingsEye.UseVisualStyleBackColor = true;
            this.btnSettingsEye.Click += new System.EventHandler(this.btnEyeSettingClick);
            // 
            // btnStartEye
            // 
            this.btnStartEye.Location = new System.Drawing.Point(97, 84);
            this.btnStartEye.Margin = new System.Windows.Forms.Padding(2);
            this.btnStartEye.Name = "btnStartEye";
            this.btnStartEye.Size = new System.Drawing.Size(115, 37);
            this.btnStartEye.TabIndex = 9;
            this.btnStartEye.Text = "Start";
            this.btnStartEye.UseVisualStyleBackColor = true;
            this.btnStartEye.Click += new System.EventHandler(this.btnEyeStart_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 52);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Resolution";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 26);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Camera";
            // 
            // cmbDeviceCapabilityEye
            // 
            this.cmbDeviceCapabilityEye.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbDeviceCapabilityEye.FormattingEnabled = true;
            this.cmbDeviceCapabilityEye.Location = new System.Drawing.Point(61, 50);
            this.cmbDeviceCapabilityEye.Name = "cmbDeviceCapabilityEye";
            this.cmbDeviceCapabilityEye.Size = new System.Drawing.Size(287, 21);
            this.cmbDeviceCapabilityEye.TabIndex = 8;
            // 
            // cmbDeviceEye
            // 
            this.cmbDeviceEye.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbDeviceEye.FormattingEnabled = true;
            this.cmbDeviceEye.Location = new System.Drawing.Point(50, 24);
            this.cmbDeviceEye.Name = "cmbDeviceEye";
            this.cmbDeviceEye.Size = new System.Drawing.Size(297, 21);
            this.cmbDeviceEye.TabIndex = 6;
            this.cmbDeviceEye.DropDown += new System.EventHandler(this.cmbDeviceEye_DropDown);
            this.cmbDeviceEye.SelectedIndexChanged += new System.EventHandler(this.cmbDeviceEye_SelectedIndexChanged);
            // 
            // tabPage_Glass
            // 
            this.tabPage_Glass.Controls.Add(this.button8);
            this.tabPage_Glass.Controls.Add(this.txtImageName);
            this.tabPage_Glass.Controls.Add(this.button7);
            this.tabPage_Glass.Controls.Add(this.progressBar1);
            this.tabPage_Glass.Controls.Add(this.pictureBox2);
            this.tabPage_Glass.Controls.Add(this.label7);
            this.tabPage_Glass.Controls.Add(this.lbCommandsToGlass);
            this.tabPage_Glass.Controls.Add(this.tbOutput);
            this.tabPage_Glass.Location = new System.Drawing.Point(4, 40);
            this.tabPage_Glass.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage_Glass.Name = "tabPage_Glass";
            this.tabPage_Glass.Size = new System.Drawing.Size(359, 624);
            this.tabPage_Glass.TabIndex = 8;
            this.tabPage_Glass.Text = "Glass";
            this.tabPage_Glass.UseVisualStyleBackColor = true;
            this.tabPage_Glass.Click += new System.EventHandler(this.tabPage_Glass_Click);
            // 
            // button8
            // 
            this.button8.Dock = System.Windows.Forms.DockStyle.Top;
            this.button8.Location = new System.Drawing.Point(0, 436);
            this.button8.Margin = new System.Windows.Forms.Padding(2);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(359, 60);
            this.button8.TabIndex = 73;
            this.button8.Text = "Show QRCode";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // txtImageName
            // 
            this.txtImageName.Location = new System.Drawing.Point(104, 519);
            this.txtImageName.Name = "txtImageName";
            this.txtImageName.Size = new System.Drawing.Size(120, 20);
            this.txtImageName.TabIndex = 74;
            this.txtImageName.Visible = false;
            this.txtImageName.TextChanged += new System.EventHandler(this.txtImageName_TextChanged);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(18, 502);
            this.button7.Margin = new System.Windows.Forms.Padding(2);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(81, 51);
            this.button7.TabIndex = 73;
            this.button7.Text = "detect target";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Visible = false;
            this.button7.Click += new System.EventHandler(this.button7_Click_1);
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.progressBar1.Location = new System.Drawing.Point(0, 426);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(2);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(359, 10);
            this.progressBar1.TabIndex = 47;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox2.Location = new System.Drawing.Point(0, 217);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(359, 209);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 46;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Paint += new System.Windows.Forms.PaintEventHandler(this.Picturebox2_Paint);
            this.pictureBox2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox2_MouseClick);
            this.pictureBox2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox2_MouseDown);
            this.pictureBox2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox2_MouseMove);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(5, 155);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(205, 13);
            this.label7.TabIndex = 45;
            this.label7.Text = "Double click on the msg you want to send";
            this.label7.Visible = false;
            // 
            // lbCommandsToGlass
            // 
            this.lbCommandsToGlass.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbCommandsToGlass.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lbCommandsToGlass.FormattingEnabled = true;
            this.lbCommandsToGlass.ItemHeight = 20;
            this.lbCommandsToGlass.Location = new System.Drawing.Point(0, 153);
            this.lbCommandsToGlass.Margin = new System.Windows.Forms.Padding(2);
            this.lbCommandsToGlass.Name = "lbCommandsToGlass";
            this.lbCommandsToGlass.Size = new System.Drawing.Size(359, 64);
            this.lbCommandsToGlass.TabIndex = 44;
            this.lbCommandsToGlass.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbCommandsToGlass_MouseDoubleClick);
            // 
            // tbOutput
            // 
            this.tbOutput.Dock = System.Windows.Forms.DockStyle.Top;
            this.tbOutput.Location = new System.Drawing.Point(0, 0);
            this.tbOutput.Multiline = true;
            this.tbOutput.Name = "tbOutput";
            this.tbOutput.ReadOnly = true;
            this.tbOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbOutput.Size = new System.Drawing.Size(359, 153);
            this.tbOutput.TabIndex = 39;
            // 
            // tabPage_Eye
            // 
            this.tabPage_Eye.Controls.Add(this.groupBox5);
            this.tabPage_Eye.Controls.Add(this.groupBox6);
            this.tabPage_Eye.Controls.Add(this.groupBox4);
            this.tabPage_Eye.Location = new System.Drawing.Point(4, 40);
            this.tabPage_Eye.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage_Eye.Name = "tabPage_Eye";
            this.tabPage_Eye.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage_Eye.Size = new System.Drawing.Size(359, 624);
            this.tabPage_Eye.TabIndex = 1;
            this.tabPage_Eye.Text = "Eye";
            this.tabPage_Eye.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.cbGM);
            this.groupBox5.Controls.Add(this.panel4);
            this.groupBox5.Controls.Add(this.cbGA);
            this.groupBox5.Controls.Add(this.cbShowGlint);
            this.groupBox5.Controls.Add(this.cbGlintDetection);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox5.Location = new System.Drawing.Point(2, 248);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox5.Size = new System.Drawing.Size(355, 120);
            this.groupBox5.TabIndex = 60;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Glint Detection";
            // 
            // cbGM
            // 
            this.cbGM.AutoSize = true;
            this.cbGM.Location = new System.Drawing.Point(18, 67);
            this.cbGM.Margin = new System.Windows.Forms.Padding(2);
            this.cbGM.Name = "cbGM";
            this.cbGM.Size = new System.Drawing.Size(60, 17);
            this.cbGM.TabIndex = 59;
            this.cbGM.Text = "Manual";
            this.cbGM.UseVisualStyleBackColor = true;
            this.cbGM.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged_2);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label11);
            this.panel4.Controls.Add(this.rbGGaussian);
            this.panel4.Controls.Add(this.rbGMean);
            this.panel4.Location = new System.Drawing.Point(9, 141);
            this.panel4.Margin = new System.Windows.Forms.Padding(2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(202, 112);
            this.panel4.TabIndex = 69;
            this.panel4.Visible = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(2, 32);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 13);
            this.label11.TabIndex = 64;
            this.label11.Text = "blockSize";
            // 
            // rbGGaussian
            // 
            this.rbGGaussian.AutoSize = true;
            this.rbGGaussian.Location = new System.Drawing.Point(112, 11);
            this.rbGGaussian.Margin = new System.Windows.Forms.Padding(2);
            this.rbGGaussian.Name = "rbGGaussian";
            this.rbGGaussian.Size = new System.Drawing.Size(69, 17);
            this.rbGGaussian.TabIndex = 61;
            this.rbGGaussian.Text = "Gaussian";
            this.rbGGaussian.UseVisualStyleBackColor = true;
            this.rbGGaussian.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged_4);
            // 
            // rbGMean
            // 
            this.rbGMean.AutoSize = true;
            this.rbGMean.Checked = true;
            this.rbGMean.Location = new System.Drawing.Point(35, 11);
            this.rbGMean.Margin = new System.Windows.Forms.Padding(2);
            this.rbGMean.Name = "rbGMean";
            this.rbGMean.Size = new System.Drawing.Size(52, 17);
            this.rbGMean.TabIndex = 60;
            this.rbGMean.TabStop = true;
            this.rbGMean.Text = "Mean";
            this.rbGMean.UseVisualStyleBackColor = true;
            this.rbGMean.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged_4);
            // 
            // cbGA
            // 
            this.cbGA.AutoSize = true;
            this.cbGA.Checked = true;
            this.cbGA.Location = new System.Drawing.Point(18, 42);
            this.cbGA.Margin = new System.Windows.Forms.Padding(2);
            this.cbGA.Name = "cbGA";
            this.cbGA.Size = new System.Drawing.Size(47, 17);
            this.cbGA.TabIndex = 58;
            this.cbGA.TabStop = true;
            this.cbGA.Text = "Auto";
            this.cbGA.UseVisualStyleBackColor = true;
            this.cbGA.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged_2);
            // 
            // cbShowGlint
            // 
            this.cbShowGlint.Appearance = System.Windows.Forms.Appearance.Button;
            this.cbShowGlint.BackColor = System.Drawing.Color.Yellow;
            this.cbShowGlint.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cbShowGlint.BackgroundImage")));
            this.cbShowGlint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cbShowGlint.Checked = true;
            this.cbShowGlint.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbShowGlint.FlatAppearance.BorderSize = 0;
            this.cbShowGlint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbShowGlint.Location = new System.Drawing.Point(195, 0);
            this.cbShowGlint.Margin = new System.Windows.Forms.Padding(2);
            this.cbShowGlint.Name = "cbShowGlint";
            this.cbShowGlint.Size = new System.Drawing.Size(14, 18);
            this.cbShowGlint.TabIndex = 57;
            this.cbShowGlint.UseVisualStyleBackColor = false;
            this.cbShowGlint.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged_8);
            // 
            // cbGlintDetection
            // 
            this.cbGlintDetection.Checked = true;
            this.cbGlintDetection.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbGlintDetection.Location = new System.Drawing.Point(83, 0);
            this.cbGlintDetection.Margin = new System.Windows.Forms.Padding(2);
            this.cbGlintDetection.Name = "cbGlintDetection";
            this.cbGlintDetection.Size = new System.Drawing.Size(106, 17);
            this.cbGlintDetection.TabIndex = 56;
            this.cbGlintDetection.UseVisualStyleBackColor = true;
            this.cbGlintDetection.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged_7);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.cbPM);
            this.groupBox6.Controls.Add(this.panel3);
            this.groupBox6.Controls.Add(this.cbPA);
            this.groupBox6.Controls.Add(this.cbRemoveGlint);
            this.groupBox6.Controls.Add(this.cbDilateErode);
            this.groupBox6.Controls.Add(this.cbShowPupil);
            this.groupBox6.Controls.Add(this.cbPupilDetection);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox6.Location = new System.Drawing.Point(2, 72);
            this.groupBox6.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox6.Size = new System.Drawing.Size(355, 176);
            this.groupBox6.TabIndex = 60;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Pupil Detection";
            // 
            // cbPM
            // 
            this.cbPM.AutoSize = true;
            this.cbPM.Location = new System.Drawing.Point(17, 69);
            this.cbPM.Margin = new System.Windows.Forms.Padding(2);
            this.cbPM.Name = "cbPM";
            this.cbPM.Size = new System.Drawing.Size(60, 17);
            this.cbPM.TabIndex = 59;
            this.cbPM.Text = "Manual";
            this.cbPM.UseVisualStyleBackColor = true;
            this.cbPM.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged_1);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.rbPGaussian);
            this.panel3.Controls.Add(this.rbPMean);
            this.panel3.Location = new System.Drawing.Point(7, 190);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(202, 112);
            this.panel3.TabIndex = 67;
            this.panel3.Visible = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(2, 32);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 13);
            this.label10.TabIndex = 64;
            this.label10.Text = "blockSize";
            // 
            // rbPGaussian
            // 
            this.rbPGaussian.AutoSize = true;
            this.rbPGaussian.Location = new System.Drawing.Point(112, 11);
            this.rbPGaussian.Margin = new System.Windows.Forms.Padding(2);
            this.rbPGaussian.Name = "rbPGaussian";
            this.rbPGaussian.Size = new System.Drawing.Size(69, 17);
            this.rbPGaussian.TabIndex = 61;
            this.rbPGaussian.Text = "Gaussian";
            this.rbPGaussian.UseVisualStyleBackColor = true;
            this.rbPGaussian.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged_3);
            // 
            // rbPMean
            // 
            this.rbPMean.AutoSize = true;
            this.rbPMean.Checked = true;
            this.rbPMean.Location = new System.Drawing.Point(35, 11);
            this.rbPMean.Margin = new System.Windows.Forms.Padding(2);
            this.rbPMean.Name = "rbPMean";
            this.rbPMean.Size = new System.Drawing.Size(52, 17);
            this.rbPMean.TabIndex = 60;
            this.rbPMean.TabStop = true;
            this.rbPMean.Text = "Mean";
            this.rbPMean.UseVisualStyleBackColor = true;
            this.rbPMean.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged_3);
            // 
            // cbPA
            // 
            this.cbPA.AutoSize = true;
            this.cbPA.Checked = true;
            this.cbPA.Location = new System.Drawing.Point(18, 44);
            this.cbPA.Margin = new System.Windows.Forms.Padding(2);
            this.cbPA.Name = "cbPA";
            this.cbPA.Size = new System.Drawing.Size(47, 17);
            this.cbPA.TabIndex = 58;
            this.cbPA.TabStop = true;
            this.cbPA.Text = "Auto";
            this.cbPA.UseVisualStyleBackColor = true;
            this.cbPA.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged_1);
            // 
            // cbRemoveGlint
            // 
            this.cbRemoveGlint.Location = new System.Drawing.Point(18, 131);
            this.cbRemoveGlint.Margin = new System.Windows.Forms.Padding(2);
            this.cbRemoveGlint.Name = "cbRemoveGlint";
            this.cbRemoveGlint.Size = new System.Drawing.Size(148, 17);
            this.cbRemoveGlint.TabIndex = 66;
            this.cbRemoveGlint.Text = "Remove Glint";
            this.cbRemoveGlint.UseVisualStyleBackColor = true;
            this.cbRemoveGlint.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged_1);
            // 
            // cbDilateErode
            // 
            this.cbDilateErode.Location = new System.Drawing.Point(18, 110);
            this.cbDilateErode.Margin = new System.Windows.Forms.Padding(2);
            this.cbDilateErode.Name = "cbDilateErode";
            this.cbDilateErode.Size = new System.Drawing.Size(148, 17);
            this.cbDilateErode.TabIndex = 65;
            this.cbDilateErode.Text = "Fill Gaps";
            this.cbDilateErode.UseVisualStyleBackColor = true;
            this.cbDilateErode.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged_6);
            // 
            // cbShowPupil
            // 
            this.cbShowPupil.Appearance = System.Windows.Forms.Appearance.Button;
            this.cbShowPupil.BackColor = System.Drawing.Color.Yellow;
            this.cbShowPupil.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cbShowPupil.BackgroundImage")));
            this.cbShowPupil.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cbShowPupil.Checked = true;
            this.cbShowPupil.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbShowPupil.FlatAppearance.BorderSize = 0;
            this.cbShowPupil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbShowPupil.Location = new System.Drawing.Point(195, -2);
            this.cbShowPupil.Margin = new System.Windows.Forms.Padding(2);
            this.cbShowPupil.Name = "cbShowPupil";
            this.cbShowPupil.Size = new System.Drawing.Size(14, 18);
            this.cbShowPupil.TabIndex = 56;
            this.cbShowPupil.UseVisualStyleBackColor = false;
            this.cbShowPupil.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged_4);
            // 
            // cbPupilDetection
            // 
            this.cbPupilDetection.Checked = true;
            this.cbPupilDetection.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbPupilDetection.Location = new System.Drawing.Point(83, -1);
            this.cbPupilDetection.Margin = new System.Windows.Forms.Padding(2);
            this.cbPupilDetection.Name = "cbPupilDetection";
            this.cbPupilDetection.Size = new System.Drawing.Size(106, 17);
            this.cbPupilDetection.TabIndex = 55;
            this.cbPupilDetection.UseVisualStyleBackColor = true;
            this.cbPupilDetection.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged_3);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cbShowIris);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox4.Location = new System.Drawing.Point(2, 2);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox4.Size = new System.Drawing.Size(355, 70);
            this.groupBox4.TabIndex = 59;
            this.groupBox4.TabStop = false;
            // 
            // cbShowIris
            // 
            this.cbShowIris.Appearance = System.Windows.Forms.Appearance.Button;
            this.cbShowIris.BackColor = System.Drawing.Color.Yellow;
            this.cbShowIris.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cbShowIris.BackgroundImage")));
            this.cbShowIris.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cbShowIris.Checked = true;
            this.cbShowIris.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbShowIris.FlatAppearance.BorderSize = 0;
            this.cbShowIris.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbShowIris.Location = new System.Drawing.Point(194, 24);
            this.cbShowIris.Margin = new System.Windows.Forms.Padding(2);
            this.cbShowIris.Name = "cbShowIris";
            this.cbShowIris.Size = new System.Drawing.Size(14, 18);
            this.cbShowIris.TabIndex = 3;
            this.cbShowIris.UseVisualStyleBackColor = false;
            this.cbShowIris.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged_2);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 28);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(40, 13);
            this.label9.TabIndex = 1;
            this.label9.Text = "IrisSize";
            // 
            // tabPage_Scene
            // 
            this.tabPage_Scene.Controls.Add(this.label17);
            this.tabPage_Scene.Controls.Add(this.groupBox8);
            this.tabPage_Scene.Controls.Add(this.cbShowGaze);
            this.tabPage_Scene.Controls.Add(this.groupBox7);
            this.tabPage_Scene.Location = new System.Drawing.Point(4, 40);
            this.tabPage_Scene.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage_Scene.Name = "tabPage_Scene";
            this.tabPage_Scene.Size = new System.Drawing.Size(359, 624);
            this.tabPage_Scene.TabIndex = 2;
            this.tabPage_Scene.Text = "Scene";
            this.tabPage_Scene.UseVisualStyleBackColor = true;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(25, 302);
            this.label17.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(146, 13);
            this.label17.TabIndex = 68;
            this.label17.Text = "Show gaze point in the image";
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.btnSceneCameraCalibration);
            this.groupBox8.Controls.Add(this.cbSceneUnDistortion);
            this.groupBox8.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox8.Location = new System.Drawing.Point(0, 216);
            this.groupBox8.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox8.Size = new System.Drawing.Size(359, 76);
            this.groupBox8.TabIndex = 63;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Lens Distortion Correction";
            // 
            // btnSceneCameraCalibration
            // 
            this.btnSceneCameraCalibration.Location = new System.Drawing.Point(37, 26);
            this.btnSceneCameraCalibration.Margin = new System.Windows.Forms.Padding(2);
            this.btnSceneCameraCalibration.Name = "btnSceneCameraCalibration";
            this.btnSceneCameraCalibration.Size = new System.Drawing.Size(161, 35);
            this.btnSceneCameraCalibration.TabIndex = 59;
            this.btnSceneCameraCalibration.Text = "Calibrate for new Camera";
            this.btnSceneCameraCalibration.UseVisualStyleBackColor = true;
            this.btnSceneCameraCalibration.Click += new System.EventHandler(this.button1_Click_6);
            // 
            // cbSceneUnDistortion
            // 
            this.cbSceneUnDistortion.Location = new System.Drawing.Point(136, 0);
            this.cbSceneUnDistortion.Margin = new System.Windows.Forms.Padding(2);
            this.cbSceneUnDistortion.Name = "cbSceneUnDistortion";
            this.cbSceneUnDistortion.Size = new System.Drawing.Size(62, 13);
            this.cbSceneUnDistortion.TabIndex = 58;
            this.cbSceneUnDistortion.UseVisualStyleBackColor = true;
            this.cbSceneUnDistortion.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged_11);
            // 
            // cbShowGaze
            // 
            this.cbShowGaze.Appearance = System.Windows.Forms.Appearance.Button;
            this.cbShowGaze.BackColor = System.Drawing.Color.Yellow;
            this.cbShowGaze.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cbShowGaze.BackgroundImage")));
            this.cbShowGaze.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cbShowGaze.Checked = true;
            this.cbShowGaze.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbShowGaze.FlatAppearance.BorderSize = 0;
            this.cbShowGaze.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbShowGaze.Location = new System.Drawing.Point(7, 299);
            this.cbShowGaze.Margin = new System.Windows.Forms.Padding(2);
            this.cbShowGaze.Name = "cbShowGaze";
            this.cbShowGaze.Size = new System.Drawing.Size(14, 18);
            this.cbShowGaze.TabIndex = 67;
            this.cbShowGaze.UseVisualStyleBackColor = false;
            this.cbShowGaze.CheckedChanged += new System.EventHandler(this.cbShowGaze_CheckedChanged_2);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.groupBox21);
            this.groupBox7.Controls.Add(this.label16);
            this.groupBox7.Controls.Add(this.label15);
            this.groupBox7.Controls.Add(this.cbShowScreen);
            this.groupBox7.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox7.Location = new System.Drawing.Point(0, 0);
            this.groupBox7.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox7.Size = new System.Drawing.Size(359, 216);
            this.groupBox7.TabIndex = 62;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Screen Detection";
            // 
            // groupBox21
            // 
            this.groupBox21.Controls.Add(this.cbShowEdges);
            this.groupBox21.Location = new System.Drawing.Point(7, 100);
            this.groupBox21.Name = "groupBox21";
            this.groupBox21.Size = new System.Drawing.Size(221, 102);
            this.groupBox21.TabIndex = 3;
            this.groupBox21.TabStop = false;
            this.groupBox21.Text = "Edge detection sensitivity";
            // 
            // cbShowEdges
            // 
            this.cbShowEdges.Appearance = System.Windows.Forms.Appearance.Button;
            this.cbShowEdges.BackColor = System.Drawing.Color.White;
            this.cbShowEdges.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cbShowEdges.BackgroundImage")));
            this.cbShowEdges.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cbShowEdges.FlatAppearance.BorderSize = 0;
            this.cbShowEdges.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbShowEdges.Location = new System.Drawing.Point(195, -1);
            this.cbShowEdges.Margin = new System.Windows.Forms.Padding(2);
            this.cbShowEdges.Name = "cbShowEdges";
            this.cbShowEdges.Size = new System.Drawing.Size(14, 18);
            this.cbShowEdges.TabIndex = 68;
            this.cbShowEdges.UseVisualStyleBackColor = false;
            this.cbShowEdges.CheckedChanged += new System.EventHandler(this.cbShowEdges_CheckedChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(35, 32);
            this.label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(164, 13);
            this.label16.TabIndex = 64;
            this.label16.Text = "Minimum display size in the image";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(49, 45);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(0, 13);
            this.label15.TabIndex = 63;
            // 
            // cbShowScreen
            // 
            this.cbShowScreen.Appearance = System.Windows.Forms.Appearance.Button;
            this.cbShowScreen.BackColor = System.Drawing.Color.Yellow;
            this.cbShowScreen.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cbShowScreen.BackgroundImage")));
            this.cbShowScreen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cbShowScreen.Checked = true;
            this.cbShowScreen.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbShowScreen.FlatAppearance.BorderSize = 0;
            this.cbShowScreen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbShowScreen.Location = new System.Drawing.Point(203, 0);
            this.cbShowScreen.Margin = new System.Windows.Forms.Padding(2);
            this.cbShowScreen.Name = "cbShowScreen";
            this.cbShowScreen.Size = new System.Drawing.Size(14, 18);
            this.cbShowScreen.TabIndex = 58;
            this.cbShowScreen.UseVisualStyleBackColor = false;
            this.cbShowScreen.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged_10);
            // 
            // tabPage_Calibration
            // 
            this.tabPage_Calibration.Controls.Add(this.gbCalibrationGlass);
            this.tabPage_Calibration.Controls.Add(this.gbCalibrationRemote);
            this.tabPage_Calibration.Controls.Add(this.gbCalibrationHM);
            this.tabPage_Calibration.Controls.Add(this.panel5);
            this.tabPage_Calibration.Location = new System.Drawing.Point(4, 40);
            this.tabPage_Calibration.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage_Calibration.Name = "tabPage_Calibration";
            this.tabPage_Calibration.Size = new System.Drawing.Size(359, 624);
            this.tabPage_Calibration.TabIndex = 3;
            this.tabPage_Calibration.Text = "Calibration";
            this.tabPage_Calibration.UseVisualStyleBackColor = true;
            // 
            // gbCalibrationGlass
            // 
            this.gbCalibrationGlass.Controls.Add(this.button9);
            this.gbCalibrationGlass.Controls.Add(this.button5);
            this.gbCalibrationGlass.Controls.Add(this.button6);
            this.gbCalibrationGlass.Controls.Add(this.label4);
            this.gbCalibrationGlass.Controls.Add(this.label3);
            this.gbCalibrationGlass.Controls.Add(this.button3);
            this.gbCalibrationGlass.Controls.Add(this.button4);
            this.gbCalibrationGlass.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbCalibrationGlass.Location = new System.Drawing.Point(0, 404);
            this.gbCalibrationGlass.Name = "gbCalibrationGlass";
            this.gbCalibrationGlass.Size = new System.Drawing.Size(359, 227);
            this.gbCalibrationGlass.TabIndex = 62;
            this.gbCalibrationGlass.TabStop = false;
            this.gbCalibrationGlass.Text = "Gaze Estimation for the Glass ";
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(173, 59);
            this.button9.Margin = new System.Windows.Forms.Padding(2);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(51, 50);
            this.button9.TabIndex = 71;
            this.button9.Tag = "4";
            this.button9.Text = "correct offset";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(31, 157);
            this.button5.Margin = new System.Windows.Forms.Padding(2);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(83, 50);
            this.button5.TabIndex = 70;
            this.button5.Tag = "4";
            this.button5.Text = "4 Points Homography";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(118, 157);
            this.button6.Margin = new System.Windows.Forms.Padding(2);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(83, 50);
            this.button6.TabIndex = 69;
            this.button6.Tag = "9";
            this.button6.Text = "9 Points Polynomial";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button5_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 132);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 13);
            this.label4.TabIndex = 68;
            this.label4.Text = "Scene Camera";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 32);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 67;
            this.label3.Text = "HMD";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(9, 59);
            this.button3.Margin = new System.Windows.Forms.Padding(2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(73, 50);
            this.button3.TabIndex = 65;
            this.button3.Tag = "4";
            this.button3.Text = "4 Points Homography";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(86, 59);
            this.button4.Margin = new System.Windows.Forms.Padding(2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(83, 50);
            this.button4.TabIndex = 64;
            this.button4.Tag = "9";
            this.button4.Text = "9 Points Polynomial";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button3_Click);
            // 
            // gbCalibrationRemote
            // 
            this.gbCalibrationRemote.Controls.Add(this.button1);
            this.gbCalibrationRemote.Controls.Add(this.button2);
            this.gbCalibrationRemote.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbCalibrationRemote.Location = new System.Drawing.Point(0, 314);
            this.gbCalibrationRemote.Name = "gbCalibrationRemote";
            this.gbCalibrationRemote.Size = new System.Drawing.Size(359, 90);
            this.gbCalibrationRemote.TabIndex = 3;
            this.gbCalibrationRemote.TabStop = false;
            this.gbCalibrationRemote.Text = "Gaze Estimation in the remote display";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(8, 25);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(83, 50);
            this.button1.TabIndex = 65;
            this.button1.Text = "4 Points Homography";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(131, 25);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(83, 50);
            this.button2.TabIndex = 64;
            this.button2.Text = "9 Points Polynomial";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_2);
            // 
            // gbCalibrationHM
            // 
            this.gbCalibrationHM.Controls.Add(this.lbl_calibration);
            this.gbCalibrationHM.Controls.Add(this.btnCalibration_Homography);
            this.gbCalibrationHM.Controls.Add(this.btnCalibration_Polynomial);
            this.gbCalibrationHM.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbCalibrationHM.Location = new System.Drawing.Point(0, 144);
            this.gbCalibrationHM.Margin = new System.Windows.Forms.Padding(2);
            this.gbCalibrationHM.Name = "gbCalibrationHM";
            this.gbCalibrationHM.Padding = new System.Windows.Forms.Padding(2);
            this.gbCalibrationHM.Size = new System.Drawing.Size(359, 170);
            this.gbCalibrationHM.TabIndex = 61;
            this.gbCalibrationHM.TabStop = false;
            this.gbCalibrationHM.Text = "Gaze Estimation in the scene image";
            // 
            // lbl_calibration
            // 
            this.lbl_calibration.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lbl_calibration.ForeColor = System.Drawing.Color.Red;
            this.lbl_calibration.Location = new System.Drawing.Point(3, 76);
            this.lbl_calibration.Name = "lbl_calibration";
            this.lbl_calibration.Size = new System.Drawing.Size(221, 84);
            this.lbl_calibration.TabIndex = 3;
            this.lbl_calibration.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnCalibration_Homography
            // 
            this.btnCalibration_Homography.Location = new System.Drawing.Point(8, 24);
            this.btnCalibration_Homography.Margin = new System.Windows.Forms.Padding(2);
            this.btnCalibration_Homography.Name = "btnCalibration_Homography";
            this.btnCalibration_Homography.Size = new System.Drawing.Size(83, 50);
            this.btnCalibration_Homography.TabIndex = 63;
            this.btnCalibration_Homography.Text = "4 Points Homography";
            this.btnCalibration_Homography.UseVisualStyleBackColor = true;
            this.btnCalibration_Homography.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // btnCalibration_Polynomial
            // 
            this.btnCalibration_Polynomial.Location = new System.Drawing.Point(131, 24);
            this.btnCalibration_Polynomial.Margin = new System.Windows.Forms.Padding(2);
            this.btnCalibration_Polynomial.Name = "btnCalibration_Polynomial";
            this.btnCalibration_Polynomial.Size = new System.Drawing.Size(83, 50);
            this.btnCalibration_Polynomial.TabIndex = 62;
            this.btnCalibration_Polynomial.Text = "9 Points Polynomial";
            this.btnCalibration_Polynomial.UseVisualStyleBackColor = true;
            this.btnCalibration_Polynomial.Click += new System.EventHandler(this.button1_Click_7);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.rbGlint);
            this.panel5.Controls.Add(this.rbPupilGlint);
            this.panel5.Controls.Add(this.rdOnlyPupil);
            this.panel5.Controls.Add(this.cbGazeSmoothing);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Margin = new System.Windows.Forms.Padding(2);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(359, 144);
            this.panel5.TabIndex = 61;
            // 
            // rbGlint
            // 
            this.rbGlint.AutoSize = true;
            this.rbGlint.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.rbGlint.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.rbGlint.Location = new System.Drawing.Point(8, 47);
            this.rbGlint.Margin = new System.Windows.Forms.Padding(2);
            this.rbGlint.Name = "rbGlint";
            this.rbGlint.Size = new System.Drawing.Size(80, 17);
            this.rbGlint.TabIndex = 67;
            this.rbGlint.Text = "Glint Center";
            this.rbGlint.UseVisualStyleBackColor = true;
            this.rbGlint.CheckedChanged += new System.EventHandler(this.rbGlint_CheckedChanged);
            // 
            // rbPupilGlint
            // 
            this.rbPupilGlint.AutoSize = true;
            this.rbPupilGlint.Checked = true;
            this.rbPupilGlint.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.rbPupilGlint.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.rbPupilGlint.Location = new System.Drawing.Point(8, 26);
            this.rbPupilGlint.Margin = new System.Windows.Forms.Padding(2);
            this.rbPupilGlint.Name = "rbPupilGlint";
            this.rbPupilGlint.Size = new System.Drawing.Size(106, 17);
            this.rbPupilGlint.TabIndex = 59;
            this.rbPupilGlint.TabStop = true;
            this.rbPupilGlint.Text = "Pupil-Glint Vector";
            this.rbPupilGlint.UseVisualStyleBackColor = true;
            this.rbPupilGlint.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged_5);
            // 
            // rdOnlyPupil
            // 
            this.rdOnlyPupil.AutoSize = true;
            this.rdOnlyPupil.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.rdOnlyPupil.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.rdOnlyPupil.Location = new System.Drawing.Point(7, 5);
            this.rdOnlyPupil.Margin = new System.Windows.Forms.Padding(2);
            this.rdOnlyPupil.Name = "rdOnlyPupil";
            this.rdOnlyPupil.Size = new System.Drawing.Size(82, 17);
            this.rdOnlyPupil.TabIndex = 58;
            this.rdOnlyPupil.Text = "Pupil Center";
            this.rdOnlyPupil.UseVisualStyleBackColor = true;
            this.rdOnlyPupil.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged_5);
            // 
            // cbGazeSmoothing
            // 
            this.cbGazeSmoothing.Checked = true;
            this.cbGazeSmoothing.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbGazeSmoothing.Location = new System.Drawing.Point(7, 115);
            this.cbGazeSmoothing.Margin = new System.Windows.Forms.Padding(2);
            this.cbGazeSmoothing.Name = "cbGazeSmoothing";
            this.cbGazeSmoothing.Size = new System.Drawing.Size(148, 17);
            this.cbGazeSmoothing.TabIndex = 66;
            this.cbGazeSmoothing.Text = "Gaze Smoothing";
            this.cbGazeSmoothing.UseVisualStyleBackColor = true;
            this.cbGazeSmoothing.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged_13);
            // 
            // tabPage_Data
            // 
            this.tabPage_Data.Controls.Add(this.groupBox11);
            this.tabPage_Data.Controls.Add(this.groupBox10);
            this.tabPage_Data.Location = new System.Drawing.Point(4, 40);
            this.tabPage_Data.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage_Data.Name = "tabPage_Data";
            this.tabPage_Data.Size = new System.Drawing.Size(359, 624);
            this.tabPage_Data.TabIndex = 4;
            this.tabPage_Data.Text = "Data";
            this.tabPage_Data.UseVisualStyleBackColor = true;
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.chart3);
            this.groupBox11.Controls.Add(this.cbPlot);
            this.groupBox11.Controls.Add(this.chart2);
            this.groupBox11.Controls.Add(this.chart1);
            this.groupBox11.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox11.Location = new System.Drawing.Point(0, 144);
            this.groupBox11.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox11.Size = new System.Drawing.Size(359, 466);
            this.groupBox11.TabIndex = 63;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "Plot";
            // 
            // chart3
            // 
            this.chart3.BackColor = System.Drawing.Color.Transparent;
            chartArea1.AxisX.IsMarginVisible = false;
            chartArea1.AxisX.LabelStyle.Enabled = false;
            chartArea1.AxisX.MajorGrid.Enabled = false;
            chartArea1.AxisX.MajorTickMark.Enabled = false;
            chartArea1.AxisY.IsLabelAutoFit = false;
            chartArea1.AxisY.LabelStyle.Interval = 0D;
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.WhiteSmoke;
            chartArea1.BackColor = System.Drawing.Color.White;
            chartArea1.InnerPlotPosition.Auto = false;
            chartArea1.InnerPlotPosition.Height = 86.87582F;
            chartArea1.InnerPlotPosition.Width = 86.45924F;
            chartArea1.InnerPlotPosition.X = 13.54076F;
            chartArea1.InnerPlotPosition.Y = 6.56209F;
            chartArea1.Name = "ChartArea1";
            chartArea1.Position.Auto = false;
            chartArea1.Position.Height = 80.00502F;
            chartArea1.Position.Width = 94F;
            chartArea1.Position.X = 3F;
            chartArea1.Position.Y = 16.99498F;
            this.chart3.ChartAreas.Add(chartArea1);
            this.chart3.Dock = System.Windows.Forms.DockStyle.Top;
            this.chart3.Location = new System.Drawing.Point(2, 294);
            this.chart3.Margin = new System.Windows.Forms.Padding(2);
            this.chart3.Name = "chart3";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.EmptyPointStyle.BorderWidth = 0;
            series1.EmptyPointStyle.Color = System.Drawing.Color.Red;
            series1.EmptyPointStyle.CustomProperties = "LabelStyle=Top";
            series1.EmptyPointStyle.IsVisibleInLegend = false;
            series1.EmptyPointStyle.MarkerColor = System.Drawing.Color.Red;
            series1.EmptyPointStyle.MarkerImageTransparentColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            series1.EmptyPointStyle.MarkerSize = 1;
            series1.EmptyPointStyle.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Cross;
            series1.Name = "PupilDiam";
            this.chart3.Series.Add(series1);
            this.chart3.Size = new System.Drawing.Size(355, 141);
            this.chart3.TabIndex = 47;
            this.chart3.Text = "chart3";
            title1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title1.Name = "PupilDiam";
            title1.Position.Auto = false;
            title1.Position.Height = 10.99498F;
            title1.Position.Width = 94F;
            title1.Position.X = 3F;
            title1.Position.Y = 3F;
            title1.Text = "Pupil Diameter";
            this.chart3.Titles.Add(title1);
            // 
            // cbPlot
            // 
            this.cbPlot.Location = new System.Drawing.Point(27, -1);
            this.cbPlot.Margin = new System.Windows.Forms.Padding(2);
            this.cbPlot.Name = "cbPlot";
            this.cbPlot.Size = new System.Drawing.Size(183, 17);
            this.cbPlot.TabIndex = 58;
            this.cbPlot.UseVisualStyleBackColor = true;
            this.cbPlot.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged_14);
            // 
            // chart2
            // 
            this.chart2.BackColor = System.Drawing.Color.Transparent;
            chartArea2.AxisX.IsMarginVisible = false;
            chartArea2.AxisX.LabelStyle.Enabled = false;
            chartArea2.AxisX.MajorGrid.Enabled = false;
            chartArea2.AxisX.MajorTickMark.Enabled = false;
            chartArea2.AxisY.IsLabelAutoFit = false;
            chartArea2.AxisY.LabelStyle.Interval = 0D;
            chartArea2.AxisY.MajorGrid.LineColor = System.Drawing.Color.WhiteSmoke;
            chartArea2.BackColor = System.Drawing.Color.White;
            chartArea2.InnerPlotPosition.Auto = false;
            chartArea2.InnerPlotPosition.Height = 86.87582F;
            chartArea2.InnerPlotPosition.Width = 86.45924F;
            chartArea2.InnerPlotPosition.X = 13.54076F;
            chartArea2.InnerPlotPosition.Y = 6.56209F;
            chartArea2.Name = "ChartArea1";
            chartArea2.Position.Auto = false;
            chartArea2.Position.Height = 80.00502F;
            chartArea2.Position.Width = 94F;
            chartArea2.Position.X = 3F;
            chartArea2.Position.Y = 16.99498F;
            this.chart2.ChartAreas.Add(chartArea2);
            this.chart2.Dock = System.Windows.Forms.DockStyle.Top;
            this.chart2.Location = new System.Drawing.Point(2, 153);
            this.chart2.Margin = new System.Windows.Forms.Padding(2);
            this.chart2.Name = "chart2";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.EmptyPointStyle.BorderWidth = 0;
            series2.EmptyPointStyle.Color = System.Drawing.Color.Red;
            series2.EmptyPointStyle.CustomProperties = "LabelStyle=Top";
            series2.EmptyPointStyle.IsVisibleInLegend = false;
            series2.EmptyPointStyle.MarkerColor = System.Drawing.Color.Red;
            series2.EmptyPointStyle.MarkerImageTransparentColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            series2.EmptyPointStyle.MarkerSize = 1;
            series2.EmptyPointStyle.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Cross;
            series2.Name = "PupilY";
            this.chart2.Series.Add(series2);
            this.chart2.Size = new System.Drawing.Size(355, 141);
            this.chart2.TabIndex = 46;
            this.chart2.Text = "chart2";
            title2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title2.Name = "PupilY";
            title2.Position.Auto = false;
            title2.Position.Height = 10.99498F;
            title2.Position.Width = 94F;
            title2.Position.X = 3F;
            title2.Position.Y = 3F;
            title2.Text = "Pupil Y";
            this.chart2.Titles.Add(title2);
            // 
            // chart1
            // 
            this.chart1.BackColor = System.Drawing.Color.Transparent;
            chartArea3.AxisX.IsMarginVisible = false;
            chartArea3.AxisX.LabelStyle.Enabled = false;
            chartArea3.AxisX.MajorGrid.Enabled = false;
            chartArea3.AxisX.MajorTickMark.Enabled = false;
            chartArea3.AxisY.IsLabelAutoFit = false;
            chartArea3.AxisY.LabelStyle.Interval = 0D;
            chartArea3.AxisY.MajorGrid.LineColor = System.Drawing.Color.WhiteSmoke;
            chartArea3.BackColor = System.Drawing.Color.White;
            chartArea3.InnerPlotPosition.Auto = false;
            chartArea3.InnerPlotPosition.Height = 86.83621F;
            chartArea3.InnerPlotPosition.Width = 86.45924F;
            chartArea3.InnerPlotPosition.X = 13.54076F;
            chartArea3.InnerPlotPosition.Y = 6.5819F;
            chartArea3.Name = "ChartArea1";
            chartArea3.Position.Auto = false;
            chartArea3.Position.Height = 79.76426F;
            chartArea3.Position.Width = 94F;
            chartArea3.Position.X = 3F;
            chartArea3.Position.Y = 17.23574F;
            this.chart1.ChartAreas.Add(chartArea3);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Top;
            this.chart1.Location = new System.Drawing.Point(2, 15);
            this.chart1.Margin = new System.Windows.Forms.Padding(2);
            this.chart1.Name = "chart1";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.EmptyPointStyle.BorderWidth = 0;
            series3.EmptyPointStyle.Color = System.Drawing.Color.Red;
            series3.EmptyPointStyle.CustomProperties = "LabelStyle=Top";
            series3.EmptyPointStyle.IsVisibleInLegend = false;
            series3.EmptyPointStyle.MarkerColor = System.Drawing.Color.Red;
            series3.EmptyPointStyle.MarkerImageTransparentColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            series3.EmptyPointStyle.MarkerSize = 1;
            series3.EmptyPointStyle.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Cross;
            series3.Name = "PupilX";
            this.chart1.Series.Add(series3);
            this.chart1.Size = new System.Drawing.Size(355, 138);
            this.chart1.TabIndex = 45;
            this.chart1.Text = "chart1";
            title3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title3.Name = "PupilX";
            title3.Position.Auto = false;
            title3.Position.Height = 11.23574F;
            title3.Position.Width = 94F;
            title3.Position.X = 3F;
            title3.Position.Y = 3F;
            title3.Text = "Pupil X";
            this.chart1.Titles.Add(title3);
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.checkBox3);
            this.groupBox10.Controls.Add(this.checkBox1);
            this.groupBox10.Controls.Add(this.btn_RecordProgress);
            this.groupBox10.Controls.Add(this.btn_Record);
            this.groupBox10.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox10.Location = new System.Drawing.Point(0, 0);
            this.groupBox10.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox10.Size = new System.Drawing.Size(359, 144);
            this.groupBox10.TabIndex = 63;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Record Videos and EyeData";
            // 
            // checkBox3
            // 
            this.checkBox3.Checked = true;
            this.checkBox3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox3.Location = new System.Drawing.Point(109, 91);
            this.checkBox3.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(86, 23);
            this.checkBox3.TabIndex = 60;
            this.checkBox3.Text = "Scene video";
            this.checkBox3.UseVisualStyleBackColor = true;
            this.checkBox3.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.Location = new System.Drawing.Point(36, 91);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(86, 23);
            this.checkBox1.TabIndex = 59;
            this.checkBox1.Text = "Eye video";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // btn_RecordProgress
            // 
            this.btn_RecordProgress.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btn_RecordProgress.ForeColor = System.Drawing.Color.Red;
            this.btn_RecordProgress.Location = new System.Drawing.Point(36, 74);
            this.btn_RecordProgress.Margin = new System.Windows.Forms.Padding(2);
            this.btn_RecordProgress.MarqueeAnimationSpeed = 10;
            this.btn_RecordProgress.Name = "btn_RecordProgress";
            this.btn_RecordProgress.Size = new System.Drawing.Size(150, 10);
            this.btn_RecordProgress.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.btn_RecordProgress.TabIndex = 0;
            this.btn_RecordProgress.Click += new System.EventHandler(this.progressBar1_Click);
            // 
            // btn_Record
            // 
            this.btn_Record.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btn_Record.Location = new System.Drawing.Point(36, 21);
            this.btn_Record.Name = "btn_Record";
            this.btn_Record.Size = new System.Drawing.Size(150, 54);
            this.btn_Record.TabIndex = 3;
            this.btn_Record.Text = "Export";
            this.btn_Record.UseVisualStyleBackColor = true;
            this.btn_Record.Click += new System.EventHandler(this.btn_Record_Click);
            // 
            // tabPage_Clients
            // 
            this.tabPage_Clients.Controls.Add(this.panelClients);
            this.tabPage_Clients.Controls.Add(this.groupBox12);
            this.tabPage_Clients.Location = new System.Drawing.Point(4, 40);
            this.tabPage_Clients.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage_Clients.Name = "tabPage_Clients";
            this.tabPage_Clients.Size = new System.Drawing.Size(359, 624);
            this.tabPage_Clients.TabIndex = 5;
            this.tabPage_Clients.Text = "Clients";
            this.tabPage_Clients.UseVisualStyleBackColor = true;
            // 
            // panelClients
            // 
            this.panelClients.AutoSize = true;
            this.panelClients.Controls.Add(this.radioButtonAutoActivation);
            this.panelClients.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelClients.Location = new System.Drawing.Point(0, 230);
            this.panelClients.Margin = new System.Windows.Forms.Padding(2);
            this.panelClients.Name = "panelClients";
            this.panelClients.Padding = new System.Windows.Forms.Padding(2);
            this.panelClients.Size = new System.Drawing.Size(359, 53);
            this.panelClients.TabIndex = 64;
            this.panelClients.TabStop = false;
            this.panelClients.Text = "Clients";
            // 
            // radioButtonAutoActivation
            // 
            this.radioButtonAutoActivation.AutoSize = true;
            this.radioButtonAutoActivation.Checked = true;
            this.radioButtonAutoActivation.Location = new System.Drawing.Point(132, 18);
            this.radioButtonAutoActivation.Name = "radioButtonAutoActivation";
            this.radioButtonAutoActivation.Size = new System.Drawing.Size(97, 17);
            this.radioButtonAutoActivation.TabIndex = 0;
            this.radioButtonAutoActivation.TabStop = true;
            this.radioButtonAutoActivation.Text = "Auto Activation";
            this.radioButtonAutoActivation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioButtonAutoActivation.UseVisualStyleBackColor = true;
            this.radioButtonAutoActivation.CheckedChanged += new System.EventHandler(this.radioButtonAutoActivation_CheckedChanged);
            // 
            // groupBox12
            // 
            this.groupBox12.Controls.Add(this.TextBoxServer);
            this.groupBox12.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox12.Location = new System.Drawing.Point(0, 0);
            this.groupBox12.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox12.Size = new System.Drawing.Size(359, 230);
            this.groupBox12.TabIndex = 63;
            this.groupBox12.TabStop = false;
            this.groupBox12.Text = "Messages ";
            // 
            // TextBoxServer
            // 
            this.TextBoxServer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextBoxServer.Location = new System.Drawing.Point(2, 15);
            this.TextBoxServer.Multiline = true;
            this.TextBoxServer.Name = "TextBoxServer";
            this.TextBoxServer.ReadOnly = true;
            this.TextBoxServer.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TextBoxServer.Size = new System.Drawing.Size(355, 213);
            this.TextBoxServer.TabIndex = 38;
            // 
            // tabPage_Gesture
            // 
            this.tabPage_Gesture.Controls.Add(this.groupBox19);
            this.tabPage_Gesture.Controls.Add(this.groupBox20);
            this.tabPage_Gesture.Controls.Add(this.groupBox16);
            this.tabPage_Gesture.Controls.Add(this.groupBox17);
            this.tabPage_Gesture.Location = new System.Drawing.Point(4, 40);
            this.tabPage_Gesture.Name = "tabPage_Gesture";
            this.tabPage_Gesture.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Gesture.Size = new System.Drawing.Size(359, 624);
            this.tabPage_Gesture.TabIndex = 6;
            this.tabPage_Gesture.Text = "Gestures";
            this.tabPage_Gesture.UseVisualStyleBackColor = true;
            // 
            // groupBox19
            // 
            this.groupBox19.Controls.Add(this.btn_Custom4);
            this.groupBox19.Controls.Add(this.prg_Custom4);
            this.groupBox19.Controls.Add(this.btn_Custom3);
            this.groupBox19.Controls.Add(this.prg_Custom3);
            this.groupBox19.Controls.Add(this.btn_Custom2);
            this.groupBox19.Controls.Add(this.prg_Custom2);
            this.groupBox19.Controls.Add(this.btn_Custom1);
            this.groupBox19.Controls.Add(this.prg_Custom1);
            this.groupBox19.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox19.Location = new System.Drawing.Point(3, 432);
            this.groupBox19.Name = "groupBox19";
            this.groupBox19.Size = new System.Drawing.Size(353, 289);
            this.groupBox19.TabIndex = 3;
            this.groupBox19.TabStop = false;
            this.groupBox19.Text = "Custom gestures  (made only by head yaw and pitch)";
            // 
            // btn_Custom4
            // 
            this.btn_Custom4.BackColor = System.Drawing.Color.White;
            this.btn_Custom4.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btn_Custom4.Location = new System.Drawing.Point(73, 230);
            this.btn_Custom4.Name = "btn_Custom4";
            this.btn_Custom4.Size = new System.Drawing.Size(84, 37);
            this.btn_Custom4.TabIndex = 71;
            this.btn_Custom4.Tag = "Custom4";
            this.btn_Custom4.Text = "Custom 4";
            this.btn_Custom4.UseVisualStyleBackColor = false;
            this.btn_Custom4.Click += new System.EventHandler(this.btn_Custom4_Click);
            // 
            // prg_Custom4
            // 
            this.prg_Custom4.Location = new System.Drawing.Point(73, 266);
            this.prg_Custom4.Name = "prg_Custom4";
            this.prg_Custom4.Size = new System.Drawing.Size(84, 10);
            this.prg_Custom4.TabIndex = 70;
            // 
            // btn_Custom3
            // 
            this.btn_Custom3.BackColor = System.Drawing.Color.White;
            this.btn_Custom3.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btn_Custom3.Location = new System.Drawing.Point(73, 168);
            this.btn_Custom3.Name = "btn_Custom3";
            this.btn_Custom3.Size = new System.Drawing.Size(84, 37);
            this.btn_Custom3.TabIndex = 71;
            this.btn_Custom3.Tag = "Custom3";
            this.btn_Custom3.Text = "Custom 3";
            this.btn_Custom3.UseVisualStyleBackColor = false;
            this.btn_Custom3.Click += new System.EventHandler(this.btn_Custom3_Click);
            // 
            // prg_Custom3
            // 
            this.prg_Custom3.Location = new System.Drawing.Point(73, 204);
            this.prg_Custom3.Name = "prg_Custom3";
            this.prg_Custom3.Size = new System.Drawing.Size(84, 10);
            this.prg_Custom3.TabIndex = 70;
            // 
            // btn_Custom2
            // 
            this.btn_Custom2.BackColor = System.Drawing.Color.White;
            this.btn_Custom2.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btn_Custom2.Location = new System.Drawing.Point(73, 105);
            this.btn_Custom2.Name = "btn_Custom2";
            this.btn_Custom2.Size = new System.Drawing.Size(84, 37);
            this.btn_Custom2.TabIndex = 69;
            this.btn_Custom2.Tag = "Custom2";
            this.btn_Custom2.Text = "Custom 2";
            this.btn_Custom2.UseVisualStyleBackColor = false;
            this.btn_Custom2.Click += new System.EventHandler(this.btn_Custom2_Click);
            // 
            // prg_Custom2
            // 
            this.prg_Custom2.Location = new System.Drawing.Point(73, 141);
            this.prg_Custom2.Name = "prg_Custom2";
            this.prg_Custom2.Size = new System.Drawing.Size(84, 10);
            this.prg_Custom2.TabIndex = 68;
            // 
            // btn_Custom1
            // 
            this.btn_Custom1.BackColor = System.Drawing.Color.White;
            this.btn_Custom1.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btn_Custom1.Location = new System.Drawing.Point(72, 44);
            this.btn_Custom1.Name = "btn_Custom1";
            this.btn_Custom1.Size = new System.Drawing.Size(84, 37);
            this.btn_Custom1.TabIndex = 67;
            this.btn_Custom1.Tag = "Custom1";
            this.btn_Custom1.Text = "Custom 1";
            this.btn_Custom1.UseVisualStyleBackColor = false;
            this.btn_Custom1.Click += new System.EventHandler(this.btn_Custom1_Click);
            // 
            // prg_Custom1
            // 
            this.prg_Custom1.Location = new System.Drawing.Point(72, 80);
            this.prg_Custom1.Name = "prg_Custom1";
            this.prg_Custom1.Size = new System.Drawing.Size(84, 10);
            this.prg_Custom1.TabIndex = 67;
            // 
            // groupBox20
            // 
            this.groupBox20.Controls.Add(this.pbUpRight2);
            this.groupBox20.Controls.Add(this.radioButton8D);
            this.groupBox20.Controls.Add(this.pbUp1);
            this.groupBox20.Controls.Add(this.pbUpLeft2);
            this.groupBox20.Controls.Add(this.pbUp2);
            this.groupBox20.Controls.Add(this.radioButton4D);
            this.groupBox20.Controls.Add(this.pbUpRight1);
            this.groupBox20.Controls.Add(this.pbRight1);
            this.groupBox20.Controls.Add(this.pbUpLeft1);
            this.groupBox20.Controls.Add(this.pbRight2);
            this.groupBox20.Controls.Add(this.pbLeft2);
            this.groupBox20.Controls.Add(this.pbDownRight1);
            this.groupBox20.Controls.Add(this.pbLeft1);
            this.groupBox20.Controls.Add(this.pbDownRight2);
            this.groupBox20.Controls.Add(this.pbDownLeft2);
            this.groupBox20.Controls.Add(this.pbDown1);
            this.groupBox20.Controls.Add(this.pbDownLeft1);
            this.groupBox20.Controls.Add(this.pbDown2);
            this.groupBox20.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox20.Location = new System.Drawing.Point(3, 143);
            this.groupBox20.Name = "groupBox20";
            this.groupBox20.Size = new System.Drawing.Size(353, 289);
            this.groupBox20.TabIndex = 3;
            this.groupBox20.TabStop = false;
            this.groupBox20.Text = "Head yaw and pitch";
            // 
            // pbUpRight2
            // 
            this.pbUpRight2.Image = global::Haytham.Properties.Resources.UR_UR;
            this.pbUpRight2.Location = new System.Drawing.Point(178, 19);
            this.pbUpRight2.Name = "pbUpRight2";
            this.pbUpRight2.Size = new System.Drawing.Size(40, 40);
            this.pbUpRight2.TabIndex = 32;
            this.pbUpRight2.TabStop = false;
            this.pbUpRight2.Visible = false;
            // 
            // radioButton8D
            // 
            this.radioButton8D.AutoSize = true;
            this.radioButton8D.Location = new System.Drawing.Point(115, 251);
            this.radioButton8D.Name = "radioButton8D";
            this.radioButton8D.Size = new System.Drawing.Size(81, 17);
            this.radioButton8D.TabIndex = 66;
            this.radioButton8D.Text = "8 Directions";
            this.radioButton8D.UseVisualStyleBackColor = true;
            this.radioButton8D.CheckedChanged += new System.EventHandler(this.radioButton8D_CheckedChanged);
            // 
            // pbUp1
            // 
            this.pbUp1.Image = global::Haytham.Properties.Resources.U_D;
            this.pbUp1.Location = new System.Drawing.Point(94, 63);
            this.pbUp1.Name = "pbUp1";
            this.pbUp1.Size = new System.Drawing.Size(40, 40);
            this.pbUp1.TabIndex = 29;
            this.pbUp1.TabStop = false;
            // 
            // pbUpLeft2
            // 
            this.pbUpLeft2.Image = global::Haytham.Properties.Resources.UL_UL;
            this.pbUpLeft2.Location = new System.Drawing.Point(9, 19);
            this.pbUpLeft2.Name = "pbUpLeft2";
            this.pbUpLeft2.Size = new System.Drawing.Size(40, 40);
            this.pbUpLeft2.TabIndex = 44;
            this.pbUpLeft2.TabStop = false;
            this.pbUpLeft2.Visible = false;
            // 
            // pbUp2
            // 
            this.pbUp2.Image = global::Haytham.Properties.Resources.U_U;
            this.pbUp2.Location = new System.Drawing.Point(94, 19);
            this.pbUp2.Name = "pbUp2";
            this.pbUp2.Size = new System.Drawing.Size(40, 40);
            this.pbUp2.TabIndex = 30;
            this.pbUp2.TabStop = false;
            // 
            // radioButton4D
            // 
            this.radioButton4D.AutoSize = true;
            this.radioButton4D.Checked = true;
            this.radioButton4D.Location = new System.Drawing.Point(29, 251);
            this.radioButton4D.Name = "radioButton4D";
            this.radioButton4D.Size = new System.Drawing.Size(81, 17);
            this.radioButton4D.TabIndex = 65;
            this.radioButton4D.TabStop = true;
            this.radioButton4D.Text = "4 Directions";
            this.radioButton4D.UseVisualStyleBackColor = true;
            this.radioButton4D.CheckedChanged += new System.EventHandler(this.radioButton4D_CheckedChanged_1);
            // 
            // pbUpRight1
            // 
            this.pbUpRight1.Image = global::Haytham.Properties.Resources.UR_DL;
            this.pbUpRight1.Location = new System.Drawing.Point(136, 63);
            this.pbUpRight1.Name = "pbUpRight1";
            this.pbUpRight1.Size = new System.Drawing.Size(40, 40);
            this.pbUpRight1.TabIndex = 31;
            this.pbUpRight1.TabStop = false;
            this.pbUpRight1.Visible = false;
            // 
            // pbRight1
            // 
            this.pbRight1.Image = global::Haytham.Properties.Resources.R_L;
            this.pbRight1.Location = new System.Drawing.Point(136, 108);
            this.pbRight1.Name = "pbRight1";
            this.pbRight1.Size = new System.Drawing.Size(40, 40);
            this.pbRight1.TabIndex = 33;
            this.pbRight1.TabStop = false;
            // 
            // pbUpLeft1
            // 
            this.pbUpLeft1.Image = global::Haytham.Properties.Resources.UL_DR;
            this.pbUpLeft1.Location = new System.Drawing.Point(52, 63);
            this.pbUpLeft1.Name = "pbUpLeft1";
            this.pbUpLeft1.Size = new System.Drawing.Size(40, 40);
            this.pbUpLeft1.TabIndex = 43;
            this.pbUpLeft1.TabStop = false;
            this.pbUpLeft1.Visible = false;
            // 
            // pbRight2
            // 
            this.pbRight2.Image = global::Haytham.Properties.Resources.R_R;
            this.pbRight2.Location = new System.Drawing.Point(178, 108);
            this.pbRight2.Name = "pbRight2";
            this.pbRight2.Size = new System.Drawing.Size(40, 40);
            this.pbRight2.TabIndex = 34;
            this.pbRight2.TabStop = false;
            // 
            // pbLeft2
            // 
            this.pbLeft2.Image = global::Haytham.Properties.Resources.L_L;
            this.pbLeft2.Location = new System.Drawing.Point(9, 108);
            this.pbLeft2.Name = "pbLeft2";
            this.pbLeft2.Size = new System.Drawing.Size(40, 40);
            this.pbLeft2.TabIndex = 42;
            this.pbLeft2.TabStop = false;
            // 
            // pbDownRight1
            // 
            this.pbDownRight1.Image = global::Haytham.Properties.Resources.DR_UL;
            this.pbDownRight1.Location = new System.Drawing.Point(136, 153);
            this.pbDownRight1.Name = "pbDownRight1";
            this.pbDownRight1.Size = new System.Drawing.Size(40, 40);
            this.pbDownRight1.TabIndex = 35;
            this.pbDownRight1.TabStop = false;
            this.pbDownRight1.Visible = false;
            // 
            // pbLeft1
            // 
            this.pbLeft1.Image = global::Haytham.Properties.Resources.L_R;
            this.pbLeft1.Location = new System.Drawing.Point(52, 108);
            this.pbLeft1.Name = "pbLeft1";
            this.pbLeft1.Size = new System.Drawing.Size(40, 40);
            this.pbLeft1.TabIndex = 41;
            this.pbLeft1.TabStop = false;
            // 
            // pbDownRight2
            // 
            this.pbDownRight2.Image = global::Haytham.Properties.Resources.DR_DR;
            this.pbDownRight2.Location = new System.Drawing.Point(178, 198);
            this.pbDownRight2.Name = "pbDownRight2";
            this.pbDownRight2.Size = new System.Drawing.Size(40, 40);
            this.pbDownRight2.TabIndex = 36;
            this.pbDownRight2.TabStop = false;
            this.pbDownRight2.Visible = false;
            // 
            // pbDownLeft2
            // 
            this.pbDownLeft2.Image = global::Haytham.Properties.Resources.DL_DL;
            this.pbDownLeft2.Location = new System.Drawing.Point(9, 198);
            this.pbDownLeft2.Name = "pbDownLeft2";
            this.pbDownLeft2.Size = new System.Drawing.Size(40, 40);
            this.pbDownLeft2.TabIndex = 40;
            this.pbDownLeft2.TabStop = false;
            this.pbDownLeft2.Visible = false;
            // 
            // pbDown1
            // 
            this.pbDown1.Image = global::Haytham.Properties.Resources.D_U;
            this.pbDown1.Location = new System.Drawing.Point(94, 153);
            this.pbDown1.Name = "pbDown1";
            this.pbDown1.Size = new System.Drawing.Size(40, 40);
            this.pbDown1.TabIndex = 37;
            this.pbDown1.TabStop = false;
            // 
            // pbDownLeft1
            // 
            this.pbDownLeft1.Image = global::Haytham.Properties.Resources.DL_UR;
            this.pbDownLeft1.Location = new System.Drawing.Point(52, 153);
            this.pbDownLeft1.Name = "pbDownLeft1";
            this.pbDownLeft1.Size = new System.Drawing.Size(40, 40);
            this.pbDownLeft1.TabIndex = 39;
            this.pbDownLeft1.TabStop = false;
            this.pbDownLeft1.Visible = false;
            // 
            // pbDown2
            // 
            this.pbDown2.Image = global::Haytham.Properties.Resources.D_D;
            this.pbDown2.Location = new System.Drawing.Point(94, 198);
            this.pbDown2.Name = "pbDown2";
            this.pbDown2.Size = new System.Drawing.Size(40, 40);
            this.pbDown2.TabIndex = 38;
            this.pbDown2.TabStop = false;
            // 
            // groupBox16
            // 
            this.groupBox16.Controls.Add(this.pbTRight);
            this.groupBox16.Controls.Add(this.pbTLeft);
            this.groupBox16.Controls.Add(this.checkBox2);
            this.groupBox16.Controls.Add(this.checkEditShowOpticalFlow);
            this.groupBox16.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox16.Location = new System.Drawing.Point(3, 66);
            this.groupBox16.Name = "groupBox16";
            this.groupBox16.Size = new System.Drawing.Size(353, 77);
            this.groupBox16.TabIndex = 5;
            this.groupBox16.TabStop = false;
            this.groupBox16.Text = "Head Roll";
            // 
            // pbTRight
            // 
            this.pbTRight.Image = global::Haytham.Properties.Resources.TR;
            this.pbTRight.Location = new System.Drawing.Point(139, 24);
            this.pbTRight.Name = "pbTRight";
            this.pbTRight.Size = new System.Drawing.Size(40, 40);
            this.pbTRight.TabIndex = 88;
            this.pbTRight.TabStop = false;
            // 
            // pbTLeft
            // 
            this.pbTLeft.Image = global::Haytham.Properties.Resources.TL;
            this.pbTLeft.Location = new System.Drawing.Point(51, 24);
            this.pbTLeft.Name = "pbTLeft";
            this.pbTLeft.Size = new System.Drawing.Size(40, 40);
            this.pbTLeft.TabIndex = 87;
            this.pbTLeft.TabStop = false;
            // 
            // checkBox2
            // 
            this.checkBox2.Location = new System.Drawing.Point(64, 0);
            this.checkBox2.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(117, 19);
            this.checkBox2.TabIndex = 85;
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged_5);
            // 
            // checkEditShowOpticalFlow
            // 
            this.checkEditShowOpticalFlow.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkEditShowOpticalFlow.BackColor = System.Drawing.Color.Transparent;
            this.checkEditShowOpticalFlow.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("checkEditShowOpticalFlow.BackgroundImage")));
            this.checkEditShowOpticalFlow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.checkEditShowOpticalFlow.FlatAppearance.BorderSize = 0;
            this.checkEditShowOpticalFlow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkEditShowOpticalFlow.Location = new System.Drawing.Point(185, 1);
            this.checkEditShowOpticalFlow.Margin = new System.Windows.Forms.Padding(2);
            this.checkEditShowOpticalFlow.Name = "checkEditShowOpticalFlow";
            this.checkEditShowOpticalFlow.Size = new System.Drawing.Size(14, 18);
            this.checkEditShowOpticalFlow.TabIndex = 82;
            this.checkEditShowOpticalFlow.UseVisualStyleBackColor = false;
            this.checkEditShowOpticalFlow.CheckedChanged += new System.EventHandler(this.checkEditShowOpticalFlow_CheckedChanged);
            // 
            // groupBox17
            // 
            this.groupBox17.Controls.Add(this.btnDbBlink);
            this.groupBox17.Controls.Add(this.btnBlink);
            this.groupBox17.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox17.Location = new System.Drawing.Point(3, 3);
            this.groupBox17.Name = "groupBox17";
            this.groupBox17.Size = new System.Drawing.Size(353, 63);
            this.groupBox17.TabIndex = 3;
            this.groupBox17.TabStop = false;
            this.groupBox17.Text = "Blink";
            // 
            // btnDbBlink
            // 
            this.btnDbBlink.BackColor = System.Drawing.Color.White;
            this.btnDbBlink.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnDbBlink.Location = new System.Drawing.Point(115, 15);
            this.btnDbBlink.Name = "btnDbBlink";
            this.btnDbBlink.Size = new System.Drawing.Size(84, 37);
            this.btnDbBlink.TabIndex = 68;
            this.btnDbBlink.Tag = "DbBlink";
            this.btnDbBlink.Text = "DbBlink";
            this.btnDbBlink.UseVisualStyleBackColor = false;
            // 
            // btnBlink
            // 
            this.btnBlink.BackColor = System.Drawing.Color.White;
            this.btnBlink.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnBlink.Location = new System.Drawing.Point(29, 15);
            this.btnBlink.Name = "btnBlink";
            this.btnBlink.Size = new System.Drawing.Size(84, 37);
            this.btnBlink.TabIndex = 68;
            this.btnBlink.Tag = "Blink";
            this.btnBlink.Text = "Blink";
            this.btnBlink.UseVisualStyleBackColor = false;
            // 
            // tabPage_ExtData
            // 
            this.tabPage_ExtData.Controls.Add(this.groupBox13);
            this.tabPage_ExtData.Location = new System.Drawing.Point(4, 40);
            this.tabPage_ExtData.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage_ExtData.Name = "tabPage_ExtData";
            this.tabPage_ExtData.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_ExtData.Size = new System.Drawing.Size(359, 624);
            this.tabPage_ExtData.TabIndex = 7;
            this.tabPage_ExtData.Text = "ExtData";
            this.tabPage_ExtData.UseVisualStyleBackColor = true;
            // 
            // groupBox13
            // 
            this.groupBox13.Controls.Add(this.btn_CleanCache);
            this.groupBox13.Controls.Add(this.label2);
            this.groupBox13.Controls.Add(this.numericUpDown1);
            this.groupBox13.Controls.Add(this.checkBox4);
            this.groupBox13.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox13.Location = new System.Drawing.Point(3, 3);
            this.groupBox13.Name = "groupBox13";
            this.groupBox13.Size = new System.Drawing.Size(353, 69);
            this.groupBox13.TabIndex = 0;
            this.groupBox13.TabStop = false;
            // 
            // btn_CleanCache
            // 
            this.btn_CleanCache.Location = new System.Drawing.Point(12, 38);
            this.btn_CleanCache.Name = "btn_CleanCache";
            this.btn_CleanCache.Size = new System.Drawing.Size(75, 23);
            this.btn_CleanCache.TabIndex = 3;
            this.btn_CleanCache.Text = "clean cache";
            this.btn_CleanCache.UseVisualStyleBackColor = true;
            this.btn_CleanCache.Click += new System.EventHandler(this.btn_CleanCache_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(108, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Font size:";
            this.label2.Visible = false;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numericUpDown1.Location = new System.Drawing.Point(166, 41);
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(52, 20);
            this.numericUpDown1.TabIndex = 1;
            this.numericUpDown1.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown1.Visible = false;
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(12, 18);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(163, 17);
            this.checkBox4.TabIndex = 0;
            this.checkBox4.Text = "Enable external data sources";
            this.checkBox4.UseVisualStyleBackColor = true;
            this.checkBox4.CheckedChanged += new System.EventHandler(this.checkBox4_CheckedChanged);
            // 
            // groupBox14
            // 
            this.groupBox14.AutoSize = true;
            this.groupBox14.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox14.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox14.Controls.Add(this.tableLayoutPanel1);
            this.groupBox14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox14.Location = new System.Drawing.Point(0, 24);
            this.groupBox14.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox14.Name = "groupBox14";
            this.groupBox14.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox14.Size = new System.Drawing.Size(898, 644);
            this.groupBox14.TabIndex = 1;
            this.groupBox14.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tableLayoutPanel1.Controls.Add(this.splitContainer2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox18, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.imEyeTest, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(2, 15);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(894, 627);
            this.tableLayoutPanel1.TabIndex = 75;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer2.Location = new System.Drawing.Point(-207, 3);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.groupBox_imgEye);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.groupBox_imgScene);
            this.splitContainer2.Size = new System.Drawing.Size(1097, 614);
            this.splitContainer2.SplitterDistance = 492;
            this.splitContainer2.TabIndex = 73;
            // 
            // groupBox_imgEye
            // 
            this.groupBox_imgEye.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox_imgEye.Controls.Add(this.panel1);
            this.groupBox_imgEye.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox_imgEye.Location = new System.Drawing.Point(0, 0);
            this.groupBox_imgEye.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox_imgEye.Name = "groupBox_imgEye";
            this.groupBox_imgEye.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox_imgEye.Size = new System.Drawing.Size(492, 614);
            this.groupBox_imgEye.TabIndex = 67;
            this.groupBox_imgEye.TabStop = false;
            this.groupBox_imgEye.Text = "Eye";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.imEye);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(2, 15);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(488, 597);
            this.panel1.TabIndex = 73;
            // 
            // imEye
            // 
            this.imEye.Location = new System.Drawing.Point(0, 0);
            this.imEye.Name = "imEye";
            this.imEye.Size = new System.Drawing.Size(60, 60);
            this.imEye.TabIndex = 72;
            this.imEye.TabStop = false;
            this.imEye.Paint += new System.Windows.Forms.PaintEventHandler(this.imEye_Paint);
            // 
            // groupBox_imgScene
            // 
            this.groupBox_imgScene.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox_imgScene.Controls.Add(this.panel2);
            this.groupBox_imgScene.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox_imgScene.Location = new System.Drawing.Point(0, 0);
            this.groupBox_imgScene.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox_imgScene.Name = "groupBox_imgScene";
            this.groupBox_imgScene.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox_imgScene.Size = new System.Drawing.Size(601, 614);
            this.groupBox_imgScene.TabIndex = 68;
            this.groupBox_imgScene.TabStop = false;
            this.groupBox_imgScene.Text = "Scene";
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.Controls.Add(this.imSceneProcessed);
            this.panel2.Controls.Add(this.imScene);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(2, 15);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(597, 597);
            this.panel2.TabIndex = 74;
            // 
            // imSceneProcessed
            // 
            this.imSceneProcessed.Dock = System.Windows.Forms.DockStyle.Left;
            this.imSceneProcessed.Location = new System.Drawing.Point(60, 0);
            this.imSceneProcessed.Name = "imSceneProcessed";
            this.imSceneProcessed.Size = new System.Drawing.Size(250, 597);
            this.imSceneProcessed.TabIndex = 75;
            this.imSceneProcessed.TabStop = false;
            this.imSceneProcessed.Paint += new System.Windows.Forms.PaintEventHandler(this.imSceneProcessed_Paint);
            // 
            // imScene
            // 
            this.imScene.Dock = System.Windows.Forms.DockStyle.Left;
            this.imScene.Location = new System.Drawing.Point(0, 0);
            this.imScene.Name = "imScene";
            this.imScene.Size = new System.Drawing.Size(60, 597);
            this.imScene.TabIndex = 73;
            this.imScene.TabStop = false;
            this.imScene.Paint += new System.Windows.Forms.PaintEventHandler(this.imScene_Paint);
            this.imScene.MouseClick += new System.Windows.Forms.MouseEventHandler(this.imScene_MouseClick);
            this.imScene.MouseMove += new System.Windows.Forms.MouseEventHandler(this.imScene_MouseMove);
            // 
            // groupBox18
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.groupBox18, 3);
            this.groupBox18.Controls.Add(this.trackBarTest);
            this.groupBox18.Controls.Add(this.chartTest);
            this.groupBox18.Location = new System.Drawing.Point(3, 623);
            this.groupBox18.Name = "groupBox18";
            this.groupBox18.Size = new System.Drawing.Size(564, 1);
            this.groupBox18.TabIndex = 3;
            this.groupBox18.TabStop = false;
            this.groupBox18.Text = "debug";
            this.groupBox18.Visible = false;
            // 
            // trackBarTest
            // 
            this.trackBarTest.Location = new System.Drawing.Point(325, 19);
            this.trackBarTest.Maximum = 25;
            this.trackBarTest.Minimum = 3;
            this.trackBarTest.Name = "trackBarTest";
            this.trackBarTest.Size = new System.Drawing.Size(227, 45);
            this.trackBarTest.TabIndex = 3;
            this.trackBarTest.Value = 21;
            this.trackBarTest.ValueChanged += new System.EventHandler(this.trackBarTest_ValueChanged);
            // 
            // chartTest
            // 
            this.chartTest.BackColor = System.Drawing.Color.Transparent;
            chartArea4.AxisX.IsMarginVisible = false;
            chartArea4.AxisX.LabelStyle.Enabled = false;
            chartArea4.AxisX.MajorGrid.Enabled = false;
            chartArea4.AxisX.MajorTickMark.Enabled = false;
            chartArea4.AxisY.IsLabelAutoFit = false;
            chartArea4.AxisY.LabelStyle.Interval = 0D;
            chartArea4.AxisY.MajorGrid.LineColor = System.Drawing.Color.WhiteSmoke;
            chartArea4.BackColor = System.Drawing.Color.White;
            chartArea4.InnerPlotPosition.Auto = false;
            chartArea4.InnerPlotPosition.Height = 86.87582F;
            chartArea4.InnerPlotPosition.Width = 86.45924F;
            chartArea4.InnerPlotPosition.X = 13.54076F;
            chartArea4.InnerPlotPosition.Y = 6.56209F;
            chartArea4.Name = "ChartArea1";
            chartArea4.Position.Auto = false;
            chartArea4.Position.Height = 80.00502F;
            chartArea4.Position.Width = 94F;
            chartArea4.Position.X = 3F;
            chartArea4.Position.Y = 16.99498F;
            this.chartTest.ChartAreas.Add(chartArea4);
            this.chartTest.Dock = System.Windows.Forms.DockStyle.Left;
            this.chartTest.Location = new System.Drawing.Point(3, 16);
            this.chartTest.Margin = new System.Windows.Forms.Padding(2);
            this.chartTest.Name = "chartTest";
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series4.EmptyPointStyle.BorderWidth = 0;
            series4.EmptyPointStyle.Color = System.Drawing.Color.Red;
            series4.EmptyPointStyle.CustomProperties = "LabelStyle=Top";
            series4.EmptyPointStyle.IsVisibleInLegend = false;
            series4.EmptyPointStyle.MarkerColor = System.Drawing.Color.Red;
            series4.EmptyPointStyle.MarkerImageTransparentColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            series4.EmptyPointStyle.MarkerSize = 1;
            series4.EmptyPointStyle.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Cross;
            series4.Name = "test";
            this.chartTest.Series.Add(series4);
            this.chartTest.Size = new System.Drawing.Size(549, 0);
            this.chartTest.TabIndex = 47;
            this.chartTest.Text = "chart3";
            title4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title4.Name = "test";
            title4.Position.Auto = false;
            title4.Position.Height = 10.99498F;
            title4.Position.Width = 94F;
            title4.Position.X = 3F;
            title4.Position.Y = 3F;
            title4.Text = "test";
            this.chartTest.Titles.Add(title4);
            // 
            // imEyeTest
            // 
            this.imEyeTest.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Minimum;
            this.imEyeTest.Location = new System.Drawing.Point(3, 3);
            this.imEyeTest.Name = "imEyeTest";
            this.imEyeTest.Size = new System.Drawing.Size(1, 608);
            this.imEyeTest.TabIndex = 70;
            this.imEyeTest.TabStop = false;
            this.imEyeTest.Visible = false;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.splitter7);
            this.panel6.Controls.Add(this.lblIP);
            this.panel6.Controls.Add(this.splitter6);
            this.panel6.Controls.Add(this.lblGlintCenter);
            this.panel6.Controls.Add(this.splitter3);
            this.panel6.Controls.Add(this.lblPupilCenter);
            this.panel6.Controls.Add(this.splitter2);
            this.panel6.Controls.Add(this.comboBox_SceneTimer);
            this.panel6.Controls.Add(this.splitter1);
            this.panel6.Controls.Add(this.comboBox_EyeTimer);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Margin = new System.Windows.Forms.Padding(2);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(898, 24);
            this.panel6.TabIndex = 0;
            // 
            // splitter7
            // 
            this.splitter7.Location = new System.Drawing.Point(557, 0);
            this.splitter7.Margin = new System.Windows.Forms.Padding(2);
            this.splitter7.Name = "splitter7";
            this.splitter7.Size = new System.Drawing.Size(2, 24);
            this.splitter7.TabIndex = 73;
            this.splitter7.TabStop = false;
            // 
            // lblIP
            // 
            this.lblIP.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lblIP.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblIP.Location = new System.Drawing.Point(378, 0);
            this.lblIP.Margin = new System.Windows.Forms.Padding(2);
            this.lblIP.Multiline = true;
            this.lblIP.Name = "lblIP";
            this.lblIP.ReadOnly = true;
            this.lblIP.Size = new System.Drawing.Size(179, 24);
            this.lblIP.TabIndex = 72;
            this.lblIP.Text = "Server IP: 000.000.000.000";
            this.lblIP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // splitter6
            // 
            this.splitter6.Location = new System.Drawing.Point(376, 0);
            this.splitter6.Margin = new System.Windows.Forms.Padding(2);
            this.splitter6.Name = "splitter6";
            this.splitter6.Size = new System.Drawing.Size(2, 24);
            this.splitter6.TabIndex = 71;
            this.splitter6.TabStop = false;
            // 
            // lblGlintCenter
            // 
            this.lblGlintCenter.AutoSize = true;
            this.lblGlintCenter.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblGlintCenter.Location = new System.Drawing.Point(314, 0);
            this.lblGlintCenter.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblGlintCenter.Name = "lblGlintCenter";
            this.lblGlintCenter.Size = new System.Drawing.Size(62, 13);
            this.lblGlintCenter.TabIndex = 66;
            this.lblGlintCenter.Text = "Glint Center";
            this.lblGlintCenter.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // splitter3
            // 
            this.splitter3.Location = new System.Drawing.Point(312, 0);
            this.splitter3.Margin = new System.Windows.Forms.Padding(2);
            this.splitter3.Name = "splitter3";
            this.splitter3.Size = new System.Drawing.Size(2, 24);
            this.splitter3.TabIndex = 65;
            this.splitter3.TabStop = false;
            // 
            // lblPupilCenter
            // 
            this.lblPupilCenter.AutoSize = true;
            this.lblPupilCenter.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblPupilCenter.Location = new System.Drawing.Point(248, 0);
            this.lblPupilCenter.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPupilCenter.Name = "lblPupilCenter";
            this.lblPupilCenter.Size = new System.Drawing.Size(64, 13);
            this.lblPupilCenter.TabIndex = 64;
            this.lblPupilCenter.Text = "Pupil Center";
            this.lblPupilCenter.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // splitter2
            // 
            this.splitter2.Location = new System.Drawing.Point(246, 0);
            this.splitter2.Margin = new System.Windows.Forms.Padding(2);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(2, 24);
            this.splitter2.TabIndex = 63;
            this.splitter2.TabStop = false;
            // 
            // comboBox_SceneTimer
            // 
            this.comboBox_SceneTimer.BackColor = System.Drawing.SystemColors.Control;
            this.comboBox_SceneTimer.Dock = System.Windows.Forms.DockStyle.Left;
            this.comboBox_SceneTimer.FormattingEnabled = true;
            this.comboBox_SceneTimer.Location = new System.Drawing.Point(124, 0);
            this.comboBox_SceneTimer.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox_SceneTimer.Name = "comboBox_SceneTimer";
            this.comboBox_SceneTimer.Size = new System.Drawing.Size(122, 21);
            this.comboBox_SceneTimer.TabIndex = 62;
            this.comboBox_SceneTimer.SelectedIndexChanged += new System.EventHandler(this.comboBox_SceneTimer_SelectedIndexChanged);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(122, 0);
            this.splitter1.Margin = new System.Windows.Forms.Padding(2);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(2, 24);
            this.splitter1.TabIndex = 61;
            this.splitter1.TabStop = false;
            // 
            // comboBox_EyeTimer
            // 
            this.comboBox_EyeTimer.BackColor = System.Drawing.SystemColors.Control;
            this.comboBox_EyeTimer.Dock = System.Windows.Forms.DockStyle.Left;
            this.comboBox_EyeTimer.FormattingEnabled = true;
            this.comboBox_EyeTimer.Location = new System.Drawing.Point(0, 0);
            this.comboBox_EyeTimer.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox_EyeTimer.Name = "comboBox_EyeTimer";
            this.comboBox_EyeTimer.Size = new System.Drawing.Size(122, 21);
            this.comboBox_EyeTimer.TabIndex = 60;
            // 
            // timerReset
            // 
            this.timerReset.Interval = 500;
            this.timerReset.Tick += new System.EventHandler(this.timerReset_Tick);
            // 
            // trackBarThresholdGlint
            // 
            this.trackBarThresholdGlint.Location = new System.Drawing.Point(0, 0);
            this.trackBarThresholdGlint.Name = "trackBarThresholdGlint";
            this.trackBarThresholdGlint.Size = new System.Drawing.Size(104, 45);
            this.trackBarThresholdGlint.TabIndex = 0;
            // 
            // trackBarThresholdEye
            // 
            this.trackBarThresholdEye.Location = new System.Drawing.Point(0, 0);
            this.trackBarThresholdEye.Maximum = 100;
            this.trackBarThresholdEye.Name = "trackBarThresholdEye";
            this.trackBarThresholdEye.Size = new System.Drawing.Size(104, 45);
            this.trackBarThresholdEye.TabIndex = 0;
            // 
            // trackBarControl3
            // 
            this.trackBarControl3.Location = new System.Drawing.Point(0, 0);
            this.trackBarControl3.Name = "trackBarControl3";
            this.trackBarControl3.Size = new System.Drawing.Size(104, 45);
            this.trackBarControl3.TabIndex = 0;
            // 
            // trackBarB
            // 
            this.trackBarB.Location = new System.Drawing.Point(0, 0);
            this.trackBarB.Name = "trackBarB";
            this.trackBarB.Size = new System.Drawing.Size(104, 45);
            this.trackBarB.TabIndex = 0;
            // 
            // trackBarG
            // 
            this.trackBarG.Location = new System.Drawing.Point(0, 0);
            this.trackBarG.Name = "trackBarG";
            this.trackBarG.Size = new System.Drawing.Size(104, 45);
            this.trackBarG.TabIndex = 0;
            // 
            // trackBarControl2
            // 
            this.trackBarControl2.Location = new System.Drawing.Point(0, 0);
            this.trackBarControl2.Name = "trackBarControl2";
            this.trackBarControl2.Size = new System.Drawing.Size(104, 45);
            this.trackBarControl2.TabIndex = 0;
            // 
            // trackBarPAConstant
            // 
            this.trackBarPAConstant.Location = new System.Drawing.Point(0, 0);
            this.trackBarPAConstant.Name = "trackBarPAConstant";
            this.trackBarPAConstant.Size = new System.Drawing.Size(104, 45);
            this.trackBarPAConstant.TabIndex = 0;
            // 
            // trackBarPABlockSize
            // 
            this.trackBarPABlockSize.Location = new System.Drawing.Point(0, 0);
            this.trackBarPABlockSize.Name = "trackBarPABlockSize";
            this.trackBarPABlockSize.Size = new System.Drawing.Size(104, 45);
            this.trackBarPABlockSize.TabIndex = 0;
            // 
            // trackBarGAConstant
            // 
            this.trackBarGAConstant.Location = new System.Drawing.Point(0, 0);
            this.trackBarGAConstant.Name = "trackBarGAConstant";
            this.trackBarGAConstant.Size = new System.Drawing.Size(104, 45);
            this.trackBarGAConstant.TabIndex = 0;
            // 
            // trackBarGABlockSize
            // 
            this.trackBarGABlockSize.Location = new System.Drawing.Point(0, 0);
            this.trackBarGABlockSize.Name = "trackBarGABlockSize";
            this.trackBarGABlockSize.Size = new System.Drawing.Size(104, 45);
            this.trackBarGABlockSize.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1268, 668);
            this.Controls.Add(this.splitContainer1);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Haytham_Server";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage_Camera.ResumeLayout(false);
            this.gbStartBoth.ResumeLayout(false);
            this.gbSceneCameraDevice.ResumeLayout(false);
            this.gbSceneCameraDevice.PerformLayout();
            this.gbEyeCameraDevice.ResumeLayout(false);
            this.gbEyeCameraDevice.PerformLayout();
            this.tabPage_Glass.ResumeLayout(false);
            this.tabPage_Glass.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.tabPage_Eye.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.tabPage_Scene.ResumeLayout(false);
            this.tabPage_Scene.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox21.ResumeLayout(false);
            this.tabPage_Calibration.ResumeLayout(false);
            this.gbCalibrationGlass.ResumeLayout(false);
            this.gbCalibrationGlass.PerformLayout();
            this.gbCalibrationRemote.ResumeLayout(false);
            this.gbCalibrationHM.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.tabPage_Data.ResumeLayout(false);
            this.groupBox11.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.groupBox10.ResumeLayout(false);
            this.tabPage_Clients.ResumeLayout(false);
            this.tabPage_Clients.PerformLayout();
            this.panelClients.ResumeLayout(false);
            this.panelClients.PerformLayout();
            this.groupBox12.ResumeLayout(false);
            this.groupBox12.PerformLayout();
            this.tabPage_Gesture.ResumeLayout(false);
            this.groupBox19.ResumeLayout(false);
            this.groupBox20.ResumeLayout(false);
            this.groupBox20.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbUpRight2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbUp1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbUpLeft2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbUp2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbUpRight1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRight1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbUpLeft1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRight2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLeft2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDownRight1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLeft1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDownRight2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDownLeft2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDownLeft1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDown2)).EndInit();
            this.groupBox16.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbTRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTLeft)).EndInit();
            this.groupBox17.ResumeLayout(false);
            this.tabPage_ExtData.ResumeLayout(false);
            this.groupBox13.ResumeLayout(false);
            this.groupBox13.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.groupBox14.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.groupBox_imgEye.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imEye)).EndInit();
            this.groupBox_imgScene.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imSceneProcessed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imScene)).EndInit();
            this.groupBox18.ResumeLayout(false);
            this.groupBox18.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarTest)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartTest)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imEyeTest)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarThresholdGlint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarThresholdEye)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarControl3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarPAConstant)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarPABlockSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarGAConstant)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarGABlockSize)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbDeviceCapabilityScene;
        private System.Windows.Forms.ComboBox cmbDeviceScene;
        private System.Windows.Forms.ComboBox cmbDeviceCapabilityEye;
        private System.Windows.Forms.ComboBox cmbDeviceEye;
        private System.Windows.Forms.TextBox TextBoxServer;
        private System.Windows.Forms.RadioButton radioButtonAutoActivation;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart3;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private System.Windows.Forms.GroupBox gbEyeCameraDevice;
        private System.Windows.Forms.Button btnStartEye;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSettingsEye;
        private System.Windows.Forms.GroupBox gbSceneCameraDevice;
        private System.Windows.Forms.Button btnSettingsScene;
        private System.Windows.Forms.Button btnStartScene;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;

        private System.Windows.Forms.Button startBoothVideos;
        private System.Windows.Forms.GroupBox gbStartBoth;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label9;
        private TransparentTrackBar trackBarControl2;
        private System.Windows.Forms.CheckBox cbShowIris;
        private System.Windows.Forms.CheckBox cbPupilDetection;
        private System.Windows.Forms.CheckBox cbShowPupil;
        private System.Windows.Forms.RadioButton cbPM;
        private System.Windows.Forms.RadioButton cbPA;
        private TransparentTrackBar trackBarThresholdEye;
        private TransparentTrackBar trackBarPAConstant;
        private System.Windows.Forms.CheckBox cbRemoveGlint;
        private System.Windows.Forms.CheckBox cbDilateErode;
        private System.Windows.Forms.CheckBox cbGlintDetection;
        private System.Windows.Forms.CheckBox cbShowGlint;
        private System.Windows.Forms.RadioButton cbGM;
        private System.Windows.Forms.RadioButton cbGA;
        private TransparentTrackBar trackBarGAConstant;
        private TransparentTrackBar trackBarThresholdGlint;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RadioButton rbPGaussian;
        private System.Windows.Forms.RadioButton rbPMean;
        private TransparentTrackBar trackBarPABlockSize;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel4;
        private TransparentTrackBar trackBarGABlockSize;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.RadioButton rbGGaussian;
        private System.Windows.Forms.RadioButton rbGMean;
        private System.Windows.Forms.CheckBox cbShowScreen;
        private TransparentTrackBar trackBarControl3;
        private TransparentTrackBar trackBarG;
        private TransparentTrackBar trackBarB;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.CheckBox cbSceneUnDistortion;
        private System.Windows.Forms.Button btnSceneCameraCalibration;
        private System.Windows.Forms.GroupBox gbCalibrationHM;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.RadioButton rbPupilGlint;
        private System.Windows.Forms.RadioButton rdOnlyPupil;
        private System.Windows.Forms.Button btnCalibration_Homography;
        private System.Windows.Forms.Button btnCalibration_Polynomial;
        private System.Windows.Forms.CheckBox cbGazeSmoothing;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.ProgressBar btn_RecordProgress;
        private System.Windows.Forms.GroupBox groupBox11;
        private System.Windows.Forms.CheckBox cbPlot;
        private System.Windows.Forms.GroupBox panelClients;
        private System.Windows.Forms.GroupBox groupBox12;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage_Camera;
        private System.Windows.Forms.TabPage tabPage_Eye;
        private System.Windows.Forms.TabPage tabPage_Scene;
        private System.Windows.Forms.TabPage tabPage_Calibration;
        private System.Windows.Forms.TabPage tabPage_Data;
        private System.Windows.Forms.TabPage tabPage_Clients;
        private System.Windows.Forms.GroupBox groupBox14;
        private System.Windows.Forms.Panel panel6;

        private System.Windows.Forms.ComboBox comboBox_EyeTimer;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.ComboBox comboBox_SceneTimer;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Splitter splitter7;
        private System.Windows.Forms.TextBox lblIP;
        private System.Windows.Forms.Splitter splitter6;
        private System.Windows.Forms.Label lblGlintCenter;
        private System.Windows.Forms.Splitter splitter3;
        private System.Windows.Forms.Label lblPupilCenter;
        private System.Windows.Forms.GroupBox groupBox_imgEye;
        private Emgu.CV.UI.ImageBox imEyeTest;
        private System.Windows.Forms.GroupBox groupBox_imgScene;
        private System.Windows.Forms.CheckBox cbShowEdges;
        private System.Windows.Forms.CheckBox cb_eye_VFlip;
        private System.Windows.Forms.CheckBox cb_scene_VFlip;
        private System.Windows.Forms.GroupBox gbCalibrationRemote;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TabPage tabPage_Gesture;
        private System.Windows.Forms.RadioButton radioButton4D;
        private System.Windows.Forms.RadioButton radioButton8D;
        private System.Windows.Forms.PictureBox pbUpLeft2;
        private System.Windows.Forms.PictureBox pbUpLeft1;
        private System.Windows.Forms.PictureBox pbLeft2;
        private System.Windows.Forms.PictureBox pbLeft1;
        private System.Windows.Forms.PictureBox pbDownLeft2;
        private System.Windows.Forms.PictureBox pbDownLeft1;
        private System.Windows.Forms.PictureBox pbDown2;
        private System.Windows.Forms.PictureBox pbDown1;
        private System.Windows.Forms.PictureBox pbDownRight2;
        private System.Windows.Forms.PictureBox pbDownRight1;
        private System.Windows.Forms.PictureBox pbRight2;
        private System.Windows.Forms.PictureBox pbRight1;
        private System.Windows.Forms.PictureBox pbUpRight2;
        private System.Windows.Forms.PictureBox pbUpRight1;
        private System.Windows.Forms.PictureBox pbUp2;
        private System.Windows.Forms.PictureBox pbUp1;
        private System.Windows.Forms.GroupBox groupBox16;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkEditShowOpticalFlow;
        private System.Windows.Forms.PictureBox pbTRight;
        private System.Windows.Forms.PictureBox pbTLeft;
        private System.Windows.Forms.Timer timerReset;
        private System.Windows.Forms.GroupBox groupBox18;
        private System.Windows.Forms.TrackBar trackBarTest;
        private System.Windows.Forms.ProgressBar prg_Custom1;
        private System.Windows.Forms.Button btn_Custom1;
        private System.Windows.Forms.Button btn_Record;
        private System.Windows.Forms.GroupBox groupBox19;
        private System.Windows.Forms.Button btn_Custom4;
        private System.Windows.Forms.ProgressBar prg_Custom4;
        private System.Windows.Forms.Button btn_Custom3;
        private System.Windows.Forms.ProgressBar prg_Custom3;
        private System.Windows.Forms.Button btn_Custom2;
        private System.Windows.Forms.ProgressBar prg_Custom2;
        private System.Windows.Forms.GroupBox groupBox20;
        private System.Windows.Forms.GroupBox groupBox17;
        private System.Windows.Forms.Button btnDbBlink;
        private System.Windows.Forms.Button btnBlink;
        private System.Windows.Forms.Label lbl_calibration;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.CheckBox cbShowGaze;
        private System.Windows.Forms.GroupBox groupBox21;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartTest;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.PictureBox imEye;
        private System.Windows.Forms.PictureBox imScene;
		private System.Windows.Forms.TabPage tabPage_ExtData;
		private System.Windows.Forms.GroupBox groupBox13;
		private System.Windows.Forms.CheckBox checkBox4;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.NumericUpDown numericUpDown1;
		private System.Windows.Forms.Button btn_CleanCache;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.SplitContainer splitContainer2;
		private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox imSceneProcessed;
        private System.Windows.Forms.RadioButton rbGlint;
        private System.Windows.Forms.GroupBox gbCalibrationGlass;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabPage tabPage_Glass;
        private System.Windows.Forms.TextBox tbOutput;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ListBox lbCommandsToGlass;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.TextBox txtImageName;
        private TransparentTrackBar TrackBar1;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
    }
}

