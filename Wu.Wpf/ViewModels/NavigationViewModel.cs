namespace Wu.ViewModels;

/// <summary>
/// 窗口导航类
/// </summary>
public class NavigationViewModel : BindableBase, INavigationAware
{
    private readonly IContainerProvider provider;
    public readonly IEventAggregator aggregator;//事件聚合器
    public NavigationViewModel() { }

    public NavigationViewModel(IContainerProvider provider)
    {
        this.provider = provider;
        this.aggregator = provider.Resolve<IEventAggregator>();
    }

    /// <summary>
    /// 是否可导航
    /// </summary>
    /// <param name="navigationContext"></param>
    /// <returns></returns>
    public virtual bool IsNavigationTarget(NavigationContext navigationContext)
    {
        return true;
    }

    /// <summary>
    /// 导航自该窗口时触发
    /// </summary>
    /// <param name="navigationContext"></param>
    public virtual void OnNavigatedFrom(NavigationContext navigationContext)
    {

    }

    /// <summary>
    /// 导航至该窗口时触发
    /// </summary>
    /// <param name="navigationContext"></param>
    public virtual void OnNavigatedTo(NavigationContext navigationContext)
    {

    }

    /// <summary>
    /// 打开等待窗口
    /// </summary>
    /// <param name="IsOpen"></param>
    public void UpdateLoading(bool IsOpen)
    {
        aggregator.UpdateLoading(new UpdateModel()
        {
            IsOpen = IsOpen
        });
    }

    /// <summary>
    /// 打开等待窗口 默认发送至主窗口
    /// </summary>
    /// <param name="IsOpen"></param>
    public void UpdateLoading(bool IsOpen, string filter = "Main")
    {
        aggregator.UpdateLoading(new UpdateModel()
        {
            IsOpen = IsOpen,
            Filter = filter
        });
    }
}
