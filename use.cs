using System;
using System.Drawing;
using System.Windows.Forms;

namespace Color_yr.Countdown
{
    class use
    {
        public void CloseWindow(int mode)
        {
            System.Diagnostics.Process bootProcess = new System.Diagnostics.Process();
            bootProcess.StartInfo.FileName = "shutdown";
            if (mode == 0)
            {
                bootProcess.StartInfo.Arguments = "-s";
                bootProcess.Start();
            }
            else if (mode == 1)
            {
                Application.SetSuspendState(PowerState.Hibernate, false, false);
            }
            else if (mode == 2)
            { 
                Application.SetSuspendState(PowerState.Suspend, false, false);
            }
            
            bootProcess.Start();
        }

        public bool isok(KeyPressEventArgs e)
        {
            if (e.KeyChar == '\b')//这是允许输入退格键
                return true;
            else if ((e.KeyChar < '0') || (e.KeyChar > '9'))//这是允许输入0-9数字
            {
                return false;
            }
            return true;
        }

        //获得控件的长度、宽度、位置、字体大小的数据
        public static void setTag(Control cons)//Control类，定义控件的基类
        {
            foreach (Control con in cons.Controls)
            {
                con.Tag = con.Width + ":" + con.Height + ":" + con.Left + ":" + con.Top + ":" + con.Font.Size;//获取或设置包含有关控件的数据的对象
                if (con.Controls.Count > 0)
                    setTag(con);//递归算法
            }
        }

        public static void setControls(float newx, float newy, Control cons)//实现控件以及字体的缩放
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

        //月份为两位
        public int SetDate(string time)
        {
            int intYear;
            int intMonth;
            int intDay;
            string year = time.Substring(0, 4);
            string month = time.Substring(5, 2);
            int.TryParse(year, out intYear);
            int.TryParse(month, out intMonth);
            if (intMonth == 02)
            {
                if (intYear % 400 == 0 || (intYear % 4 == 0 && intYear % 100 != 0))//判断是不是闰年  
                {
                    intDay = 29;
                }
                else
                {
                    intDay = 28;
                }
            }
            switch (intMonth)
            {
                case 04:
                case 06:
                case 09:
                case 11: intDay = 30; break;
                default: intDay = 31; break;
            }
            return intDay;
        }

        public int form_local(string local)
        {
            switch (local)
            {
                case "左上角":
                    return 1;
                case "右上角":
                    return 2;
                case "左下角":
                    return 3;
                case "右下角":
                    return 4;
                default:
                    return 0;
            }
        }

        public int form_color(string color)
        {
            switch (color)
            {
                case "红色":
                    return 1;
                case "黄色":
                    return 2;
                case "蓝色":
                    return 3;
                case "绿色":
                    return 4;
                case "青色":
                    return 5;
                case "紫色":
                    return 6;
                case "黑色":
                    return 7;
                case "白色":
                    return 8;
                default:
                    return 0;
            }
        }

        public bool check_close_time(string time, int[] time1)
        {
            if (time.Length != 5)
                return false;
            int c = int.Parse(time.Substring(0, 2));
            int d = int.Parse(time.Substring(3, 2));
            if (c > 23 && d > 59)
                return false;
            else
            {
                time1[0] = c;
                time1[1] = d;
            }
            return true;
        }

        public Color form_color(int color)
        {
            switch (color)
            {
                case 1:
                    return Color.Red;
                case 2:
                    return Color.Yellow;
                case 3:
                    return Color.Blue;
                case 4:
                    return Color.Green;
                case 5:
                    return Color.Cyan;
                case 6:
                    return Color.Purple;
                case 7:
                    return Color.Black;
                case 8:
                    return Color.White;
                default:
                    return Color.Red;
            }
        }
    }
}
