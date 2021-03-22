using System;
using System.Windows.Forms;

namespace Coloryr.Countdown.Froms
{
    public partial class CloseFrom : Form
    {
        int time;

        public CloseFrom()
        {
            InitializeComponent();
        }

        private void close_Load(object sender, EventArgs e)
        {
            time = 20;
            label4.Text = time.ToString();
            timer1.Enabled = true;
            label1.Text = "定时已到，是否要" + Program.Config.Close.CloseMode;
            label3.Text = "秒后自动" + Program.Config.Close.CloseMode;
            Program.IsClose = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            Utils.CloseWindow();
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            Hide();
            Close();
            Program.IsClose = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            time--;
            label4.Text = time.ToString();
            if (time == 0)
            {
                timer1.Enabled = false;
                Utils.CloseWindow();
                Close();
            }
        }
    }
}
