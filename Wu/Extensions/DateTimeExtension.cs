﻿namespace Wu.Extensions;

public static class DateTimeExtension
{
    /// <summary>
    /// 将时间转成long表示的秒
    /// </summary>
    /// <param name="dt"></param>
    /// <returns></returns>
    public static long ConvertDataTimeLong(this DateTime dt)
    {
        DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
        TimeSpan toNow = dt.Subtract(dtStart);
        long timeStamp = toNow.Ticks;
        timeStamp = long.Parse(timeStamp.ToString().Substring(0, timeStamp.ToString().Length - 4));
        return timeStamp;
    }

    /// <summary>
    /// 将long表示的秒转换为DateTime
    /// </summary>
    /// <param name="d"></param>
    /// <returns></returns>
    public static DateTime ConvertLongDateTime(long d)
    {
        DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
        long lTime = long.Parse(d + "0000");
        TimeSpan toNow = new TimeSpan(lTime);
        DateTime dtResult = dtStart.Add(toNow);
        return dtResult;
    }


    /// <summary>
    /// 时间合并
    /// </summary>
    /// <param name="date"></param>
    /// <param name="time"></param>
    /// <returns></returns>
    public static DateTime Merge(DateTime date, DateTime time)
    {
        return new DateTime(date.Year, date.Month, date.Day, time.Hour, time.Minute, time.Second);
    }


    #region 月初
    /// <summary>
    /// 根据给定时间 返回月初
    /// </summary>
    /// <param name="dateTime"></param>
    /// <returns></returns>
    public static DateTime BeginOfMonth(this DateTime dateTime)
    {
        DateTime bmonth = dateTime.AddDays(1 - dateTime.Day);
        //DateTime bmonth = System.Convert.ToDateTime(dateTime.ToString("yyyy-MM-01"));
        return bmonth;
    }

    public static DateTime BeginOfMonth(this DateTime? dateTime)
    {
        DateTime bmonth = System.Convert.ToDateTime(((DateTime)dateTime).ToString("yyyy-MM-01"));
        return bmonth;
    }
    #endregion

    #region 月末
    /// <summary>
    /// 根据给定时间 返回月末
    /// </summary>
    /// <param name="dateTime"></param>
    /// <returns></returns>
    public static DateTime EndOfMonth(this DateTime dateTime)
    {
        //DateTime emonth = System.Convert.ToDateTime(dateTime.AddMonths(1).ToString("yyyy-MM-01")).AddDays(-1);//月末
        dateTime.BeginOfMonth().AddMonths(1).AddDays(-1);
        return dateTime;
    }

    public static DateTime EndOfMonth(this DateTime? dateTime)
    {
        DateTime emonth = System.Convert.ToDateTime(((DateTime)dateTime).AddMonths(1).ToString("yyyy-MM-01")).AddDays(-1);//月末
        return emonth;
    }
    #endregion



    /// <summary>
    /// 获取指定日期时间是 第几个季度
    /// </summary>
    /// <param name="dateTime"></param>
    /// <returns></returns>
    public static int GetQuarterNum(this DateTime dateTime)
    {
        //缓存年份
        int year = dateTime.Year;
        //季度
        int quaterNum;
        //DateTime dt0 = new DateTime(year, 1, 1);
        DateTime dt1 = new(year, 4, 1);
        DateTime dt2 = new(year, 7, 1);
        DateTime dt3 = new(year, 10, 1);
        if (dateTime.CompareTo(dt1) < 0)
            quaterNum = 1;
        else if (dateTime.CompareTo(dt2) < 0)
            quaterNum = 2;
        else if (dateTime.CompareTo(dt3) < 0)
            quaterNum = 3;
        else
            quaterNum = 4;
        return quaterNum;
    }




    /// <summary>
    /// 根据年份季度返回季度初时间
    /// </summary>
    /// <param name="year">年</param>
    /// <param name="quarter">季度</param>
    public static DateTime BeginOfQuarter(int year, int quarter)
    {
        //该年该季度月初
        return quarter switch
        {
            1 => new DateTime(year, 1, 1),
            2 => new DateTime(year, 4, 1),
            3 => new DateTime(year, 7, 1),
            _ => new DateTime(year, 10, 1),
        };
    }



    /// <summary>
    /// 根据年份季度返回季度末时间
    /// </summary>
    /// <param name="year">年</param>
    /// <param name="quarter">季度</param>
    public static DateTime EndOfQuarter(int year, int quarter)
    {
        //该年该季度月初
        return quarter switch
        {
            1 => EndOfMonth(new DateTime(year, 3, 31)),
            2 => EndOfMonth(new DateTime(year, 6, 30)),
            3 => EndOfMonth(new DateTime(year, 9, 30)),
            _ => EndOfMonth(new DateTime(year, 12, 31)),
        };
    }



    #region 参考
    //DateTime dt = DateTime.Now;  //当前时间
    //DateTime startWeek = dt.AddDays(1 - Convert.ToInt32(dt.DayOfWeek.ToString("d")));  //本周周一
    //DateTime endWeek = startWeek.AddDays(6);  //本周周日

    //DateTime startMonth = dt.AddDays(1 - dt.Day);  //本月月初
    //DateTime endMonth = startMonth.AddMonths(1).AddDays(-1);  //本月月末//

    //endMonth = startMonth.AddDays((dt.AddMonths(1) - dt).Days - 1);  //本月月末
    //DateTime startQuarter = dt.AddMonths(0 - (dt.Month - 1) % 3).AddDays(1 - dt.Day);  //本季度初
    //DateTime endQuarter = startQuarter.AddMonths(3).AddDays(-1);  //本季度末

    //DateTime startYear = new DateTime(dt.Year, 1, 1);  //本年年初
    //DateTime endYear = new DateTime(dt.Year, 12, 31);  //本年年末至于昨天、明天、上周、上月、上季度、上年度等等，

    //var 上周一 = DateTime.Now.AddDays(Convert.ToInt32(1 - Convert.ToInt32(DateTime.Now.DayOfWeek)) - 7);        //上周一
    //var 上周末 = DateTime.Now.AddDays(Convert.ToInt32(1 - Convert.ToInt32(DateTime.Now.DayOfWeek)) - 7).AddDays(6);     //上周末（星期日）//下周
    //var 下周一 = DateTime.Now.AddDays(Convert.ToInt32(1 - Convert.ToInt32(DateTime.Now.DayOfWeek)) + 7);        //下周一
    //var 下周末 = DateTime.Now.AddDays(Convert.ToInt32(1 - Convert.ToInt32(DateTime.Now.DayOfWeek)) + 7).AddDays(6); //下周末 

    //DateTime.Parse(DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + "1").AddMonths(1).AddDays(-1).ToShortDateString();//最后一天
    //                                                                                                                                //巧用C#里ToString的字符格式化更简便
    //DateTime.Now.ToString("yyyy-MM-01");//本月初
    //DateTime.Parse(DateTime.Now.ToString("yyyy-MM-01")).AddMonths(1).AddDays(-1).ToShortDateString();//本月最后一天
    //DateTime.Parse(DateTime.Now.ToString("yyyy-MM-01")).AddMonths(-1).ToShortDateString();//上个月1号
    //DateTime.Parse(DateTime.Now.ToString("yyyy-MM-01")).AddDays(-1).ToShortDateString();//上个月最后一天
    //DateTime.Parse(DateTime.Now.ToString("yyyy-MM-01")).AddMonths(1).ToShortDateString();// 下个月1号
    //DateTime.Parse(DateTime.Now.ToString("yyyy-MM-01")).AddMonths(2).AddDays(-1).ToShortDateString();//下下月最后一天
    //DateTime.Now.AddDays(7).ToShortDateString();//7天后
    //DateTime.Now.AddDays(-7).ToShortDateString();//7天前
    //DateTime.Now.Date.ToShortDateString();//本年度，用ToString的字符格式化我们也很容易地算出本年度的第一天和最后一天

    //DateTime.Parse(DateTime.Now.ToString("yyyy-01-01")).ToShortDateString();//本年度第一天
    //DateTime.Parse(DateTime.Now.ToString("yyyy-01-01")).AddYears(1).AddDays(-1).ToShortDateString();//本年度最后一天

    //DateTime.Parse(DateTime.Now.ToString("yyyy-01-01")).AddYears(-1).ToShortDateString(); //上年度第一天， 
    //DateTime.Parse(DateTime.Now.ToString("yyyy-01-01")).AddDays(-1).ToShortDateString();//上年度第最后一天， 

    //DateTime.Parse(DateTime.Now.ToString("yyyy-01-01")).AddYears(1).ToShortDateString();  //下年度第一天
    //DateTime.Parse(DateTime.Now.ToString("yyyy-01-01")).AddYears(2).AddDays(-1).ToShortDateString();//下年度最后一天
    //                                                                                                //本季度，
    //DateTime.Now.AddMonths(0 - ((DateTime.Now.Month - 1) % 3)).AddDays(1 - DateTime.Now.Day);//本季度第一天； 
    //DateTime.Parse(DateTime.Now.AddMonths(3 - ((DateTime.Now.Month - 1) % 3)).ToString("yyyy-MM-01")).AddDays(-1).ToShortDateString();//本季度的最后一天
    //DateTime.Now.AddMonths(3 - ((DateTime.Now.Month - 1) % 3)).ToString("yyyy-MM-01");//下季度的第一天
    //DateTime.Parse(DateTime.Now.AddMonths(6 - ((DateTime.Now.Month - 1) % 3)).ToString("yyyy-MM-01")).AddDays(-1).ToShortDateString();// 下季度最后一天

    //DateTime.Now.AddMonths(-3 - ((DateTime.Now.Month - 1) % 3)).AddDays(1 - DateTime.Now.Day);// 上季度第一天
    //DateTime.Now.AddMonths(0 - ((DateTime.Now.Month - 1) % 3)).AddDays(1 - DateTime.Now.Day).AddDays(-1).ToShortDateString();// 上季度最后一天
    #endregion


    /// <summary>
    /// 获取时间戳 毫秒
    /// </summary>
    /// <returns></returns>
    public static long GetTimeStamp_Milliseconds()
    {
        TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
        return Convert.ToInt64(ts.TotalMilliseconds);
    }


    /// <summary>
    /// 获取时间戳 秒
    /// </summary>
    /// <returns></returns>
    public static long GetTimeStamp_Second()
    {
        TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
        return Convert.ToInt64(ts.TotalSeconds);
    }


}
