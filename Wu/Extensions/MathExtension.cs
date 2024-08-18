namespace Wu.Extensions;

/// <summary>
/// System.Math 扩展
/// </summary>
public static class MathExtension
{

    public static double Round2(this double value)
    {
        return Math.Round(value, 2);
    }

    public static double Round3(this double value)
    {
        return Math.Round(value, 3);
    }



    /// <summary>
    /// 将字符串表示的字节数组 转换为字节数组
    /// </summary>
    /// <param name="msg"></param>
    /// <returns></returns>
    public static byte[] GetBytes(this string msg)
    {
        msg = msg.Replace(" ", "").Replace("-", "");
        if ((msg.Length % 2) != 0) msg += " ";
        byte[] returnBytes = new byte[msg.Length / 2];
        for (int i = 0; i < returnBytes.Length; i++)
            returnBytes[i] = Convert.ToByte(msg.Substring(i * 2, 2), 16);
        return returnBytes;
    }

}
