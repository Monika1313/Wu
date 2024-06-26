﻿namespace Wu.Wpf.ViewModels;

/// <summary>
/// 询问窗口 ViewModel
/// </summary>
public partial class QuestionViewModel : ObservableObject, IDialogHostAware
{
    /// <summary>
    /// 标题
    /// </summary>
    [ObservableProperty]
    string title = string.Empty;

    /// <summary>
    /// 内容
    /// </summary>
    [ObservableProperty]
    string content = string.Empty;

    public string DialogHostName { get; set; } = "Root";

    public void OnDialogOpened(IDialogParameters parameters)
    {
        //接收参数
        if (parameters.ContainsKey(nameof(Title)))
            Title = parameters.GetValue<string>(nameof(Title));
        if (parameters.ContainsKey(nameof(Content)))
            Content = parameters.GetValue<string>(nameof(Content));
    }

    /// <summary>
    /// 取消
    /// </summary>
    [RelayCommand]
    private void Cancel()
    {
        //若窗口处于打开状态则关闭
        if (!DialogHost.IsDialogOpen(DialogHostName))
            return;
        DialogHost.Close(DialogHostName, new DialogResult(ButtonResult.No));
    }

    /// <summary>
    /// 保存
    /// </summary>
    [RelayCommand]
    private void Save()
    {
        if (!DialogHost.IsDialogOpen(DialogHostName))
            return;
        DialogParameters param = new();
        //关闭窗口,并返回参数
        DialogHost.Close(DialogHostName, new DialogResult(ButtonResult.OK, param));
    }
}
