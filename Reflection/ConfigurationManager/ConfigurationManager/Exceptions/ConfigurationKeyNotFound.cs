namespace ConfigManager.Exceptions
{
    public class ConfigurationKeyNotFound : Exception
    {
        public ConfigurationKeyNotFound(string message)
            : base(message)
        {
        }
    }
}
