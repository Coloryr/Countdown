using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Color_yr.Countdown
{
    public partial class setting_form : Form
    {
        //月份为两位
        private int SetDate(string time)
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

        public setting_form()
        {
            InitializeComponent();
        }

        private void setting_Load(object sender, EventArgs e)
        {
            textBox1.Text = XML.read(XML.config, "设置年份");
            textBox2.Text = XML.read(XML.config, "设置年");
            textBox3.Text = XML.read(XML.config, "设置月");
            textBox4.Text = XML.read(XML.config, "设置日");
            textBox5.Text = XML.read(XML.config, "设置长");
            textBox6.Text = XML.read(XML.config, "设置高");
            if (XML.read(XML.config, "自定义时间") == "true")
                checkBox1.Checked = true;
            else
                checkBox1.Checked = false;
            change_setting_time();
        }
        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();   //隐藏窗体
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            change_setting_time();
        }
        private void change_setting_time()
        {
            if (checkBox1.Checked == true)
            {
                textBox1.ReadOnly = true;
                textBox2.ReadOnly = false;
                textBox3.ReadOnly = false;
                textBox4.ReadOnly = false;
                XML.write(XML.config, "自定义时间", "true");
            }
            else
            {
                textBox1.ReadOnly = false;
                textBox2.ReadOnly = true;
                textBox3.ReadOnly = true;
                textBox4.ReadOnly = true;
                XML.write(XML.config, "自定义时间", "false");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public static bool isok(int max, KeyPressEventArgs e, string text)
        {
            if (e.KeyChar == '\b')//这是允许输入退格键
            {
                return true;
            }
            if ((e.KeyChar < '0') || (e.KeyChar > '9'))//这是允许输入0-9数字
            {
                return false;
            }
            int number;
            int.TryParse(text, out number);
            if (number > max)
            {
                return false;
            }
            return true;
        }

        private void TextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\b')//这是允许输入退格键
                return;
            string test = textBox1.Text + e.KeyChar;
            if (isok(9999, e, test) == false)
                e.Handled = true;
            else
                XML.write(XML.config, "设置年份", test);
        }
        private void TextBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\b')//这是允许输入退格键
                return;
            string test = textBox2.Text + e.KeyChar;
            if (isok(9999, e, test) == false)
                e.Handled = true;
            else
                XML.write(XML.config, "设置年", test);
        }
        private void TextBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\b')//这是允许输入退格键
                return;
            string test = textBox3.Text + e.KeyChar;
            if (isok(12, e, test) == false)
                e.Handled = true;
            else
                XML.write(XML.config, "设置月", test);
        }
        private void TextBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\b')//这是允许输入退格键
                return;
            DateTime dt = DateTime.Now;
            string test = textBox4.Text + e.KeyChar;
            int da = SetDate(dt.ToString());
            if (isok(da, e, test) == false)
                e.Handled = true;
            else
                XML.write(XML.config, "设置日", test);
        }
        private void TextBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\b')//这是允许输入退格键
                return;
            string test = textBox5.Text + e.KeyChar;
            if (isok(1000, e, test) == false)
                e.Handled = true;
            else
                XML.write(XML.config, "设置长", test);
        }
        private void TextBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\b')//这是允许输入退格键
                return;
            string test = textBox6.Text + e.KeyChar;
            if (isok(1000, e, test) == false)
                e.Handled = true;
            else
                XML.write(XML.config, "设置高", test);
        }
    }
}
