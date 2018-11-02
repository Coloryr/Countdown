using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        public static void start()
        {
            if (XML.read(XML.config, "设置年份") == null)
            {
                XML.write(XML.config, "设置年份", "2019");
                XML.write(XML.config, "设置年", "2019");
                XML.write(XML.config, "设置月", "6");
                XML.write(XML.config, "设置日", "7");
                XML.write(XML.config, "设置长", "668");
                XML.write(XML.config, "设置高", "450");
                XML.write(XML.config, "自定义时间", "false");
                XML.write(XML.config, "显示位置", "左上角");
            }
            if (XML.read(XML.config, "设置年") == null)
            {
                XML.write(XML.config, "设置年", "2019");
            }
            if (XML.read(XML.config, "设置月") == null)
            {
                XML.write(XML.config, "设置月", "6");
            }
            if (XML.read(XML.config, "设置日") == null)
            {
                XML.write(XML.config, "设置日", "7");
            }
            if (XML.read(XML.config, "设置长") == null)
            {
                XML.write(XML.config, "设置长", "668");
            }
            if (XML.read(XML.config, "设置高") == null)
            {
                XML.write(XML.config, "设置高", "450");
            }
            if (XML.read(XML.config, "自定义时间") == null)
            {
                XML.write(XML.config, "自定义时间", "false");
            }
            if (XML.read(XML.config, "自定义时间") == "false")
            {
                int.TryParse(XML.read(XML.config, "设置年份"), out year);
                month = 6;
                day = 7;
            }
            else
            {
                int.TryParse(XML.read(XML.config, "设置年"), out year);
                int.TryParse(XML.read(XML.config, "设置月"), out month);
                int.TryParse(XML.read(XML.config, "设置日"), out day);
            }
        }
    }
}
