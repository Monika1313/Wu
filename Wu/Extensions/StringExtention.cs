using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
        /// 剔除字符串中的空格
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static string RemoveSpace(this string self) => self.Replace(" ", string.Empty);


        /// <summary>
        /// 字符串MD5加密
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static string GetMD5(this string data)
        {
            //验证字符串
            if (string.IsNullOrEmpty(data))
                throw new ArgumentNullException(nameof(data));
            //加密
            var hash = MD5.Create().ComputeHash(Encoding.Default.GetBytes(data));
            return Convert.ToBase64String(hash);
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
