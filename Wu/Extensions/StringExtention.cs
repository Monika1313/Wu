﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Wu.Extensions
{
    /// <summary>
    /// string拓展
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

    }
}