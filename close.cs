using System;
using System.Windows.Forms;

namespace Color_yr.Countdown
{
    public partial class close : Form
    {
        int time;

        public close()
        {
            InitializeComponent();           
        }

        private void close_Load(object sender, EventArgs e)
        {
            time = 20;
            label4.Text = time.ToString();
            timer1.Enabled = true;
            label1.Text = "定时已到，是否要" + setting_form.close_list[use.close_mode];
            label3.Text = "秒后自动" + setting_form.close_list[use.close_mode];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            use use = new use();
            use.CloseWindow(use.close_mode);
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            Hide();
            Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            time--;
            label4.Text = time.ToString();
            if (time == 0)
            {
                timer1.Enabled = false;
                use use = new use();
                use.CloseWindow(use.close_mode);
                Close();
            }
        }
    }
}
