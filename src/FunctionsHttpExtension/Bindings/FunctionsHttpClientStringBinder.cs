using System;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.WebJobs.Extensions.FunctionsHttpClient.Bindings
{
    public class FunctionsHttpClientStringBinder : IAsyncConverter<FunctionsHttpClientAttribute, string>
    {
        private readonly IFunctionsHttpClient _functionsHttpClient;

        public FunctionsHttpClientStringBinder(IFunctionsHttpClient functionsHttpClient)
        {
            _functionsHttpClient = functionsHttpClient;
        }

        public async Task<string> ConvertAsync(FunctionsHttpClientAttribute input, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(input?.RequestUrl))
            {
                throw new InvalidOperationException($"{nameof(input.RequestUrl)} cannot be null");
            }
            string result = null;
            switch (input.RequestMethod)
            {
                case RequestMethod.Get:
                    result = await _functionsHttpClient.GetAsStringAsync(input.RequestUrl, input.Headers, CancellationToken.None);
                    break;
                case RequestMethod.Post:
                    result = await _functionsHttpClient.PostAsStringAsync(input.RequestUrl, input.Body, input.Headers, CancellationToken.None);
                    break;
                case RequestMethod.Put:
                    result = await _functionsHttpClient.PutAsStringAsync(input.RequestUrl, input.Body, input.Headers, CancellationToken.None);
                    break;
                case RequestMethod.Delete:
                    result = await _functionsHttpClient.DeleteAsStringAsync(input.RequestUrl, input.Headers, CancellationToken.None);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(input.RequestMethod));
            }
            return result;
        }
    }
}
