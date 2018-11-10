﻿using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Threading;
using LayeredSkin.Forms;

namespace Color_yr.Countdown
{
    public partial class time_form : LayeredForm
    {
        private float X_form, Y_form;
        public time_form()
        {
            InitializeComponent();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                try
                {                    
                    start();
                    Thread.Sleep(1000);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
        private void time_form_Load(object sender, EventArgs e)
        {
            try
            {
                Width = 300;
                X_form = Width;
                Y_form = Height;
                use.setTag(this);
                backgroundWorker1.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void start()
        {
            Action<int> action = (data) =>
            {
                var now_time = DateTime.Now;
                string h, m, d, mo;
                if (WindowState == FormWindowState.Minimized || use.time_enable == true)      //如果窗口大小发生改变后变成最小化，则将窗口重新设置为正常大小
                {
                    Show();
                    WindowState = FormWindowState.Normal;
                }
                if (now_time.Hour < 10)
                    h = " " + now_time.Hour.ToString();
                else
                    h = now_time.Hour.ToString();
                if (now_time.Minute < 10)
                    m = "0" + now_time.Minute.ToString();
                else
                    m = now_time.Minute.ToString();
                if (now_time.Day < 10)
                    d = "0" + now_time.Day.ToString();
                else
                    d = now_time.Day.ToString();
                if (now_time.Month < 10)
                    mo = " " + now_time.Month.ToString();
                else
                    mo = now_time.Month.ToString();
                label1.Text = h + ":" + m;
                label2.Text = mo + "月" + d + "日";
                if (use.time_restart == true)
                { 
                    Width = use.time_Width;
                    Height = use.time_Height;
                    float newx = use.time_Width / X_form;//当前宽度与变化前宽度之比
                    float newy = use.time_Height / Y_form;//当前高度与变化前宽度之比
                    use.setControls(newx, newy, this);
                    switch (use.time_local)
                    {
                        case 1:
                            Left = 0;
                            Top = 0;
                            break;
                        case 2:
                            Left = Screen.PrimaryScreen.WorkingArea.Width - Width;
                            Top = 0;
                            break;
                        case 3:
                            Left = 0;
                            Top = Screen.PrimaryScreen.WorkingArea.Height - Height;
                            break;
                        case 4:
                            Left = Screen.PrimaryScreen.WorkingArea.Width - Width;
                            Top = Screen.PrimaryScreen.WorkingArea.Height - Height;
                            break;
                    }
                    if (use.time_enable == true)
                    {
                        Hide();
                        Show();
                    }
                    else
                    {
                        Hide();
                    }
                    use.time_restart = false;
                }
            };
            Invoke(action, 0);
        }
    }
}
