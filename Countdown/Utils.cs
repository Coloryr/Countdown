using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace Coloryr.Countdown
{
    class Utils
    {
        public static void CloseWindow()
        {
            switch (Program.Config.Close.CloseMode)
            {
                case MyMode.关机:
                    Process bootProcess = new Process();
                    bootProcess.StartInfo.FileName = "shutdown";
                    bootProcess.StartInfo.Arguments = "-s";
                    bootProcess.Start();
                    break;
                case MyMode.休眠:
                    Application.SetSuspendState(PowerState.Hibernate, false, false);
                    break;
                case MyMode.睡眠:
                    Application.SetSuspendState(PowerState.Suspend, false, false);
                    break;
            }
        }

        public static bool IsOk(KeyPressEventArgs e)
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
        public static void SetTag(Control cons)//Control类，定义控件的基类
        {
            foreach (Control con in cons.Controls)
            {
                con.Tag = con.Width + ":" + con.Height + ":" + con.Left + ":" + con.Top + ":" + con.Font.Size;//获取或设置包含有关控件的数据的对象
                if (con.Controls.Count > 0)
                    SetTag(con);//递归算法
            }
        }

        public static void SetControls(float newx, float newy, Control cons)//实现控件以及字体的缩放
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
                    SetControls(newx, newy, con);//递归
                }
            }
        }

        //月份为两位
        public static int SetDate(string time)
        {
            int intDay;
            string year = time.Substring(0, 4);
            string month = time.Substring(5, 2);
            int.TryParse(year, out int intYear);
            int.TryParse(month, out int intMonth);
            switch (intMonth)
            {
                case 02:
                    if (intYear % 400 == 0 || (intYear % 4 == 0 && intYear % 100 != 0))//判断是不是闰年  
                    {
                        intDay = 29;
                    }
                    else
                    {
                        intDay = 28;
                    }
                    break;
                case 04:
                case 06:
                case 09:
                case 11: intDay = 30; break;
                default: intDay = 31; break;
            }
            return intDay;
        }

        public static int form_color(string color)
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

        public static Color FontColor(MyColor color)
        {
            switch (color)
            {
                case MyColor.红色:
                    return Color.Red;
                case MyColor.黄色:
                    return Color.Yellow;
                case MyColor.蓝色:
                    return Color.Blue;
                case MyColor.绿色:
                    return Color.GreenYellow;
                case MyColor.青色:
                    return Color.Cyan;
                case MyColor.紫色:
                    return Color.Purple;
                case MyColor.黑色:
                    return Color.Black;
                case MyColor.白色:
                    return Color.White;
                default:
                    return Color.Red;
            }
        }
    }
}
