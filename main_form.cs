using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Color_yr.Countdown
{
    public partial class mian : Form
    {
        public mian()
        {
            InitializeComponent();

        }
        [DllImport("user32.dll", EntryPoint = "SetParent")]
        public static extern int SetParent(int hWndChild, int hWndNewParent);
        [DllImport("user32.dll", EntryPoint = "FindWindow")]
        public static extern int FindWindow(string lpClassName, string lpWindowName);

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {            
            var target = new DateTime(year, month, day);
            var now = DateTime.Now;
            if (target < now)
            {
                MessageBox.Show("时间错误，请重新设置");
                return;
            }
            var delta = target - now;

            Action<int> action = (data) =>
            {
                label2.Text = delta.Days.ToString();
            };
            Invoke(action, 0);
        }

        private void mian_Load(object sender, EventArgs e)
        {
            notifyIcon1.Visible = true; //使托盘图标可见           
            backgroundWorker1.RunWorkerAsync();
            Left = Screen.PrimaryScreen.WorkingArea.Width - this.Width;
            Top = 0;
            X = Width;
            Y = Height;
            setTag(this);
            sethight();
            SetParent(this.Handle.ToInt32(), FindWindow("Progman", "Program Manager"));
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            Form setting = new setting_form();
            setting.Show();
        }

        private float X, Y;
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
                Single currentSize = Convert.ToSingle(mytag[4]) * newy;
                con.Font = new Font(con.Font.Name, currentSize, con.Font.Style, con.Font.Unit);
                if (con.Controls.Count > 0)
                {
                    setControls(newx, newy, con);//递归
                }
            }
        }

        public void sethight()
        {
            int newxpos, newtpos;
            int.TryParse(XML.read(XML.config, "设置长"), out newxpos);
            int.TryParse(XML.read(XML.config, "设置高"), out newtpos);
            Width = newxpos;
            Height = newtpos;
            float newx = Width / X;//当前宽度与变化前宽度之比
            float newy = Height / Y;//当前高度与变化前宽度之比
            setControls(newx, newy, this);
            Left = Screen.PrimaryScreen.WorkingArea.Width - this.Width;
            Top = 0;
        }
    }
}
