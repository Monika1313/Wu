namespace Wu.Wpf.Models;

/// <summary>
/// 系统导航菜单
/// </summary>
public class MenuBar : BindableBase
{
    /// <summary>
    /// 菜单图标
    /// </summary>
    public string? Icon { get => _Icon; set => SetProperty(ref _Icon, value); }
    private string? _Icon;

    /// <summary>
    /// 菜单名称
    /// </summary>
    public string? Title { get => _Title; set => SetProperty(ref _Title, value); }
    private string? _Title;

    /// <summary>
    /// 菜单命名空间
    /// </summary>
    public string? NameSpace { get => _NameSpace; set => SetProperty(ref _NameSpace, value); }
    private string? _NameSpace;

}
