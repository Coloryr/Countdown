using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using LayeredSkin.Forms;
using System.Runtime.InteropServices;

namespace Color_yr.Countdown
{
    public partial class Countdown : LayeredForm
    {
        private Form setting = new setting_form();
        private Form close = new close_form();

        private float X_form, Y_form;

        public Countdown()
        {
            InitializeComponent();
        }

        private void mian_Load(object sender, EventArgs e)
        {
            try
            {
                use use = new use();
                notifyIcon1.Visible = true;
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

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            if (setting.Visible == true)
                return;
            else
            {
                setting = new setting_form();
                setting.Show();
            }
        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
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

        public void openClose()
        {
            MethodInvoker MethInvk = new MethodInvoker(Showclose);
            BeginInvoke(MethInvk);
        }

        private static void Showclose()
        {
            close_form close = new close_form();
            close.TopMost = true;           
            close.SetBounds((Screen.GetBounds(close).Width / 2) - (close.Width / 2),
                (Screen.GetBounds(close).Height / 2) - (close.Height / 2),
                close.Width, close.Height, BoundsSpecified.Location);
            close.Show();
        }

        public void start()
        {
            var set_time = new DateTime(config.countdown_form_year, config.countdown_form_month, config.countdown_form_day, 0, 0, 0);
            var now = DateTime.Now;
            var now_time = new DateTime(now.Year, now.Month, now.Day, 0, 0, 0);
            if (set_time < now_time)
            {
                MessageBox.Show("时间错误，请重新设置");
                XML XML = new XML();
                XML.write(XML.config, "时间设置", "自定义时间", "关");
                config.is_user = false;
            }
            var delta = set_time - now_time;

            if (config.close_enable == true && config.is_close == true && now.Second < 2)
            {
                int hour, min;
                hour = now.Hour;
                min = now.Minute;
                if (config.close1[0] == hour && config.close1[1] == min)
                    openClose();
                if (config.close2[0] == hour && config.close2[1] == min)
                    openClose();
                if (config.close3[0] == hour && config.close3[1] == min)
                    openClose();
            }

            Action<int> action = (data) =>
            {
                if (WindowState == FormWindowState.Minimized)      //如果窗口大小发生改变后变成最小化，则将窗口重新设置为正常大小
                {
                    Show();
                    WindowState = FormWindowState.Normal;
                }
                if (delta.Days < 10)
                    label2.Text = "  " + delta.Days.ToString();
                else if (delta.Days < 100)
                    label2.Text = " " + delta.Days.ToString();
                else
                    label2.Text = delta.Days.ToString();
                if (config.restart == true)
                {
                    use use = new use();
                    float newx = config.countdown_form_Width / X_form;//当前宽度与变化前宽度之比
                    float newy = config.countdown_form_Height / Y_form;//当前高度与变化前宽度之比
                    Width = config.countdown_form_Width;
                    Height = config.countdown_form_Height;
                    use.setControls(newx, newy, this);
                    switch (config.countdown_form_local)
                    {
                        case 1:
                            Left = 0;
                            Top = 0;
                            break;
                        case 2:
                            Left = Screen.PrimaryScreen.WorkingArea.Width - config.countdown_form_Width;
                            Top = 0;
                            break;
                        case 3:
                            Left = 0;
                            Top = Screen.PrimaryScreen.WorkingArea.Height - config.countdown_form_Height;
                            break;
                        case 4:
                            Left = Screen.PrimaryScreen.WorkingArea.Width - config.countdown_form_Width;
                            Top = Screen.PrimaryScreen.WorkingArea.Height - config.countdown_form_Height;
                            break;
                    }
                    Hide();
                    Show();
                    if (config.is_user == true)
                        label1.Text = config.user_string;
                    else
                        label1.Text = "距离高考还有：";
                    
                    label2.ForeColor = use.form_color(config.countdown_form_color);
                    label1.ForeColor = label3.ForeColor = use.form_color(config.countdown_form_string_color);
                    config.restart = false;
                }
            };
            Invoke(action, 0);
        }
    }
}
