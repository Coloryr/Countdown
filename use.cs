using System;
using System.Windows.Forms;

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

        public static bool restart = true;
        public static bool time_restart = true;
        public static bool time_enable = false;

        public static bool isok(KeyPressEventArgs e)
        {
            if (e.KeyChar == '\b')//这是允许输入退格键
                return true;
            else if ((e.KeyChar < '0') || (e.KeyChar > '9'))//这是允许输入0-9数字
            {
                return false;
            }
            return true;
        }

        //月份为两位
        public static int SetDate(string time)
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

        public static void start()
        {
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
            if (XML.read(XML.config, "自定义时间") == "false")
            {
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
            time_restart = true;
        }
    }
}
