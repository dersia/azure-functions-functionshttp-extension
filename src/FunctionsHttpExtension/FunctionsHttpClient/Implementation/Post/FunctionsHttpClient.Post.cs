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
        public Task PostAsync(string requestUri, string content, HttpHeaders requestHeaders, CancellationToken cancellationToken) => PostAsync(requestUri, CreateContent(content, requestHeaders), cancellationToken);
        public Task PostAsync(Uri requestUri, string content, HttpHeaders requestHeaders, CancellationToken cancellationToken) => PostAsync(requestUri, CreateContent(content, requestHeaders), cancellationToken);
        public Task PostAsync<S>(string requestUri, S content, HttpHeaders requestHeaders, CancellationToken cancellationToken) => PostAsync(requestUri, CreateContent(content, requestHeaders), cancellationToken);
        public Task PostAsync<S>(Uri requestUri, S content, HttpHeaders requestHeaders, CancellationToken cancellationToken) => PostAsync(requestUri, CreateContent(content, requestHeaders), cancellationToken);
        public Task PostAsync(string requestUri, string content, IDictionary<string, string> requestHeaders, CancellationToken cancellationToken) => PostAsync(requestUri, CreateContent(content, ParseHeaders(requestHeaders)), cancellationToken);
        public Task PostAsync(Uri requestUri, string content, IDictionary<string, string> requestHeaders, CancellationToken cancellationToken) => PostAsync(requestUri, CreateContent(content, ParseHeaders(requestHeaders)), cancellationToken);
        public Task PostAsync<S>(string requestUri, S content, IDictionary<string, string> requestHeaders, CancellationToken cancellationToken) => PostAsync(requestUri, CreateContent(content, ParseHeaders(requestHeaders)), cancellationToken);
        public Task PostAsync<S>(Uri requestUri, S content, IDictionary<string, string> requestHeaders, CancellationToken cancellationToken) => PostAsync(requestUri, CreateContent(content, ParseHeaders(requestHeaders)), cancellationToken);
        public Task PostAsync(string requestUri, string content, string requestHeaders, CancellationToken cancellationToken) => PostAsync(requestUri, CreateContent(content, ParseHeaders(requestHeaders)), cancellationToken);
        public Task PostAsync(Uri requestUri, string content, string requestHeaders, CancellationToken cancellationToken) => PostAsync(requestUri, CreateContent(content, ParseHeaders(requestHeaders)), cancellationToken);
        public Task PostAsync<S>(string requestUri, S content, string requestHeaders, CancellationToken cancellationToken) => PostAsync(requestUri, CreateContent(content, ParseHeaders(requestHeaders)), cancellationToken);
        public Task PostAsync<S>(Uri requestUri, S content, string requestHeaders, CancellationToken cancellationToken) => PostAsync(requestUri, CreateContent(content, ParseHeaders(requestHeaders)), cancellationToken);
        public Task PostAsync(string requestUri, string content, CancellationToken cancellationToken) => PostAsync(requestUri, CreateContent(content, null), cancellationToken);
        public Task PostAsync(Uri requestUri, string content, CancellationToken cancellationToken) => PostAsync(requestUri, CreateContent(content, null), cancellationToken);
        public Task PostAsync<S>(string requestUri, S content, CancellationToken cancellationToken) => PostAsync(requestUri, CreateContent(content, null), cancellationToken);
        public Task PostAsync<S>(Uri requestUri, S content, CancellationToken cancellationToken) => PostAsync(requestUri, CreateContent(content, null), cancellationToken);
        public Task PostAsync(string requestUri, HttpContent content, CancellationToken cancellationToken) => PostAsync(CreateUri(requestUri), content, cancellationToken);
        public Task PostAsync(Uri requestUri, HttpContent content, CancellationToken cancellationToken) => CorePostAsync(requestUri, content, cancellationToken);
        #endregion

        #region privateMethods
        private async Task CorePostAsync(Uri requestUri, HttpContent content, CancellationToken cancellationToken)
        {
            var response = await CoreSendAsync(HttpMethod.Post, requestUri, content, null, _defaultCompletionOption, cancellationToken);
        }
        #endregion
    }
}
