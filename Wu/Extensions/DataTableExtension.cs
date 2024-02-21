namespace Wu.Extensions;

public static class DataTableExtension
{
    /// <summary>
    /// 行倒序重排
    /// </summary>
    /// <param name="dt"></param>
    /// <returns></returns>
    public static DataTable Invert(this DataTable dt)
    {
        DataTable ndt = dt.Clone();               //克隆表格结构 不复制数据
        DataRow[] drs = dt.Select();              //获取原始表格行数据
        for (int i = dt.Rows.Count; i > 0; --i)
        {
            ndt.ImportRow(dt.Rows[i - 1]);
        }
        return ndt;
    }

}
