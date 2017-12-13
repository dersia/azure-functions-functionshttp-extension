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
        #region NoResponse
        Task GetAsync(string requestUri, CancellationToken cancellationToken);
        Task GetAsync(Uri requestUri, CancellationToken cancellationToken);

        Task GetAsync(string requestUri, HttpHeaders requestHeaders, CancellationToken cancellationToken);
        Task GetAsync(Uri requestUri, HttpHeaders requestHeaders, CancellationToken cancellationToken);

        Task GetAsync(string requestUri, IDictionary<string, string> requestHeaders, CancellationToken cancellationToken);
        Task GetAsync(Uri requestUri, IDictionary<string, string> requestHeaders, CancellationToken cancellationToken);

        Task GetAsync(string requestUri, string requestHeaders, CancellationToken cancellationToken);
        Task GetAsync(Uri requestUri, string requestHeaders, CancellationToken cancellationToken);

        Task GetAsync(string requestUri, HttpCompletionOption completionOption, CancellationToken cancellationToken);
        Task GetAsync(Uri requestUri, HttpCompletionOption completionOption, CancellationToken cancellationToken);

        Task GetAsync(string requestUri, HttpHeaders requestHeaders, HttpCompletionOption completionOption, CancellationToken cancellationToken);
        Task GetAsync(Uri requestUri, HttpHeaders requestHeaders, HttpCompletionOption completionOption, CancellationToken cancellationToken);

        Task GetAsync(string requestUri, IDictionary<string, string> requestHeaders, HttpCompletionOption completionOption, CancellationToken cancellationToken);
        Task GetAsync(Uri requestUri, IDictionary<string, string> requestHeaders, HttpCompletionOption completionOption, CancellationToken cancellationToken);

        Task GetAsync(string requestUri, string requestHeaders, HttpCompletionOption completionOption, CancellationToken cancellationToken);
        Task GetAsync(Uri requestUri, string requestHeaders, HttpCompletionOption completionOption, CancellationToken cancellationToken);
        #endregion
    }
}
