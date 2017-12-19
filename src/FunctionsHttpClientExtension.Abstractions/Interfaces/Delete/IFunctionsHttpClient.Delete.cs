using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.WebJobs.Extensions.FunctionsHttpClient
{
    public partial interface IFunctionsHttpClient : IDisposable
    {
        #region NoResponse
        Task DeleteAsync(string requestUri, CancellationToken cancellationToken);
        Task DeleteAsync(Uri requestUri, CancellationToken cancellationToken);

        Task DeleteAsync(string requestUri, HttpHeaders requestHeaders, CancellationToken cancellationToken);
        Task DeleteAsync(Uri requestUri, HttpHeaders requestHeaders, CancellationToken cancellationToken);

        Task DeleteAsync(string requestUri, IDictionary<string, string> requestHeaders, CancellationToken cancellationToken);
        Task DeleteAsync(Uri requestUri, IDictionary<string, string> requestHeaders, CancellationToken cancellationToken);

        Task DeleteAsync(string requestUri, string requestHeaders, CancellationToken cancellationToken);
        Task DeleteAsync(Uri requestUri, string requestHeaders, CancellationToken cancellationToken);

        Task DeleteAsync(string requestUri, HttpCompletionOption completionOption, CancellationToken cancellationToken);
        Task DeleteAsync(Uri requestUri, HttpCompletionOption completionOption, CancellationToken cancellationToken);

        Task DeleteAsync(string requestUri, HttpHeaders requestHeaders, HttpCompletionOption completionOption, CancellationToken cancellationToken);
        Task DeleteAsync(Uri requestUri, HttpHeaders requestHeaders, HttpCompletionOption completionOption, CancellationToken cancellationToken);

        Task DeleteAsync(string requestUri, IDictionary<string, string> requestHeaders, HttpCompletionOption completionOption, CancellationToken cancellationToken);
        Task DeleteAsync(Uri requestUri, IDictionary<string, string> requestHeaders, HttpCompletionOption completionOption, CancellationToken cancellationToken);

        Task DeleteAsync(string requestUri, string requestHeaders, HttpCompletionOption completionOption, CancellationToken cancellationToken);
        Task DeleteAsync(Uri requestUri, string requestHeaders, HttpCompletionOption completionOption, CancellationToken cancellationToken);
        #endregion
    }
}
