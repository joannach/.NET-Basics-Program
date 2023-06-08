namespace ConfigManager.Exceptions
{
    public class ConfigurationValueIsEmptyException : Exception
    {
        public ConfigurationValueIsEmptyException(string message)
            : base(message)
        {
        }
    }
}
