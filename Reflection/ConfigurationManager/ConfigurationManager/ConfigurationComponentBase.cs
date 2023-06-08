using ConfigManager.Attributes;
using ConfigManager.Exceptions;
using ConfigManager.Providers;

namespace ConfigManager
{
    public class ConfigurationComponentBase
    {
        public void SaveSettings(string? filePath = "")
        {
            var properties = GetType().GetProperties();
            foreach (var property in properties)
            {
                var attribute = property.GetCustomAttributes(typeof(ConfigurationItemAttribute), false);
                if (attribute.Length > 0)
                {
                    var configAttribute = (ConfigurationItemAttribute)attribute[0];
                    var settingName = configAttribute.SettingName;
                    var value = property.GetValue(this)?.ToString();
                    var providerType = configAttribute.ProviderType;

                    if (providerType == typeof(FileConfigurationProvider))
                    {
                        if (string.IsNullOrEmpty(filePath))
                            throw new ConfigurationFilePathIsEmptyException("File path is invalid");

                        if (string.IsNullOrEmpty(value))
                            throw new ConfigurationValueIsEmptyException("Configuration value is empty");

                        var fileProvider = new FileConfigurationProvider(filePath);
                        fileProvider.SetValue(settingName, value);
                    }
                    else if (providerType == typeof(ConfigurationManagerConfigurationProvider))
                    {
                        var configManagerProvider = new ConfigurationManagerConfigurationProvider();
                        configManagerProvider.SetValue(settingName, value);
                    }
                }
            }
        }

        public void LoadSettings(string? filePath = "")
        {
            var properties = GetType().GetProperties();
            foreach (var property in properties)
            {
                var attribute = property.GetCustomAttributes(typeof(ConfigurationItemAttribute), false);
                if (attribute.Length > 0)
                {
                    var configAttribute = (ConfigurationItemAttribute)attribute[0];
                    var settingName = configAttribute.SettingName;
                    var providerType = configAttribute.ProviderType;

                    string value = null;

                    if (providerType == typeof(FileConfigurationProvider))
                    {
                        var fileProvider = new FileConfigurationProvider(filePath);
                        value = fileProvider.GetValue(settingName);
                    }
                    else if (providerType == typeof(ConfigurationManagerConfigurationProvider))
                    {
                        var configManagerProvider = new ConfigurationManagerConfigurationProvider();
                        value = configManagerProvider.GetValue(settingName);
                    }

                    if (!string.IsNullOrEmpty(value))
                    {
                        var propertyType = property.PropertyType;
                        var convertedValue = Convert.ChangeType(value, propertyType);
                        property.SetValue(this, convertedValue);
                    }
                }
            }
        }
    }
}
