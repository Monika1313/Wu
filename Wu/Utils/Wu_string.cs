using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Wu.Helper
{
    public static class Wu_string
    {
        /// <summary>
        /// 单引号作转义 文本显示为 \'   页面使用脚本做错误提示时,错误信息中含单引号将导致脚本格式错误 无法显示
        /// </summary>
        public static string ReplaceSingleQuote(this string str)
        {
            return str.Replace("'", "\\'");
        }


        /// <summary>
        /// 将信息封装成信息提示框
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static string LiteralAlert(this string message)
        {
            return "<script>alert('" + message.ReplaceSingleQuote() + "!')</script>";
        }


        /// <summary>
        /// 将字符串表示的字节数组 转换为字节数组
        /// 
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static byte[] GetBytes(this string msg)
        {
            msg = msg.Replace(" ", "").Replace("-","");
            if ((msg.Length % 2) != 0) msg += " ";

            byte[] returnBytes = new byte[msg.Length / 2];
            for (int i = 0; i < returnBytes.Length; i++)
                returnBytes[i] = Convert.ToByte(msg.Substring(i * 2, 2), 16);
            return returnBytes;
        }






        /// <summary>
        /// 使用正则表达式验证字符串是否为ip
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public static bool IsIp(this string ip)
        {
            if(string.IsNullOrEmpty(ip))
            {
                return false;
            }
            ip = ip.Trim();
            //正则验证
            //200-249或250-255或0-199点 匹配3次 最后0-255
            string pattern = @"^((2[0-4]\d|25[0-5]|[1]?\d?\d)\.){3}(2[0-4]\d|25[0-5]|[1]?\d\d?)$";

            //private static final String PATTERN_L2DOMAIN = "(?<=http://|\\.)[^.]*?\\.(com|cn|net|org|biz|info|cc|tv)";
            return Regex.IsMatch(ip, pattern);
        }




    }
}
