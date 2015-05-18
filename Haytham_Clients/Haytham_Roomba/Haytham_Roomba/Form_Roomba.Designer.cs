namespace Haytham_Client
{
    partial class Form_Roomba
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
            this.cmb_left = new System.Windows.Forms.ComboBox();
            this.cmb_stop = new System.Windows.Forms.ComboBox();
            this.cmb_back = new System.Windows.Forms.ComboBox();
            this.cmb_fwd = new System.Windows.Forms.ComboBox();
            this.cmb_right = new System.Windows.Forms.ComboBox();
            this.left = new System.Windows.Forms.Button();
            this.back = new System.Windows.Forms.Button();
            this.right = new System.Windows.Forms.Button();
            this.fwd = new System.Windows.Forms.Button();
            this.stop = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.cboPorts = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDebug = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.txtMsgToSend = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.PortRoomba = new System.IO.Ports.SerialPort(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.radioButton_gaze = new System.Windows.Forms.RadioButton();
            this.radioButton_gestures = new System.Windows.Forms.RadioButton();
            this.cmb_clean = new System.Windows.Forms.ComboBox();
            this.clean = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmb_left
            // 
            this.cmb_left.FormattingEnabled = true;
            this.cmb_left.Location = new System.Drawing.Point(12, 112);
            this.cmb_left.Name = "cmb_left";
            this.cmb_left.Size = new System.Drawing.Size(141, 21);
            this.cmb_left.TabIndex = 112;
            this.cmb_left.Tag = "right";
            this.cmb_left.SelectedIndexChanged += new System.EventHandler(this.cmb_SelectedIndexChanged);
            // 
            // cmb_stop
            // 
            this.cmb_stop.FormattingEnabled = true;
            this.cmb_stop.Location = new System.Drawing.Point(12, 78);
            this.cmb_stop.Name = "cmb_stop";
            this.cmb_stop.Size = new System.Drawing.Size(141, 21);
            this.cmb_stop.TabIndex = 111;
            this.cmb_stop.Tag = "left";
            this.cmb_stop.SelectedIndexChanged += new System.EventHandler(this.cmb_SelectedIndexChanged);
            // 
            // cmb_back
            // 
            this.cmb_back.FormattingEnabled = true;
            this.cmb_back.Location = new System.Drawing.Point(12, 42);
            this.cmb_back.Name = "cmb_back";
            this.cmb_back.Size = new System.Drawing.Size(141, 21);
            this.cmb_back.TabIndex = 110;
            this.cmb_back.Tag = "stop";
            this.cmb_back.SelectedIndexChanged += new System.EventHandler(this.cmb_SelectedIndexChanged);
            // 
            // cmb_fwd
            // 
            this.cmb_fwd.FormattingEnabled = true;
            this.cmb_fwd.Location = new System.Drawing.Point(12, 8);
            this.cmb_fwd.Name = "cmb_fwd";
            this.cmb_fwd.Size = new System.Drawing.Size(141, 21);
            this.cmb_fwd.TabIndex = 109;
            this.cmb_fwd.Tag = "back";
            this.cmb_fwd.SelectedIndexChanged += new System.EventHandler(this.cmb_SelectedIndexChanged);
            // 
            // cmb_right
            // 
            this.cmb_right.FormattingEnabled = true;
            this.cmb_right.Location = new System.Drawing.Point(12, 139);
            this.cmb_right.Name = "cmb_right";
            this.cmb_right.Size = new System.Drawing.Size(141, 21);
            this.cmb_right.TabIndex = 108;
            this.cmb_right.Tag = "fwd";
            this.cmb_right.SelectedIndexChanged += new System.EventHandler(this.cmb_SelectedIndexChanged);
            // 
            // left
            // 
            this.left.Location = new System.Drawing.Point(18, 175);
            this.left.Name = "left";
            this.left.Size = new System.Drawing.Size(55, 28);
            this.left.TabIndex = 7;
            this.left.Text = "left";
            this.left.UseVisualStyleBackColor = true;
            this.left.MouseDown += new System.Windows.Forms.MouseEventHandler(this.left_MouseDown);
            this.left.MouseUp += new System.Windows.Forms.MouseEventHandler(this.stop_MouseUp);
            // 
            // back
            // 
            this.back.Location = new System.Drawing.Point(18, 107);
            this.back.Name = "back";
            this.back.Size = new System.Drawing.Size(55, 28);
            this.back.TabIndex = 6;
            this.back.Text = "back";
            this.back.UseVisualStyleBackColor = true;
            this.back.Click += new System.EventHandler(this.back_Click);
            this.back.MouseDown += new System.Windows.Forms.MouseEventHandler(this.back_MouseDown);
            this.back.MouseUp += new System.Windows.Forms.MouseEventHandler(this.stop_MouseUp);
            // 
            // right
            // 
            this.right.Location = new System.Drawing.Point(18, 209);
            this.right.Name = "right";
            this.right.Size = new System.Drawing.Size(55, 28);
            this.right.TabIndex = 5;
            this.right.Text = "right";
            this.right.UseVisualStyleBackColor = true;
            this.right.MouseDown += new System.Windows.Forms.MouseEventHandler(this.right_MouseDown);
            this.right.MouseUp += new System.Windows.Forms.MouseEventHandler(this.stop_MouseUp);
            // 
            // fwd
            // 
            this.fwd.Location = new System.Drawing.Point(18, 71);
            this.fwd.Name = "fwd";
            this.fwd.Size = new System.Drawing.Size(55, 28);
            this.fwd.TabIndex = 3;
            this.fwd.Text = "fwd";
            this.fwd.UseVisualStyleBackColor = true;
            this.fwd.MouseDown += new System.Windows.Forms.MouseEventHandler(this.fwd_MouseDown);
            this.fwd.MouseUp += new System.Windows.Forms.MouseEventHandler(this.stop_MouseUp);
            // 
            // stop
            // 
            this.stop.Location = new System.Drawing.Point(18, 141);
            this.stop.Name = "stop";
            this.stop.Size = new System.Drawing.Size(55, 28);
            this.stop.TabIndex = 4;
            this.stop.Text = "stop";
            this.stop.UseVisualStyleBackColor = true;
            this.stop.Click += new System.EventHandler(this.stop_Click);
            this.stop.MouseUp += new System.Windows.Forms.MouseEventHandler(this.stop_MouseUp);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(276, 198);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(79, 27);
            this.btnStart.TabIndex = 95;
            this.btnStart.Text = "Open";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // cboPorts
            // 
            this.cboPorts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPorts.FormattingEnabled = true;
            this.cboPorts.Location = new System.Drawing.Point(276, 171);
            this.cboPorts.Name = "cboPorts";
            this.cboPorts.Size = new System.Drawing.Size(79, 21);
            this.cboPorts.Sorted = true;
            this.cboPorts.TabIndex = 93;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(215, 174);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 92;
            this.label1.Text = "Serial Port";
            // 
            // txtDebug
            // 
            this.txtDebug.BackColor = System.Drawing.SystemColors.Control;
            this.txtDebug.Location = new System.Drawing.Point(12, 171);
            this.txtDebug.Multiline = true;
            this.txtDebug.Name = "txtDebug";
            this.txtDebug.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDebug.Size = new System.Drawing.Size(180, 54);
            this.txtDebug.TabIndex = 94;
            this.txtDebug.WordWrap = false;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(276, 145);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(79, 20);
            this.button3.TabIndex = 91;
            this.button3.Text = "Send to Server";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // txtMsgToSend
            // 
            this.txtMsgToSend.Location = new System.Drawing.Point(12, 145);
            this.txtMsgToSend.Name = "txtMsgToSend";
            this.txtMsgToSend.Size = new System.Drawing.Size(258, 20);
            this.txtMsgToSend.TabIndex = 90;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 12);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(345, 124);
            this.textBox1.TabIndex = 89;
            // 
            // PortRoomba
            // 
            this.PortRoomba.BaudRate = 115000;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Controls.Add(this.radioButton_gaze);
            this.groupBox1.Controls.Add(this.radioButton_gestures);
            this.groupBox1.Controls.Add(this.cmb_clean);
            this.groupBox1.Controls.Add(this.left);
            this.groupBox1.Controls.Add(this.stop);
            this.groupBox1.Controls.Add(this.fwd);
            this.groupBox1.Controls.Add(this.right);
            this.groupBox1.Controls.Add(this.clean);
            this.groupBox1.Controls.Add(this.back);
            this.groupBox1.Enabled = false;
            this.groupBox1.Location = new System.Drawing.Point(30, 254);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(293, 300);
            this.groupBox1.TabIndex = 100;
            this.groupBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cmb_left);
            this.panel2.Controls.Add(this.cmb_stop);
            this.panel2.Controls.Add(this.cmb_back);
            this.panel2.Controls.Add(this.cmb_fwd);
            this.panel2.Controls.Add(this.cmb_right);
            this.panel2.Location = new System.Drawing.Point(107, 70);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(164, 169);
            this.panel2.TabIndex = 113;
            // 
            // radioButton_gaze
            // 
            this.radioButton_gaze.AutoSize = true;
            this.radioButton_gaze.Location = new System.Drawing.Point(44, 28);
            this.radioButton_gaze.Name = "radioButton_gaze";
            this.radioButton_gaze.Size = new System.Drawing.Size(78, 17);
            this.radioButton_gaze.TabIndex = 98;
            this.radioButton_gaze.Text = "Gaze Drive";
            this.radioButton_gaze.UseVisualStyleBackColor = true;
            this.radioButton_gaze.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton_gestures
            // 
            this.radioButton_gestures.AutoSize = true;
            this.radioButton_gestures.Checked = true;
            this.radioButton_gestures.Location = new System.Drawing.Point(141, 28);
            this.radioButton_gestures.Name = "radioButton_gestures";
            this.radioButton_gestures.Size = new System.Drawing.Size(107, 17);
            this.radioButton_gestures.TabIndex = 98;
            this.radioButton_gestures.TabStop = true;
            this.radioButton_gestures.Text = "Drive by gestures";
            this.radioButton_gestures.UseVisualStyleBackColor = true;
            this.radioButton_gestures.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // cmb_clean
            // 
            this.cmb_clean.FormattingEnabled = true;
            this.cmb_clean.Location = new System.Drawing.Point(119, 250);
            this.cmb_clean.Name = "cmb_clean";
            this.cmb_clean.Size = new System.Drawing.Size(141, 21);
            this.cmb_clean.TabIndex = 108;
            this.cmb_clean.Tag = "clean";
            this.cmb_clean.SelectedIndexChanged += new System.EventHandler(this.cmb_SelectedIndexChanged);
            // 
            // clean
            // 
            this.clean.Location = new System.Drawing.Point(18, 250);
            this.clean.Name = "clean";
            this.clean.Size = new System.Drawing.Size(55, 28);
            this.clean.TabIndex = 5;
            this.clean.Text = "clean";
            this.clean.UseVisualStyleBackColor = true;
            this.clean.Click += new System.EventHandler(this.clean_Click);
            this.clean.MouseUp += new System.Windows.Forms.MouseEventHandler(this.stop_MouseUp);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 3000;
            // 
            // Form_Roomba
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 563);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.cboPorts);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDebug);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.txtMsgToSend);
            this.Controls.Add(this.textBox1);
            this.Name = "Form_Roomba";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form_Roomba";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Roomba_FormClosing);
            this.Load += new System.EventHandler(this.Form_BOCU_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button left;
        private System.Windows.Forms.Button back;
        private System.Windows.Forms.Button right;
        private System.Windows.Forms.Button fwd;
        private System.Windows.Forms.Button stop;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.ComboBox cboPorts;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDebug;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox txtMsgToSend;
        private System.Windows.Forms.TextBox textBox1;
        private System.IO.Ports.SerialPort PortRoomba;
        private System.Windows.Forms.ComboBox cmb_left;
        private System.Windows.Forms.ComboBox cmb_stop;
        private System.Windows.Forms.ComboBox cmb_back;
        private System.Windows.Forms.ComboBox cmb_fwd;
        private System.Windows.Forms.ComboBox cmb_right;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmb_clean;
        private System.Windows.Forms.Button clean;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton radioButton_gaze;
        private System.Windows.Forms.RadioButton radioButton_gestures;
        private System.Windows.Forms.Timer timer1;
    }
}