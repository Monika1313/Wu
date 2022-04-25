using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Wu.Extensions
{
    /// <summary>
    /// string扩展
    /// </summary>
    public static class StringExtention
    {
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

        /// <summary>
        /// 使用正则表达式验证字符串是否为IP
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public static bool IsIp(this string ip)
        {
            if (string.IsNullOrWhiteSpace(ip))
                return false;
            ip = ip.Trim();
            //200-249或250-255或0-199点 匹配3次 最后0-255
            return Regex.IsMatch(ip, @"^((2[0-4]\d|25[0-5]|[1]?\d?\d)\.){3}(2[0-4]\d|25[0-5]|[1]?\d\d?)$");
        }

        /// <summary>
        /// 剔除字符串中的空格
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static string RemoveSpace(this string self) => self.Replace(" ", string.Empty);


        /// <summary>
        /// 判断字符串是否包含中文
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsHasChinese(this string str)
        {
            return Regex.IsMatch(str, @"[\u4e00-\u9fa5]");
        }



        #region 字符串长度处理
        /// <summary>
        /// 按单字节字符串向左填充长度
        /// </summary>
        /// <param name="input"></param>
        /// <param name="length"></param>
        /// <param name="paddingChar"></param>
        /// <returns></returns>
        public static string PadLeftWhileDouble(this string input, int length, char paddingChar = '\0')
        {
            var singleLength = GetSingleLength(input);
            return input.PadLeft(length - singleLength + input.Length, paddingChar);
        }

        /// <summary>
        /// 获取字符串长度
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        private static int GetSingleLength(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentNullException();
            }
            return Regex.Replace(input, @"[^\x00-\xff]", "aa").Length;//计算得到该字符串对应单字节字符串的长度
        }

        /// <summary>
        /// 按单字节字符串向右填充长度
        /// </summary>
        /// <param name="input"></param>
        /// <param name="length"></param>
        /// <param name="paddingChar"></param>
        /// <returns></returns>
        public static string PadRightWhileDouble(this string input, int length, char paddingChar = '\0')
        {
            var singleLength = GetSingleLength(input);
            return input.PadRight(length - singleLength + input.Length, paddingChar);
        }

        public static string PadLeftEx(this string str, int totalByteCount, char c = ' ')
        {
            Encoding coding = Encoding.GetEncoding("gb2312");
            int dcount = 0;
            foreach (char ch in str.ToCharArray())
            {
                if (coding.GetByteCount(ch.ToString()) == 2) dcount++;
            }
            string w = str.PadRight(totalByteCount - dcount, c);
            return w;
        }

        public static string PadRightEx(this string str, int totalByteCount, char c = ' ')
        {
            Encoding coding = Encoding.GetEncoding("gb2312"); int dcount = 0;
            foreach (char ch in str.ToCharArray())
            {
                if (coding.GetByteCount(ch.ToString()) == 2) dcount++;
            }
            string w = str.PadRight(totalByteCount - dcount, c);
            return w;
        }   
        #endregion
    }
}
