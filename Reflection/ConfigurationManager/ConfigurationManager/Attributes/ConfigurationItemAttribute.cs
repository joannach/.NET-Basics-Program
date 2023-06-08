namespace ConfigManager.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ConfigurationItemAttribute : Attribute
    {
        public string SettingName { get; set; }
        public Type ProviderType { get; set; }

        public ConfigurationItemAttribute(string settingName, Type providerType)
        {
            SettingName = settingName;
            ProviderType = providerType;
        }
    }
}
