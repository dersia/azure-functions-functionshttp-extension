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
        #region StringResponse
        Task<string> DeleteAsStringAsync(string requestUri, CancellationToken cancellationToken);
        Task<string> DeleteAsStringAsync(Uri requestUri, CancellationToken cancellationToken);

        Task<string> DeleteAsStringAsync(string requestUri, HttpHeaders requestHeaders, CancellationToken cancellationToken);
        Task<string> DeleteAsStringAsync(Uri requestUri, HttpHeaders requestHeaders, CancellationToken cancellationToken);

        Task<string> DeleteAsStringAsync(string requestUri, IDictionary<string, string> requestHeaders, CancellationToken cancellationToken);
        Task<string> DeleteAsStringAsync(Uri requestUri, IDictionary<string, string> requestHeaders, CancellationToken cancellationToken);

        Task<string> DeleteAsStringAsync(string requestUri, string requestHeaders, CancellationToken cancellationToken);
        Task<string> DeleteAsStringAsync(Uri requestUri, string requestHeaders, CancellationToken cancellationToken);

        Task<string> DeleteAsStringAsync(string requestUri, HttpCompletionOption completionOption, CancellationToken cancellationToken);
        Task<string> DeleteAsStringAsync(Uri requestUri, HttpCompletionOption completionOption, CancellationToken cancellationToken);

        Task<string> DeleteAsStringAsync(string requestUri, HttpHeaders requestHeaders, HttpCompletionOption completionOption, CancellationToken cancellationToken);
        Task<string> DeleteAsStringAsync(Uri requestUri, HttpHeaders requestHeaders, HttpCompletionOption completionOption, CancellationToken cancellationToken);

        Task<string> DeleteAsStringAsync(string requestUri, IDictionary<string, string> requestHeaders, HttpCompletionOption completionOption, CancellationToken cancellationToken);
        Task<string> DeleteAsStringAsync(Uri requestUri, IDictionary<string, string> requestHeaders, HttpCompletionOption completionOption, CancellationToken cancellationToken);

        Task<string> DeleteAsStringAsync(string requestUri, string requestHeaders, HttpCompletionOption completionOption, CancellationToken cancellationToken);
        Task<string> DeleteAsStringAsync(Uri requestUri, string requestHeaders, HttpCompletionOption completionOption, CancellationToken cancellationToken);
        #endregion
    }
}
