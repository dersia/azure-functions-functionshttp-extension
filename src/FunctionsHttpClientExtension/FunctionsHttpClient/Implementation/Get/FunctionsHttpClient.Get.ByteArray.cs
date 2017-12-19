using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.WebJobs.Extensions.FunctionsHttpClient.FunctionsHttpClient
{
    public sealed partial class FunctionsHttpClient : IFunctionsHttpClient
    {
        #region publicMethods
        public Task<byte[]> GetByteArrayAsync(string requestUri, CancellationToken cancellationToken) => GetByteArrayAsync(requestUri, _defualtHeaders, _defaultCompletionOption, cancellationToken);
        public Task<byte[]> GetByteArrayAsync(Uri requestUri, CancellationToken cancellationToken) => GetByteArrayAsync(requestUri, _defualtHeaders, _defaultCompletionOption, cancellationToken);
        public Task<byte[]> GetByteArrayAsync(string requestUri, IDictionary<string, string> requestHeaders, CancellationToken cancellationToken) => GetByteArrayAsync(requestUri, ParseHeaders(requestHeaders), _defaultCompletionOption, cancellationToken);
        public Task<byte[]> GetByteArrayAsync(Uri requestUri, IDictionary<string, string> requestHeaders, CancellationToken cancellationToken) => GetByteArrayAsync(requestUri, ParseHeaders(requestHeaders), _defaultCompletionOption, cancellationToken);
        public Task<byte[]> GetByteArrayAsync(string requestUri, string requestHeaders, CancellationToken cancellationToken) => GetByteArrayAsync(requestUri, ParseHeaders(requestHeaders), _defaultCompletionOption, cancellationToken);
        public Task<byte[]> GetByteArrayAsync(Uri requestUri, string requestHeaders, CancellationToken cancellationToken) => GetByteArrayAsync(requestUri, ParseHeaders(requestHeaders), _defaultCompletionOption, cancellationToken);
        public Task<byte[]> GetByteArrayAsync(string requestUri, HttpHeaders requestHeaders, CancellationToken cancellationToken) => GetByteArrayAsync(requestUri, requestHeaders, _defaultCompletionOption, cancellationToken);
        public Task<byte[]> GetByteArrayAsync(Uri requestUri, HttpHeaders requestHeaders, CancellationToken cancellationToken) => GetByteArrayAsync(requestUri, requestHeaders, _defaultCompletionOption, cancellationToken);
        public Task<byte[]> GetByteArrayAsync(string requestUri, HttpCompletionOption completionOption, CancellationToken cancellationToken) => GetByteArrayAsync(requestUri, _defualtHeaders, completionOption, cancellationToken);
        public Task<byte[]> GetByteArrayAsync(Uri requestUri, HttpCompletionOption completionOption, CancellationToken cancellationToken) => GetByteArrayAsync(requestUri, _defualtHeaders, completionOption, cancellationToken);
        public Task<byte[]> GetByteArrayAsync(string requestUri, IDictionary<string, string> requestHeaders, HttpCompletionOption completionOption, CancellationToken cancellationToken) => GetByteArrayAsync(requestUri, ParseHeaders(requestHeaders), completionOption, cancellationToken);
        public Task<byte[]> GetByteArrayAsync(Uri requestUri, IDictionary<string, string> requestHeaders, HttpCompletionOption completionOption, CancellationToken cancellationToken) => GetByteArrayAsync(requestUri, ParseHeaders(requestHeaders), completionOption, cancellationToken);
        public Task<byte[]> GetByteArrayAsync(string requestUri, string requestHeaders, HttpCompletionOption completionOption, CancellationToken cancellationToken) => GetByteArrayAsync(requestUri, ParseHeaders(requestHeaders), completionOption, cancellationToken);
        public Task<byte[]> GetByteArrayAsync(Uri requestUri, string requestHeaders, HttpCompletionOption completionOption, CancellationToken cancellationToken) => GetByteArrayAsync(requestUri, ParseHeaders(requestHeaders), completionOption, cancellationToken);
        public Task<byte[]> GetByteArrayAsync(string requestUri, HttpHeaders requestHeaders, HttpCompletionOption completionOption, CancellationToken cancellationToken) => GetByteArrayAsync(CreateUri(requestUri), requestHeaders, completionOption, cancellationToken);
        public Task<byte[]> GetByteArrayAsync(Uri requestUri, HttpHeaders requestHeaders, HttpCompletionOption completionOption, CancellationToken cancellationToken) => CoreGetByteArrayAsync(requestUri, requestHeaders, completionOption, cancellationToken);
        #endregion

        #region privateMethods
        private async Task<byte[]> CoreGetByteArrayAsync(Uri requestUri, HttpHeaders requestHeaders, HttpCompletionOption completionOption, CancellationToken cancellationToken)
        {
            var response = await CoreSendAsync(HttpMethod.Get, requestUri, requestHeaders, completionOption, cancellationToken);
            return await response.ReadAsByteArrayAsync();
        }
        #endregion
    }
}
