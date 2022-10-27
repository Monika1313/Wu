using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public static void ExecuteFun(Action action)
        {
            Action action2 = action;
            if (IsUIThread())
            {
                action2();
                return;
            }

            Application.Current.Dispatcher.Invoke(delegate
            {
                action2();
            });
        }

        public static void ExecuteFunBeginInvoke(Action action)
        {
            Action action2 = action;
            if (IsUIThread())
            {
                action2();
                return;
            }

            Application.Current.Dispatcher.BeginInvoke((Action)delegate
            {
                action2();
            });
        }
    }
}
