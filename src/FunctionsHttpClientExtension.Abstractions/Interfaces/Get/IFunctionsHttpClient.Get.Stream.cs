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
        Task<Stream> GetStreamAsync(string requestUri, CancellationToken cancellationToken);
        Task<Stream> GetStreamAsync(Uri requestUri, CancellationToken cancellationToken);

        Task<Stream> GetStreamAsync(string requestUri, HttpHeaders requestHeaders, CancellationToken cancellationToken);
        Task<Stream> GetStreamAsync(Uri requestUri, HttpHeaders requestHeaders, CancellationToken cancellationToken);

        Task<Stream> GetStreamAsync(string requestUri, IDictionary<string, string> requestHeaders, CancellationToken cancellationToken);
        Task<Stream> GetStreamAsync(Uri requestUri, IDictionary<string, string> requestHeaders, CancellationToken cancellationToken);

        Task<Stream> GetStreamAsync(string requestUri, string requestHeaders, CancellationToken cancellationToken);
        Task<Stream> GetStreamAsync(Uri requestUri, string requestHeaders, CancellationToken cancellationToken);

        Task<Stream> GetStreamAsync(string requestUri, HttpCompletionOption completionOption, CancellationToken cancellationToken);
        Task<Stream> GetStreamAsync(Uri requestUri, HttpCompletionOption completionOption, CancellationToken cancellationToken);

        Task<Stream> GetStreamAsync(string requestUri, HttpHeaders requestHeaders, HttpCompletionOption completionOption, CancellationToken cancellationToken);
        Task<Stream> GetStreamAsync(Uri requestUri, HttpHeaders requestHeaders, HttpCompletionOption completionOption, CancellationToken cancellationToken);

        Task<Stream> GetStreamAsync(string requestUri, IDictionary<string, string> requestHeaders, HttpCompletionOption completionOption, CancellationToken cancellationToken);
        Task<Stream> GetStreamAsync(Uri requestUri, IDictionary<string, string> requestHeaders, HttpCompletionOption completionOption, CancellationToken cancellationToken);

        Task<Stream> GetStreamAsync(string requestUri, string requestHeaders, HttpCompletionOption completionOption, CancellationToken cancellationToken);
        Task<Stream> GetStreamAsync(Uri requestUri, string requestHeaders, HttpCompletionOption completionOption, CancellationToken cancellationToken);
        #endregion
    }
}
