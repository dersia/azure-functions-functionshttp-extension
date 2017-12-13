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
        public Task<byte[]> PostByteArrayAsync(string requestUri, string content, HttpHeaders requestHeaders, CancellationToken cancellationToken) => PostByteArrayAsync(requestUri, CreateContent(content, requestHeaders), cancellationToken);
        public Task<byte[]> PostByteArrayAsync(Uri requestUri, string content, HttpHeaders requestHeaders, CancellationToken cancellationToken) => PostByteArrayAsync(requestUri, CreateContent(content, requestHeaders), cancellationToken);
        public Task<byte[]> PostByteArrayAsync<S>(string requestUri, S content, HttpHeaders requestHeaders, CancellationToken cancellationToken) => PostByteArrayAsync(requestUri, CreateContent(content, requestHeaders), cancellationToken);
        public Task<byte[]> PostByteArrayAsync<S>(Uri requestUri, S content, HttpHeaders requestHeaders, CancellationToken cancellationToken) => PostByteArrayAsync(requestUri, CreateContent(content, requestHeaders), cancellationToken);
        public Task<byte[]> PostByteArrayAsync(string requestUri, string content, IDictionary<string, string> requestHeaders, CancellationToken cancellationToken) => PostByteArrayAsync(requestUri, CreateContent(content, ParseHeaders(requestHeaders)), cancellationToken);
        public Task<byte[]> PostByteArrayAsync(Uri requestUri, string content, IDictionary<string, string> requestHeaders, CancellationToken cancellationToken) => PostByteArrayAsync(requestUri, CreateContent(content, ParseHeaders(requestHeaders)), cancellationToken);
        public Task<byte[]> PostByteArrayAsync<S>(string requestUri, S content, IDictionary<string, string> requestHeaders, CancellationToken cancellationToken) => PostByteArrayAsync(requestUri, CreateContent(content, ParseHeaders(requestHeaders)), cancellationToken);
        public Task<byte[]> PostByteArrayAsync<S>(Uri requestUri, S content, IDictionary<string, string> requestHeaders, CancellationToken cancellationToken) => PostByteArrayAsync(requestUri, CreateContent(content, ParseHeaders(requestHeaders)), cancellationToken);
        public Task<byte[]> PostByteArrayAsync(string requestUri, string content, string requestHeaders, CancellationToken cancellationToken) => PostByteArrayAsync(requestUri, CreateContent(content, ParseHeaders(requestHeaders)), cancellationToken);
        public Task<byte[]> PostByteArrayAsync(Uri requestUri, string content, string requestHeaders, CancellationToken cancellationToken) => PostByteArrayAsync(requestUri, CreateContent(content, ParseHeaders(requestHeaders)), cancellationToken);
        public Task<byte[]> PostByteArrayAsync<S>(string requestUri, S content, string requestHeaders, CancellationToken cancellationToken) => PostByteArrayAsync(requestUri, CreateContent(content, ParseHeaders(requestHeaders)), cancellationToken);
        public Task<byte[]> PostByteArrayAsync<S>(Uri requestUri, S content, string requestHeaders, CancellationToken cancellationToken) => PostByteArrayAsync(requestUri, CreateContent(content, ParseHeaders(requestHeaders)), cancellationToken);
        public Task<byte[]> PostByteArrayAsync(string requestUri, string content, CancellationToken cancellationToken) => PostByteArrayAsync(requestUri, CreateContent(content, null), cancellationToken);
        public Task<byte[]> PostByteArrayAsync(Uri requestUri, string content, CancellationToken cancellationToken) => PostByteArrayAsync(requestUri, CreateContent(content, null), cancellationToken);
        public Task<byte[]> PostByteArrayAsync<S>(string requestUri, S content, CancellationToken cancellationToken) => PostByteArrayAsync(requestUri, CreateContent(content, null), cancellationToken);
        public Task<byte[]> PostByteArrayAsync<S>(Uri requestUri, S content, CancellationToken cancellationToken) => PostByteArrayAsync(requestUri, CreateContent(content, null), cancellationToken);
        public Task<byte[]> PostByteArrayAsync(string requestUri, HttpContent content, CancellationToken cancellationToken) => PostByteArrayAsync(CreateUri(requestUri), content, cancellationToken);
        public Task<byte[]> PostByteArrayAsync(Uri requestUri, HttpContent content, CancellationToken cancellationToken) => CorePostByteArrayAsync(requestUri, content, cancellationToken);
        #endregion

        #region privateMethods
        private async Task<byte[]> CorePostByteArrayAsync(Uri requestUri, HttpContent content, CancellationToken cancellationToken)
        {
            var response = await CoreSendAsync(HttpMethod.Post, requestUri, content, null, _defaultCompletionOption, cancellationToken);
            return await response.ReadAsByteArrayAsync();
        }
        #endregion
    }
}
