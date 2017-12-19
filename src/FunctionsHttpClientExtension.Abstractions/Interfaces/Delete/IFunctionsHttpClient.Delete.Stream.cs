using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.WebJobs.Extensions.FunctionsHttpClient
{
    public partial interface IFunctionsHttpClient : IDisposable
    {
        #region StreamResponse
        Task<Stream> DeleteStreamAsync(string requestUri, CancellationToken cancellationToken);
        Task<Stream> DeleteStreamAsync(Uri requestUri, CancellationToken cancellationToken);

        Task<Stream> DeleteStreamAsync(string requestUri, HttpHeaders requestHeaders, CancellationToken cancellationToken);
        Task<Stream> DeleteStreamAsync(Uri requestUri, HttpHeaders requestHeaders, CancellationToken cancellationToken);

        Task<Stream> DeleteStreamAsync(string requestUri, IDictionary<string, string> requestHeaders, CancellationToken cancellationToken);
        Task<Stream> DeleteStreamAsync(Uri requestUri, IDictionary<string, string> requestHeaders, CancellationToken cancellationToken);

        Task<Stream> DeleteStreamAsync(string requestUri, string requestHeaders, CancellationToken cancellationToken);
        Task<Stream> DeleteStreamAsync(Uri requestUri, string requestHeaders, CancellationToken cancellationToken);

        Task<Stream> DeleteStreamAsync(string requestUri, HttpCompletionOption completionOption, CancellationToken cancellationToken);
        Task<Stream> DeleteStreamAsync(Uri requestUri, HttpCompletionOption completionOption, CancellationToken cancellationToken);

        Task<Stream> DeleteStreamAsync(string requestUri, HttpHeaders requestHeaders, HttpCompletionOption completionOption, CancellationToken cancellationToken);
        Task<Stream> DeleteStreamAsync(Uri requestUri, HttpHeaders requestHeaders, HttpCompletionOption completionOption, CancellationToken cancellationToken);

        Task<Stream> DeleteStreamAsync(string requestUri, IDictionary<string, string> requestHeaders, HttpCompletionOption completionOption, CancellationToken cancellationToken);
        Task<Stream> DeleteStreamAsync(Uri requestUri, IDictionary<string, string> requestHeaders, HttpCompletionOption completionOption, CancellationToken cancellationToken);

        Task<Stream> DeleteStreamAsync(string requestUri, string requestHeaders, HttpCompletionOption completionOption, CancellationToken cancellationToken);
        Task<Stream> DeleteStreamAsync(Uri requestUri, string requestHeaders, HttpCompletionOption completionOption, CancellationToken cancellationToken);
        #endregion
    }
}
