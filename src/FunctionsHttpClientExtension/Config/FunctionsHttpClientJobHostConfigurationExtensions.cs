using System;

namespace Microsoft.Azure.WebJobs.Extensions.FunctionsHttpClient.Config
{
    public static class FunctionsHttpClientJobHostConfigurationExtensions
    {
        public static void UseFunctionsHttpClient(this JobHostConfiguration config, FunctionsHttpClientConfig functionsHttpClientConfig = null)
        {
            if (config == null)
            {
                throw new ArgumentNullException("config");
            }

            if (functionsHttpClientConfig == null)
            {
                functionsHttpClientConfig = new FunctionsHttpClientConfig();
            }

            config.RegisterExtensionConfigProvider(functionsHttpClientConfig);
        }
    }
}
