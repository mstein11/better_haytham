namespace Haytham_Client
{
    partial class Form_monitor
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txtMsgToSend = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.cmb_RightClick = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmb_ArrowRight = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmb_ArrowLeft = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmb_ArrowDown = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmb_ArrowUp = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmb_Space = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmb_Enter = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmb_LeftClick = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBox_showGaze = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(4, 3);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(240, 124);
            this.textBox1.TabIndex = 40;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(132, 132);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 57);
            this.button1.TabIndex = 41;
            this.button1.Text = "4x5 Grid Demo";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtMsgToSend
            // 
            this.txtMsgToSend.Location = new System.Drawing.Point(4, 107);
            this.txtMsgToSend.Name = "txtMsgToSend";
            this.txtMsgToSend.Size = new System.Drawing.Size(132, 20);
            this.txtMsgToSend.TabIndex = 43;
            this.txtMsgToSend.Visible = false;
            this.txtMsgToSend.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMsgToSend_KeyDown);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(139, 106);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(105, 20);
            this.button3.TabIndex = 44;
            this.button3.Text = "Send to Server";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Visible = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox1.Location = new System.Drawing.Point(4, 132);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(112, 57);
            this.checkBox1.TabIndex = 46;
            this.checkBox1.Text = "Mouse Control";
            this.checkBox1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // checkBox3
            // 
            this.checkBox3.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox3.Location = new System.Drawing.Point(132, 199);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(112, 57);
            this.checkBox3.TabIndex = 51;
            this.checkBox3.Text = "Export data";
            this.checkBox3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBox3.UseVisualStyleBackColor = true;
            this.checkBox3.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(132, 255);
            this.progressBar1.MarqueeAnimationSpeed = 10;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(112, 11);
            this.progressBar1.TabIndex = 52;
            // 
            // cmb_RightClick
            // 
            this.cmb_RightClick.FormattingEnabled = true;
            this.cmb_RightClick.Location = new System.Drawing.Point(70, 31);
            this.cmb_RightClick.Name = "cmb_RightClick";
            this.cmb_RightClick.Size = new System.Drawing.Size(140, 21);
            this.cmb_RightClick.TabIndex = 53;
            this.cmb_RightClick.SelectedIndexChanged += new System.EventHandler(this.cmb_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.cmb_ArrowRight);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.cmb_ArrowLeft);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cmb_ArrowDown);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cmb_ArrowUp);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cmb_Space);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cmb_Enter);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cmb_LeftClick);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmb_RightClick);
            this.groupBox1.Location = new System.Drawing.Point(253, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(221, 263);
            this.groupBox1.TabIndex = 54;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Commands";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 223);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 13);
            this.label8.TabIndex = 66;
            this.label8.Text = "Arrow Right";
            // 
            // cmb_ArrowRight
            // 
            this.cmb_ArrowRight.FormattingEnabled = true;
            this.cmb_ArrowRight.Location = new System.Drawing.Point(70, 220);
            this.cmb_ArrowRight.Name = "cmb_ArrowRight";
            this.cmb_ArrowRight.Size = new System.Drawing.Size(140, 21);
            this.cmb_ArrowRight.TabIndex = 67;
            this.cmb_ArrowRight.SelectedIndexChanged += new System.EventHandler(this.cmb_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 196);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 13);
            this.label7.TabIndex = 64;
            this.label7.Text = "Arrow Left";
            // 
            // cmb_ArrowLeft
            // 
            this.cmb_ArrowLeft.FormattingEnabled = true;
            this.cmb_ArrowLeft.Location = new System.Drawing.Point(70, 193);
            this.cmb_ArrowLeft.Name = "cmb_ArrowLeft";
            this.cmb_ArrowLeft.Size = new System.Drawing.Size(140, 21);
            this.cmb_ArrowLeft.TabIndex = 65;
            this.cmb_ArrowLeft.SelectedIndexChanged += new System.EventHandler(this.cmb_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 169);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 13);
            this.label6.TabIndex = 62;
            this.label6.Text = "Arrow Down";
            // 
            // cmb_ArrowDown
            // 
            this.cmb_ArrowDown.FormattingEnabled = true;
            this.cmb_ArrowDown.Location = new System.Drawing.Point(70, 166);
            this.cmb_ArrowDown.Name = "cmb_ArrowDown";
            this.cmb_ArrowDown.Size = new System.Drawing.Size(140, 21);
            this.cmb_ArrowDown.TabIndex = 63;
            this.cmb_ArrowDown.SelectedIndexChanged += new System.EventHandler(this.cmb_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 142);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 60;
            this.label5.Text = "Arrow Up";
            // 
            // cmb_ArrowUp
            // 
            this.cmb_ArrowUp.FormattingEnabled = true;
            this.cmb_ArrowUp.Location = new System.Drawing.Point(70, 139);
            this.cmb_ArrowUp.Name = "cmb_ArrowUp";
            this.cmb_ArrowUp.Size = new System.Drawing.Size(140, 21);
            this.cmb_ArrowUp.TabIndex = 61;
            this.cmb_ArrowUp.SelectedIndexChanged += new System.EventHandler(this.cmb_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 58;
            this.label4.Text = "Space";
            // 
            // cmb_Space
            // 
            this.cmb_Space.FormattingEnabled = true;
            this.cmb_Space.Location = new System.Drawing.Point(70, 112);
            this.cmb_Space.Name = "cmb_Space";
            this.cmb_Space.Size = new System.Drawing.Size(140, 21);
            this.cmb_Space.TabIndex = 59;
            this.cmb_Space.SelectedIndexChanged += new System.EventHandler(this.cmb_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 56;
            this.label3.Text = "Enter";
            // 
            // cmb_Enter
            // 
            this.cmb_Enter.FormattingEnabled = true;
            this.cmb_Enter.Location = new System.Drawing.Point(70, 85);
            this.cmb_Enter.Name = "cmb_Enter";
            this.cmb_Enter.Size = new System.Drawing.Size(140, 21);
            this.cmb_Enter.TabIndex = 57;
            this.cmb_Enter.SelectedIndexChanged += new System.EventHandler(this.cmb_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 54;
            this.label2.Text = "Left Click";
            // 
            // cmb_LeftClick
            // 
            this.cmb_LeftClick.FormattingEnabled = true;
            this.cmb_LeftClick.Location = new System.Drawing.Point(70, 58);
            this.cmb_LeftClick.Name = "cmb_LeftClick";
            this.cmb_LeftClick.Size = new System.Drawing.Size(140, 21);
            this.cmb_LeftClick.TabIndex = 55;
            this.cmb_LeftClick.SelectedIndexChanged += new System.EventHandler(this.cmb_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Right Click";
            // 
            // checkBox_showGaze
            // 
            this.checkBox_showGaze.AutoSize = true;
            this.checkBox_showGaze.Checked = true;
            this.checkBox_showGaze.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_showGaze.Location = new System.Drawing.Point(22, 222);
            this.checkBox_showGaze.Name = "checkBox_showGaze";
            this.checkBox_showGaze.Size = new System.Drawing.Size(85, 17);
            this.checkBox_showGaze.TabIndex = 55;
            this.checkBox_showGaze.Text = "Show gaze  ";
            this.checkBox_showGaze.UseVisualStyleBackColor = true;
            this.checkBox_showGaze.CheckedChanged += new System.EventHandler(this.checkBox_showGaze_CheckedChanged);
            // 
            // Form_monitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(479, 274);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.checkBox_showGaze);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.txtMsgToSend);
            this.Controls.Add(this.checkBox3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.checkBox1);
            this.Name = "Form_monitor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Haytham_Monitor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_monitor_FormClosing);
            this.Load += new System.EventHandler(this.Form_monitor_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtMsgToSend;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ComboBox cmb_RightClick;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmb_ArrowRight;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmb_ArrowLeft;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmb_ArrowDown;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmb_ArrowUp;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmb_Space;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmb_Enter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmb_LeftClick;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBox_showGaze;
    }
}