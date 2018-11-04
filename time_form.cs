using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Threading;
using System.Drawing;

namespace Color_yr.Countdown
{
    public partial class time_form : Form
    {
        private float X_form, Y_form;
        private static int time_h, time_m;
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
                    var now_time = DateTime.Now;
                    time_h = now_time.Hour;
                    time_m = now_time.Minute;
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
                setTag(this);
                backgroundWorker1.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        //获得控件的长度、宽度、位置、字体大小的数据
        private void setTag(Control cons)//Control类，定义控件的基类
        {
            foreach (Control con in cons.Controls)
            {
                con.Tag = con.Width + ":" + con.Height + ":" + con.Left + ":" + con.Top + ":" + con.Font.Size;//获取或设置包含有关控件的数据的对象
                if (con.Controls.Count > 0)
                    setTag(con);//递归算法
            }
        }

        private void setControls(float newx, float newy, Control cons)//实现控件以及字体的缩放
        {
            foreach (Control con in cons.Controls)
            {
                string[] mytag = con.Tag.ToString().Split(new char[] { ':' });
                float a = Convert.ToSingle(mytag[0]) * newx;
                con.Width = (int)a;
                a = Convert.ToSingle(mytag[1]) * newy;
                con.Height = (int)(a);
                a = Convert.ToSingle(mytag[2]) * newx;
                con.Left = (int)(a);
                a = Convert.ToSingle(mytag[3]) * newy;
                con.Top = (int)(a);
                float currentSize = Convert.ToSingle(mytag[4]) * newy;
                con.Font = new Font(con.Font.Name, currentSize, con.Font.Style, con.Font.Unit);
                if (con.Controls.Count > 0)
                {
                    setControls(newx, newy, con);//递归
                }
            }
        }
        private void start()
        {
            Action<int> action = (data) =>
            {
                string h, m;
                if (WindowState == FormWindowState.Minimized || use.time_enable == true)      //如果窗口大小发生改变后变成最小化，则将窗口重新设置为正常大小
                {
                    Show();
                    WindowState = FormWindowState.Normal;
                }
                if (time_h < 10)
                    h = "0" + time_h.ToString();
                else
                    h = time_h.ToString();
                if (time_m < 10)
                    m = "0" + time_m.ToString();
                else
                    m = time_m.ToString();
                label1.Text = h + ":" + m;
                if (use.time_restart == true)
                { 
                    Width = use.time_Width;
                    Height = use.time_Height;
                    float newx = use.time_Width / X_form;//当前宽度与变化前宽度之比
                    float newy = use.time_Height / Y_form;//当前高度与变化前宽度之比
                    setControls(newx, newy, this);
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
