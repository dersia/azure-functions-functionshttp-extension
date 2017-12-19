using Microsoft.Azure.WebJobs.Extensions.FunctionsHttpClient.Bindings;
using Microsoft.Azure.WebJobs.Extensions.FunctionsHttpClient.Config;

namespace Microsoft.Azure.WebJobs.Extensions.FunctionsHttpClient.Converter
{
    public class AsyncCollectorConverter<T> : IConverter<FunctionsHttpClientAttribute, IAsyncCollector<T>>
    {
        private readonly FunctionsHttpClientConfig _config;

        public AsyncCollectorConverter(FunctionsHttpClientConfig config)
        {
            _config = config;
        }

        public IAsyncCollector<T> Convert(FunctionsHttpClientAttribute input) => new FunctionsHttpClientCollectorBinder<T>(_config.CreateContext(input));
    }
}
