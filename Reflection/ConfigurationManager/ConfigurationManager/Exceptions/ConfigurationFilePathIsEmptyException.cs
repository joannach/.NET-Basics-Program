namespace ConfigManager.Exceptions
{
    public class ConfigurationFilePathIsEmptyException : Exception
    {
        public ConfigurationFilePathIsEmptyException(string message)
            : base(message)
        {
        }
    }
}
