using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Reflection;
using System.Linq;
using System;
using System.Collections.Generic;

namespace Wu.Extensions
{
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
            if (string.IsNullOrWhiteSpace(disp))
                disp = typeof(T).GetProperties().FirstOrDefault(prop => prop.Name.Equals(propName))?.GetCustomAttribute<DisplayAttribute>()?.Name ?? string.Empty;
            return disp;
        }

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



        ///// <summary>
        ///// 动态获取 DisplayName和Display(Name='')
        ///// </summary>
        ///// <typeparam name="T"></typeparam>
        ///// <param name="t"></param>
        ///// <returns></returns>
        //public static List<Dictionary<string, string>> GetClassDisplayNameDict<T>(T t)
        //{
        //    List<Dictionary<string, string>> dicList = new List<Dictionary<string, string>>();
        //    Dictionary<string, string> dic;
        //    Type type = t.GetType();
        //    PropertyInfo[] ProInfo = type.GetProperties();
        //    foreach (var item in ProInfo)
        //    {
        //        if (dicList.Count > 0)
        //        {
        //            //获取Display(Name='')
        //            dic = new Dictionary<string, string>();
        //            var attribute = type.GetProperty(item.Name);
        //            var displayName = attribute.GetCustomAttribute<DisplayAttribute>();
        //            dic.Add(item.Name, displayName.Name);
        //            dicList.Add(dic);
        //        }
        //        else
        //        {
        //            //获取 DisplayName
        //            dic = new Dictionary<string, string>();
        //            var attribute = type.GetProperty(item.Name);
        //            var displayName = attribute.GetCustomAttribute<DisplayNameAttribute>();
        //            dic.Add(item.Name, displayName.DisplayName);
        //            dicList.Add(dic);
        //        }
        //    }
        //    return dicList;
        //}
    }
}
