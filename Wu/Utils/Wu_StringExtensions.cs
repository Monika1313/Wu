using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Wu.Helper
{
    public static class Wu_StringExtensions
    {
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
    }
}
