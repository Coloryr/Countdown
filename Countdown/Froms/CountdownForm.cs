using LayeredSkin.Forms;
using System;
using System.ComponentModel;
using System.Threading;
using System.Windows.Forms;

namespace Coloryr.Countdown.Froms
{
    public partial class CountdownFrom : LayeredForm
    {
        private Form Setting = new SettingFrom();

        private float FormX, FormY;

        public CountdownFrom()
        {
            InitializeComponent();
        }

        private void From_Load(object sender, EventArgs e)
        {
            try
            {
                notifyIcon1.Visible = true;
                FormX = Width;
                FormY = Height;
                Utils.SetTag(this);
                backgroundWorker1.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            if (Setting.Visible == true)
                return;
            else
            {
                Setting = new SettingFrom();
                Setting.Show();
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                try
                {
                    var set_time = new DateTime(Program.Config.Countdown.Year, Program.Config.Countdown.Month, Program.Config.Countdown.Day, 0, 0, 0);
                    var now = DateTime.Now;
                    var now_time = new DateTime(now.Year, now.Month, now.Day, 0, 0, 0);
                    if (set_time < now_time)
                    {
                        MessageBox.Show("时间错误，请重新设置");
                    }

                    var delta = set_time - now_time;

                    if (Program.Config.Close.Enable == true && now.Second < 2)
                    {
                        int hour, min;
                        hour = now.Hour;
                        min = now.Minute;
                        if (Program.Config.Close.Close1.Hour == hour && Program.Config.Close.Close1.Minute == min)
                            OpenClose();
                        if (Program.Config.Close.Close2.Hour == hour && Program.Config.Close.Close2.Minute == min)
                            OpenClose();
                        if (Program.Config.Close.Close3.Hour == hour && Program.Config.Close.Close3.Minute == min)
                            OpenClose();
                    }

                    Invoke(new Action(() =>
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
                        if (Program.CountdownRestart == true)
                        {
                            float newx = Program.Config.Countdown.Width / FormX;//当前宽度与变化前宽度之比
                            float newy = Program.Config.Countdown.Height / FormY;//当前高度与变化前宽度之比
                            Width = Program.Config.Countdown.Width;
                            Height = Program.Config.Countdown.Height;
                            Utils.SetControls(newx, newy, this);
                            switch (Program.Config.Countdown.Local)
                            {
                                case MyLocal.左上角:
                                    Left = 0;
                                    Top = 0;
                                    break;
                                case MyLocal.右上角:
                                    Left = Screen.PrimaryScreen.WorkingArea.Width - Program.Config.Countdown.Width;
                                    Top = 0;
                                    break;
                                case MyLocal.左下角:
                                    Left = 0;
                                    Top = Screen.PrimaryScreen.WorkingArea.Height - Program.Config.Countdown.Height;
                                    break;
                                case MyLocal.右下角:
                                    Left = Screen.PrimaryScreen.WorkingArea.Width - Program.Config.Countdown.Width;
                                    Top = Screen.PrimaryScreen.WorkingArea.Height - Program.Config.Countdown.Height;
                                    break;
                            }
                            Hide();
                            Show();
                            label1.Text = Program.Config.Countdown.SetText;

                            label2.ForeColor = Utils.FontColor(Program.Config.Countdown.Color);
                            label1.ForeColor = label3.ForeColor = Utils.FontColor(Program.Config.Countdown.StringColor);
                            Program.CountdownRestart = false;
                        }
                    }));
                    Thread.Sleep(1000);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        public void OpenClose()
        {
            MethodInvoker MethInvk = new MethodInvoker(Showclose);
            BeginInvoke(MethInvk);
        }

        private static void Showclose()
        {
            CloseFrom close = new CloseFrom
            {
                TopMost = true
            };
            close.SetBounds((Screen.GetBounds(close).Width / 2) - (close.Width / 2),
                (Screen.GetBounds(close).Height / 2) - (close.Height / 2),
                close.Width, close.Height, BoundsSpecified.Location);
            close.Show();
        }
    }
}
