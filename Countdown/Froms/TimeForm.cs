using LayeredSkin.Forms;
using System;
using System.ComponentModel;
using System.Threading;
using System.Windows.Forms;

namespace Coloryr.Countdown.Froms
{
    public partial class TimeForm : LayeredForm
    {
        private float FormX, FromY;
        public TimeForm()
        {
            InitializeComponent();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                try
                {
                    Invoke(new Action(() =>
                    {
                        var now_time = DateTime.Now;
                        string h, m, d, mo;
                        if (WindowState == FormWindowState.Minimized || Program.Config.Time.Enable)      //如果窗口大小发生改变后变成最小化，则将窗口重新设置为正常大小
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
                        if (Program.TimeRestart == true)
                        {
                            float newx = Program.Config.Time.Width / FormX;//当前宽度与变化前宽度之比
                            float newy = Program.Config.Time.Height / FromY;//当前高度与变化前宽度之比
                            Width = Program.Config.Time.Width;
                            Height = Program.Config.Time.Height;
                            Utils.SetControls(newx, newy, this);
                            switch (Program.Config.Time.Local)
                            {
                                case MyLocal.左上角:
                                    Left = 0;
                                    Top = 0;
                                    break;
                                case MyLocal.右上角:
                                    Left = Screen.PrimaryScreen.WorkingArea.Width - Program.Config.Time.Width;
                                    Top = 0;
                                    break;
                                case MyLocal.左下角:
                                    Left = 0;
                                    Top = Screen.PrimaryScreen.WorkingArea.Height - Program.Config.Time.Height;
                                    break;
                                case MyLocal.右下角:
                                    Left = Screen.PrimaryScreen.WorkingArea.Width - Program.Config.Time.Width;
                                    Top = Screen.PrimaryScreen.WorkingArea.Height - Program.Config.Time.Height;
                                    break;
                            }
                            if (Program.Config.Time.Enable)
                            {
                                Hide();
                                Show();
                            }
                            else
                                Hide();
                            label1.ForeColor = Utils.FontColor(Program.Config.Time.TimeColor);

                            label2.ForeColor = Utils.FontColor(Program.Config.Time.DateColor);
                            Program.TimeRestart = false;
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
        private void TimeForm_Load(object sender, EventArgs e)
        {
            try
            {
                FormX = Width;
                FromY = Height;
                Utils.SetTag(this);
                backgroundWorker1.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
