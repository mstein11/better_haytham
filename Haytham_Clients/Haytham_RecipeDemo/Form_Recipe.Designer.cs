namespace Haytham_Client
{
    partial class Form_Recipe
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
            this.panel_Image = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.panel_Volume = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel_Music = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_Next = new System.Windows.Forms.Button();
            this.btn_Previous = new System.Windows.Forms.Button();
            this.radioButton_Play = new System.Windows.Forms.RadioButton();
            this.radioButton_Stop = new System.Windows.Forms.RadioButton();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.timerMakeFlashReady = new System.Windows.Forms.Timer(this.components);
            this.progressBar1 = new VerticalProgressBar();
            this.panel_Image.SuspendLayout();
            this.panel_Volume.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel_Music.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_Image
            // 
            this.panel_Image.BackColor = System.Drawing.Color.SkyBlue;
            this.panel_Image.Controls.Add(this.label3);
            this.panel_Image.Controls.Add(this.webBrowser1);
            this.panel_Image.Location = new System.Drawing.Point(24, 81);
            this.panel_Image.Name = "panel_Image";
            this.panel_Image.Size = new System.Drawing.Size(230, 318);
            this.panel_Image.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(95, 230);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 62);
            this.label3.TabIndex = 5;
            this.label3.Text = "x";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label3.Visible = false;
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(15, 22);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.ScrollBarsEnabled = false;
            this.webBrowser1.Size = new System.Drawing.Size(192, 270);
            this.webBrowser1.TabIndex = 1;
            this.webBrowser1.Url = new System.Uri("", System.UriKind.Relative);
            this.webBrowser1.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser1_DocumentCompleted);
            this.webBrowser1.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.webBrowser1_PreviewKeyDown);
            // 
            // panel_Volume
            // 
            this.panel_Volume.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_Volume.Controls.Add(this.progressBar1);
            this.panel_Volume.Controls.Add(this.pictureBox1);
            this.panel_Volume.Controls.Add(this.label1);
            this.panel_Volume.Enabled = false;
            this.panel_Volume.Location = new System.Drawing.Point(293, 71);
            this.panel_Volume.Margin = new System.Windows.Forms.Padding(2);
            this.panel_Volume.Name = "panel_Volume";
            this.panel_Volume.Size = new System.Drawing.Size(214, 353);
            this.panel_Volume.TabIndex = 6;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Haytham_Client.Properties.Resources.VolumeOff;
            this.pictureBox1.Location = new System.Drawing.Point(135, 134);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(66, 62);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(141, 172);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 62);
            this.label1.TabIndex = 4;
            this.label1.Text = "x";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel_Music
            // 
            this.panel_Music.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_Music.Controls.Add(this.label2);
            this.panel_Music.Controls.Add(this.btn_Next);
            this.panel_Music.Controls.Add(this.btn_Previous);
            this.panel_Music.Controls.Add(this.radioButton_Play);
            this.panel_Music.Controls.Add(this.radioButton_Stop);
            this.panel_Music.Enabled = false;
            this.panel_Music.Location = new System.Drawing.Point(629, 131);
            this.panel_Music.Margin = new System.Windows.Forms.Padding(2);
            this.panel_Music.Name = "panel_Music";
            this.panel_Music.Size = new System.Drawing.Size(280, 268);
            this.panel_Music.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(92, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 112);
            this.label2.TabIndex = 4;
            this.label2.Text = "x";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_Next
            // 
            this.btn_Next.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_Next.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Next.Location = new System.Drawing.Point(186, 77);
            this.btn_Next.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Next.Name = "btn_Next";
            this.btn_Next.Size = new System.Drawing.Size(92, 112);
            this.btn_Next.TabIndex = 0;
            this.btn_Next.Text = "Next";
            this.btn_Next.UseVisualStyleBackColor = true;
            this.btn_Next.Click += new System.EventHandler(this.btn_Next_Click);
            // 
            // btn_Previous
            // 
            this.btn_Previous.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn_Previous.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Previous.Location = new System.Drawing.Point(0, 77);
            this.btn_Previous.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Previous.Name = "btn_Previous";
            this.btn_Previous.Size = new System.Drawing.Size(92, 112);
            this.btn_Previous.TabIndex = 3;
            this.btn_Previous.Text = "Previous";
            this.btn_Previous.UseVisualStyleBackColor = true;
            this.btn_Previous.Click += new System.EventHandler(this.btn_Previous_Click);
            // 
            // radioButton_Play
            // 
            this.radioButton_Play.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButton_Play.Checked = true;
            this.radioButton_Play.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.radioButton_Play.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton_Play.Location = new System.Drawing.Point(0, 189);
            this.radioButton_Play.Margin = new System.Windows.Forms.Padding(2);
            this.radioButton_Play.Name = "radioButton_Play";
            this.radioButton_Play.Size = new System.Drawing.Size(278, 77);
            this.radioButton_Play.TabIndex = 2;
            this.radioButton_Play.TabStop = true;
            this.radioButton_Play.Text = "Play";
            this.radioButton_Play.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioButton_Play.UseVisualStyleBackColor = true;
            this.radioButton_Play.CheckedChanged += new System.EventHandler(this.radioButton_Play_CheckedChanged);
            // 
            // radioButton_Stop
            // 
            this.radioButton_Stop.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButton_Stop.Dock = System.Windows.Forms.DockStyle.Top;
            this.radioButton_Stop.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton_Stop.Location = new System.Drawing.Point(0, 0);
            this.radioButton_Stop.Margin = new System.Windows.Forms.Padding(2);
            this.radioButton_Stop.Name = "radioButton_Stop";
            this.radioButton_Stop.Size = new System.Drawing.Size(278, 77);
            this.radioButton_Stop.TabIndex = 1;
            this.radioButton_Stop.Text = "Stop";
            this.radioButton_Stop.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioButton_Stop.UseVisualStyleBackColor = true;
            this.radioButton_Stop.CheckedChanged += new System.EventHandler(this.radioButton_Stop_CheckedChanged);
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // timerMakeFlashReady
            // 
            this.timerMakeFlashReady.Interval = 5000;
            this.timerMakeFlashReady.Tick += new System.EventHandler(this.timerMakeFlashReady_Tick);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(146, 31);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(2);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(46, 284);
            this.progressBar1.TabIndex = 5;
            this.progressBar1.Value = 50;
            // 
            // Form_Recipe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1122, 690);
            this.Controls.Add(this.panel_Music);
            this.Controls.Add(this.panel_Volume);
            this.Controls.Add(this.panel_Image);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form_Recipe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form_Recipe";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Recipe_FormClosing);
            this.Load += new System.EventHandler(this.Form_Recipe_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_Recipe_KeyDown);
            this.panel_Image.ResumeLayout(false);
            this.panel_Volume.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel_Music.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_Image;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Panel panel_Volume;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private VerticalProgressBar progressBar1;
        private System.Windows.Forms.Panel panel_Music;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_Next;
        private System.Windows.Forms.Button btn_Previous;
        private System.Windows.Forms.RadioButton radioButton_Play;
        private System.Windows.Forms.RadioButton radioButton_Stop;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Timer timerMakeFlashReady;
    }
}