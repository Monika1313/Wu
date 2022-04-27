using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wu.Extensions.Judge
{
    public static class CharJudge
    {
        /// <summary>
        /// 判断是否为操作数
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static bool IsDigit(this char self) => ".0123456789".Contains(self);

        /// <summary>
        /// 判断是否为运算符
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static bool IsOperator(this char self) => "+-*/^".Contains(self);

        /// <summary>
        /// 判断是否为字母
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static bool IsLetter(this char self) => 'a' <= self && self <= 'z' || 'A' <= self && self <= 'Z';

        /// <summary>
        /// 判断是否为做括号
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static bool IsLeftBracket(this char self) => '(' == self;

        /// <summary>
        /// 判断是否为右括号
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static bool IsRightBracket(this char self) => ')' == self;
    }
}
