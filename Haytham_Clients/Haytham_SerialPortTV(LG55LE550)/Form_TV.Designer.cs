namespace Haytham_Client
{
    partial class Form_TV
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
            this.btnSendToServer = new System.Windows.Forms.Button();
            this.txtMsgToSend = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.txtDebug = new System.Windows.Forms.TextBox();
            this.txtSend = new System.Windows.Forms.TextBox();
            this.PortLG = new System.IO.Ports.SerialPort(this.components);
            this.btn_28 = new System.Windows.Forms.Button();
            this.btn_45 = new System.Windows.Forms.Button();
            this.btn_43 = new System.Windows.Forms.Button();
            this.btn_09 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_01 = new System.Windows.Forms.Button();
            this.btn_03 = new System.Windows.Forms.Button();
            this.btn_00 = new System.Windows.Forms.Button();
            this.btn_02 = new System.Windows.Forms.Button();
            this.btn_1A = new System.Windows.Forms.Button();
            this.btn_10 = new System.Windows.Forms.Button();
            this.btn_53 = new System.Windows.Forms.Button();
            this.btn_19 = new System.Windows.Forms.Button();
            this.btn_18 = new System.Windows.Forms.Button();
            this.btn_17 = new System.Windows.Forms.Button();
            this.btn_16 = new System.Windows.Forms.Button();
            this.btn_15 = new System.Windows.Forms.Button();
            this.btn_14 = new System.Windows.Forms.Button();
            this.btn_13 = new System.Windows.Forms.Button();
            this.btn_12 = new System.Windows.Forms.Button();
            this.btn_11 = new System.Windows.Forms.Button();
            this.btn_41 = new System.Windows.Forms.Button();
            this.btn_06 = new System.Windows.Forms.Button();
            this.btn_07 = new System.Windows.Forms.Button();
            this.btn_40 = new System.Windows.Forms.Button();
            this.btn_44 = new System.Windows.Forms.Button();
            this.cboPorts = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Panel2 = new System.Windows.Forms.Panel();
            this.fraLGControl = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.Panel2.SuspendLayout();
            this.fraLGControl.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSendToServer
            // 
            this.btnSendToServer.Location = new System.Drawing.Point(276, 145);
            this.btnSendToServer.Name = "btnSendToServer";
            this.btnSendToServer.Size = new System.Drawing.Size(79, 20);
            this.btnSendToServer.TabIndex = 47;
            this.btnSendToServer.Text = "Send to Server";
            this.btnSendToServer.UseVisualStyleBackColor = true;
            this.btnSendToServer.Click += new System.EventHandler(this.btnSendToServer_Click);
            // 
            // txtMsgToSend
            // 
            this.txtMsgToSend.Location = new System.Drawing.Point(12, 145);
            this.txtMsgToSend.Name = "txtMsgToSend";
            this.txtMsgToSend.Size = new System.Drawing.Size(258, 20);
            this.txtMsgToSend.TabIndex = 46;
            this.txtMsgToSend.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMsgToSend_KeyDown);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 47);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(345, 89);
            this.textBox1.TabIndex = 45;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(227, 5);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(84, 22);
            this.btnSend.TabIndex = 51;
            this.btnSend.Text = "Send to TV";
            this.btnSend.UseVisualStyleBackColor = true;
            // 
            // txtDebug
            // 
            this.txtDebug.Location = new System.Drawing.Point(10, 149);
            this.txtDebug.Multiline = true;
            this.txtDebug.Name = "txtDebug";
            this.txtDebug.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDebug.Size = new System.Drawing.Size(140, 388);
            this.txtDebug.TabIndex = 50;
            this.txtDebug.WordWrap = false;
            // 
            // txtSend
            // 
            this.txtSend.Location = new System.Drawing.Point(7, 7);
            this.txtSend.Name = "txtSend";
            this.txtSend.Size = new System.Drawing.Size(214, 20);
            this.txtSend.TabIndex = 52;
            // 
            // btn_28
            // 
            this.btn_28.Location = new System.Drawing.Point(11, 349);
            this.btn_28.Name = "btn_28";
            this.btn_28.Size = new System.Drawing.Size(51, 23);
            this.btn_28.TabIndex = 31;
            this.btn_28.Text = "Back";
            this.btn_28.UseVisualStyleBackColor = true;
            this.btn_28.Click += new System.EventHandler(this.btn_28_Click);
            // 
            // btn_45
            // 
            this.btn_45.Enabled = false;
            this.btn_45.Location = new System.Drawing.Point(113, 232);
            this.btn_45.Name = "btn_45";
            this.btn_45.Size = new System.Drawing.Size(51, 23);
            this.btn_45.TabIndex = 30;
            this.btn_45.Text = "Q.Menu";
            this.btn_45.UseVisualStyleBackColor = true;
            this.btn_45.Click += new System.EventHandler(this.btn_45_Click);
            // 
            // btn_43
            // 
            this.btn_43.Location = new System.Drawing.Point(11, 232);
            this.btn_43.Name = "btn_43";
            this.btn_43.Size = new System.Drawing.Size(51, 23);
            this.btn_43.TabIndex = 28;
            this.btn_43.Text = "Menu";
            this.btn_43.UseVisualStyleBackColor = true;
            this.btn_43.Click += new System.EventHandler(this.btn_43_Click);
            // 
            // btn_09
            // 
            this.btn_09.Location = new System.Drawing.Point(58, 203);
            this.btn_09.Name = "btn_09";
            this.btn_09.Size = new System.Drawing.Size(64, 23);
            this.btn_09.TabIndex = 27;
            this.btn_09.Text = "Mute";
            this.btn_09.UseVisualStyleBackColor = true;
            this.btn_09.Click += new System.EventHandler(this.btn_09_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(125, 179);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 24;
            this.label3.Text = "Channel";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 179);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = "Volume";
            // 
            // btn_01
            // 
            this.btn_01.Font = new System.Drawing.Font("Marlett", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btn_01.Location = new System.Drawing.Point(128, 203);
            this.btn_01.Name = "btn_01";
            this.btn_01.Size = new System.Drawing.Size(36, 23);
            this.btn_01.TabIndex = 22;
            this.btn_01.Text = "6";
            this.btn_01.UseVisualStyleBackColor = true;
            this.btn_01.Click += new System.EventHandler(this.btn_01_Click);
            // 
            // btn_03
            // 
            this.btn_03.Font = new System.Drawing.Font("Marlett", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btn_03.Location = new System.Drawing.Point(11, 203);
            this.btn_03.Name = "btn_03";
            this.btn_03.Size = new System.Drawing.Size(36, 23);
            this.btn_03.TabIndex = 21;
            this.btn_03.Text = "6";
            this.btn_03.UseVisualStyleBackColor = true;
            this.btn_03.Click += new System.EventHandler(this.btn_03_Click);
            // 
            // btn_00
            // 
            this.btn_00.Font = new System.Drawing.Font("Marlett", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btn_00.Location = new System.Drawing.Point(128, 145);
            this.btn_00.Name = "btn_00";
            this.btn_00.Size = new System.Drawing.Size(36, 23);
            this.btn_00.TabIndex = 20;
            this.btn_00.Text = "5";
            this.btn_00.UseVisualStyleBackColor = true;
            this.btn_00.Click += new System.EventHandler(this.btn_00_Click);
            // 
            // btn_02
            // 
            this.btn_02.Font = new System.Drawing.Font("Marlett", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btn_02.Location = new System.Drawing.Point(11, 145);
            this.btn_02.Name = "btn_02";
            this.btn_02.Size = new System.Drawing.Size(36, 23);
            this.btn_02.TabIndex = 19;
            this.btn_02.Text = "5";
            this.btn_02.UseVisualStyleBackColor = true;
            this.btn_02.Click += new System.EventHandler(this.btn_02_Click);
            // 
            // btn_1A
            // 
            this.btn_1A.Location = new System.Drawing.Point(105, 111);
            this.btn_1A.Name = "btn_1A";
            this.btn_1A.Size = new System.Drawing.Size(59, 28);
            this.btn_1A.TabIndex = 18;
            this.btn_1A.Text = "Q.View";
            this.btn_1A.UseVisualStyleBackColor = true;
            this.btn_1A.Click += new System.EventHandler(this.btn_1A_Click);
            // 
            // btn_10
            // 
            this.btn_10.Location = new System.Drawing.Point(68, 111);
            this.btn_10.Name = "btn_10";
            this.btn_10.Size = new System.Drawing.Size(28, 28);
            this.btn_10.TabIndex = 17;
            this.btn_10.Text = "0";
            this.btn_10.UseVisualStyleBackColor = true;
            // 
            // btn_53
            // 
            this.btn_53.Location = new System.Drawing.Point(11, 111);
            this.btn_53.Name = "btn_53";
            this.btn_53.Size = new System.Drawing.Size(51, 28);
            this.btn_53.TabIndex = 16;
            this.btn_53.Text = "List";
            this.btn_53.UseVisualStyleBackColor = true;
            this.btn_53.Click += new System.EventHandler(this.btn_53_Click);
            // 
            // btn_19
            // 
            this.btn_19.Location = new System.Drawing.Point(102, 77);
            this.btn_19.Name = "btn_19";
            this.btn_19.Size = new System.Drawing.Size(28, 28);
            this.btn_19.TabIndex = 15;
            this.btn_19.Text = "9";
            this.btn_19.UseVisualStyleBackColor = true;
            // 
            // btn_18
            // 
            this.btn_18.Location = new System.Drawing.Point(68, 77);
            this.btn_18.Name = "btn_18";
            this.btn_18.Size = new System.Drawing.Size(28, 28);
            this.btn_18.TabIndex = 14;
            this.btn_18.Text = "8";
            this.btn_18.UseVisualStyleBackColor = true;
            // 
            // btn_17
            // 
            this.btn_17.Location = new System.Drawing.Point(34, 77);
            this.btn_17.Name = "btn_17";
            this.btn_17.Size = new System.Drawing.Size(28, 28);
            this.btn_17.TabIndex = 13;
            this.btn_17.Text = "7";
            this.btn_17.UseVisualStyleBackColor = true;
            // 
            // btn_16
            // 
            this.btn_16.Location = new System.Drawing.Point(103, 43);
            this.btn_16.Name = "btn_16";
            this.btn_16.Size = new System.Drawing.Size(28, 28);
            this.btn_16.TabIndex = 12;
            this.btn_16.Text = "6";
            this.btn_16.UseVisualStyleBackColor = true;
            // 
            // btn_15
            // 
            this.btn_15.Location = new System.Drawing.Point(68, 43);
            this.btn_15.Name = "btn_15";
            this.btn_15.Size = new System.Drawing.Size(28, 28);
            this.btn_15.TabIndex = 11;
            this.btn_15.Text = "5";
            this.btn_15.UseVisualStyleBackColor = true;
            // 
            // btn_14
            // 
            this.btn_14.Location = new System.Drawing.Point(34, 43);
            this.btn_14.Name = "btn_14";
            this.btn_14.Size = new System.Drawing.Size(28, 28);
            this.btn_14.TabIndex = 10;
            this.btn_14.Text = "4";
            this.btn_14.UseVisualStyleBackColor = true;
            // 
            // btn_13
            // 
            this.btn_13.Location = new System.Drawing.Point(103, 9);
            this.btn_13.Name = "btn_13";
            this.btn_13.Size = new System.Drawing.Size(28, 28);
            this.btn_13.TabIndex = 9;
            this.btn_13.Text = "3";
            this.btn_13.UseVisualStyleBackColor = true;
            // 
            // btn_12
            // 
            this.btn_12.Location = new System.Drawing.Point(68, 9);
            this.btn_12.Name = "btn_12";
            this.btn_12.Size = new System.Drawing.Size(28, 28);
            this.btn_12.TabIndex = 8;
            this.btn_12.Text = "2";
            this.btn_12.UseVisualStyleBackColor = true;
            // 
            // btn_11
            // 
            this.btn_11.Location = new System.Drawing.Point(34, 9);
            this.btn_11.Name = "btn_11";
            this.btn_11.Size = new System.Drawing.Size(28, 28);
            this.btn_11.TabIndex = 7;
            this.btn_11.Text = "1";
            this.btn_11.UseVisualStyleBackColor = true;
            // 
            // btn_41
            // 
            this.btn_41.Font = new System.Drawing.Font("Marlett", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btn_41.Location = new System.Drawing.Point(68, 320);
            this.btn_41.Name = "btn_41";
            this.btn_41.Size = new System.Drawing.Size(36, 23);
            this.btn_41.TabIndex = 6;
            this.btn_41.Text = "6";
            this.btn_41.UseVisualStyleBackColor = true;
            this.btn_41.Click += new System.EventHandler(this.btn_41_Click);
            // 
            // btn_06
            // 
            this.btn_06.Font = new System.Drawing.Font("Marlett", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btn_06.Location = new System.Drawing.Point(110, 291);
            this.btn_06.Name = "btn_06";
            this.btn_06.Size = new System.Drawing.Size(32, 23);
            this.btn_06.TabIndex = 5;
            this.btn_06.Text = "4";
            this.btn_06.UseVisualStyleBackColor = true;
            this.btn_06.Click += new System.EventHandler(this.btn_06_Click);
            // 
            // btn_07
            // 
            this.btn_07.Font = new System.Drawing.Font("Marlett", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btn_07.Location = new System.Drawing.Point(30, 291);
            this.btn_07.Name = "btn_07";
            this.btn_07.Size = new System.Drawing.Size(30, 23);
            this.btn_07.TabIndex = 4;
            this.btn_07.Text = "3";
            this.btn_07.UseVisualStyleBackColor = true;
            this.btn_07.Click += new System.EventHandler(this.btn_07_Click);
            // 
            // btn_40
            // 
            this.btn_40.Font = new System.Drawing.Font("Marlett", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btn_40.Location = new System.Drawing.Point(68, 262);
            this.btn_40.Name = "btn_40";
            this.btn_40.Size = new System.Drawing.Size(36, 23);
            this.btn_40.TabIndex = 3;
            this.btn_40.Text = "5";
            this.btn_40.UseVisualStyleBackColor = true;
            this.btn_40.Click += new System.EventHandler(this.btn_40_Click);
            // 
            // btn_44
            // 
            this.btn_44.Location = new System.Drawing.Point(66, 291);
            this.btn_44.Name = "btn_44";
            this.btn_44.Size = new System.Drawing.Size(38, 23);
            this.btn_44.TabIndex = 2;
            this.btn_44.Text = "Ok";
            this.btn_44.UseVisualStyleBackColor = true;
            this.btn_44.Click += new System.EventHandler(this.btn_44_Click);
            // 
            // cboPorts
            // 
            this.cboPorts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPorts.FormattingEnabled = true;
            this.cboPorts.Location = new System.Drawing.Point(142, 16);
            this.cboPorts.Name = "cboPorts";
            this.cboPorts.Size = new System.Drawing.Size(130, 21);
            this.cboPorts.Sorted = true;
            this.cboPorts.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Serial Port (LG Connected)";
            // 
            // btnStop
            // 
            this.btnStop.Enabled = false;
            this.btnStop.Location = new System.Drawing.Point(142, 43);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(54, 27);
            this.btnStop.TabIndex = 3;
            this.btnStop.Text = "Off";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(218, 43);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(54, 27);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "On";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel1.Controls.Add(this.txtDebug);
            this.panel1.Controls.Add(this.Panel2);
            this.panel1.Controls.Add(this.fraLGControl);
            this.panel1.Controls.Add(this.btnStop);
            this.panel1.Controls.Add(this.cboPorts);
            this.panel1.Controls.Add(this.btnStart);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 171);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(345, 553);
            this.panel1.TabIndex = 53;
            // 
            // Panel2
            // 
            this.Panel2.Controls.Add(this.btnSend);
            this.Panel2.Controls.Add(this.txtSend);
            this.Panel2.Enabled = false;
            this.Panel2.Location = new System.Drawing.Point(10, 112);
            this.Panel2.Name = "Panel2";
            this.Panel2.Size = new System.Drawing.Size(320, 31);
            this.Panel2.TabIndex = 54;
            // 
            // fraLGControl
            // 
            this.fraLGControl.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.fraLGControl.Controls.Add(this.btn_28);
            this.fraLGControl.Controls.Add(this.btn_45);
            this.fraLGControl.Controls.Add(this.btn_43);
            this.fraLGControl.Controls.Add(this.btn_09);
            this.fraLGControl.Controls.Add(this.label3);
            this.fraLGControl.Controls.Add(this.btn_10);
            this.fraLGControl.Controls.Add(this.label2);
            this.fraLGControl.Controls.Add(this.btn_44);
            this.fraLGControl.Controls.Add(this.btn_01);
            this.fraLGControl.Controls.Add(this.btn_40);
            this.fraLGControl.Controls.Add(this.btn_03);
            this.fraLGControl.Controls.Add(this.btn_07);
            this.fraLGControl.Controls.Add(this.btn_00);
            this.fraLGControl.Controls.Add(this.btn_06);
            this.fraLGControl.Controls.Add(this.btn_02);
            this.fraLGControl.Controls.Add(this.btn_41);
            this.fraLGControl.Controls.Add(this.btn_1A);
            this.fraLGControl.Controls.Add(this.btn_11);
            this.fraLGControl.Controls.Add(this.btn_12);
            this.fraLGControl.Controls.Add(this.btn_53);
            this.fraLGControl.Controls.Add(this.btn_13);
            this.fraLGControl.Controls.Add(this.btn_19);
            this.fraLGControl.Controls.Add(this.btn_14);
            this.fraLGControl.Controls.Add(this.btn_18);
            this.fraLGControl.Controls.Add(this.btn_15);
            this.fraLGControl.Controls.Add(this.btn_17);
            this.fraLGControl.Controls.Add(this.btn_16);
            this.fraLGControl.Enabled = false;
            this.fraLGControl.Location = new System.Drawing.Point(156, 149);
            this.fraLGControl.Name = "fraLGControl";
            this.fraLGControl.Size = new System.Drawing.Size(174, 388);
            this.fraLGControl.TabIndex = 53;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip1.Size = new System.Drawing.Size(371, 24);
            this.menuStrip1.TabIndex = 54;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // Form_TV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(371, 733);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnSendToServer);
            this.Controls.Add(this.txtMsgToSend);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form_TV";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Client_TV";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_TV_FormClosing);
            this.Load += new System.EventHandler(this.Form_TV_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.Panel2.ResumeLayout(false);
            this.Panel2.PerformLayout();
            this.fraLGControl.ResumeLayout(false);
            this.fraLGControl.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSendToServer;
        private System.Windows.Forms.TextBox txtMsgToSend;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox txtDebug;
        private System.Windows.Forms.TextBox txtSend;
        private System.IO.Ports.SerialPort PortLG;
        private System.Windows.Forms.Button btn_28;
        private System.Windows.Forms.Button btn_45;
        private System.Windows.Forms.Button btn_43;
        private System.Windows.Forms.Button btn_09;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_01;
        private System.Windows.Forms.Button btn_03;
        private System.Windows.Forms.Button btn_00;
        private System.Windows.Forms.Button btn_02;
        private System.Windows.Forms.Button btn_1A;
        private System.Windows.Forms.Button btn_10;
        private System.Windows.Forms.Button btn_53;
        private System.Windows.Forms.Button btn_19;
        private System.Windows.Forms.Button btn_18;
        private System.Windows.Forms.Button btn_17;
        private System.Windows.Forms.Button btn_16;
        private System.Windows.Forms.Button btn_15;
        private System.Windows.Forms.Button btn_14;
        private System.Windows.Forms.Button btn_13;
        private System.Windows.Forms.Button btn_12;
        private System.Windows.Forms.Button btn_11;
        private System.Windows.Forms.Button btn_41;
        private System.Windows.Forms.Button btn_06;
        private System.Windows.Forms.Button btn_07;
        private System.Windows.Forms.Button btn_40;
        private System.Windows.Forms.Button btn_44;
        private System.Windows.Forms.ComboBox cboPorts;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel fraLGControl;
        private System.Windows.Forms.Panel Panel2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
    }
}