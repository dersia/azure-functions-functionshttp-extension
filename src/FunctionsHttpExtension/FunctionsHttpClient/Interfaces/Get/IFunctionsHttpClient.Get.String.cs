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
        #region StringResponse
        Task<string> GetAsStringAsync(string requestUri, CancellationToken cancellationToken);
        Task<string> GetAsStringAsync(Uri requestUri, CancellationToken cancellationToken);

        Task<string> GetAsStringAsync(string requestUri, HttpHeaders requestHeaders, CancellationToken cancellationToken);
        Task<string> GetAsStringAsync(Uri requestUri, HttpHeaders requestHeaders, CancellationToken cancellationToken);

        Task<string> GetAsStringAsync(string requestUri, IDictionary<string,string> requestHeaders, CancellationToken cancellationToken);
        Task<string> GetAsStringAsync(Uri requestUri, IDictionary<string, string> requestHeaders, CancellationToken cancellationToken);

        Task<string> GetAsStringAsync(string requestUri, string requestHeaders, CancellationToken cancellationToken);
        Task<string> GetAsStringAsync(Uri requestUri, string requestHeaders, CancellationToken cancellationToken);

        Task<string> GetAsStringAsync(string requestUri, HttpCompletionOption completionOption, CancellationToken cancellationToken);
        Task<string> GetAsStringAsync(Uri requestUri, HttpCompletionOption completionOption, CancellationToken cancellationToken);

        Task<string> GetAsStringAsync(string requestUri, HttpHeaders requestHeaders, HttpCompletionOption completionOption, CancellationToken cancellationToken);
        Task<string> GetAsStringAsync(Uri requestUri, HttpHeaders requestHeaders, HttpCompletionOption completionOption, CancellationToken cancellationToken);

        Task<string> GetAsStringAsync(string requestUri, IDictionary<string, string> requestHeaders, HttpCompletionOption completionOption, CancellationToken cancellationToken);
        Task<string> GetAsStringAsync(Uri requestUri, IDictionary<string, string> requestHeaders, HttpCompletionOption completionOption, CancellationToken cancellationToken);

        Task<string> GetAsStringAsync(string requestUri, string requestHeaders, HttpCompletionOption completionOption, CancellationToken cancellationToken);
        Task<string> GetAsStringAsync(Uri requestUri, string requestHeaders, HttpCompletionOption completionOption, CancellationToken cancellationToken);
        #endregion
    }
}
