using System;
using System.Windows.Forms;

namespace Color_yr.Countdown
{
    partial class setting_form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.comboBox5 = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.comboBox6 = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.textBox12 = new System.Windows.Forms.TextBox();
            this.textBox13 = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.textBox14 = new System.Windows.Forms.TextBox();
            this.textBox15 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(309, 224);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 25);
            this.button1.TabIndex = 2;
            this.button1.Text = "关闭程序";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(417, 224);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(103, 25);
            this.button2.TabIndex = 18;
            this.button2.Text = "保存";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(7, 58);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(104, 19);
            this.checkBox1.TabIndex = 3;
            this.checkBox1.Text = "自定义时间";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(223, 9);
            this.checkBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(89, 19);
            this.checkBox2.TabIndex = 21;
            this.checkBox2.Text = "启用时钟";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "左上角",
            "右上角",
            "左下角",
            "右下角"});
            this.comboBox1.Location = new System.Drawing.Point(81, 178);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(132, 23);
            this.comboBox1.TabIndex = 19;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "左上角",
            "右上角",
            "左下角",
            "右下角"});
            this.comboBox2.Location = new System.Drawing.Point(297, 99);
            this.comboBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(87, 23);
            this.comboBox2.TabIndex = 26;
            this.comboBox2.Tag = "";
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "高考年份设置";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(55, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "年";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(124, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "月";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(195, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(22, 15);
            this.label4.TabIndex = 9;
            this.label4.Text = "日";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 118);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 15);
            this.label5.TabIndex = 14;
            this.label5.Text = "设置长度";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(4, 149);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 15);
            this.label6.TabIndex = 16;
            this.label6.Text = "设置高度";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(4, 181);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 15);
            this.label7.TabIndex = 20;
            this.label7.Text = "显示位置";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(220, 102);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 15);
            this.label8.TabIndex = 27;
            this.label8.Text = "显示位置";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(220, 70);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 15);
            this.label9.TabIndex = 24;
            this.label9.Text = "设置高度";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(220, 39);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(67, 15);
            this.label10.TabIndex = 23;
            this.label10.Text = "设置长度";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(7, 28);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(95, 25);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "2019";
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_number_check);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(7, 82);
            this.textBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(41, 25);
            this.textBox2.TabIndex = 4;
            this.textBox2.Text = "2019";
            this.textBox2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_number_check);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(81, 82);
            this.textBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(36, 25);
            this.textBox3.TabIndex = 5;
            this.textBox3.Text = "6";
            this.textBox3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_number_check);
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(152, 82);
            this.textBox4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(36, 25);
            this.textBox4.TabIndex = 6;
            this.textBox4.Text = "7";
            this.textBox4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_number_check);
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(81, 114);
            this.textBox5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(57, 25);
            this.textBox5.TabIndex = 10;
            this.textBox5.Text = "501";
            this.textBox5.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_number_check);
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(81, 145);
            this.textBox6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(57, 25);
            this.textBox6.TabIndex = 17;
            this.textBox6.Text = "360";
            this.textBox6.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_number_check);
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(297, 66);
            this.textBox8.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(57, 25);
            this.textBox8.TabIndex = 25;
            this.textBox8.Text = "200";
            this.textBox8.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_number_check);
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(297, 35);
            this.textBox7.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(57, 25);
            this.textBox7.TabIndex = 22;
            this.textBox7.Text = "600";
            this.textBox7.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_number_check);
            // 
            // comboBox3
            // 
            this.comboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Items.AddRange(new object[] {
            "红色",
            "黄色",
            "蓝色",
            "绿色",
            "青色",
            "紫色",
            "黑色",
            "白色"});
            this.comboBox3.Location = new System.Drawing.Point(297, 196);
            this.comboBox3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(87, 23);
            this.comboBox3.TabIndex = 28;
            this.comboBox3.SelectedIndexChanged += new System.EventHandler(this.comboBox3_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(220, 200);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(67, 15);
            this.label11.TabIndex = 29;
            this.label11.Text = "字体颜色";
            // 
            // comboBox4
            // 
            this.comboBox4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Items.AddRange(new object[] {
            "红色",
            "黄色",
            "蓝色",
            "绿色",
            "青色",
            "紫色",
            "黑色",
            "白色"});
            this.comboBox4.Location = new System.Drawing.Point(297, 131);
            this.comboBox4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(87, 23);
            this.comboBox4.TabIndex = 30;
            this.comboBox4.SelectedIndexChanged += new System.EventHandler(this.comboBox4_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(220, 135);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(67, 15);
            this.label12.TabIndex = 31;
            this.label12.Text = "时钟颜色";
            // 
            // comboBox5
            // 
            this.comboBox5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox5.FormattingEnabled = true;
            this.comboBox5.Items.AddRange(new object[] {
            "红色",
            "黄色",
            "蓝色",
            "绿色",
            "青色",
            "紫色",
            "黑色",
            "白色"});
            this.comboBox5.Location = new System.Drawing.Point(297, 164);
            this.comboBox5.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBox5.Name = "comboBox5";
            this.comboBox5.Size = new System.Drawing.Size(87, 23);
            this.comboBox5.TabIndex = 32;
            this.comboBox5.SelectedIndexChanged += new System.EventHandler(this.comboBox5_SelectedIndexChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(220, 168);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(67, 15);
            this.label13.TabIndex = 33;
            this.label13.Text = "日月颜色";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(4, 206);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(112, 15);
            this.label14.TabIndex = 35;
            this.label14.Text = "自定义考试文字";
            // 
            // textBox9
            // 
            this.textBox9.Location = new System.Drawing.Point(7, 224);
            this.textBox9.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(207, 25);
            this.textBox9.TabIndex = 34;
            this.textBox9.Text = "2019";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 1000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(392, 9);
            this.checkBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(119, 19);
            this.checkBox3.TabIndex = 36;
            this.checkBox3.Text = "启用自动关机";
            this.checkBox3.UseVisualStyleBackColor = true;
            this.checkBox3.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            // 
            // comboBox6
            // 
            this.comboBox6.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox6.FormattingEnabled = true;
            this.comboBox6.Items.AddRange(new object[] {
            "关机",
            "休眠",
            "睡眠"});
            this.comboBox6.Location = new System.Drawing.Point(392, 66);
            this.comboBox6.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBox6.Name = "comboBox6";
            this.comboBox6.Size = new System.Drawing.Size(113, 23);
            this.comboBox6.TabIndex = 37;
            this.comboBox6.Tag = "";
            this.comboBox6.SelectedIndexChanged += new System.EventHandler(this.comboBox6_SelectedIndexChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(389, 39);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(67, 15);
            this.label15.TabIndex = 38;
            this.label15.Text = "关机类型";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(424, 134);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(22, 15);
            this.label16.TabIndex = 42;
            this.label16.Text = "时";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(484, 134);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(22, 15);
            this.label17.TabIndex = 43;
            this.label17.Text = "分";
            // 
            // textBox12
            // 
            this.textBox12.Location = new System.Drawing.Point(392, 130);
            this.textBox12.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new System.Drawing.Size(25, 25);
            this.textBox12.TabIndex = 39;
            this.textBox12.Text = "17";
            this.textBox12.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_number_check);
            // 
            // textBox13
            // 
            this.textBox13.Location = new System.Drawing.Point(452, 130);
            this.textBox13.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox13.Name = "textBox13";
            this.textBox13.Size = new System.Drawing.Size(25, 25);
            this.textBox13.TabIndex = 40;
            this.textBox13.Text = "15";
            this.textBox13.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_number_check);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(424, 102);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(22, 15);
            this.label19.TabIndex = 48;
            this.label19.Text = "时";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(484, 102);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(22, 15);
            this.label20.TabIndex = 49;
            this.label20.Text = "分";
            // 
            // textBox10
            // 
            this.textBox10.Location = new System.Drawing.Point(392, 99);
            this.textBox10.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(25, 25);
            this.textBox10.TabIndex = 45;
            this.textBox10.Text = "12";
            this.textBox10.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_number_check);
            // 
            // textBox11
            // 
            this.textBox11.Location = new System.Drawing.Point(452, 99);
            this.textBox11.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new System.Drawing.Size(25, 25);
            this.textBox11.TabIndex = 46;
            this.textBox11.Text = "00";
            this.textBox11.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_number_check);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(424, 165);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(22, 15);
            this.label22.TabIndex = 54;
            this.label22.Text = "时";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(484, 165);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(22, 15);
            this.label23.TabIndex = 55;
            this.label23.Text = "分";
            // 
            // textBox14
            // 
            this.textBox14.Location = new System.Drawing.Point(392, 161);
            this.textBox14.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox14.Name = "textBox14";
            this.textBox14.Size = new System.Drawing.Size(25, 25);
            this.textBox14.TabIndex = 51;
            this.textBox14.Text = "22";
            this.textBox14.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_number_check);
            // 
            // textBox15
            // 
            this.textBox15.Location = new System.Drawing.Point(452, 161);
            this.textBox15.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox15.Name = "textBox15";
            this.textBox15.Size = new System.Drawing.Size(25, 25);
            this.textBox15.TabIndex = 52;
            this.textBox15.Text = "00";
            this.textBox15.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_number_check);
            // 
            // setting_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(524, 255);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.textBox14);
            this.Controls.Add(this.textBox15);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.textBox10);
            this.Controls.Add(this.textBox11);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.textBox12);
            this.Controls.Add(this.textBox13);
            this.Controls.Add(this.comboBox6);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.checkBox3);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.textBox9);
            this.Controls.Add(this.comboBox5);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.comboBox4);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.comboBox3);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.textBox8);
            this.Controls.Add(this.textBox7);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = global::Color_yr.Countdown.Properties.Resources.Color_yr;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "setting_form";
            this.Text = "时间设置";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.setting_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private ComboBox comboBox3;
        private Label label11;
        private ComboBox comboBox4;
        private Label label12;
        private ComboBox comboBox5;
        private Label label13;
        private Label label14;
        private TextBox textBox9;
        private Timer timer1;
        private Timer timer2;
        private CheckBox checkBox3;
        private ComboBox comboBox6;
        private Label label15;
        private Label label16;
        private Label label17;
        private TextBox textBox12;
        private TextBox textBox13;
        private Label label19;
        private Label label20;
        private TextBox textBox10;
        private TextBox textBox11;
        private Label label22;
        private Label label23;
        private TextBox textBox14;
        private TextBox textBox15;
    }
}