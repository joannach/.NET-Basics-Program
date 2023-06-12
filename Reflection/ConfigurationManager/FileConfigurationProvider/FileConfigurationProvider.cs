using ConfigManager.Exceptions;
using Newtonsoft.Json.Linq;
using System.Text.Json;

namespace ConfigManager.Providers
{
    public class FileConfigurationProvider : IConfigurationProvider
    {
        private readonly string filePath;

        public FileConfigurationProvider(string filePath)
        {
            this.filePath = filePath;
        }

        public Dictionary<string, string> GetSettings()
        {
            if (File.Exists(filePath))
            {
                var json = File.ReadAllText(filePath);
                return JsonSerializer.Deserialize<Dictionary<string, string>>(json);
            }

            return new Dictionary<string, string>();
        }

        public string GetValue(string settingName)
        {
            var settings = GetSettings();
            if (settings.ContainsKey(settingName))
            {
                return settings[settingName];
            }

            return null;
        }

        public void SetValue(string settingName, string value)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException(filePath);

            string json = File.ReadAllText(filePath);
            if (string.IsNullOrEmpty(json))
            {
                throw new ConfigurationValueIsEmptyException("Setting file is empty");
            }

            var jsonObject = JObject.Parse(json);
            jsonObject[settingName] = value;

            var modifiedJson = jsonObject.ToString();


            File.WriteAllText(filePath, modifiedJson);
        }
    }
}
