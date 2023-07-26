using Prism.Events;

namespace Wu.Wpf.Events
{
    /// <summary>
    /// 数据更新模型
    /// </summary>
    public class UpdateModel
    {
        /// <summary>
        /// 数据更新窗口是否打开
        /// </summary>
        public bool IsOpen { get; set; }

        /// <summary>
        /// 过滤器
        /// </summary>
        public string Filter { get; set; } = "Main";
    }

    public class UpdateLoadingEvent : PubSubEvent<UpdateModel>
    {

    }
}
