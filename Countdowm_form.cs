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

        System.Reflection.Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            string dllName = args.Name.Contains(",") ? args.Name.Substring(0, args.Name.IndexOf(',')) : args.Name.Replace(".dll", "");
            dllName = dllName.Replace(".", "_");
            if (dllName.EndsWith("_resources")) return null;
            System.Resources.ResourceManager rm = new System.Resources.ResourceManager(GetType().Namespace + ".Properties.Resources", System.Reflection.Assembly.GetExecutingAssembly());
            byte[] bytes = (byte[])rm.GetObject(dllName);
            return System.Reflection.Assembly.Load(bytes);
        }

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
                //label1.BackColor = Color.Transparent;
                //Opacity = 0.1;

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
                if (use.restart == true)
                {                                      
                    Width = use.Width;
                    Height = use.Height;
                    float newx = Width / X_form;//当前宽度与变化前宽度之比
                    float newy = Height / Y_form;//当前高度与变化前宽度之比
                    if(delta.Days<10)
                        label2.Text = "  "+delta.Days.ToString();
                    else if(delta.Days < 100)
                        label2.Text = " " + delta.Days.ToString();
                    use.setControls(newx, newy, this);
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
                    if (use.is_user == true)
                        label1.Text = "距离考试还有：";
                    else
                        label1.Text = "距离高考还有：";
                    use.restart = false;
                }
            };
            Invoke(action, 0);
        }
    }
}
