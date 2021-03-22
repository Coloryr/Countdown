using Coloryr.Countdown.Froms;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coloryr.Countdown
{
    static class Program
    {
        public static ConfigObj Config;
        public static Form TimeForm;
        public static Form CountdownForm;
        public static string RunLocal;

        public static bool IsClose = false;
        public static bool CountdownRestart = true;
        public static bool TimeRestart = true;
        public static bool IsOpen = true;

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            RunLocal = AppDomain.CurrentDomain.BaseDirectory;
            if (!File.Exists(RunLocal + @"\LayeredSkin.dll"))
            {
                byte[] Save = Properties.Resources.LayeredSkin;
                FileStream fsObj = new FileStream(RunLocal + @"\LayeredSkin.dll", FileMode.CreateNew);
                fsObj.Write(Save, 0, Save.Length);
                fsObj.Close();
                MessageBox.Show("初始化完成");
            }
            Config = ConfigUtils.Read(RunLocal + "config.json",
                new ConfigObj
                {
                    Countdown = new CountdownObj
                    {
                        Width = 501,
                        Height = 360,
                        Local = MyLocal.左上角,
                        Color = MyColor.黑色,
                        StringColor = MyColor.红色,
                        Year = 2021,
                        Month = 6,
                        Day = 7,
                        SetText = "距离高考还有："
                    },
                    Time = new TimeObj
                    {
                        Enable = true,
                        Width = 600,
                        Height = 260,
                        Local = MyLocal.右上角,
                        DateColor = MyColor.红色,
                        TimeColor = MyColor.红色
                    },
                    Close = new CloseObj
                    {
                        Enable = false,
                        CloseMode = MyMode.关机,
                        Close1 = new CloseTimeObj
                        {
                            Hour = 12,
                            Minute = 0
                        },
                        Close2 = new CloseTimeObj
                        {
                            Hour = 17,
                            Minute = 15
                        },
                        Close3 = new CloseTimeObj
                        {
                            Hour = 22,
                            Minute = 0
                        }
                    }
                });
            if (Config.Countdown == null)
            {
                Config.Countdown = new CountdownObj
                {
                    Width = 501,
                    Height = 360,
                    Local = MyLocal.左上角,
                    Color = MyColor.红色,
                    StringColor = MyColor.红色,
                    Year = 2021,
                    Month = 6,
                    Day = 7,
                    SetText = "距离高考还有"
                };
            }
            if (Config.Time == null)
            {
                Config.Time = new TimeObj
                {
                    Enable = true,
                    Width = 600,
                    Height = 260,
                    Local = MyLocal.右上角,
                    DateColor = MyColor.红色,
                    TimeColor = MyColor.红色
                };
            }
            if (Config.Close == null)
            {
                Config.Close = new CloseObj
                {
                    Enable = false,
                    CloseMode = MyMode.关机,
                    Close1 = new CloseTimeObj
                    {
                        Hour = 12,
                        Minute = 0
                    },
                    Close2 = new CloseTimeObj
                    {
                        Hour = 17,
                        Minute = 15
                    },
                    Close3 = new CloseTimeObj
                    {
                        Hour = 22,
                        Minute = 0
                    }
                };
            }

            DateTime time = DateTime.Now;
            if (Config.Countdown.Year > time.Year)
            {
                Config.Countdown.Year++;
            }

            CloseTimeObj obj = Config.Close.Close1;
            if (obj.Hour > 23 || obj.Hour < 0 || obj.Minute > 59 || obj.Minute < 0)
            {
                Task.Run(() =>
                {
                    MessageBox.Show("自动关机时间1错误");
                });
                Config.Close.Enable = false;
                Config.Close.Close1 = new CloseTimeObj
                {
                    Hour = 12,
                    Minute = 0
                };
            }
            obj = Config.Close.Close2;
            if (obj.Hour > 23 || obj.Hour < 0 || obj.Minute > 59 || obj.Minute < 0)
            {
                Task.Run(() =>
                {
                    MessageBox.Show("自动关机时间2错误");
                });
                Config.Close.Enable = false;
                Config.Close.Close2 = new CloseTimeObj
                {
                    Hour = 12,
                    Minute = 0
                };
            }
            obj = Config.Close.Close3;
            if (obj.Hour > 23 || obj.Hour < 0 || obj.Minute > 59 || obj.Minute < 0)
            {
                Task.Run(() =>
                {
                    MessageBox.Show("自动关机时间3错误");
                });
                Config.Close.Enable = false;
                Config.Close.Close3 = new CloseTimeObj
                {
                    Hour = 12,
                    Minute = 0
                };
            }
            Save();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SettingFrom());
        }
        public static void Save()
        {
            File.Delete(RunLocal + "config_old.json");
            File.Move(RunLocal + "config.json", RunLocal + "config_old.json");
            ConfigUtils.Write(Config, RunLocal + "config.json");
        }
    }
}
