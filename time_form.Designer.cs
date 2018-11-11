namespace Color_yr.Countdown
{
    partial class time_form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(time_form));
            this.label1 = new LayeredSkin.Controls.LayeredLabel();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.label2 = new LayeredSkin.Controls.LayeredLabel();
            this.SuspendLayout();
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
            this.label1.Font = new System.Drawing.Font("宋体", 180F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.HaloSize = 5;
            this.label1.Location = new System.Drawing.Point(0, -30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(886, 301);
            this.label1.TabIndex = 0;
            this.label1.Text = "00:00";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
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
            this.label2.Font = new System.Drawing.Font("宋体", 80.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label2.HaloSize = 5;
            this.label2.Location = new System.Drawing.Point(110, 186);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(599, 135);
            this.label2.TabIndex = 1;
            this.label2.Text = "00月00日";
            // 
            // time_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Transparent;
            this.ClientSize = new System.Drawing.Size(705, 300);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.DrawIcon = false;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "time_form";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "";
            this.Load += new System.EventHandler(this.time_form_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private LayeredSkin.Controls.LayeredLabel label1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private LayeredSkin.Controls.LayeredLabel label2;
    }
}