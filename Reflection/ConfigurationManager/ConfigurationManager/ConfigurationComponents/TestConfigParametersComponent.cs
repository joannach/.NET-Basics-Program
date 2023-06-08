using ConfigManager;
using ConfigManager.Attributes;
using ConfigManager.Providers;

namespace ConfigManager.ConfigurationComponents
{
    public class TestConfigParametersComponent : ConfigurationComponentBase
    {

        [ConfigurationItem("MaxConfigSections", typeof(FileConfigurationProvider))]
        public int MaxConfigSections { get; set; }

        [ConfigurationItem("RegexConfigSectionNames", typeof(FileConfigurationProvider))]
        public string RegexConfigSectionNames { get; set; }
    }
}
