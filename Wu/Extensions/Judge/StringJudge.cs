using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Wu.Extensions.Judge
{
    public static class StringJudge
    {
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
        /// 判断字符串是否包含中文
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsHasChinese(this string str)
        {
            return Regex.IsMatch(str, @"[\u4e00-\u9fa5]");
        }




    }
}
