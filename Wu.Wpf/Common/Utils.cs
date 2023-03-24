using System;
using System.Windows;

namespace Wu.Wpf.Common
{
    public static class Utils
    {
        /// <summary>
        /// 判断当前线程是否为UI线程
        /// </summary>
        /// <returns></returns>
        public static bool IsUIThread()
        {
            var UiThreadId = Application.Current.Dispatcher.Thread.ManagedThreadId;       //UI线程ID
            var currentThreadId = Environment.CurrentManagedThreadId;                     //当前线程
            //是UI线程
            if (UiThreadId.Equals(currentThreadId))
                return true;
            //不是UI线程
            return false;
        }

        /// <summary>
        /// 执行方法 无关UI线程和子线程
        /// </summary>
        /// <param name="action">执行的方法</param>
        public static void ExecuteFun(Action action)
        {
            //当前线程为主线程 直接执行
            if (IsUIThread()) { action(); }
            //当前线程为子线程 委托UI线程执行
            else { Application.Current.Dispatcher.Invoke(() => { action(); }); }
        }

        /// <summary>
        /// 执行方法 无关UI线程和子线程
        /// </summary>
        /// <param name="action">执行的方法</param>
        public static void ExecuteFunBeginInvoke(Action action)
        {
            //当前线程为主线程 直接执行
            if (IsUIThread()) { action(); }
            //当前线程为子线程 委托UI线程执行
            else { Application.Current.Dispatcher.BeginInvoke(() => { action(); }); }
        }


        /// <summary>
        /// 计时方法所用的时间
        /// </summary>
        /// <param name="action"></param>
        public static double ElapsedTime(Action action)
        {
            System.Diagnostics.Stopwatch sw = new(); 
            sw.Start();
            action();
            sw.Stop();
            return sw.ElapsedMilliseconds;
        }
    }
}
