using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wu.Utils
{
    public class DataTableUtil
    {
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



        /// <summary>
        /// 表格转置 标题列为ColumnName  数据列为Column1~n
        /// </summary>
        /// <param name="dt">原始表格</param>
        /// <returns>转置后表格</returns>
        public static DataTable GetTranspose(DataTable dt)
        {
            DataTable ndt = new DataTable();
            ndt.Columns.Add("ColumnName", typeof(string));
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ndt.Columns.Add("Column" + (i + 1).ToString(), typeof(string));
            }
            foreach (DataColumn dc in dt.Columns)
            {
                DataRow drNew = ndt.NewRow();
                drNew["ColumnName"] = dc.ColumnName;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    drNew[i + 1] = dt.Rows[i][dc].ToString();
                }
                ndt.Rows.Add(drNew);
            }
            return ndt;
        }



    }
}
