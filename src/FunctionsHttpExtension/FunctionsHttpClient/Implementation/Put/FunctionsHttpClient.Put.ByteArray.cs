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
        public Task<byte[]> PutByteArrayAsync(string requestUri, string content, HttpHeaders requestHeaders, CancellationToken cancellationToken) => PutByteArrayAsync(requestUri, CreateContent(content, requestHeaders), cancellationToken);
        public Task<byte[]> PutByteArrayAsync(Uri requestUri, string content, HttpHeaders requestHeaders, CancellationToken cancellationToken) => PutByteArrayAsync(requestUri, CreateContent(content, requestHeaders), cancellationToken);
        public Task<byte[]> PutByteArrayAsync<S>(string requestUri, S content, HttpHeaders requestHeaders, CancellationToken cancellationToken) => PutByteArrayAsync(requestUri, CreateContent(content, requestHeaders), cancellationToken);
        public Task<byte[]> PutByteArrayAsync<S>(Uri requestUri, S content, HttpHeaders requestHeaders, CancellationToken cancellationToken) => PutByteArrayAsync(requestUri, CreateContent(content, requestHeaders), cancellationToken);
        public Task<byte[]> PutByteArrayAsync(string requestUri, string content, IDictionary<string, string> requestHeaders, CancellationToken cancellationToken) => PutByteArrayAsync(requestUri, CreateContent(content, ParseHeaders(requestHeaders)), cancellationToken);
        public Task<byte[]> PutByteArrayAsync(Uri requestUri, string content, IDictionary<string, string> requestHeaders, CancellationToken cancellationToken) => PutByteArrayAsync(requestUri, CreateContent(content, ParseHeaders(requestHeaders)), cancellationToken);
        public Task<byte[]> PutByteArrayAsync<S>(string requestUri, S content, IDictionary<string, string> requestHeaders, CancellationToken cancellationToken) => PutByteArrayAsync(requestUri, CreateContent(content, ParseHeaders(requestHeaders)), cancellationToken);
        public Task<byte[]> PutByteArrayAsync<S>(Uri requestUri, S content, IDictionary<string, string> requestHeaders, CancellationToken cancellationToken) => PutByteArrayAsync(requestUri, CreateContent(content, ParseHeaders(requestHeaders)), cancellationToken);
        public Task<byte[]> PutByteArrayAsync(string requestUri, string content, string requestHeaders, CancellationToken cancellationToken) => PutByteArrayAsync(requestUri, CreateContent(content, ParseHeaders(requestHeaders)), cancellationToken);
        public Task<byte[]> PutByteArrayAsync(Uri requestUri, string content, string requestHeaders, CancellationToken cancellationToken) => PutByteArrayAsync(requestUri, CreateContent(content, ParseHeaders(requestHeaders)), cancellationToken);
        public Task<byte[]> PutByteArrayAsync<S>(string requestUri, S content, string requestHeaders, CancellationToken cancellationToken) => PutByteArrayAsync(requestUri, CreateContent(content, ParseHeaders(requestHeaders)), cancellationToken);
        public Task<byte[]> PutByteArrayAsync<S>(Uri requestUri, S content, string requestHeaders, CancellationToken cancellationToken) => PutByteArrayAsync(requestUri, CreateContent(content, ParseHeaders(requestHeaders)), cancellationToken);
        public Task<byte[]> PutByteArrayAsync(string requestUri, string content, CancellationToken cancellationToken) => PutByteArrayAsync(requestUri, CreateContent(content, null), cancellationToken);
        public Task<byte[]> PutByteArrayAsync(Uri requestUri, string content, CancellationToken cancellationToken) => PutByteArrayAsync(requestUri, CreateContent(content, null), cancellationToken);
        public Task<byte[]> PutByteArrayAsync<S>(string requestUri, S content, CancellationToken cancellationToken) => PutByteArrayAsync(requestUri, CreateContent(content, null), cancellationToken);
        public Task<byte[]> PutByteArrayAsync<S>(Uri requestUri, S content, CancellationToken cancellationToken) => PutByteArrayAsync(requestUri, CreateContent(content, null), cancellationToken);
        public Task<byte[]> PutByteArrayAsync(string requestUri, HttpContent content, CancellationToken cancellationToken) => PutByteArrayAsync(CreateUri(requestUri), content, cancellationToken);
        public Task<byte[]> PutByteArrayAsync(Uri requestUri, HttpContent content, CancellationToken cancellationToken) => CorePutByteArrayAsync(requestUri, content, cancellationToken);
        #endregion

        #region privateMethods
        private async Task<byte[]> CorePutByteArrayAsync(Uri requestUri, HttpContent content, CancellationToken cancellationToken)
        {
            var response = await CoreSendAsync(HttpMethod.Put, requestUri, content, null, _defaultCompletionOption, cancellationToken);
            return await response.ReadAsByteArrayAsync();
        }
        #endregion
    }
}
