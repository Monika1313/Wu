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
        /// <param name="action">需要执行的方法</param>
        public static void ExecuteFun(Action action)
        {
            //判断是UI线程还是子线程 若是子线程需要用委托
            var UiThreadId = Application.Current.Dispatcher.Thread.ManagedThreadId;       //UI线程ID
            var currentThreadId = Environment.CurrentManagedThreadId;                     //当前线程ID
            //当前线程为主线程
            if (currentThreadId == UiThreadId) { action(); }
            //当前线程为子线程
            else { Application.Current.Dispatcher.Invoke(() => { action(); }); }
        }
    }
}
