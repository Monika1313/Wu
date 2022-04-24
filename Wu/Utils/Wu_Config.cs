using System;
using System.Configuration;

namespace Wu.Helper
{
    /// <summary>
    /// App.congif 配置文件操作
    /// </summary>
    public static class Wu_Config
    {

        #region 读取配置文件
        /// <summary>
        /// 读取配置设置
        /// </summary>
        /// <param name="settingName"></param>
        /// <returns></returns>
        public static string GetConfig(string settingName)
        {
            try
            {
                string settingString = ConfigurationManager.AppSettings[settingName].ToString();
                return settingString;
            }
            catch (Exception)
            {
                return null;
            }
        }
        #endregion




        #region 更新配置文件
        /// <summary>
        /// 更新设置 若配置无该字段则添加
        /// </summary>
        /// <param name="settingName"></param>
        /// <param name="valueName"></param>
        public static bool UpdateConfig(string settingName, string valueName)
        {
            try
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                if (ConfigurationManager.AppSettings[settingName] != null)
                {
                    config.AppSettings.Settings.Remove(settingName);
                }
                config.AppSettings.Settings.Add(settingName, valueName);
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion
    }
}
