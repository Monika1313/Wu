using System.Drawing;

namespace Wu.Utils;

/// <summary>
/// 格式转换操作
/// </summary>
public static class ConvertUtil
{
    /// <summary>
    /// 截取字节数组 并转换大小端
    /// </summary>
    /// <param name="input">字节数组</param>
    /// <param name="skip">起始位置</param>
    /// <param name="take">读取数量</param>
    /// <returns></returns>
    public static byte[] SmallBigConvert(byte[] input, int skip, int take)
    {
        byte[] arr = input.Skip(skip).Take(take).ToArray();
        Array.Reverse(arr);
        return arr;
    }


    /// <summary>
    /// 从大端数组中指定位置读取short数据
    /// </summary>
    /// <param name="data"></param>
    /// <param name="p"></param>
    /// <returns></returns>
    public static ushort GetUInt16FromBigEndianBytes(byte[] data, int p)
    {
        return BitConverter.ToUInt16(SmallBigConvert(data, p, 2), 0);
    }

    /// <summary>
    /// 从大端数组中指定位置读取Unsigned Short数据
    /// </summary>
    /// <param name="data"></param>
    /// <param name="p"></param>
    /// <returns></returns>
    public static uint GetUIntFromBigEndianBytes(byte[] data, int p)
    {
        return BitConverter.ToUInt32(SmallBigConvert(data, p, 4), 0);
    }

    /// <summary>
    /// 从大端数组指定位置读取unsigned Long数据
    /// </summary>
    /// <param name="data"></param>
    /// <param name="p"></param>
    /// <returns></returns>
    public static ulong GetUInt64FromBigEndianBytes(byte[] data, int p)
    {
        return BitConverter.ToUInt64(SmallBigConvert(data, p, 8), 0);
    }

    /// <summary>
    /// 从大端数组指定位置读取short数据
    /// </summary>
    /// <param name="data"></param>
    /// <param name="p"></param>
    /// <returns></returns>
    public static short GetInt16FromBigEndianBytes(byte[] data, int p)
    {
        return BitConverter.ToInt16(SmallBigConvert(data, p, 2), 0);
    }

    /// <summary>
    /// 从大端数组指定位置读取Int数据
    /// </summary>
    /// <param name="data"></param>
    /// <param name="p"></param>
    /// <returns></returns>
    public static int GetIntFromBigEndianBytes(byte[] data, int p)
    {
        return BitConverter.ToInt32(SmallBigConvert(data, p, 4), 0);
    }

    /// <summary>
    /// 从大端数组指定位置读取Long数据
    /// </summary>
    /// <param name="data"></param>
    /// <param name="p"></param>
    /// <returns></returns>
    public static long GetInt64FromBigEndianBytes(byte[] data, int p)
    {
        return BitConverter.ToInt64(SmallBigConvert(data, p, 8), 0);
    }


    /// <summary>
    /// 从大端数组中指定位置读取float数据
    /// </summary>
    /// <param name="data"></param>
    /// <param name="p">指示数据在数组中的起始位置</param>
    /// <returns></returns>
    public static float GetFloatFromBigEndianBytes(byte[] data, int p)
    {
        return BitConverter.ToSingle(SmallBigConvert(data, p, 4), 0);
    }


    /// <summary>
    /// 从大端数组指定位置读取Double数据
    /// </summary>
    /// <param name="data"></param>
    /// <param name="p"></param>
    /// <returns></returns>
    public static double GetDouble(byte[] data, int p)
    {
        return BitConverter.ToDouble(SmallBigConvert(data, p, 8), 0);
    }












    /// <summary>
    /// 尝试将obj 转换为 decimal,无法转换的返回null
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public static decimal? TryParse_Decimal(this object obj)
    {
        return decimal.TryParse(obj.ToString(), out decimal parsed) ? parsed as decimal? : null;
    }


    /// <summary>
    /// 尝试将obj装换为DateTime , 无法转换的返回null
    /// </summary>
    /// <param name="obj">待转换的object</param>
    /// <returns></returns>
    public static DateTime? TryParse_DateTime(this object obj)
    {
        var dt = DateTime.TryParse(obj.ToString(), out DateTime parsed) ? parsed as DateTime? : null;              //尝试直接转换为DateTime
        if (dt == null)                                                                                             //转换失败 尝试使用ole转换
        {
            double? oleTime = obj.TryParse_Double();
            if (oleTime == null)
            {
                return null;
            }
            else
            {
                return DateTime.FromOADate((double)oleTime);
            }
        }
        else
        {
            return dt;
        }
    }


    /// <summary>
    /// 尝试将obj 转换为 int,无法转换的返回null
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public static int? TryParse_Int(this object obj)
    {
        return int.TryParse(obj.ToString(), out int parsed) ? parsed as int? : null;
    }



    /// <summary>
    /// 尝试将obj 转换为 double,无法转换的返回null
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public static double? TryParse_Double(this object obj)
    {
        return double.TryParse(obj.ToString(), out double parsed) ? parsed as double? : null;
    }



    /// <summary>
    /// 尝试将obj 转换为 double, 转换失败的返回0
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public static double TryParse_Double_0(this object obj)
    {
        return double.TryParse(obj.ToString(), out double parsed) ? parsed : 0;
    }





    /// <summary>
    ///  RGB转HSB
    /// </summary>
    /// <param name="red">红色值</param>
    /// <param name="green">绿色值</param>
    /// <param name="blue">蓝色值</param>
    /// <returns>返回：HSB值集合</returns>
    public static List<float> RGB2HSB(int red, int green, int blue)
    {
        List<float> hsbList = new List<float>();
        System.Drawing.Color dColor = System.Drawing.Color.FromArgb(red, green, blue);
        hsbList.Add(dColor.GetHue());
        hsbList.Add(dColor.GetSaturation());
        hsbList.Add(dColor.GetBrightness());
        return hsbList;
    }


    /// <summary>
    /// HSB转RGB
    /// </summary>
    /// <param name="hue">色调</param>
    /// <param name="saturation">饱和度</param>
    /// <param name="brightness">亮度</param>
    /// <returns>返回：Color</returns>
    public static Color HSB2RGB(float hue, float saturation, float brightness)
    {
        int r = 0, g = 0, b = 0;
        if (saturation == 0)
        {
            r = g = b = (int)(brightness * 255.0f + 0.5f);
        }
        else
        {
            float h = (hue - (float)Math.Floor(hue)) * 6.0f;
            float f = h - (float)Math.Floor(h);
            float p = brightness * (1.0f - saturation);
            float q = brightness * (1.0f - saturation * f);
            float t = brightness * (1.0f - (saturation * (1.0f - f)));
            switch ((int)h)
            {
                case 0:
                    r = (int)(brightness * 255.0f + 0.5f);
                    g = (int)(t * 255.0f + 0.5f);
                    b = (int)(p * 255.0f + 0.5f);
                    break;
                case 1:
                    r = (int)(q * 255.0f + 0.5f);
                    g = (int)(brightness * 255.0f + 0.5f);
                    b = (int)(p * 255.0f + 0.5f);
                    break;
                case 2:
                    r = (int)(p * 255.0f + 0.5f);
                    g = (int)(brightness * 255.0f + 0.5f);
                    b = (int)(t * 255.0f + 0.5f);
                    break;
                case 3:
                    r = (int)(p * 255.0f + 0.5f);
                    g = (int)(q * 255.0f + 0.5f);
                    b = (int)(brightness * 255.0f + 0.5f);
                    break;
                case 4:
                    r = (int)(t * 255.0f + 0.5f);
                    g = (int)(p * 255.0f + 0.5f);
                    b = (int)(brightness * 255.0f + 0.5f);
                    break;
                case 5:
                    r = (int)(brightness * 255.0f + 0.5f);
                    g = (int)(p * 255.0f + 0.5f);
                    b = (int)(q * 255.0f + 0.5f);
                    break;
            }
        }
        return Color.FromArgb(Convert.ToByte(255), Convert.ToByte(r), Convert.ToByte(g), Convert.ToByte(b));
    }










}
