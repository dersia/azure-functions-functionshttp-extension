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
        public Task PutAsync(string requestUri, string content, HttpHeaders requestHeaders, CancellationToken cancellationToken) => PutAsync(requestUri, CreateContent(content, requestHeaders), cancellationToken);
        public Task PutAsync(Uri requestUri, string content, HttpHeaders requestHeaders, CancellationToken cancellationToken) => PutAsync(requestUri, CreateContent(content, requestHeaders), cancellationToken);
        public Task PutAsync<S>(string requestUri, S content, HttpHeaders requestHeaders, CancellationToken cancellationToken) => PutAsync(requestUri, CreateContent(content, requestHeaders), cancellationToken);
        public Task PutAsync<S>(Uri requestUri, S content, HttpHeaders requestHeaders, CancellationToken cancellationToken) => PutAsync(requestUri, CreateContent(content, requestHeaders), cancellationToken);
        public Task PutAsync(string requestUri, string content, IDictionary<string, string> requestHeaders, CancellationToken cancellationToken) => PutAsync(requestUri, CreateContent(content, ParseHeaders(requestHeaders)), cancellationToken);
        public Task PutAsync(Uri requestUri, string content, IDictionary<string, string> requestHeaders, CancellationToken cancellationToken) => PutAsync(requestUri, CreateContent(content, ParseHeaders(requestHeaders)), cancellationToken);
        public Task PutAsync<S>(string requestUri, S content, IDictionary<string, string> requestHeaders, CancellationToken cancellationToken) => PutAsync(requestUri, CreateContent(content, ParseHeaders(requestHeaders)), cancellationToken);
        public Task PutAsync<S>(Uri requestUri, S content, IDictionary<string, string> requestHeaders, CancellationToken cancellationToken) => PutAsync(requestUri, CreateContent(content, ParseHeaders(requestHeaders)), cancellationToken);
        public Task PutAsync(string requestUri, string content, string requestHeaders, CancellationToken cancellationToken) => PutAsync(requestUri, CreateContent(content, ParseHeaders(requestHeaders)), cancellationToken);
        public Task PutAsync(Uri requestUri, string content, string requestHeaders, CancellationToken cancellationToken) => PutAsync(requestUri, CreateContent(content, ParseHeaders(requestHeaders)), cancellationToken);
        public Task PutAsync<S>(string requestUri, S content, string requestHeaders, CancellationToken cancellationToken) => PutAsync(requestUri, CreateContent(content, ParseHeaders(requestHeaders)), cancellationToken);
        public Task PutAsync<S>(Uri requestUri, S content, string requestHeaders, CancellationToken cancellationToken) => PutAsync(requestUri, CreateContent(content, ParseHeaders(requestHeaders)), cancellationToken);
        public Task PutAsync(string requestUri, string content, CancellationToken cancellationToken) => PutAsync(requestUri, CreateContent(content, null), cancellationToken);
        public Task PutAsync(Uri requestUri, string content, CancellationToken cancellationToken) => PutAsync(requestUri, CreateContent(content, null), cancellationToken);
        public Task PutAsync<S>(string requestUri, S content, CancellationToken cancellationToken) => PutAsync(requestUri, CreateContent(content, null), cancellationToken);
        public Task PutAsync<S>(Uri requestUri, S content, CancellationToken cancellationToken) => PutAsync(requestUri, CreateContent(content, null), cancellationToken);
        public Task PutAsync(string requestUri, HttpContent content, CancellationToken cancellationToken) => PutAsync(CreateUri(requestUri), content, cancellationToken);
        public Task PutAsync(Uri requestUri, HttpContent content, CancellationToken cancellationToken) => CorePutAsync(requestUri, content, cancellationToken);
        #endregion

        #region privateMethods
        private async Task CorePutAsync(Uri requestUri, HttpContent content, CancellationToken cancellationToken)
        {
            var response = await CoreSendAsync(HttpMethod.Put, requestUri, content, null, _defaultCompletionOption, cancellationToken);
        }
        #endregion
    }
}
