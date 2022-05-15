using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wu.Wpf.Mvvm;

namespace Wu.Wpf.Models
{
    /// <summary>
    /// 打开抽屉
    /// </summary>
    public class OpenDrawers : BindableBase
    {
        /// <summary>
        /// 左侧抽屉
        /// </summary>
        public bool LeftDrawer { get => _LeftDrawer; set => SetProperty(ref _LeftDrawer, value); }
        private bool _LeftDrawer;

        /// <summary>
        /// 右侧抽屉
        /// </summary>
        public bool RightDrawer { get => _RightDrawer; set => SetProperty(ref _RightDrawer, value); }
        private bool _RightDrawer;

        /// <summary>
        /// 上端抽屉
        /// </summary>
        public bool TopDrawer { get => _TopDrawer; set => SetProperty(ref _TopDrawer, value); }
        private bool _TopDrawer;

        /// <summary>
        /// 底部抽屉
        /// </summary>
        public bool BottomDrawer { get => _BottomDrawer; set => SetProperty(ref _BottomDrawer, value); }
        private bool _BottomDrawer;
    }
}
