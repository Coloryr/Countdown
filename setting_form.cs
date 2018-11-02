using System;
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
            change_setting_time();
            timer_check();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            change_setting_time();
        }
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            timer_check();
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

        private void TextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (use.isok(e) == false)
                e.Handled = true;
        }
        private void TextBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (use.isok(e) == false)
                e.Handled = true;
        }
        private void TextBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (use.isok(e) == false)
                e.Handled = true;
        }
        private void TextBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (use.isok(e) == false)
                e.Handled = true;
        }
        private void TextBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (use.isok(e) == false)
                e.Handled = true;
        }
        private void TextBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (use.isok(e) == false)
                e.Handled = true;
        }
        private void TextBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (use.isok(e) == false)
                e.Handled = true;
        }
        private void TextBox8_KeyPress(object sender, KeyPressEventArgs e)
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

        private void change_setting_time()
        {
            if (checkBox1.Checked == true)
            {
                textBox1.ReadOnly = true;
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

            switch (set_local)
            {
                case 1:
                    XML.write(XML.config, "显示位置", "左上角");
                    break;
                case 2:
                    XML.write(XML.config, "显示位置", "右上角");
                    break;
                case 3:
                    XML.write(XML.config, "显示位置", "左下角");
                    break;
                case 4:
                    XML.write(XML.config, "显示位置", "右下角");
                    break;
            }
            switch (set_time_local)
            {
                case 1:
                    XML.write(XML.config, "时钟-显示位置", "左上角");
                    break;
                case 2:
                    XML.write(XML.config, "时钟-显示位置", "右上角");
                    break;
                case 3:
                    XML.write(XML.config, "时钟-显示位置", "左下角");
                    break;
                case 4:
                    XML.write(XML.config, "时钟-显示位置", "右下角");
                    break;
            }

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
        }
    }
}
