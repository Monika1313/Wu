using Newtonsoft.Json;

namespace Wu.Utils
{
    /// <summary>
    /// Json
    /// </summary>
    public static class JsonUtil
    {
        //忽略json循环引用设置
        private static JsonSerializerSettings setting = new JsonSerializerSettings
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore         //忽略循环引用
        };

        /// <summary>
        /// json序列化 忽略循环引用
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="jsonClass"></param>
        /// <returns></returns>
        public static string SeriallizeIgnoreLoop<T>(T jsonClass)
        {
            return JsonConvert.SerializeObject(jsonClass, setting);
        }

    }
}
