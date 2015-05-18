namespace RoombaControl
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.serialPort = new System.IO.Ports.SerialPort(this.components);
            this.traceRichTextBox = new System.Windows.Forms.RichTextBox();
            this.connectButton = new System.Windows.Forms.Button();
            this.disconnectButton = new System.Windows.Forms.Button();
            this.startButton = new System.Windows.Forms.Button();
            this.OpcodesTextBox = new System.Windows.Forms.TextBox();
            this.sendButton = new System.Windows.Forms.Button();
            this.sendTextbutton = new System.Windows.Forms.Button();
            this.addCRcheckBox = new System.Windows.Forms.CheckBox();
            this.fwdButton = new System.Windows.Forms.Button();
            this.leftButton = new System.Windows.Forms.Button();
            this.rightButton = new System.Windows.Forms.Button();
            this.backButton = new System.Windows.Forms.Button();
            this.speedTrackBar = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.speedLabel = new System.Windows.Forms.Label();
            this.dockButton = new System.Windows.Forms.Button();
            this.cleanButton = new System.Windows.Forms.Button();
            this.sensorsButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.updateFreqLabel = new System.Windows.Forms.Label();
            this.sensorTextBox = new System.Windows.Forms.TextBox();
            this.streamButton = new System.Windows.Forms.Button();
            this.sensorGroupList = new System.Windows.Forms.ListBox();
            this.updateFreqTrackBar = new System.Windows.Forms.TrackBar();
            this.spotButton = new System.Windows.Forms.Button();
            this.recordButton = new System.Windows.Forms.Button();
            this.replayButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.brushesButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.traceCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.portNametextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.clearTrailButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.zoomOutButton = new System.Windows.Forms.Button();
            this.zoomInButton = new System.Windows.Forms.Button();
            this.zoomTrackBar = new System.Windows.Forms.TrackBar();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.clearTraceButton = new System.Windows.Forms.Button();
            this.canvas1 = new RoombaControl.Canvas();
            ((System.ComponentModel.ISupportInitialize)(this.speedTrackBar)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.updateFreqTrackBar)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.zoomTrackBar)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // serialPort
            // 
            this.serialPort.BaudRate = 115000;
            this.serialPort.PortName = "COM4";
            this.serialPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort_DataReceived);
            // 
            // traceRichTextBox
            // 
            this.traceRichTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.traceRichTextBox.Location = new System.Drawing.Point(512, 410);
            this.traceRichTextBox.Name = "traceRichTextBox";
            this.traceRichTextBox.Size = new System.Drawing.Size(260, 170);
            this.traceRichTextBox.TabIndex = 0;
            this.traceRichTextBox.Text = "";
            this.traceRichTextBox.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // connectButton
            // 
            this.connectButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.connectButton.Location = new System.Drawing.Point(200, 20);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(72, 22);
            this.connectButton.TabIndex = 1;
            this.connectButton.Text = "Connect";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // disconnectButton
            // 
            this.disconnectButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.disconnectButton.Location = new System.Drawing.Point(116, 19);
            this.disconnectButton.Name = "disconnectButton";
            this.disconnectButton.Size = new System.Drawing.Size(78, 22);
            this.disconnectButton.TabIndex = 2;
            this.disconnectButton.Text = "Disconnect";
            this.disconnectButton.UseVisualStyleBackColor = true;
            this.disconnectButton.Click += new System.EventHandler(this.disconnectButton_Click);
            // 
            // startButton
            // 
            this.startButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.startButton.Location = new System.Drawing.Point(22, 19);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(88, 23);
            this.startButton.TabIndex = 3;
            this.startButton.Text = "Start SCI";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // OpcodesTextBox
            // 
            this.OpcodesTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.OpcodesTextBox.Location = new System.Drawing.Point(12, 12);
            this.OpcodesTextBox.Name = "OpcodesTextBox";
            this.OpcodesTextBox.Size = new System.Drawing.Size(751, 20);
            this.OpcodesTextBox.TabIndex = 4;
            this.OpcodesTextBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // sendButton
            // 
            this.sendButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sendButton.Location = new System.Drawing.Point(769, 12);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(104, 22);
            this.sendButton.TabIndex = 5;
            this.sendButton.Text = "Send as bytes";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // sendTextbutton
            // 
            this.sendTextbutton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sendTextbutton.Location = new System.Drawing.Point(879, 12);
            this.sendTextbutton.Name = "sendTextbutton";
            this.sendTextbutton.Size = new System.Drawing.Size(104, 22);
            this.sendTextbutton.TabIndex = 6;
            this.sendTextbutton.Text = "Send as Text";
            this.sendTextbutton.UseVisualStyleBackColor = true;
            this.sendTextbutton.Click += new System.EventHandler(this.sendTextbutton_Click);
            // 
            // addCRcheckBox
            // 
            this.addCRcheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.addCRcheckBox.AutoSize = true;
            this.addCRcheckBox.Location = new System.Drawing.Point(989, 15);
            this.addCRcheckBox.Name = "addCRcheckBox";
            this.addCRcheckBox.Size = new System.Drawing.Size(74, 17);
            this.addCRcheckBox.TabIndex = 7;
            this.addCRcheckBox.Text = "add <CR>";
            this.addCRcheckBox.UseVisualStyleBackColor = true;
            // 
            // fwdButton
            // 
            this.fwdButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.fwdButton.Location = new System.Drawing.Point(83, 15);
            this.fwdButton.Name = "fwdButton";
            this.fwdButton.Size = new System.Drawing.Size(75, 23);
            this.fwdButton.TabIndex = 8;
            this.fwdButton.Text = "Fwd";
            this.fwdButton.UseVisualStyleBackColor = true;
            this.fwdButton.Click += new System.EventHandler(this.fwdButton_Click);
            this.fwdButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.fwdButton_MouseDown);
            this.fwdButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.fwdButton_MouseUp);
            // 
            // leftButton
            // 
            this.leftButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.leftButton.Location = new System.Drawing.Point(16, 44);
            this.leftButton.Name = "leftButton";
            this.leftButton.Size = new System.Drawing.Size(75, 23);
            this.leftButton.TabIndex = 9;
            this.leftButton.Text = "Left";
            this.leftButton.UseVisualStyleBackColor = true;
            this.leftButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.leftButton_MouseDown);
            this.leftButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.leftButton_MouseUp);
            // 
            // rightButton
            // 
            this.rightButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rightButton.Location = new System.Drawing.Point(148, 44);
            this.rightButton.Name = "rightButton";
            this.rightButton.Size = new System.Drawing.Size(75, 23);
            this.rightButton.TabIndex = 10;
            this.rightButton.Text = "Right";
            this.rightButton.UseVisualStyleBackColor = true;
            this.rightButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.rightButton_MouseDown);
            this.rightButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.rightButton_MouseUp);
            // 
            // backButton
            // 
            this.backButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.backButton.Location = new System.Drawing.Point(83, 73);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(75, 23);
            this.backButton.TabIndex = 11;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.backButton_MouseDown);
            this.backButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.backButton_MouseUp);
            // 
            // speedTrackBar
            // 
            this.speedTrackBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.speedTrackBar.Location = new System.Drawing.Point(6, 161);
            this.speedTrackBar.Maximum = 500;
            this.speedTrackBar.Name = "speedTrackBar";
            this.speedTrackBar.Size = new System.Drawing.Size(217, 45);
            this.speedTrackBar.TabIndex = 12;
            this.speedTrackBar.Value = 50;
            this.speedTrackBar.Scroll += new System.EventHandler(this.speedTrackBar_Scroll);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 135);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Speed";
            // 
            // speedLabel
            // 
            this.speedLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.speedLabel.AutoSize = true;
            this.speedLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.speedLabel.Location = new System.Drawing.Point(79, 135);
            this.speedLabel.Name = "speedLabel";
            this.speedLabel.Size = new System.Drawing.Size(61, 20);
            this.speedLabel.TabIndex = 14;
            this.speedLabel.Text = "5 cm/s";
            // 
            // dockButton
            // 
            this.dockButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dockButton.Location = new System.Drawing.Point(164, 225);
            this.dockButton.Name = "dockButton";
            this.dockButton.Size = new System.Drawing.Size(75, 23);
            this.dockButton.TabIndex = 15;
            this.dockButton.Text = "Dock";
            this.dockButton.UseVisualStyleBackColor = true;
            this.dockButton.Click += new System.EventHandler(this.dockButton_Click);
            // 
            // cleanButton
            // 
            this.cleanButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cleanButton.Location = new System.Drawing.Point(83, 225);
            this.cleanButton.Name = "cleanButton";
            this.cleanButton.Size = new System.Drawing.Size(75, 23);
            this.cleanButton.TabIndex = 16;
            this.cleanButton.Text = "Clean";
            this.cleanButton.UseVisualStyleBackColor = true;
            this.cleanButton.Click += new System.EventHandler(this.cleanButton_Click);
            // 
            // sensorsButton
            // 
            this.sensorsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sensorsButton.Location = new System.Drawing.Point(164, 254);
            this.sensorsButton.Name = "sensorsButton";
            this.sensorsButton.Size = new System.Drawing.Size(75, 23);
            this.sensorsButton.TabIndex = 17;
            this.sensorsButton.Text = "Sensors";
            this.sensorsButton.UseVisualStyleBackColor = true;
            this.sensorsButton.Click += new System.EventHandler(this.sensorsButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.updateFreqLabel);
            this.groupBox1.Controls.Add(this.sensorTextBox);
            this.groupBox1.Controls.Add(this.streamButton);
            this.groupBox1.Controls.Add(this.sensorGroupList);
            this.groupBox1.Controls.Add(this.updateFreqTrackBar);
            this.groupBox1.Location = new System.Drawing.Point(778, 40);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(278, 459);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sensors";
            // 
            // updateFreqLabel
            // 
            this.updateFreqLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.updateFreqLabel.AutoSize = true;
            this.updateFreqLabel.Location = new System.Drawing.Point(135, 432);
            this.updateFreqLabel.Name = "updateFreqLabel";
            this.updateFreqLabel.Size = new System.Drawing.Size(64, 13);
            this.updateFreqLabel.TabIndex = 7;
            this.updateFreqLabel.Text = "3 updates/s";
            // 
            // sensorTextBox
            // 
            this.sensorTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.sensorTextBox.Location = new System.Drawing.Point(6, 19);
            this.sensorTextBox.Multiline = true;
            this.sensorTextBox.Name = "sensorTextBox";
            this.sensorTextBox.Size = new System.Drawing.Size(266, 316);
            this.sensorTextBox.TabIndex = 4;
            // 
            // streamButton
            // 
            this.streamButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.streamButton.Location = new System.Drawing.Point(205, 427);
            this.streamButton.Name = "streamButton";
            this.streamButton.Size = new System.Drawing.Size(67, 23);
            this.streamButton.TabIndex = 1;
            this.streamButton.Text = "Start/Stop sensors";
            this.streamButton.UseVisualStyleBackColor = true;
            this.streamButton.Click += new System.EventHandler(this.streamButton_Click);
            // 
            // sensorGroupList
            // 
            this.sensorGroupList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.sensorGroupList.FormattingEnabled = true;
            this.sensorGroupList.Location = new System.Drawing.Point(6, 341);
            this.sensorGroupList.Name = "sensorGroupList";
            this.sensorGroupList.Size = new System.Drawing.Size(268, 82);
            this.sensorGroupList.TabIndex = 0;
            this.sensorGroupList.SelectedIndexChanged += new System.EventHandler(this.sensorGroupList_SelectedIndexChanged);
            // 
            // updateFreqTrackBar
            // 
            this.updateFreqTrackBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.updateFreqTrackBar.Location = new System.Drawing.Point(6, 425);
            this.updateFreqTrackBar.Maximum = 20;
            this.updateFreqTrackBar.Minimum = 1;
            this.updateFreqTrackBar.Name = "updateFreqTrackBar";
            this.updateFreqTrackBar.Size = new System.Drawing.Size(131, 45);
            this.updateFreqTrackBar.TabIndex = 6;
            this.updateFreqTrackBar.Value = 3;
            this.updateFreqTrackBar.Scroll += new System.EventHandler(this.updateFreqTrackBar_Scroll);
            // 
            // spotButton
            // 
            this.spotButton.Location = new System.Drawing.Point(84, 254);
            this.spotButton.Name = "spotButton";
            this.spotButton.Size = new System.Drawing.Size(75, 23);
            this.spotButton.TabIndex = 23;
            this.spotButton.Text = "Spot";
            this.spotButton.UseVisualStyleBackColor = true;
            this.spotButton.Click += new System.EventHandler(this.spotButton_Click);
            // 
            // recordButton
            // 
            this.recordButton.Location = new System.Drawing.Point(6, 19);
            this.recordButton.Name = "recordButton";
            this.recordButton.Size = new System.Drawing.Size(75, 23);
            this.recordButton.TabIndex = 24;
            this.recordButton.Text = "Record";
            this.recordButton.UseVisualStyleBackColor = true;
            this.recordButton.Click += new System.EventHandler(this.recordButton_Click);
            // 
            // replayButton
            // 
            this.replayButton.Location = new System.Drawing.Point(83, 19);
            this.replayButton.Name = "replayButton";
            this.replayButton.Size = new System.Drawing.Size(75, 23);
            this.replayButton.TabIndex = 25;
            this.replayButton.Text = "Replay";
            this.replayButton.UseVisualStyleBackColor = true;
            this.replayButton.Click += new System.EventHandler(this.replayButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.Location = new System.Drawing.Point(98, 44);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(45, 23);
            this.stopButton.TabIndex = 26;
            this.stopButton.Text = "Stop";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // brushesButton
            // 
            this.brushesButton.Location = new System.Drawing.Point(3, 225);
            this.brushesButton.Name = "brushesButton";
            this.brushesButton.Size = new System.Drawing.Size(75, 23);
            this.brushesButton.TabIndex = 27;
            this.brushesButton.Text = "Brushes";
            this.brushesButton.UseVisualStyleBackColor = true;
            this.brushesButton.Click += new System.EventHandler(this.brushesButton_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.brushesButton);
            this.groupBox2.Controls.Add(this.stopButton);
            this.groupBox2.Controls.Add(this.spotButton);
            this.groupBox2.Controls.Add(this.sensorsButton);
            this.groupBox2.Controls.Add(this.cleanButton);
            this.groupBox2.Controls.Add(this.dockButton);
            this.groupBox2.Controls.Add(this.speedLabel);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.speedTrackBar);
            this.groupBox2.Controls.Add(this.backButton);
            this.groupBox2.Controls.Add(this.rightButton);
            this.groupBox2.Controls.Add(this.leftButton);
            this.groupBox2.Controls.Add(this.fwdButton);
            this.groupBox2.Location = new System.Drawing.Point(512, 38);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(251, 290);
            this.groupBox2.TabIndex = 28;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Control";
            // 
            // traceCheckBox
            // 
            this.traceCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.traceCheckBox.AutoSize = true;
            this.traceCheckBox.Checked = true;
            this.traceCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.traceCheckBox.Location = new System.Drawing.Point(512, 392);
            this.traceCheckBox.Name = "traceCheckBox";
            this.traceCheckBox.Size = new System.Drawing.Size(54, 17);
            this.traceCheckBox.TabIndex = 28;
            this.traceCheckBox.Text = "Trace";
            this.traceCheckBox.UseVisualStyleBackColor = true;
            this.traceCheckBox.CheckedChanged += new System.EventHandler(this.traceCheckBox_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.portNametextBox);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.startButton);
            this.groupBox3.Controls.Add(this.disconnectButton);
            this.groupBox3.Controls.Add(this.connectButton);
            this.groupBox3.Location = new System.Drawing.Point(778, 505);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(278, 74);
            this.groupBox3.TabIndex = 29;
            this.groupBox3.TabStop = false;
            // 
            // portNametextBox
            // 
            this.portNametextBox.Location = new System.Drawing.Point(172, 47);
            this.portNametextBox.Name = "portNametextBox";
            this.portNametextBox.Size = new System.Drawing.Size(100, 20);
            this.portNametextBox.TabIndex = 5;
            this.portNametextBox.TextChanged += new System.EventHandler(this.portNametextBox_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(135, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Port:";
            // 
            // clearTrailButton
            // 
            this.clearTrailButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.clearTrailButton.Location = new System.Drawing.Point(6, 512);
            this.clearTrailButton.Name = "clearTrailButton";
            this.clearTrailButton.Size = new System.Drawing.Size(75, 23);
            this.clearTrailButton.TabIndex = 28;
            this.clearTrailButton.Text = "Clear Trail";
            this.clearTrailButton.UseVisualStyleBackColor = true;
            this.clearTrailButton.Click += new System.EventHandler(this.clearTrailButton_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.Location = new System.Drawing.Point(87, 512);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 26;
            this.button1.Text = "Straighten";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // zoomOutButton
            // 
            this.zoomOutButton.Location = new System.Drawing.Point(6, 16);
            this.zoomOutButton.Name = "zoomOutButton";
            this.zoomOutButton.Size = new System.Drawing.Size(30, 23);
            this.zoomOutButton.TabIndex = 33;
            this.zoomOutButton.Text = "-";
            this.zoomOutButton.UseVisualStyleBackColor = true;
            this.zoomOutButton.Click += new System.EventHandler(this.zoomOutButton_Click);
            // 
            // zoomInButton
            // 
            this.zoomInButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.zoomInButton.Location = new System.Drawing.Point(458, 16);
            this.zoomInButton.Name = "zoomInButton";
            this.zoomInButton.Size = new System.Drawing.Size(30, 23);
            this.zoomInButton.TabIndex = 34;
            this.zoomInButton.Text = "+";
            this.zoomInButton.UseVisualStyleBackColor = true;
            this.zoomInButton.Click += new System.EventHandler(this.zoomInButton_Click);
            // 
            // zoomTrackBar
            // 
            this.zoomTrackBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.zoomTrackBar.Location = new System.Drawing.Point(34, 23);
            this.zoomTrackBar.Maximum = 400;
            this.zoomTrackBar.Minimum = 10;
            this.zoomTrackBar.Name = "zoomTrackBar";
            this.zoomTrackBar.Size = new System.Drawing.Size(421, 45);
            this.zoomTrackBar.TabIndex = 35;
            this.zoomTrackBar.Value = 50;
            this.zoomTrackBar.Scroll += new System.EventHandler(this.zoomTrackBar_Scroll);
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.recordButton);
            this.groupBox4.Controls.Add(this.replayButton);
            this.groupBox4.Location = new System.Drawing.Point(512, 334);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(251, 52);
            this.groupBox4.TabIndex = 36;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Record";
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Controls.Add(this.canvas1);
            this.groupBox5.Controls.Add(this.zoomOutButton);
            this.groupBox5.Controls.Add(this.clearTrailButton);
            this.groupBox5.Controls.Add(this.button1);
            this.groupBox5.Controls.Add(this.zoomTrackBar);
            this.groupBox5.Controls.Add(this.zoomInButton);
            this.groupBox5.Location = new System.Drawing.Point(12, 37);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(494, 542);
            this.groupBox5.TabIndex = 37;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Path tracking";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(219, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 36;
            this.label2.Text = "Zoom";
            // 
            // clearTraceButton
            // 
            this.clearTraceButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.clearTraceButton.Location = new System.Drawing.Point(596, 386);
            this.clearTraceButton.Name = "clearTraceButton";
            this.clearTraceButton.Size = new System.Drawing.Size(75, 23);
            this.clearTraceButton.TabIndex = 38;
            this.clearTraceButton.Text = "Clear Trace";
            this.clearTraceButton.UseVisualStyleBackColor = true;
            this.clearTraceButton.Click += new System.EventHandler(this.clearTraceButton_Click);
            // 
            // canvas1
            // 
            this.canvas1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.canvas1.Location = new System.Drawing.Point(6, 45);
            this.canvas1.Name = "canvas1";
            this.canvas1.Size = new System.Drawing.Size(482, 465);
            this.canvas1.TabIndex = 32;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1068, 591);
            this.Controls.Add(this.clearTraceButton);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.traceCheckBox);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.addCRcheckBox);
            this.Controls.Add(this.sendTextbutton);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.OpcodesTextBox);
            this.Controls.Add(this.traceRichTextBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "RoombaControl";
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.Activated += new System.EventHandler(this.Form1_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.speedTrackBar)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.updateFreqTrackBar)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.zoomTrackBar)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.Ports.SerialPort serialPort;
        private System.Windows.Forms.RichTextBox traceRichTextBox;
        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.Button disconnectButton;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.TextBox OpcodesTextBox;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.Button sendTextbutton;
        private System.Windows.Forms.CheckBox addCRcheckBox;
        private System.Windows.Forms.Button fwdButton;
        private System.Windows.Forms.Button leftButton;
        private System.Windows.Forms.Button rightButton;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.TrackBar speedTrackBar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label speedLabel;
        private System.Windows.Forms.Button dockButton;
        private System.Windows.Forms.Button cleanButton;
        private System.Windows.Forms.Button sensorsButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button spotButton;
        private System.Windows.Forms.Button recordButton;
        private System.Windows.Forms.Button replayButton;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.Button brushesButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListBox sensorGroupList;
        private System.Windows.Forms.Button streamButton;
        private System.Windows.Forms.TextBox sensorTextBox;
        private System.Windows.Forms.TrackBar updateFreqTrackBar;
        private System.Windows.Forms.Label updateFreqLabel;
        private System.Windows.Forms.Button button1;
        private Canvas canvas1;
        private System.Windows.Forms.Button zoomOutButton;
        private System.Windows.Forms.Button zoomInButton;
        private System.Windows.Forms.TrackBar zoomTrackBar;
        private System.Windows.Forms.CheckBox traceCheckBox;
        private System.Windows.Forms.Button clearTrailButton;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox portNametextBox;
        private System.Windows.Forms.Button clearTraceButton;
    }
}

