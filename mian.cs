using System;
using System.IO;
using System.Windows.Forms;

namespace Color_yr.Countdown
{
    static class Program
    {
        public static Form time_form;
        public static Form start_form;
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]

        static void Main()
        {
            string path = Application.StartupPath;
            if (!File.Exists(path + @"\LayeredSkin.dll"))
            {
                byte[] Save = Properties.Resources.LayeredSkin;
                FileStream fsObj = new FileStream(path + @"\LayeredSkin.dll", FileMode.CreateNew);
                fsObj.Write(Save, 0, Save.Length);
                fsObj.Close();
                MessageBox.Show("初始化完成");
            }
            config config = new config();
            config.start();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new setting_form());
        }
    }
}
