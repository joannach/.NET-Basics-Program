using ConfigManager.ConfigurationComponents;

namespace ConfigManager
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var configurationComponent = new TestConfigParametersComponent();
            configurationComponent.MaxConfigSections = 10;
            configurationComponent.RegexConfigSectionNames = "test";

            configurationComponent.SaveSettings("mySettings.json");
        }
    }
}