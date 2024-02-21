using System.Runtime.InteropServices;

namespace Wu.Utils;

internal class User32Util

{

    [DllImport("User32.dll", CharSet = CharSet.Auto)]
    public static extern int GetWindowThreadProcessId(IntPtr hwnd, out int ID);      //通过窗口句柄获取进程ID


    [DllImport("user32.dll", SetLastError = true)]
    public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);                   //查找窗口



    [DllImport("user32.dll", EntryPoint = "FindWindowEx")]
    public static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);


    [DllImport("user32.dll")]
    public static extern int SendMessage(IntPtr hwnd, uint wMsg, int wParam, int lParam);

    [DllImport("USER32.DLL")]
    public static extern bool SetForegroundWindow(IntPtr hwnd);                                               //激活窗口

    [DllImport("User32.dll")]
    public static extern int PostMessage(IntPtr A_0, uint A_1, int A_2, int A_3);

    [DllImport("User32.dll")]
    public static extern int PostMessage(IntPtr A_0, uint A_1, int A_2, IntPtr A_3);

    [DllImport("user32.dll")]
    public static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);                //键盘模拟操作


    [DllImport("user32.dll")]
    public static extern int SetCursorPos(int x, int y);          //设置鼠标光标位置



    //private const int MOUSEEVENTF_ABSOLUTE = 0x8000;			  //绝对坐标移动
    //private const int MOUSEEVENTF_MOVE = 0x0001;				  //鼠标发生移动
    //private const int MOUSEEVENTF_LEFTDOWN = 0x0002;			  //按下鼠标左键
    //private const int MOUSEEVENTF_LEFTUP = 0x0004;				  //松开鼠标左键
    //private const int MOUSEEVENTF_RIGHTDOWN = 0x0008;			  //按下鼠标右键
    //private const int MOUSEEVENTF_RIGHTUP = 0x0010;               //松开鼠标右键
    //private const int MOUSEEVENTF_MIDDLEDOWN = 0x0020;			  //按下鼠标中间
    //private const int MOUSEEVENTF_MIDDLEUP = 0x0040;              //按下鼠标中间
    //private const int MOUSEEVENTF_WHEEL = 0x0800;				  //鼠标滚轮移动
    [DllImport("user32")]
    public static extern IntPtr mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);         //鼠标模拟操作

    [DllImport("Kernel32.dll", CharSet = CharSet.Auto)]
    private static extern int GetSystemDefaultLocaleName([Out] StringBuilder A_0, int A_1);


    [DllImport("kernel32.dll")]
    public static extern IntPtr GetCurrentProcess();

    [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
    public static extern IntPtr GetModuleHandle(string A_0);

    [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern IntPtr GetProcAddress(IntPtr A_0, [MarshalAs(UnmanagedType.LPStr)] string A_1);

    [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool IsWow64Process(IntPtr A_0, out bool A_1);

    [DllImport("user32.dll", EntryPoint = "GetDoubleClickTime")]
    public static extern int GetDoubleClickTime();                                                             //双击的时间间隔 单位毫秒
    [DllImport("user32.dll")]
    public static extern int GetCareBinkTime();                                                                //获取光标闪烁的频率


    public const int SM_CMOUSEBUTTONS = 43;                                                                     //鼠标按键的数量
    [DllImport("user32", EntryPoint = "GetSystemMetrics")]
    public static extern int GetSystemMetrics(int intcount);                                                    //获取鼠标键数

    //[DllImport("user32")]
    //public static extern 




    #region 鼠标操作
    /// <summary>
    /// 左键点击一次
    /// </summary>
    public static void LeftMouseDownUp()
    {
        mouse_event((int)Mk.LeftDown, 0, 0, 0, 0);
        mouse_event((int)Mk.LeftUp, 0, 0, 0, 0);
    }

    /// <summary>
    /// 右键点击一次
    /// </summary>
    public static void RightMouseDownUp()
    {
        mouse_event((int)Mk.RightDown, 0, 0, 0, 0);
        mouse_event((int)Mk.RightUp, 0, 0, 0, 0);
    }

    /// <summary>
    /// 鼠标相对移动
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    public static void MouseMove(int x, int y)
    {
        mouse_event((int)Mk.Move, x, y, 0, 0);
    }

    /// <summary>
    /// 功能异常,请使用SetCursorPos()设置绝对坐标   鼠标移动到绝对位置    则dX和dy含有标准化的绝对坐标，其值在0到65535之间。事件程序将此坐标映射到显示表面。坐标（0，0）映射到显示表面的左上角，（65535，65535）映射到右下角。
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    public static void MouseAbsolute(int x, int y)
    {
        mouse_event((int)Mk.Absolute | (int)Mk.Move, x, y, 0, 0);
    }
    #endregion









    /// <summary>
    /// 按下按键
    /// </summary>
    /// <param name="key"></param>
    public static void KeyDown(Vk key)
    {
        keybd_event((byte)key, 0, 0, 0);
    }





    /// <summary>
    /// 松开按键
    /// </summary>
    /// <param name="key"></param>
    public static void KeyUp(Vk key)
    {
        keybd_event((byte)key, 0, 2, 0);
    }


    /// <summary>
    /// 按一次按键
    /// </summary>
    /// <param name="key"></param>
    public static void KeyDownUp(Vk key)
    {
        keybd_event((byte)key, 0, 0, 0);
        keybd_event((byte)key, 0, 2, 0);
    }


    /// <summary>
    /// 虚拟键码枚举
    /// </summary>
    public enum Vk : byte
    {
        Ctrl = 0x11,
        Tab = 0x09,
        V = 86,
        Backspace = 0x08,
        Enter = 0x0D
    }

    /// <summary>
    /// 虚拟鼠标操作码     各值可以使用"|"组合使用    移动方式 中间 右键 左键
    /// </summary>
    public enum Mk : int
    {
        Absolute = 0x8000,     //绝对坐标标志       需要与其他的或才能使用    dX和dy含有标准化的绝对坐标，其值在0到65535之间。坐标（0，0）映射到显示表面的左上角，（65535，65535）映射到右下角。
        AbsoluteMove = 0x8001, //鼠标绝对坐标移动   Absolute | Move
        /// <summary>
        /// 相对移动
        /// </summary>
        Move = 0x0001,       //鼠标相对坐标移动
        LeftDown = 0x0002,   //按下鼠标左键
        LeftUp = 0x0004,     //松开鼠标左键
        RightDown = 0x0008,  //按下鼠标右键
        RightUp = 0x0010,    //松开鼠标右键
        MiddleDown = 0x0020, //按下鼠标中间
        MiddleUp = 0x0040,   //松开鼠标中间
        Wheel = 0x0800       //鼠标滚轮移动
    }



    /// <summary>
    /// 按一次 Ctrl + V
    /// </summary>
    /// <returns></returns>
    public static void Ctrl_V()
    {
        KeyDown(Vk.Ctrl);
        KeyDown(Vk.V);
        KeyUp(Vk.V);
        KeyUp(Vk.Ctrl);
    }



    public static void Tab()
    {
        KeyDown(Vk.Tab);
        KeyUp(Vk.Tab);
    }



}
