using System;
using System.Windows.Forms;
using System.Threading;
using System.Drawing;
using System.IO;
using Microsoft.Win32;
using System.Runtime.InteropServices;

namespace Color_yr.Countdown
{
    class use
    {
        public static int Width;
        public static int Height;
        public static int year;
        public static int month;
        public static int day;
        public static int local;
        public static int time_Width;
        public static int time_Height;
        public static int time_local;
        public static int set_color;
        public static int set_color_time;
        public static int set_color_date;
        public static int close_mode;

        public static Form time_form;
        public static Form start_form;

        public static bool is_close = false;
        public static bool restart = true;
        public static bool time_restart = true;
        public static bool time_enable = false;
        public static bool is_user = false;
        public static bool is_open = true;
        public static bool close_enable = false;

        public static int[] close1 = new int[2] { 12, 0};
        public static int[] close2 = new int[2] { 17, 15};
        public static int[] close3 = new int[2] { 22, 0};

        public static string user_string;

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

        public void start()
        {
            XML XML = new XML();
            if (XML.read(XML.config, "设置年份") == null)
            {
                XML.write(XML.config, "设置年份", "2019");
                XML.write(XML.config, "设置年", "2019");
                XML.write(XML.config, "设置月", "6");
                XML.write(XML.config, "设置日", "7");
                XML.write(XML.config, "设置长", "501");
                XML.write(XML.config, "设置高", "360");
                XML.write(XML.config, "自定义时间", "false");
                XML.write(XML.config, "显示位置", "左上角");
                XML.write(XML.config, "时钟-启用", "false");
                XML.write(XML.config, "时钟-长", "600");
                XML.write(XML.config, "时钟-高", "190");
                XML.write(XML.config, "时钟-显示位置", "左上角");
                XML.write(XML.config, "字体颜色", "黑色");
                XML.write(XML.config, "时间颜色", "黑色");
                XML.write(XML.config, "日月颜色", "黑色");
                XML.write(XML.config, "自定义字符", "距离高考还有：");
                XML.write(XML.config, "自动关机-开关", "false");
                XML.write(XML.config, "自动关机-模式", "关机");
                XML.write(XML.config, "自动关机-时间1", "12:00");
                XML.write(XML.config, "自动关机-时间2", "17:15");
                XML.write(XML.config, "自动关机-时间3", "20:00");
            }
            if (XML.read(XML.config, "设置年") == null)
                XML.write(XML.config, "设置年", "2019");
            if (XML.read(XML.config, "设置月") == null)
                XML.write(XML.config, "设置月", "6");
            if (XML.read(XML.config, "设置日") == null)
                XML.write(XML.config, "设置日", "7");
            if (XML.read(XML.config, "设置长") == null)
                XML.write(XML.config, "设置长", "668");
            if (XML.read(XML.config, "设置高") == null)
                XML.write(XML.config, "设置高", "450");
            if (XML.read(XML.config, "自定义时间") == null)
                XML.write(XML.config, "自定义时间", "false");
            if (XML.read(XML.config, "显示位置") == null)
                XML.write(XML.config, "显示位置", "左上角");
            if (XML.read(XML.config, "时钟-启用") == null)
                XML.write(XML.config, "时钟-启用", "false");
            if (XML.read(XML.config, "时钟-长") == null)
                XML.write(XML.config, "时钟-长", "600");
            if (XML.read(XML.config, "时钟-高") == null)
                XML.write(XML.config, "时钟-高", "190");
            if (XML.read(XML.config, "时钟-显示位置") == null)
                XML.write(XML.config, "时钟-显示位置", "左上角");
            if (XML.read(XML.config, "字体颜色") == null)
                XML.write(XML.config, "字体颜色", "黑色");
            if (XML.read(XML.config, "时间颜色") == null)
                XML.write(XML.config, "时间颜色", "黑色");
            if (XML.read(XML.config, "日月颜色") == null)
                XML.write(XML.config, "日月颜色", "黑色");
            if (XML.read(XML.config, "自定义字符") == null)
                XML.write(XML.config, "自定义字符", "距离高考还有：");
            if (XML.read(XML.config, "自动关机-开关") == null)
                XML.write(XML.config, "自动关机-开关", "false");
            if (XML.read(XML.config, "自动关机-模式") == null)
                XML.write(XML.config, "自动关机-模式", "关机");
            if (XML.read(XML.config, "自动关机-时间1") == null)
                XML.write(XML.config, "自动关机-时间1", "12:00");
            if (XML.read(XML.config, "自动关机-时间2") == null)
                XML.write(XML.config, "自动关机-时间2", "17:15");
            if (XML.read(XML.config, "自动关机-时间3") == null)
                XML.write(XML.config, "自动关机-时间3", "20:00");

            if (XML.read(XML.config, "自定义时间") == "false")
            {
                is_user = false;
                int.TryParse(XML.read(XML.config, "设置年份"), out year);
                if (year > 2099 || year < 2000)
                {
                    year = 2019;
                    XML.write(XML.config, "设置年份", "2019");
                }
                month = 6;
                day = 7;
            }
            else
            {
                is_user = true;
                int.TryParse(XML.read(XML.config, "设置年"), out year);
                if (year > 2099 || year < 2000)
                {
                    year = 2019;
                    XML.write(XML.config, "设置年", "2019");
                }
                int.TryParse(XML.read(XML.config, "设置月"), out month);
                if (month > 12 || month < 1)
                {
                    month = 6;
                    XML.write(XML.config, "设置月", "6");
                }
                int.TryParse(XML.read(XML.config, "设置日"), out day);
                if (day > SetDate(DateTime.Now.ToString()) || day < 1)
                {
                    day = 7;
                    XML.write(XML.config, "设置月", "7");
                }
            }
            int.TryParse(XML.read(XML.config, "设置长"), out Width);
            int.TryParse(XML.read(XML.config, "设置高"), out Height);
            switch (XML.read(XML.config, "显示位置"))
            {
                case "左上角":
                    local = 1;
                    break;
                case "右上角":
                    local = 2;
                    break;
                case "左下角":
                    local = 3;
                    break;
                case "右下角":
                    local = 4;
                    break;
                default:
                    XML.write(XML.config, "显示位置", "左上角");
                    local = 1;
                    break;
            }
            int.TryParse(XML.read(XML.config, "时钟-长"), out time_Width);
            int.TryParse(XML.read(XML.config, "时钟-高"), out time_Height);
            switch (XML.read(XML.config, "时钟-显示位置"))
            {
                case "左上角":
                    time_local = 1;
                    break;
                case "右上角":
                    time_local = 2;
                    break;
                case "左下角":
                    time_local = 3;
                    break;
                case "右下角":
                    time_local = 4;
                    break;
                default:
                    XML.write(XML.config, "时钟-显示位置", "左上角");
                    time_local = 1;
                    break;
            }
            if (XML.read(XML.config, "时钟-启用") == "true")
                time_enable = true;
            else
                time_enable = false;

            switch (XML.read(XML.config, "字体颜色"))
            {
                case "红色":
                    set_color = 1;
                    break;
                case "黄色":
                    set_color = 2;
                    break;
                case "蓝色":
                    set_color = 3;
                    break;
                case "绿色":
                    set_color = 4;
                    break;
                case "青色":
                    set_color = 5;
                    break;
                case "紫色":
                    set_color = 6;
                    break;
                case "黑色":
                    set_color = 7;
                    break;
                case "白色":
                    set_color = 8;
                    break;
                default:
                    XML.write(XML.config, "字体颜色", "黑色");
                    set_color_time = 7;
                    break;
            }
            switch (XML.read(XML.config, "时间颜色"))
            {
                case "红色":
                    set_color_time = 1;
                    break;
                case "黄色":
                    set_color_time = 2;
                    break;
                case "蓝色":
                    set_color_time = 3;
                    break;
                case "绿色":
                    set_color_time = 4;
                    break;
                case "青色":
                    set_color_time = 5;
                    break;
                case "紫色":
                    set_color_time = 6;
                    break;
                case "黑色":
                    set_color_time = 7;
                    break;
                case "白色":
                    set_color_time = 8;
                    break;
                default:
                    XML.write(XML.config, "时间颜色", "黑色");
                    set_color_time = 7;
                    break;
            }
            switch (XML.read(XML.config, "日月颜色"))
            {
                case "红色":
                    set_color_date = 1;
                    break;
                case "黄色":
                    set_color_date = 2;
                    break;
                case "蓝色":
                    set_color_date = 3;
                    break;
                case "绿色":
                    set_color_date = 4;
                    break;
                case "青色":
                    set_color_date = 5;
                    break;
                case "紫色":
                    set_color_date = 6;
                    break;
                case "黑色":
                    set_color_date = 7;
                    break;
                case "白色":
                    set_color_date = 8;
                    break;
                default:
                    XML.write(XML.config, "日月颜色", "黑色");
                    set_color_time = 7;
                    break;
            }
            user_string = XML.read(XML.config, "自定义字符");
            close_check_time();

            time_restart = true;
            XML = null;
        }
        public void close_check_time()
        {
            XML XML = new XML();
            string text = XML.read(XML.config, "自动关机-开关");
            if (text == "true")
                close_enable = true;
            else
                close_enable = false;
            string a = XML.read(XML.config, "自动关机-时间1");
            if (a.Length != 5)
            {
                MessageBox.Show("自动关机-时间1错误");
                close_enable = false;
                return;
            }
            int c, d;
            c = int.Parse(a.Substring(0, 2));
            d = int.Parse(a.Substring(3, 2));
            if (c > 23 && d > 59)
            {
                MessageBox.Show("自动关机-时间1错误");
                close_enable = false;
                return;
            }
            else
            {
                close1[0] = c;
                close1[1] = d;
            }

            a = XML.read(XML.config, "自动关机-时间2");
            if (a.Length != 5)
            {
                MessageBox.Show("自动关机-时间2错误");
                close_enable = false;
                return;
            }
            c = int.Parse(a.Substring(0, 2));
            d = int.Parse(a.Substring(3, 2));
            if (c > 23 && d > 59)
            {
                MessageBox.Show("自动关机-时间2错误");
                close_enable = false;
                return;
            }
            else
            {
                close2[0] = c;
                close2[1] = d;
            }

            a = XML.read(XML.config, "自动关机-时间3");
            if (a.Length != 5)
            {
                MessageBox.Show("自动关机-时间3错误");
                close_enable = false;
                return;
            }
            c = int.Parse(a.Substring(0, 2));
            d = int.Parse(a.Substring(3, 2));
            if (c > 23 && d > 59)
            {
                MessageBox.Show("自动关机-时间3错误");
                close_enable = false;
                return;
            }
            else
            {
                close3[0] = c;
                close3[1] = d;
            }

            a = XML.read(XML.config, "自动关机-模式");
            switch (a)
            {
                case "关机":
                    close_mode = 0;
                    break;
                case "休眠":
                    close_mode = 1;
                    break;
                case "睡眠":
                    close_mode = 2;
                    break;
                default:
                    MessageBox.Show("自动关机模式错误，已设置成关机");
                    XML.write(XML.config, "自动关机-模式", "关机");
                    close_mode = 0;
                    break;
            }
            XML = null;
        }
    }
}
