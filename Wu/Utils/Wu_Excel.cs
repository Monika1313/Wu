using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace Wu.Helper
{
    public static class Wu_Excel
    {


        #region 关闭Excel进程
        //关闭进程
        private static void KillExcelProcess(this Excel.Application excel)
        {
            try
            {
                if (excel != null)
                {
                    Wu_user32.GetWindowThreadProcessId(new IntPtr(excel.Hwnd), out int pid);   //根据句柄获取进程id
                    //GetWindowThreadProcessId(new IntPtr(excel.Hwnd), out int lpdwProcessId);
                    System.Diagnostics.Process.GetProcessById(pid).Kill();                     //通过进程ID获取进程 关闭进程
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Delete Excel Process Error:" + ex.Message);
            }
        }
        #endregion




        #region 读取表格数据 范围快速读取
        public static DataTable GetExcelData(string path)
        {
            DataTable dataTable = new DataTable();                                                                //声明DataTable用于返回
            Excel.Application excel = new Excel.Application                                                       //创建Excel应用
            {                                                                                                     
                Visible = false,                                                                                  //excel后台运行
                ScreenUpdating = false,                                                                           //停止更新屏幕，加快速度
                DisplayAlerts = false                                                                             //不显示弹窗警告
            };                                          //创建Excel应用                                           
            try                                                                                                   
            {                                                                                                     
                Excel.Workbook workbook = excel.Workbooks.Open(path);                                              //打开该路径的文件  获取工作簿
                Excel.Worksheet worksheet = (Excel.Worksheet)workbook.Worksheets[1];                               //指定第一个工作表
                int rowCount = worksheet.UsedRange.Rows.Count;                                                     //获取总行数
                int columnCount = worksheet.UsedRange.Columns.Count;                                               //获取总列数
                Excel.Range range = worksheet.get_Range("A1", Missing.Value);                                      //表格区域  从表格A列1行开始
                range = range.get_Resize(rowCount, columnCount);                                                   //指定区域大小
                object[,] objs = (object[,])range.Value2;                                                          //读取该区域存入二维数组
                int objsRow = objs.GetLength(0);                                                                   //二维数组行数
                int objsCol = objs.GetLength(1);                                                                   //二维数组列数
                for (int iCol = 1; iCol <= objsCol; iCol++)                                                        //表格标题行
                {
                    dataTable.Columns.Add(objs[1, iCol] != null ? objs[1, iCol].ToString() : iCol.ToString());
                }                                            //表格标题行
                
                for (int iRow = 2; iRow <= objsRow; iRow++)                                               //读取表格信息
                {
                    DataRow dr = dataTable.NewRow();                                                      //新建行
                    for (int iCol = 1; iCol <= objsCol; iCol++)
                    {
                        try
                        {
                            dr[iCol - 1] = objs[iRow, iCol] != null ? objs[iRow, iCol].ToString().Trim() : string.Empty;
                        }
                        catch { }
                    }
                    dataTable.Rows.Add(dr);
                }                                                     //读取表格信息
                excel.Quit();                                                                                          //退出软件
                KillExcelProcess(excel);                                                                               //立即关闭进程释放内存
                return dataTable;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                excel.Quit();                                                                                        //关闭Excel软件
                KillExcelProcess(excel);                                                                             //立即关闭进程释放内存
            }
        }
        #endregion




    }
}
