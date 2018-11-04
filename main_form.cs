using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

namespace Color_yr.Countdown
{
    public partial class mian : Form
    {
        private Form setting = new setting_form();
        public static Form time = new time_form();
        private float X_form, Y_form;
        public mian()
        {
            InitializeComponent();
        }

        private void mian_Load(object sender, EventArgs e)
        {
            try
            {
                notifyIcon1.Visible = true; //使托盘图标可见           
                use.start();
                X_form = Width;
                Y_form = Height;
                setTag(this);
                time = new time_form();
                time.Width = use.time_Width;
                time.Height = use.time_Height;
                time.Show();
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
                if (use.restart == true)
                {                                      
                    Width = use.Width;
                    Height = use.Height;
                    float newx = Width / X_form;//当前宽度与变化前宽度之比
                    float newy = Height / Y_form;//当前高度与变化前宽度之比
                    label2.Text = delta.Days.ToString();
                    setControls(newx, newy, this);
                    switch (use.local)
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
                    Hide();
                    Show();
                    use.restart = false;
                }
            };
            Invoke(action, 0);
        }
    }
}
