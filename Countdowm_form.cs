using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using LayeredSkin.Forms;

namespace Color_yr.Countdown
{
    public partial class Countdown : LayeredForm
    {
        private Form setting = new setting_form();
        private float X_form, Y_form;

        public Countdown()
        {
            InitializeComponent();
        }

        private void mian_Load(object sender, EventArgs e)
        {
            try
            {
                use.start();
                notifyIcon1.Visible = true;
                X_form = Width;
                Y_form = Height;
                use.setTag(this);
                use.time_form = new time_form();
                use.time_form.Show();
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
                    GC.Collect();
                    Thread.Sleep(1000);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        public void start()
        {
            var set_time = new DateTime(use.year, use.month, use.day, 0, 0, 0);
            var now = DateTime.Now;
            var now_time = new DateTime(now.Year, now.Month, now.Day, 0, 0, 0);
            if (set_time < now_time)
            {
                MessageBox.Show("时间错误，请重新设置");
                return;
            }
            var delta = set_time - now_time;

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
                if (use.restart == true)
                {
                    float newx = use.Width / X_form;//当前宽度与变化前宽度之比
                    float newy = use.Height / Y_form;//当前高度与变化前宽度之比
                    Width = use.Width;
                    Height = use.Height;

                    use.setControls(newx, newy, this);
                    switch (use.local)
                    {
                        case 1:
                            Left = 0;
                            Top = 0;
                            break;
                        case 2:
                            Left = Screen.PrimaryScreen.WorkingArea.Width - use.Width;
                            Top = 0;
                            break;
                        case 3:
                            Left = 0;
                            Top = Screen.PrimaryScreen.WorkingArea.Height - use.Height;
                            break;
                        case 4:
                            Left = Screen.PrimaryScreen.WorkingArea.Width - use.Width;
                            Top = Screen.PrimaryScreen.WorkingArea.Height - use.Height;
                            break;
                    }
                    Hide();
                    Show();
                    if (use.is_user == true)
                        label1.Text = use.user_string;
                    else
                        label1.Text = "距离高考还有：";
                    switch (use.set_color)
                    {
                        case 1:
                            label2.ForeColor = Color.Red;
                            break;
                        case 2:
                            label2.ForeColor = Color.Yellow;
                            break;
                        case 3:
                            label2.ForeColor = Color.Blue;
                            break;
                        case 4:
                            label2.ForeColor = Color.Green;
                            break;
                        case 5:
                            label2.ForeColor = Color.Cyan;
                            break;
                        case 6:
                            label2.ForeColor = Color.Purple;
                            break;
                        case 7:
                            label2.ForeColor = Color.Black;
                            break;
                        case 8:
                            label2.ForeColor = Color.White;
                            break;
                    }
                    use.restart = false;
                }
            };
            Invoke(action, 0);
        }
    }
}
