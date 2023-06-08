﻿namespace ConfigManager.Providers
{
    public interface IConfigurationProvider
    {
        string GetValue(string settingName);

        void SetValue(string settingName, string value);
    }
}
