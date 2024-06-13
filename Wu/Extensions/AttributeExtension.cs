#if !NETFRAMEWORK
using System.ComponentModel.DataAnnotations;
#endif
using System.ComponentModel;
using System.Reflection;

namespace Wu.Extensions;

/// <summary>
/// 特性的扩展
/// </summary>
public static class AttributeExtension
{
    /// <summary>
    /// 获取DisplayName
    /// 优先获取DisplayNameAttribute , 没有设置再获取DisplayAttribute
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="propName"></param>
    /// <returns></returns>
    public static string GetDisplayName<T>(this string propName)
    {
        var disp = typeof(T).GetProperties().FirstOrDefault(prop => prop.Name.Equals(propName))?.GetCustomAttribute<DisplayNameAttribute>()?.DisplayName ?? string.Empty;
#if !NETFRAMEWORK
        if (string.IsNullOrWhiteSpace(disp))
            disp = typeof(T).GetProperties().FirstOrDefault(prop => prop.Name.Equals(propName))?.GetCustomAttribute<DisplayAttribute>()?.Name ?? string.Empty;
#endif
        return disp;
    }

#if !NETFRAMEWORK
    /// <summary>
    /// 获取DisplayName
    /// 优先获取DisplayAttribute , 没有设置再获取DisplayNameAttribute
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="propName"></param>
    /// <returns></returns>
    public static string GetDisplay<T>(this string propName)
    {
        var disp = typeof(T).GetProperties().FirstOrDefault(prop => prop.Name.Equals(propName))?.GetCustomAttribute<DisplayAttribute>()?.Name ?? string.Empty;
        if (string.IsNullOrWhiteSpace(disp))
            disp = typeof(T).GetProperties().FirstOrDefault(prop => prop.Name.Equals(propName))?.GetCustomAttribute<DisplayNameAttribute>()?.DisplayName ?? string.Empty;
        return disp;
    }
    #region 另一种实现方式
    /// <summary>
    /// 获取DisplayName
    /// 优先获取DisplayNameAttribute , 没有设置再获取DisplayAttribute
    /// </summary>
    /// <param name="modelType"></param>
    /// <param name="propertyDisplayName"></param>
    /// <returns></returns>
    public static string GetDisplayName(Type modelType, string propertyDisplayName)
    {
        string disp = (TypeDescriptor.GetProperties(modelType)[propertyDisplayName]?.Attributes[typeof(DisplayNameAttribute)] as DisplayNameAttribute)?.DisplayName ?? string.Empty;
        if (string.IsNullOrWhiteSpace(disp))
        {
            disp = (TypeDescriptor.GetProperties(modelType)[propertyDisplayName]?.Attributes[typeof(DisplayAttribute)] as DisplayAttribute)?.Name ?? string.Empty;
        }
        return disp;
    }

    /// <summary>
    /// 获取DisplayName
    /// 优先获取DisplayAttribute , 没有设置再获取DisplayNameAttribute 
    /// </summary>
    /// <param name="modelType"></param>
    /// <param name="propertyDisplayName"></param>
    /// <returns></returns>
    public static string GetDisplay(Type modelType, string propertyDisplayName)
    {
        string disp = (TypeDescriptor.GetProperties(modelType)[propertyDisplayName]?.Attributes[typeof(DisplayAttribute)] as DisplayAttribute)?.Name ?? string.Empty;
        if (string.IsNullOrWhiteSpace(disp))
        {
            disp = (TypeDescriptor.GetProperties(modelType)[propertyDisplayName]?.Attributes[typeof(DisplayNameAttribute)] as DisplayNameAttribute)?.DisplayName ?? string.Empty;
        }
        return disp;
    }
    #endregion
#endif





}
