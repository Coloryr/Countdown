using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Threading;
using LayeredSkin.Forms;
using System.Drawing;

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
                if (WindowState == FormWindowState.Minimized || config.time_enable == true)      //如果窗口大小发生改变后变成最小化，则将窗口重新设置为正常大小
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
                if (config.time_restart == true)
                {
                    use use = new use();
                    float newx = config.time_form_Width / X_form;//当前宽度与变化前宽度之比
                    float newy = config.time_form_Height / Y_form;//当前高度与变化前宽度之比
                    Width = config.time_form_Width;
                    Height = config.time_form_Height;
                    use.setControls(newx, newy, this);
                    switch (config.time_form_local)
                    {
                        case 1:
                            Left = 0;
                            Top = 0;
                            break;
                        case 2:
                            Left = Screen.PrimaryScreen.WorkingArea.Width - config.time_form_Width;
                            Top = 0;
                            break;
                        case 3:
                            Left = 0;
                            Top = Screen.PrimaryScreen.WorkingArea.Height - config.time_form_Height;
                            break;
                        case 4:
                            Left = Screen.PrimaryScreen.WorkingArea.Width - config.time_form_Width;
                            Top = Screen.PrimaryScreen.WorkingArea.Height - config.time_form_Height;
                            break;
                    }
                    if (config.time_enable == true)
                    {
                        Hide();
                        Show();
                    }
                    else
                        Hide();
                    label1.ForeColor = use.form_color(config.time_form_time_color);
                    
                    label2.ForeColor = use.form_color(config.time_form_date_color);
                    config.time_restart = false;
                }
            };
            Invoke(action, 0);
        }
    }
}
