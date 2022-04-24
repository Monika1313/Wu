using System;
using System.Data;
using System.Text;
using System.Text.RegularExpressions;

namespace Wu.Helper
{
    /// <summary>
    /// Utility
    /// </summary>
    public static class Wu_Utility
    {



        /// <summary>
        /// 字符串是否为"正常"或"异常"
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool IsNormalOrAbnormal(object obj)
        {
            //null
            if (obj == null) return false;
            //获取字符串
            string value = obj.ToString().Trim();
            //为正常或异常则返回true;
            if (value == "正常" || value == "异常") return true;
            //否则返回false
            return false;
        }

        /// <summary>
        /// 字符串是否为 "是" 或 "否"
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool IsYesOrNo(object obj)
        {
            if(obj == null) return false;
            //获取字符串
            string value = obj.ToString().Trim();
            if(value == "是" || value == "否")
            {
                return true;
            }
            else
            {
                return false;
            }

        }





        #region 判断字符串是否包含中文
        //判断字符串是否包含中文
        public static bool HasChinese(this string str)
        {
            return Regex.IsMatch(str, @"[\u4e00-\u9fa5]");
        }
        #endregion




        /// <summary>
        /// 表格转置 转置后默认列标题为Column1~n
        /// </summary>
        /// <param name="sourceDataTable">原始表</param>
        /// <param name="column">原始表的column列作为转置后的标题</param>
        /// <returns></returns>
        public static DataTable GetTransposeDataTable(DataTable sourceDataTable, int column)
        {
            //声明返回表
            DataTable newDataTable = new DataTable();
            //添加列 并设置标题
            foreach (var x in sourceDataTable.Select())
            {
                newDataTable.Columns.Add(x[column].ToString(), typeof(string));
            }
            //填充数据
            foreach (DataColumn dc in sourceDataTable.Columns)
            {
                DataRow drNew = newDataTable.NewRow();
                for (int i = 0; i < sourceDataTable.Rows.Count; i++)
                {
                    drNew[i] = sourceDataTable.Rows[i][dc].ToString();
                }
                newDataTable.Rows.Add(drNew);
            }
            return newDataTable;
        }







       



    }
}
