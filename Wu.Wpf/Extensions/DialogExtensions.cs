namespace Wu.Wpf.Extensions;

/// <summary>
/// 弹窗扩展方法
/// </summary>
public static class DialogExtensions
{
    #region 询问窗口
    /// <summary>
    /// 询问窗口
    /// </summary>
    /// <param name="dialogHost">指定的DialogHost会话主机</param>
    /// <param name="title">标题</param>
    /// <param name="content">询问内容</param>
    /// <param name="dialogHostName">会话主机名称</param>
    /// <returns></returns>
    public static async Task<IDialogResult> Question(this IDialogHostService dialogHost, string title, string content, string dialogHostName = "Root")
    {
        DialogParameters param = new()
        {
            { "Title", title },
            { "Content", content },
            { "dialogHostName", dialogHostName }
        };
        var dialogResult = await dialogHost.ShowDialog("MsgView", param, dialogHostName);
        return dialogResult;
    }

    /// <summary>
    /// 询问窗口
    /// </summary>
    /// <param name="dialogHost">指定的DialogHost会话主机</param>
    /// <param name="title">标题</param>
    /// <param name="content">询问内容</param>
    /// <param name="dialogHostName">会话主机名称</param>
    /// <param name="dialogName">弹窗的名称</param>
    /// <returns></returns>
    public static async Task<IDialogResult> Question(this IDialogHostService dialogHost, string title, string content, string dialogHostName = "Root", string dialogName = "MsgView")
    {
        DialogParameters param = new()
        {
            { "Title", title },
            { "Content", content },
            { "dialogHostName", dialogHostName }
        };
        var dialogResult = await dialogHost.ShowDialog(dialogName, param, dialogHostName);
        return dialogResult;
    }
    #endregion


    #region 页面等待消息
    /// <summary>
    /// 注册等待消息 (不带消息过滤器)
    /// </summary>
    /// <param name="aggregator"></param>
    /// <param name="action"></param>
    public static void Resgiter(this IEventAggregator aggregator, Action<UpdateModel> action)
    {
        //没有过滤器
        aggregator.GetEvent<UpdateLoadingEvent>().Subscribe(action);
    }

    /// <summary>
    /// 注册等待消息 (带消息过滤器)
    /// </summary>
    /// <param name="aggregator"></param>
    /// <param name="action"></param>
    /// <param name="filterName">消息过滤器名称</param>
    public static void Resgiter(this IEventAggregator aggregator, Action<UpdateModel> action, string filterName = "Main")
    {
        //带过滤器
        aggregator.GetEvent<UpdateLoadingEvent>().Subscribe(action, ThreadOption.PublisherThread, true, (x) =>
        {
            return x.Filter.Equals(filterName);
        });
    }

    /// <summary>
    /// 推送等待消息 不带过滤器的
    /// </summary>
    /// <param name="aggregator"></param>
    /// <param name="model"></param>
    public static void UpdateLoading(this IEventAggregator aggregator, UpdateModel model)
    {
        aggregator.GetEvent<UpdateLoadingEvent>().Publish(model);
    }
    #endregion



    #region 消息发布与订阅
    /// <summary>
    /// 注册提示消息事件
    /// </summary>
    /// <param name="aggregator"></param>
    /// <param name="action"></param>
    /// <param name="filterName">过滤器名称</param>
    public static void ResgiterMessage(this IEventAggregator aggregator, Action<MessageModel> action, string filterName = "Main")
    {
        aggregator.GetEvent<MessageEvent>().Subscribe(action, ThreadOption.PublisherThread, true, (m) =>
        {
            return m.Filter.Equals(filterName);
        });
    }

    /// <summary>
    /// 发送提示消息
    /// </summary>
    /// <param name="aggregator"></param>
    /// <param name="msg"></param>
    public static void SendMessage(this IEventAggregator aggregator, string msg, string filterName = "Main")
    {
        aggregator.GetEvent<MessageEvent>().Publish(new MessageModel()
        {
            Message = msg,
            Filter = filterName
        });
    }
    #endregion
}
