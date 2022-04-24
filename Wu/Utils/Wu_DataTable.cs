using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wu.Helper
{
    /// <summary>
    /// 拓展DataTable方法
    /// </summary>
    public static class Wu_DataTable
    {
        /// <summary>
        /// 行倒序重排
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DataTable Invert(this DataTable dt)
        {
            //克隆表格结构 不复制数据
            DataTable ndt = dt.Clone();

            //获取原始表格行数据
            DataRow[] drs = dt.Select();
            
            for(int i = dt.Rows.Count; i > 0; --i)
            {
                ndt.ImportRow(dt.Rows[i-1]);
            }
            return ndt;
        }


        /// <summary>
        /// 表格转置
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
                //新表格列标题为
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
        /// 表格转置
        /// </summary>
        /// <param name="sourceDataTable">原始表</param>
        /// <returns></returns>
        public static DataTable GetTransposeDataTable(DataTable sourceDataTable)
        {
            //声明返回表
            DataTable newDataTable = new DataTable();
            int j = 1;
            //添加列 并设置标题  列标题默认为Column 1~n
            foreach (var x in sourceDataTable.Select())
            {
                //新表格列标题为
                newDataTable.Columns.Add("Column" + j.ToString(), typeof(string));
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
        /// 表格转置
        /// </summary>
        /// <param name="sourceDataTable">原始表</param>
        /// <param name="le">原始表</param>
        /// <returns></returns>
        public static DataTable GetTransposeDataTable(DataTable sourceDataTable,bool le)
        {
            //声明返回表
            DataTable newDataTable = new DataTable();
            int j = 1;
            //添加列 并设置标题  列标题默认为Column 1~n
            foreach (var x in sourceDataTable.Select())
            {
                //新表格列标题为
                newDataTable.Columns.Add("Column" + j.ToString(), typeof(string));
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
