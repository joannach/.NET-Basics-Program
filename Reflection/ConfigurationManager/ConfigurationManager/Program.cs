using ConfigManager.ConfigurationComponents;
using System.Security.Policy;

namespace ConfigManager
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Demo();
        }

        public static void Demo()
        {
            var configurationComponent = new TestConfigParametersComponent();
            configurationComponent.MaxConfigSections = 10;
            configurationComponent.RegexConfigSectionNames = "test";

            configurationComponent.SaveSettings("mySet.json");
        }
    }
}