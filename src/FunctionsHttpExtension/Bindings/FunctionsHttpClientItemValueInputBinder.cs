using Microsoft.Azure.WebJobs.Host.Bindings;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.WebJobs.Extensions.FunctionsHttpClient.Bindings
{
    public class FunctionsHttpClientItemValueInputBinder<T> : IAsyncConverter<FunctionsHttpClientAttribute, T> where T: class
    {
        private readonly IFunctionsHttpClient _functionsHttpClient;

        public FunctionsHttpClientItemValueInputBinder(IFunctionsHttpClient functionsHttpClient)
        {
            _functionsHttpClient = functionsHttpClient;
        }

        public async Task<T> ConvertAsync(FunctionsHttpClientAttribute input, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(input?.RequestUrl))
            {
                throw new InvalidOperationException($"{nameof(input.RequestUrl)} cannot be null");
            }
            T result = null;
            switch (input.RequestMethod)
            {
                case RequestMethod.Get:
                    result = await _functionsHttpClient.GetTAsync<T>(input.RequestUrl, input.Headers, CancellationToken.None);
                    break;
                case RequestMethod.Post:
                    result = await _functionsHttpClient.PostTAsync<T>(input.RequestUrl, input.Body, input.Headers, CancellationToken.None);
                    break;
                case RequestMethod.Put:
                    result = await _functionsHttpClient.PutTAsync<T>(input.RequestUrl, input.Body, input.Headers, CancellationToken.None);
                    break;
                case RequestMethod.Delete:
                    result = await _functionsHttpClient.DeleteTAsync<T>(input.RequestUrl, input.Headers, CancellationToken.None);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(input.RequestMethod));
            }
            return result;
        }
    }
}
