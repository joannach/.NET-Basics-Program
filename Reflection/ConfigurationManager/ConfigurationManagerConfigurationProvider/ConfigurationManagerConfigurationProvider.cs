using ConfigManager.Exceptions;
using System.Configuration;

namespace ConfigManager.Providers
{
    public class ConfigurationManagerConfigurationProvider : IConfigurationProvider
    {
        public string GetValue(string settingName)
        {
            var result = ConfigurationManager.AppSettings[settingName];
            if (result == null)
                throw new ConfigurationKeyNotFound("Configuration key not found");

            return result;
        }

        public void SetValue(string settingName, string value)
        {
            if (ConfigurationManager.AppSettings[settingName] == null)
                throw new ConfigurationKeyNotFound("Configuration key not found");

            ConfigurationManager.AppSettings[settingName] = value;
        }
    }
}
