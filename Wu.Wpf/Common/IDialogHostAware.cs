namespace Wu.Wpf.Common;

public interface IDialogHostAware
{
    /// <summary>
    /// 窗口名称
    /// </summary>
    public string DialogHostName { get; set; }

    /// <summary>
    /// 打开过程中执行
    /// </summary>
    /// <param name="parameters">接收参数</param>
    void OnDialogOpened(IDialogParameters parameters);

    /// <summary>
    /// 确定
    /// </summary>
    IRelayCommand SaveCommand { get;}

    /// <summary>
    /// 取消
    /// </summary>
    IRelayCommand CancelCommand { get;}
}
