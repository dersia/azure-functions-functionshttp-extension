using System;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.WebJobs.Extensions.FunctionsHttpClient.Bindings
{
    public class FunctionsHttpClientByteArrayBinder : IAsyncConverter<FunctionsHttpClientAttribute, byte[]>
    {
        private readonly IFunctionsHttpClient _functionsHttpClient;

        public FunctionsHttpClientByteArrayBinder(IFunctionsHttpClient functionsHttpClient)
        {
            _functionsHttpClient = functionsHttpClient;
        }

        public async Task<byte[]> ConvertAsync(FunctionsHttpClientAttribute input, CancellationToken cancellationToken)
        {
            byte[] result = null;
            switch (input.RequestMethod)
            {
                case RequestMethod.Get:
                    result = await _functionsHttpClient.GetByteArrayAsync(input.RequestUrl, input.Headers, CancellationToken.None);
                    break;
                case RequestMethod.Post:
                    result = await _functionsHttpClient.PostByteArrayAsync(input.RequestUrl, input.Body, input.Headers, CancellationToken.None);
                    break;
                case RequestMethod.Put:
                    result = await _functionsHttpClient.PutByteArrayAsync(input.RequestUrl, input.Body, input.Headers, CancellationToken.None);
                    break;
                case RequestMethod.Delete:
                    result = await _functionsHttpClient.DeleteByteArrayAsync(input.RequestUrl, input.Headers, CancellationToken.None);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(input.RequestMethod));
            }
            return result;
        }
    }
}
