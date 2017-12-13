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
        public Task<string> PostAsStringAsync<S>(string requestUri, S content, HttpHeaders requestHeaders, CancellationToken cancellationToken) => PostAsStringAsync(requestUri, CreateContent(content, requestHeaders), cancellationToken);
        public Task<string> PostAsStringAsync<S>(Uri requestUri, S content, HttpHeaders requestHeaders, CancellationToken cancellationToken) => PostAsStringAsync(requestUri, CreateContent(content, requestHeaders), cancellationToken);
        public Task<string> PostAsStringAsync(string requestUri, string content, IDictionary<string, string> requestHeaders, CancellationToken cancellationToken) => PostAsStringAsync(requestUri, CreateContent(content, ParseHeaders(requestHeaders)), cancellationToken);
        public Task<string> PostAsStringAsync(Uri requestUri, string content, IDictionary<string, string> requestHeaders, CancellationToken cancellationToken) => PostAsStringAsync(requestUri, CreateContent(content, ParseHeaders(requestHeaders)), cancellationToken);
        public Task<string> PostAsStringAsync<S>(string requestUri, S content, IDictionary<string, string> requestHeaders, CancellationToken cancellationToken) => PostAsStringAsync(requestUri, CreateContent(content, ParseHeaders(requestHeaders)), cancellationToken);
        public Task<string> PostAsStringAsync<S>(Uri requestUri, S content, IDictionary<string, string> requestHeaders, CancellationToken cancellationToken) => PostAsStringAsync(requestUri, CreateContent(content, ParseHeaders(requestHeaders)), cancellationToken);
        public Task<string> PostAsStringAsync(string requestUri, string content, string requestHeaders, CancellationToken cancellationToken) => PostAsStringAsync(requestUri, CreateContent(content, ParseHeaders(requestHeaders)), cancellationToken);
        public Task<string> PostAsStringAsync(Uri requestUri, string content, string requestHeaders, CancellationToken cancellationToken) => PostAsStringAsync(requestUri, CreateContent(content, ParseHeaders(requestHeaders)), cancellationToken);
        public Task<string> PostAsStringAsync<S>(string requestUri, S content, string requestHeaders, CancellationToken cancellationToken) => PostAsStringAsync(requestUri, CreateContent(content, ParseHeaders(requestHeaders)), cancellationToken);
        public Task<string> PostAsStringAsync<S>(Uri requestUri, S content, string requestHeaders, CancellationToken cancellationToken) => PostAsStringAsync(requestUri, CreateContent(content, ParseHeaders(requestHeaders)), cancellationToken);
        public Task<string> PostAsStringAsync(string requestUri, string content, HttpHeaders requestHeaders, CancellationToken cancellationToken) => PostAsStringAsync(requestUri, CreateContent(content, requestHeaders), cancellationToken);
        public Task<string> PostAsStringAsync(Uri requestUri, string content, HttpHeaders requestHeaders, CancellationToken cancellationToken) => PostAsStringAsync(requestUri, CreateContent(content, requestHeaders), cancellationToken);
        public Task<string> PostAsStringAsync(string requestUri, string content, CancellationToken cancellationToken) => PostAsStringAsync(requestUri, CreateContent(content, null), cancellationToken);
        public Task<string> PostAsStringAsync(Uri requestUri, string content, CancellationToken cancellationToken) => PostAsStringAsync(requestUri, CreateContent(content, null), cancellationToken);
        public Task<string> PostAsStringAsync<S>(string requestUri, S content, CancellationToken cancellationToken) => PostAsStringAsync(requestUri, CreateContent(content, null), cancellationToken);
        public Task<string> PostAsStringAsync<S>(Uri requestUri, S content, CancellationToken cancellationToken) => PostAsStringAsync(requestUri, CreateContent(content, null), cancellationToken);
        public Task<string> PostAsStringAsync(string requestUri, HttpContent content, CancellationToken cancellationToken) => PostAsStringAsync(CreateUri(requestUri), content, cancellationToken);
        public Task<string> PostAsStringAsync(Uri requestUri, HttpContent content, CancellationToken cancellationToken) => CorePostStringAsync(requestUri, content, cancellationToken);
        #endregion

        #region privateMethods
        private async Task<string> CorePostStringAsync(Uri requestUri, HttpContent content, CancellationToken cancellationToken)
        {
            var response = await CoreSendAsync(HttpMethod.Post, requestUri, content, null, _defaultCompletionOption, cancellationToken);
            return await response.ReadAsStringAsync();
        }
        #endregion
    }
}
