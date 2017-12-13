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
        #region TResponse
        Task<T> PostTAsync<T>(string requestUri, HttpContent content, CancellationToken cancellationToken);
        Task<T> PostTAsync<T>(Uri requestUri, HttpContent content, CancellationToken cancellationToken);
        Task<T> PostTAsync<T>(string requestUri, string content, CancellationToken cancellationToken);
        Task<T> PostTAsync<T>(Uri requestUri, string content, CancellationToken cancellationToken);
        Task<T> PostTAsync<T,S>(string requestUri, S content, CancellationToken cancellationToken);
        Task<T> PostTAsync<T, S>(Uri requestUri, S content, CancellationToken cancellationToken);

        Task<T> PostTAsync<T>(string requestUri, string content, HttpHeaders requestHeaders, CancellationToken cancellationToken);
        Task<T> PostTAsync<T>(Uri requestUri, string content, HttpHeaders requestHeaders, CancellationToken cancellationToken);
        Task<T> PostTAsync<T, S>(string requestUri, S content, HttpHeaders requestHeaders, CancellationToken cancellationToken);
        Task<T> PostTAsync<T, S>(Uri requestUri, S content, HttpHeaders requestHeaders, CancellationToken cancellationToken);

        Task<T> PostTAsync<T>(string requestUri, string content, IDictionary<string, string> requestHeaders, CancellationToken cancellationToken);
        Task<T> PostTAsync<T>(Uri requestUri, string content, IDictionary<string, string> requestHeaders, CancellationToken cancellationToken);
        Task<T> PostTAsync<T, S>(string requestUri, S content, IDictionary<string, string> requestHeaders, CancellationToken cancellationToken);
        Task<T> PostTAsync<T, S>(Uri requestUri, S content, IDictionary<string, string> requestHeaders, CancellationToken cancellationToken);

        Task<T> PostTAsync<T>(string requestUri, string content, string requestHeaders, CancellationToken cancellationToken);
        Task<T> PostTAsync<T>(Uri requestUri, string content, string requestHeaders, CancellationToken cancellationToken);
        Task<T> PostTAsync<T, S>(string requestUri, S content, string requestHeaders, CancellationToken cancellationToken);
        Task<T> PostTAsync<T, S>(Uri requestUri, S content, string requestHeaders, CancellationToken cancellationToken);
        #endregion
    }
}
