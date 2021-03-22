using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Coloryr.Countdown.Froms
{
    public partial class SettingFrom : Form
    {
        private object[] locals = new object[] { MyLocal.左上角, MyLocal.右上角, MyLocal.左下角, MyLocal.右下角 };
        private object[] colors = new object[] { MyColor.红色, MyColor.黄色, MyColor.蓝色, MyColor.绿色, MyColor.青色, MyColor.紫色, MyColor.黑色, MyColor.白色 };
        private object[] modes = new object[] { MyMode.关机, MyMode.休眠, MyMode.睡眠 };
        public SettingFrom()
        {
            InitializeComponent();
            comboBox1.Items.AddRange(locals);
            comboBox2.Items.AddRange(locals);

            comboBox3.Items.AddRange(colors);
            comboBox7.Items.AddRange(colors);
            comboBox4.Items.AddRange(colors);
            comboBox5.Items.AddRange(colors);

            comboBox6.Items.AddRange(modes);
        }

        private void setting_Load(object sender, EventArgs e)
        {
            textBox2.Text = Program.Config.Countdown.Year.ToString();
            textBox3.Text = Program.Config.Countdown.Month.ToString();
            textBox4.Text = Program.Config.Countdown.Day.ToString();
            textBox5.Text = Program.Config.Countdown.Width.ToString();
            textBox6.Text = Program.Config.Countdown.Height.ToString();
            textBox7.Text = Program.Config.Time.Width.ToString();
            textBox8.Text = Program.Config.Time.Height.ToString();
            textBox9.Text = Program.Config.Countdown.SetText;

            comboBox1.SelectedItem = Program.Config.Countdown.Local;
            comboBox2.SelectedItem = Program.Config.Time.Local;
            comboBox3.SelectedItem = Program.Config.Countdown.Color;
            comboBox4.SelectedItem = Program.Config.Time.TimeColor;
            comboBox5.SelectedItem = Program.Config.Time.DateColor;
            comboBox6.SelectedItem = Program.Config.Close.CloseMode;
            comboBox7.SelectedItem = Program.Config.Countdown.StringColor;

            checkBox2.Checked = Program.Config.Time.Enable;
            checkBox3.Checked = Program.Config.Close.Enable;

            textBox10.Text = Program.Config.Close.Close1.Hour.ToString();
            textBox11.Text = Program.Config.Close.Close1.Minute.ToString();

            textBox12.Text = Program.Config.Close.Close2.Hour.ToString();
            textBox13.Text = Program.Config.Close.Close2.Minute.ToString();

            textBox14.Text = Program.Config.Close.Close3.Hour.ToString();
            textBox15.Text = Program.Config.Close.Close3.Minute.ToString();

            TimerCheck();
            CloseCheck();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            TimerCheck();
        }
        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            CloseCheck();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void TextBox_number_check(object sender, KeyPressEventArgs e)
        {
            if (Utils.IsOk(e) == false)
                e.Handled = true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Program.Config.Countdown.Local = comboBox1.SelectedItem == null
                ? MyLocal.左上角 : (MyLocal)comboBox1.SelectedItem;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Program.Config.Time.Local = comboBox2.SelectedItem == null
                ? MyLocal.左上角 : (MyLocal)comboBox2.SelectedItem;
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            Program.Config.Countdown.Color = comboBox3.SelectedItem == null
                ? MyColor.红色 : (MyColor)comboBox3.SelectedItem;
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            Program.Config.Time.TimeColor = comboBox4.SelectedItem == null
                ? MyColor.红色 : (MyColor)comboBox4.SelectedItem;
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            Program.Config.Time.DateColor = comboBox5.SelectedItem == null
                ? MyColor.红色 : (MyColor)comboBox5.SelectedItem;
        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            Program.Config.Countdown.StringColor = comboBox7.SelectedItem == null
                ? MyColor.红色 : (MyColor)comboBox7.SelectedItem;
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            Program.Config.Close.CloseMode = comboBox6.SelectedItem == null
                ? MyMode.关机 : (MyMode)comboBox6.SelectedItem;
        }

        private void TimerCheck()
        {
            if (checkBox2.Checked == true)
            {
                textBox7.ReadOnly = false;
                textBox8.ReadOnly = false;
                comboBox2.Enabled = true;
            }
            else
            {
                textBox7.ReadOnly = true;
                textBox8.ReadOnly = true;
                comboBox2.Enabled = false;
            }
        }
        private void CloseCheck()
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

        private void Save()
        {

            int.TryParse(textBox5.Text, out int test);
            if (test > 0)
            {
                Program.Config.Countdown.Width = test;
            }
            int.TryParse(textBox6.Text, out test);
            if (test > 0)
            {
                Program.Config.Countdown.Height = test;
            }

            int.TryParse(textBox7.Text, out test);
            if (test > 0)
            {
                Program.Config.Time.Width = test;
            }
            int.TryParse(textBox8.Text, out test);
            if (test > 0)
            {
                Program.Config.Time.Height = test;
            }

            int.TryParse(textBox2.Text, out test);
            if (test > 2099 || test < 2000)
            {
                MessageBox.Show("年设置错误", "保存失败");
                return;
            }

            Program.Config.Countdown.Year = test;

            int.TryParse(textBox3.Text, out test);
            if (test > 12 || test < 1)
            {
                MessageBox.Show("月设置错误", "保存失败");
                return;
            }

            Program.Config.Countdown.Month = test;

            int.TryParse(textBox4.Text, out test);
            if (test > Utils.SetDate(DateTime.Now.ToString()) || test < 1)
            {
                MessageBox.Show("日设置错误", "保存失败");
                return;
            }

            Program.Config.Countdown.Day = test;

            int a, b;
            int.TryParse(textBox10.Text, out a);
            int.TryParse(textBox11.Text, out b);
            if (a > 23 || b > 59 || a < 0 || b < 0)
            {
                MessageBox.Show("时间1错误");
                return;
            }
            Program.Config.Close.Close1.Hour = a;
            Program.Config.Close.Close1.Minute = b;

            int.TryParse(textBox12.Text, out a);
            int.TryParse(textBox13.Text, out b);
            if (a > 23 || b > 59 || a < 0 || b < 0)
            {
                MessageBox.Show("时间2错误");
                return;
            }
            Program.Config.Close.Close2.Hour = a;
            Program.Config.Close.Close2.Minute = b;

            int.TryParse(textBox14.Text, out a);
            int.TryParse(textBox15.Text, out b);
            if (a > 23 || b > 59 || a < 0 || b < 0)
            {
                MessageBox.Show("时间3错误");
                return;
            }
            Program.Config.Close.Close3.Hour = a;
            Program.Config.Close.Close3.Minute = b;

            Program.Config.Time.Enable = checkBox2.Checked;
            Program.Config.Close.Enable = checkBox3.Checked;

            Program.Save();

            Program.CountdownRestart = true;
            Program.TimeRestart = true;

            MessageBox.Show("已保存");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Program.IsOpen == true)
            {
                Program.IsOpen = false;
                timer1.Enabled = false;
                Program.CountdownForm = new CountdownFrom();
                Program.CountdownForm.Show();
                Program.TimeForm = new TimeForm();
                Program.TimeForm.Show();
                timer2.Enabled = true;
                Hide();
            }
            timer1.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/Coloryr/Countdown");
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            Program.CountdownRestart = true;
            Program.TimeRestart = true;
            timer2.Enabled = false;
        }
    }
}
