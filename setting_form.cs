using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Color_yr.Countdown
{
    public partial class setting_form : Form
    {
        public setting_form()
        {
            InitializeComponent();
        }

        private static int set_local;
        private static int set_time_local;
        private static int set_color;
        private static int set_color_time;
        private static int set_color_date;
        private static int set_close_mode;

        private static string[] local_list = { "左上角", "右上角", "左下角", "右下角" };
        private static string[] color_list = { "红色", "黄色", "蓝色", "绿色", "青色", "紫色", "黑色", "白色" };
        public static string[] close_list = { "关机", "休眠", "睡眠" };

        private void setting_Load(object sender, EventArgs e)
        {

            textBox1.Text = XML.read(XML.config, "设置年份");
            textBox2.Text = XML.read(XML.config, "设置年");
            textBox3.Text = XML.read(XML.config, "设置月");
            textBox4.Text = XML.read(XML.config, "设置日");
            textBox5.Text = XML.read(XML.config, "设置长");
            textBox6.Text = XML.read(XML.config, "设置高");
            textBox7.Text = XML.read(XML.config, "时钟-高");
            textBox8.Text = XML.read(XML.config, "时钟-长");
            textBox9.Text = XML.read(XML.config, "自定义字符");
            if (XML.read(XML.config, "自定义时间") == "true")
                checkBox1.Checked = true;
            else
                checkBox1.Checked = false;
            if (XML.read(XML.config, "时钟-启用") == "true")
                checkBox2.Checked = true;
            else
                checkBox2.Checked = false;
            comboBox1.Text = XML.read(XML.config, "显示位置");
            comboBox2.Text = XML.read(XML.config, "时钟-显示位置");
            comboBox3.Text = XML.read(XML.config, "字体颜色");
            comboBox4.Text = XML.read(XML.config, "时间颜色");
            comboBox5.Text = XML.read(XML.config, "日月颜色");
            comboBox6.Text = XML.read(XML.config, "自动关机-模式");
            string text = XML.read(XML.config, "自动关机-开关");
            if (text == "true")
                checkBox3.Checked = true;
            else
                checkBox3.Checked = false;
            text = XML.read(XML.config, "自动关机-时间1");
            textBox10.Text = text.Substring(0, 2);
            textBox11.Text = text.Substring(3, 2);
            text = XML.read(XML.config, "自动关机-时间2");
            textBox12.Text = text.Substring(0, 2);
            textBox13.Text = text.Substring(3, 2);
            text = XML.read(XML.config, "自动关机-时间3");
            textBox14.Text = text.Substring(0, 2);
            textBox15.Text = text.Substring(3, 2);
            change_setting_time();
            timer_check();
            close_check();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            change_setting_time();
        }
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            timer_check();
        }
        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            close_check();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            save_config();
            use.start();
            use.restart = true;
            use.time_restart = true;
        }

        private void TextBox_number_check(object sender, KeyPressEventArgs e)
        {
            if (use.isok(e) == false)
                e.Handled = true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.Text)
            {
                case "左上角":
                    set_local = 1;
                    break;
                case "右上角":
                    set_local = 2;
                    break;
                case "左下角":
                    set_local = 3;
                    break;
                case "右下角":
                    set_local = 4;
                    break;
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox2.Text)
            {
                case "左上角":
                    set_time_local = 1;
                    break;
                case "右上角":
                    set_time_local = 2;
                    break;
                case "左下角":
                    set_time_local = 3;
                    break;
                case "右下角":
                    set_time_local = 4;
                    break;
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox3.Text)
            {
                case "红色":
                    set_color = 0;
                    break;
                case "黄色":
                    set_color = 1;
                    break;
                case "蓝色":
                    set_color = 2;
                    break;
                case "绿色":
                    set_color = 3;
                    break;
                case "青色":
                    set_color = 4;
                    break;
                case "紫色":
                    set_color = 5;
                    break;
                case "黑色":
                    set_color = 6;
                    break;
                case "白色":
                    set_color = 7;
                    break;
            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox4.Text)
            {
                case "红色":
                    set_color_time = 0;
                    break;
                case "黄色":
                    set_color_time = 1;
                    break;
                case "蓝色":
                    set_color_time = 2;
                    break;
                case "绿色":
                    set_color_time = 3;
                    break;
                case "青色":
                    set_color_time = 4;
                    break;
                case "紫色":
                    set_color_time = 5;
                    break;
                case "黑色":
                    set_color_time = 6;
                    break;
                case "白色":
                    set_color_time = 7;
                    break;
            }
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox5.Text)
            {
                case "红色":
                    set_color_date = 0;
                    break;
                case "黄色":
                    set_color_date = 1;
                    break;
                case "蓝色":
                    set_color_date = 2;
                    break;
                case "绿色":
                    set_color_date = 3;
                    break;
                case "青色":
                    set_color_date = 4;
                    break;
                case "紫色":
                    set_color_date = 5;
                    break;
                case "黑色":
                    set_color_date = 6;
                    break;
                case "白色":
                    set_color_date = 7;
                    break;
            }
        }
        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox6.Text)
            {
                case "关机":
                    set_close_mode = 0;
                    break;
                case "休眠":
                    set_close_mode = 1;
                    break;
                case "睡眠":
                    set_close_mode = 2;
                    break;
            }
        }

        private void change_setting_time()
        {
            if (checkBox1.Checked == true)
            {
                textBox1.ReadOnly = true;
                textBox9.ReadOnly = false;
                textBox2.ReadOnly = false;
                textBox3.ReadOnly = false;
                textBox4.ReadOnly = false;
            }
            else
            {
                textBox1.ReadOnly = false;
                textBox2.ReadOnly = true;
                textBox3.ReadOnly = true;
                textBox4.ReadOnly = true;
                textBox9.ReadOnly = true;
            }
        }
        private void timer_check()
        {
            if (checkBox2.Checked == true)
            {
                textBox8.ReadOnly = false;
                textBox7.ReadOnly = false;
                comboBox2.Enabled = true;
            }
            else
            {
                textBox8.ReadOnly = true;
                textBox7.ReadOnly = true;
                comboBox2.Enabled = false;
            }
        }
        private void close_check()
        {
            if (checkBox3.Checked == true)
            {
                comboBox6.Enabled = true;
                textBox10.ReadOnly = false;
                textBox11.ReadOnly = false;
                textBox12.ReadOnly = false;
                textBox13.ReadOnly = false;
                textBox14.ReadOnly = false;
                textBox15.ReadOnly = false;
            }
            else
            {
                comboBox6.Enabled = false;
                textBox10.ReadOnly = true;
                textBox11.ReadOnly = true;
                textBox12.ReadOnly = true;
                textBox13.ReadOnly = true;
                textBox14.ReadOnly = true;
                textBox15.ReadOnly = true;
            }
        }

        private void save_config()
        {
            int test;

            int.TryParse(textBox1.Text, out test);
            if (test > 2099 || test < 2000)
            {
                MessageBox.Show("年份设置错误", "保存失败");
                return;
            }

            int.TryParse(textBox2.Text, out test);
            if (test > 2099 || test < 2000)
            {
                MessageBox.Show("年设置错误", "保存失败");
                return;
            }

            int.TryParse(textBox3.Text, out test);
            if (test > 12 || test < 1)
            {
                MessageBox.Show("月设置错误", "保存失败");
                return;
            }

            int.TryParse(textBox4.Text, out test);
            if (test > use.SetDate(DateTime.Now.ToString()) || test < 1)
            {
                MessageBox.Show("日设置错误", "保存失败");
                return;
            }

            XML.write(XML.config, "显示位置", local_list[set_local - 1]);
            XML.write(XML.config, "时钟-显示位置", local_list[set_time_local - 1]);
            XML.write(XML.config, "时钟-长", textBox8.Text);
            XML.write(XML.config, "时钟-高", textBox7.Text);
            XML.write(XML.config, "设置高", textBox6.Text);
            XML.write(XML.config, "设置长", textBox5.Text);
            XML.write(XML.config, "设置日", textBox4.Text);
            XML.write(XML.config, "设置月", textBox3.Text);
            XML.write(XML.config, "设置年", textBox2.Text);
            XML.write(XML.config, "设置年份", textBox1.Text);
            if (checkBox1.Checked == true)
                XML.write(XML.config, "自定义时间", "true");
            else
                XML.write(XML.config, "自定义时间", "false");
            if (checkBox2.Checked == true)
                XML.write(XML.config, "时钟-启用", "true");
            else
                XML.write(XML.config, "时钟-启用", "false");
            XML.write(XML.config, "字体颜色", color_list[set_color]);
            XML.write(XML.config, "时间颜色", color_list[set_color_time]);
            XML.write(XML.config, "日月颜色", color_list[set_color_date]);
            if (textBox9.Text.Length > 7)
                MessageBox.Show("字符过多");
            else
                XML.write(XML.config, "自定义字符", textBox9.Text);
            if (checkBox3.Checked == true)
                XML.write(XML.config, "自动关机-开关", "true");
            else
                XML.write(XML.config, "自动关机-开关", "false");
            int a, b;
            int.TryParse(textBox10.Text, out a);
            int.TryParse(textBox11.Text, out b);
            if (a > 23 && b > 59)
            {
                MessageBox.Show("时间1错误");
            }
            else
            {
                string write;
                if (a < 10)
                    write = "0" + a.ToString();
                else
                    write = a.ToString();
                if (b < 10)
                    write = write + ":0" + b.ToString();
                else
                    write = write + ":" + b.ToString();
                XML.write(XML.config, "自动关机-时间1", write);
                use.close1[0] = a;
                use.close1[1] = b;
            }

            int.TryParse(textBox12.Text, out a);
            int.TryParse(textBox13.Text, out b);
            if (a > 23 && b > 59)
            {
                MessageBox.Show("时间2错误");
            }
            else
            {
                string write;
                if (a < 10)
                    write = "0" + a.ToString();
                else
                    write = a.ToString();
                if (b < 10)
                    write = write + ":0" + b.ToString();
                else
                    write = write + ":" + b.ToString();
                XML.write(XML.config, "自动关机-时间2", write);
                use.close2[0] = a;
                use.close2[1] = b;
            }

            int.TryParse(textBox14.Text, out a);
            int.TryParse(textBox15.Text, out b);
            if (a > 23 && b > 59)
            {
                MessageBox.Show("时间3错误");
            }
            else
            {
                string write;
                if (a < 10)
                    write = "0" + a.ToString();
                else
                    write = a.ToString();
                if (b < 10)
                    write = write + ":0" + b.ToString();
                else
                    write = write + ":" + b.ToString();
                XML.write(XML.config, "自动关机-时间3", write);
                use.close3[0] = a;
                use.close3[1] = b;
            }
            XML.write(XML.config, "自动关机-模式", close_list[set_close_mode]);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (use.is_open == true)
            {
                use.is_open = false;
                timer1.Enabled = false;
                use.start_form = new Countdown();
                use.start_form.Show();
                timer2.Enabled = true;
                Hide();
            }
            timer1.Enabled = false;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            use.restart = true;
            use.time_restart = true;
            timer2.Enabled = false;
        }
    }
}
