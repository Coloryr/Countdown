using System;
using System.Windows.Forms;

namespace Color_yr.Countdown
{
    class config
    {

        public static int countdown_form_Width;
        public static int countdown_form_Height;
        public static int countdown_form_year;
        public static int countdown_form_month;
        public static int countdown_form_day;
        public static int countdown_form_local;
        public static int countdown_form_color;
        public static int countdown_form_string_color;

        public static int time_form_Width;
        public static int time_form_Height;
        public static int time_form_local;
        public static int time_form_time_color;
        public static int time_form_date_color;

        public static int close_mode;

        public static bool is_close = false;
        public static bool restart = true;
        public static bool time_restart = true;
        public static bool time_enable = false;
        public static bool is_user = false;
        public static bool is_open = true;
        public static bool close_enable = false;

        public static int[] close1 = new int[2] { 12, 0 };
        public static int[] close2 = new int[2] { 17, 15 };
        public static int[] close3 = new int[2] { 22, 0 };

        public static string user_string;

        public void start()
        {
            try
            {
                conifg_reload();
                config_check();
                close_check_time();
            }
            catch
            { }
        }

        public void conifg_reload()
        {
            XML XML = new XML();
            if (XML.read(XML.config, "时间设置", "设置年份") == null)
            {
                XML.write(XML.config, "时间设置", "设置年份", "2019");
                XML.write(XML.config, "时间设置", "设置年", "2019");
                XML.write(XML.config, "时间设置", "设置月", "6");
                XML.write(XML.config, "时间设置", "设置日", "7");
                XML.write(XML.config, "时间设置", "自定义时间", "关");

                XML.write(XML.config, "倒计时设置", "窗体长", "501");
                XML.write(XML.config, "倒计时设置", "窗体高", "360");
                XML.write(XML.config, "倒计时设置", "窗体位置", "左上角");
                XML.write(XML.config, "倒计时设置", "字体颜色", "红色");
                XML.write(XML.config, "倒计时设置", "数字颜色", "红色");
                XML.write(XML.config, "倒计时设置", "自定义字符", "距离高考还有：");

                XML.write(XML.config, "时钟设置", "启用", "开");
                XML.write(XML.config, "时钟设置", "窗体长", "600");
                XML.write(XML.config, "时钟设置", "窗体高", "190");
                XML.write(XML.config, "时钟设置", "窗体位置", "右上角");
                XML.write(XML.config, "时钟设置", "时间颜色", "红色");
                XML.write(XML.config, "时钟设置", "日月颜色", "红色");

                XML.write(XML.config, "自动关机", "启用", "关");
                XML.write(XML.config, "自动关机", "模式", "关机");
                XML.write(XML.config, "自动关机", "时间1", "12:00");
                XML.write(XML.config, "自动关机", "时间2", "17:15");
                XML.write(XML.config, "自动关机", "时间3", "20:00");
            }

            if (XML.read(XML.config, "时间设置", "设置年份") == null)
                XML.write(XML.config, "时间设置", "设置年份", "2019");
            if (XML.read(XML.config, "时间设置", "设置年") == null)
                XML.write(XML.config, "时间设置", "设置年份", "2019");
            if (XML.read(XML.config, "时间设置", "设置月") == null)
                XML.write(XML.config, "时间设置", "设置月", "6");
            if (XML.read(XML.config, "时间设置", "设置日") == null)
                XML.write(XML.config, "时间设置", "设置日", "7");

            if (XML.read(XML.config, "倒计时设置", "窗体长") == null)
                XML.write(XML.config, "倒计时设置", "窗体长", "501");
            if (XML.read(XML.config, "倒计时设置", "窗体高") == null)
                XML.write(XML.config, "倒计时设置", "窗体高", "360");
            if (XML.read(XML.config, "倒计时设置", "窗体位置") == null)
                XML.write(XML.config, "倒计时设置", "窗体位置", "右上角");
            if (XML.read(XML.config, "倒计时设置", "字体颜色") == null)
                XML.write(XML.config, "倒计时设置", "字体颜色", "红色");
            if (XML.read(XML.config, "倒计时设置", "日月颜色") == null)
                XML.write(XML.config, "倒计时设置", "日月颜色", "红色");
            if (XML.read(XML.config, "倒计时设置", "自定义字符") == null)
                XML.write(XML.config, "倒计时设置", "自定义字符", "距离高考还有");

            if (XML.read(XML.config, "自动关机", "启用") == null)
                XML.write(XML.config, "自动关机", "启用", "2019");
            if (XML.read(XML.config, "自动关机", "模式") == null)
                XML.write(XML.config, "自动关机", "模式", "2019");
            if (XML.read(XML.config, "自动关机", "时间1") == null)
                XML.write(XML.config, "自动关机", "时间1", "2019");
            if (XML.read(XML.config, "自动关机", "时间2") == null)
                XML.write(XML.config, "自动关机", "时间2", "2019");
            if (XML.read(XML.config, "自动关机", "时间3") == null)
                XML.write(XML.config, "自动关机", "时间3", "2019");
        }
        public void config_check()
        {
            XML XML = new XML();
            use use = new use();
            if (XML.read(XML.config, "时间设置", "自定义时间") == "关")
            {
                is_user = false;
                int.TryParse(XML.read(XML.config, "时间设置", "设置年份"), out countdown_form_year);
                if (countdown_form_year > 2099 || countdown_form_year < 2000)
                {
                    countdown_form_year = 2019;
                    XML.write(XML.config, "时间设置",  "设置年份", "2019");
                }
                countdown_form_month = 6;
                countdown_form_day = 7;
            }
            else
            {
                is_user = true;
                int.TryParse(XML.read(XML.config, "时间设置", "设置年"), out countdown_form_year);
                if (countdown_form_year > 2099 || countdown_form_year < 2000)
                {
                    countdown_form_year = 2019;
                    XML.write(XML.config, "时间设置", "设置年", "2019");
                }
                int.TryParse(XML.read(XML.config, "时间设置", "设置月"), out countdown_form_month);
                if (countdown_form_month > 12 || countdown_form_month < 1)
                {
                    countdown_form_month = 6;
                    XML.write(XML.config, "时间设置", "设置月", "6");
                }
                int.TryParse(XML.read(XML.config, "时间设置", "设置日"), out countdown_form_day);
                if (countdown_form_day > use.SetDate(DateTime.Now.ToString()) || countdown_form_day < 1)
                {
                    countdown_form_day = 7;
                    XML.write(XML.config, "时间设置", "设置月", "7");
                }
            }
            int.TryParse(XML.read(XML.config, "倒计时设置", "窗体长"), out countdown_form_Width);
            int.TryParse(XML.read(XML.config, "倒计时设置", "窗体高"), out countdown_form_Height);
            countdown_form_local = use.form_local(XML.read(XML.config, "倒计时设置", "窗体位置"));
            if (countdown_form_local == 0)
            {
                countdown_form_local = 1;
                XML.write(XML.config, "倒计时设置", "窗体位置", "左上角");
            }
            countdown_form_color = use.form_color(XML.read(XML.config, "倒计时设置", "数字颜色"));
            if (countdown_form_color == 0)
            {
                countdown_form_color = 1;
                XML.write(XML.config, "倒计时设置", "数字颜色", "红色");
            }
            countdown_form_string_color = use.form_color(XML.read(XML.config, "倒计时设置", "字体颜色"));
            if (countdown_form_string_color == 0)
            {
                countdown_form_string_color = 1;
                XML.write(XML.config, "倒计时设置", "字体颜色", "红色");
            }
            user_string = XML.read(XML.config, "倒计时设置", "自定义字符");

            int.TryParse(XML.read(XML.config, "时钟设置", "窗体长"), out time_form_Width);
            int.TryParse(XML.read(XML.config, "时钟设置",  "窗体高"), out time_form_Height);
            time_form_local = use.form_local(XML.read(XML.config, "时钟设置", "窗体位置"));
            if (time_form_local == 0)
            {
                time_form_local = 1;
                XML.write(XML.config, "时钟设置", "显示位置", "左上角");
            }
            if (XML.read(XML.config, "时钟设置",  "启用") == "开")
                time_enable = true;
            else
                time_enable = false;

            time_form_time_color = use.form_color(XML.read(XML.config, "时钟设置", "时间颜色"));
            if (time_form_time_color == 0)
            {
                time_form_time_color = 1;
                XML.write(XML.config, "时钟设置", "时间颜色", "红色");
            }
            time_form_date_color = use.form_color(XML.read(XML.config, "时间设置", "日月颜色"));
            if (time_form_date_color == 0)
            {
                time_form_date_color = 1;
                XML.write(XML.config, "时钟设置", "日月颜色", "红色");
            }
        }
        public void close_check_time()
        {
            XML XML = new XML();
            use use = new use();
            string text = XML.read(XML.config, "自动关机", "启用");
            if (text == "开")
                close_enable = true;
            else
                close_enable = false;
            if (use.check_close_time(XML.read(XML.config, "自动关机", "时间1"), close1) == false)
            {
                MessageBox.Show("自动关机-时间1错误");
                close_enable = false;
                return;
            }

            if (use.check_close_time(XML.read(XML.config, "自动关机", "时间2"), close2) == false)
            {
                MessageBox.Show("自动关机-时间2错误");
                close_enable = false;
                return;
            }

            if (use.check_close_time(XML.read(XML.config, "自动关机", "时间3"), close3) == false)
            {
                MessageBox.Show("自动关机-时间3错误");
                close_enable = false;
                return;
            }

            switch (XML.read(XML.config, "自动关机", "模式"))
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
                    XML.write(XML.config, "自动关机", "模式", "关机");
                    close_mode = 0;
                    break;
            }
        }
    }
}
