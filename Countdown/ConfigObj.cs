namespace Coloryr.Countdown
{
    public enum MyLocal
    {
        左上角, 右上角, 左下角, 右下角
    }

    public enum MyColor
    {
        红色, 黄色, 蓝色, 绿色, 青色, 紫色, 黑色, 白色
    }
    public enum MyMode
    {
        关机, 休眠, 睡眠
    }
    public class CountdownObj
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }
        public MyLocal Local { get; set; }
        public MyColor Color { get; set; }
        public MyColor StringColor { get; set; }
        public string SetText { get; set; }
    }
    public class TimeObj
    {
        public bool Enable { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public MyLocal Local { get; set; }
        public MyColor TimeColor { get; set; }
        public MyColor DateColor { get; set; }
    }
    public class CloseTimeObj
    {
        public int Hour { get; set; }
        public int Minute { get; set; }
    }
    public class CloseObj
    {
        public bool Enable { get; set; }
        public MyMode CloseMode { get; set; }
        public CloseTimeObj Close1 { get; set; }
        public CloseTimeObj Close2 { get; set; }
        public CloseTimeObj Close3 { get; set; }
    }
    public class ConfigObj
    {
        public CountdownObj Countdown { get; set; }
        public TimeObj Time { get; set; }
        public CloseObj Close { get; set; }
    }
}
