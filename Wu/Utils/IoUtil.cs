using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wu.Utils
{
    public class IOUtil
    {
        /// <summary>
        /// 根据文件路径返回文件夹目录
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string GetDict(string path)
        {
            //var x = path.Split('\\');
            //string 
            return "";
        }


        /// <summary>
        /// 文件目录是否存在
        /// </summary>
        /// <param name="dict"></param>
        /// <returns></returns>
        public static bool Exists(string dict)
        {
            if (Directory.Exists(dict)) return true;        //目录存在返回true
            else                                            //目录不存在创建目录 并返回false
            {
                Directory.CreateDirectory(dict);
                return false;
            }                                         //目录不存在创建目录 并返回false

        }

    }
}
