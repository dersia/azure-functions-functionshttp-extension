using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.WebJobs.Extensions.FunctionsHttpClient.Bindings
{
    public class FunctionsHttpClientStreamBinder : IAsyncConverter<FunctionsHttpClientAttribute, Stream>
    {
        private readonly IFunctionsHttpClient _functionsHttpClient;

        public FunctionsHttpClientStreamBinder(IFunctionsHttpClient functionsHttpClient)
        {
            _functionsHttpClient = functionsHttpClient;
        }

        public async Task<Stream> ConvertAsync(FunctionsHttpClientAttribute input, CancellationToken cancellationToken)
        {
            if(string.IsNullOrWhiteSpace(input?.RequestUrl))
            {
                throw new InvalidOperationException($"{nameof(input.RequestUrl)} cannot be null");
            }
            Stream result = null;
            switch (input.RequestMethod)
            {
                case RequestMethod.Get:
                    result = await _functionsHttpClient.GetStreamAsync(input.RequestUrl, input.Headers, CancellationToken.None);
                    break;
                case RequestMethod.Post:
                    result = await _functionsHttpClient.PostStreamAsync(input.RequestUrl, input.Body, input.Headers, CancellationToken.None);
                    break;
                case RequestMethod.Put:
                    result = await _functionsHttpClient.PutStreamAsync(input.RequestUrl, input.Body, input.Headers, CancellationToken.None);
                    break;
                case RequestMethod.Delete:
                    result = await _functionsHttpClient.DeleteStreamAsync(input.RequestUrl, input.Headers, CancellationToken.None);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(input.RequestMethod));
            }
            return result;
        }
    }
}
