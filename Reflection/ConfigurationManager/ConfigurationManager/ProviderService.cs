using ConfigManager.Providers;
using System.Reflection;

namespace ConfigurationManager
{
    public class ProviderService
    {
        public IConfigurationProvider GetProviderByType(Type providerType, string fileName = null)
        {
            var provider = Activator.CreateInstance(providerType, fileName) as IConfigurationProvider;

            if (provider == null)
                throw new InvalidOperationException("Provider not found");

            return provider;
        }

        public IConfigurationProvider LoadConfigurationProvider(string providerDllPath, params object[] constructorArgs)
        {
            var providerAssembly = Assembly.LoadFrom(providerDllPath);
            var providerType = providerAssembly.GetTypes().FirstOrDefault(t => typeof(IConfigurationProvider).IsAssignableFrom(t));
            if (providerType != null)
            {
                var provider = Activator.CreateInstance(providerType, constructorArgs) as IConfigurationProvider;
                return provider;
            }
            return null;
        }
    }
}
