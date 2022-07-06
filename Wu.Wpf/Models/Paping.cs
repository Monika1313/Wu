using Wu.Wpf.Mvvm;

namespace Wu.Wpf.Models
{
    /// <summary>
    /// 分页设置
    /// </summary>
    public class Paping : BindableBase
    {
        /// <summary>
        /// 页码
        /// </summary>
        public int PageIndex { get => _PageIndex; set => SetProperty(ref _PageIndex, value); }
        private int _PageIndex = 1;

        /// <summary>
        /// 最大页数
        /// </summary>
        public int MaxPageCount { get => _MaxPageCount; set => SetProperty(ref _MaxPageCount, value); }
        private int _MaxPageCount = 1;

        /// <summary>
        /// 当前选中的按钮距离左右两个方向按钮的最大间隔（4表示间隔4个按钮，如果超过则用省略号表示）
        /// </summary>
        public int MaxPageInterval { get => _MaxPageInterval; set => SetProperty(ref _MaxPageInterval, value); }
        private int _MaxPageInterval = 5;

        /// <summary>
        /// 每页数据数量
        /// </summary>
        public int DataCountPerPage { get => _DataCountPerPage; set => SetProperty(ref _DataCountPerPage, value); }
        private int _DataCountPerPage = 100;

        /// <summary>
        /// 总数据量
        /// </summary>
        public int DataCount { get => _DataCount; set => SetProperty(ref _DataCount, value); }
        private int _DataCount = 0;
    }
}
