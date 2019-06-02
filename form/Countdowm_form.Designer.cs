namespace Color_yr.Countdown
{
    partial class Countdown
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Countdown));
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.label1 = new LayeredSkin.Controls.LayeredLabel();
            this.label2 = new LayeredSkin.Controls.LayeredLabel();
            this.label3 = new LayeredSkin.Controls.LayeredLabel();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = Properties.Resources.Color_yr;
            this.notifyIcon1.Text = "Countdown";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.label1.Borders.BottomColor = System.Drawing.Color.Empty;
            this.label1.Borders.BottomWidth = 1;
            this.label1.Borders.LeftColor = System.Drawing.Color.Empty;
            this.label1.Borders.LeftWidth = 1;
            this.label1.Borders.RightColor = System.Drawing.Color.Empty;
            this.label1.Borders.RightWidth = 1;
            this.label1.Borders.TopColor = System.Drawing.Color.Empty;
            this.label1.Borders.TopWidth = 1;
            this.label1.Canvas = ((System.Drawing.Bitmap)(resources.GetObject("label1.Canvas")));
            this.label1.Font = new System.Drawing.Font("宋体", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.HaloSize = 5;
            this.label1.Location = new System.Drawing.Point(28, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(489, 65);
            this.label1.TabIndex = 0;
            this.label1.Text = "距离高考还有：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.label2.Borders.BottomColor = System.Drawing.Color.Empty;
            this.label2.Borders.BottomWidth = 1;
            this.label2.Borders.LeftColor = System.Drawing.Color.Empty;
            this.label2.Borders.LeftWidth = 1;
            this.label2.Borders.RightColor = System.Drawing.Color.Empty;
            this.label2.Borders.RightWidth = 1;
            this.label2.Borders.TopColor = System.Drawing.Color.Empty;
            this.label2.Borders.TopWidth = 1;
            this.label2.Canvas = ((System.Drawing.Bitmap)(resources.GetObject("label2.Canvas")));
            this.label2.Font = new System.Drawing.Font("宋体", 199.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.HaloSize = 5;
            this.label2.Location = new System.Drawing.Point(-33, 56);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(523, 268);
            this.label2.TabIndex = 1;
            this.label2.Text = "000";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.label3.Borders.BottomColor = System.Drawing.Color.Empty;
            this.label3.Borders.BottomWidth = 1;
            this.label3.Borders.LeftColor = System.Drawing.Color.Empty;
            this.label3.Borders.LeftWidth = 1;
            this.label3.Borders.RightColor = System.Drawing.Color.Empty;
            this.label3.Borders.RightWidth = 1;
            this.label3.Borders.TopColor = System.Drawing.Color.Empty;
            this.label3.Borders.TopWidth = 1;
            this.label3.Canvas = ((System.Drawing.Bitmap)(resources.GetObject("label3.Canvas")));
            this.label3.Font = new System.Drawing.Font("宋体", 49.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.HaloSize = 5;
            this.label3.Location = new System.Drawing.Point(414, 284);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 68);
            this.label3.TabIndex = 2;
            this.label3.Text = "天";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // Countdown
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Transparent;
            this.ClientSize = new System.Drawing.Size(501, 360);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.DrawIcon = false;
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Countdown";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "";
            this.Load += new System.EventHandler(this.mian_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private LayeredSkin.Controls.LayeredLabel label1;
        private LayeredSkin.Controls.LayeredLabel label3;
        private LayeredSkin.Controls.LayeredLabel label2;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Timer timer1;
    }
}

