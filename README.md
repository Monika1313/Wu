# 1 Wu
## 1.1 Wu.Extensions
包含一些String、DateTime等的扩展方法
## 1.2 Wu.Utils
包含Crc校验等


# 2 Wu.Wpf
|名称|功能|
|-|-|
|IsUIThread|判断是否为UI线程|
|ExecuteFun|在UI线程执行方法|
|ExecuteFunBeginInvoke|在UI线程执行方法|

## 2.1 Wu.Wpf.Converters
转换器
|名称|功能|
|-|-|
|ValueConverterBase|转换器基类|
|ReverseBool|反转Bool|
|False2Collapsed|False转换Collapsed|
|True2Collapsed|True转换Collapsed|
|Zero2Collapsed|0转换Collapsed|
|NonZero2Collapsed|非零转换Collapsed|
|StringIsNullOrWhiteSpace2Collapsed|空字符转换Collapsed|
|StringIsNullOrWhiteSpace2True|空字符转换True|
|EnumDescriptionTypeConverter|使枚举绑定值改为Description|
|[EnumBindingSourceExtension](https://github.com/Monika1313/Wu/blob/master/Wu.Wpf/Converters/EnumBindingSourceExtension.cs)|使枚举支持直接绑定|
|MergeText|合并多段文本|


## Wu.Wpf.Extensions
扩展方法
|名称|功能|
|-|-|
|PasswordExtensions|使Password支持绑定|
|ScrollViewerExtensions|使ScrollViewer自动移动到最下方|
|TextBoxExtensions|使TextBox支持获取焦点时全选|


# Wu.CodeSnippets
包含一些CodeSnippet代码段

|名称|功能|
|-|-|
|bindablebase|继承Prism.Mvvm.BindableBase基类|
|propr|声明带属性通知的属性|
|propdf|声明依赖属性|
|propdfb|声明依赖属性带回调|
|realizeINotifyPropertyChanged|继承并实现INotifyPropertyChanged接口|











