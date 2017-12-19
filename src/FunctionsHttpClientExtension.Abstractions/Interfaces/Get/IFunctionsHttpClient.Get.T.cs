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
        #region TResponse
        Task<T> GetTAsync<T>(string requestUri, CancellationToken cancellationToken);
        Task<T> GetTAsync<T>(Uri requestUri, CancellationToken cancellationToken);

        Task<T> GetTAsync<T>(string requestUri, HttpHeaders requestHeaders, CancellationToken cancellationToken);
        Task<T> GetTAsync<T>(Uri requestUri, HttpHeaders requestHeaders, CancellationToken cancellationToken);

        Task<T> GetTAsync<T>(string requestUri, IDictionary<string, string> requestHeaders, CancellationToken cancellationToken);
        Task<T> GetTAsync<T>(Uri requestUri, IDictionary<string, string> requestHeaders, CancellationToken cancellationToken);

        Task<T> GetTAsync<T>(string requestUri, string requestHeaders, CancellationToken cancellationToken);
        Task<T> GetTAsync<T>(Uri requestUri, string requestHeaders, CancellationToken cancellationToken);

        Task<T> GetTAsync<T>(string requestUri, HttpCompletionOption completionOption, CancellationToken cancellationToken);
        Task<T> GetTAsync<T>(Uri requestUri, HttpCompletionOption completionOption, CancellationToken cancellationToken);

        Task<T> GetTAsync<T>(string requestUri, HttpHeaders requestHeaders, HttpCompletionOption completionOption, CancellationToken cancellationToken);
        Task<T> GetTAsync<T>(Uri requestUri, HttpHeaders requestHeaders, HttpCompletionOption completionOption, CancellationToken cancellationToken);

        Task<T> GetTAsync<T>(string requestUri, IDictionary<string, string> requestHeaders, HttpCompletionOption completionOption, CancellationToken cancellationToken);
        Task<T> GetTAsync<T>(Uri requestUri, IDictionary<string, string> requestHeaders, HttpCompletionOption completionOption, CancellationToken cancellationToken);

        Task<T> GetTAsync<T>(string requestUri, string requestHeaders, HttpCompletionOption completionOption, CancellationToken cancellationToken);
        Task<T> GetTAsync<T>(Uri requestUri, string requestHeaders, HttpCompletionOption completionOption, CancellationToken cancellationToken);
        #endregion
    }
}
