//##########################################################################
//★★★★★★★           http://www.cnpopsoft.com           ★★★★★★★
//★★          VB & C# source code and articles for free !!!           ★★
//★★★★★★★                Davidwu                       ★★★★★★★
//##########################################################################

namespace Haytham
{
    partial class AnimatedCursor
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // AnimatedCursor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(211, 122);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AnimatedCursor";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "animatedCursor";
            this.ResumeLayout(false);

        }

        #endregion
    }
}