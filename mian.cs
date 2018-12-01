using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

namespace Color_yr.Countdown
{
    static class Program
    {
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
            use.start();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new setting_form());
        }
    }
}
