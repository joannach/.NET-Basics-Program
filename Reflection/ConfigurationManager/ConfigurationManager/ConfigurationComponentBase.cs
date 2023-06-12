using ConfigManager.Attributes;
using ConfigManager.Exceptions;
using ConfigurationManager;

namespace ConfigManager
{
    public class ConfigurationComponentBase
    {
        private readonly ProviderService providerService;

        public ConfigurationComponentBase()
        {
            providerService = new ProviderService();
        }

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
                    if (string.IsNullOrEmpty(value))
                        throw new ConfigurationValueIsEmptyException("Configuration value is empty");

                    var providerType = configAttribute.ProviderType;
                    var configProvider = providerService.GetProviderByType(providerType, filePath);

                    configProvider.SetValue(settingName, value);
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
                    var configProvider = providerService.GetProviderByType(providerType, filePath);

                    var value = configProvider.GetValue(settingName);

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
