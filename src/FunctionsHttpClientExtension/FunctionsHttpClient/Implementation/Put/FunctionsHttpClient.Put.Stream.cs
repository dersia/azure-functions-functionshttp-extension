using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.WebJobs.Extensions.FunctionsHttpClient.FunctionsHttpClient
{
    public sealed partial class FunctionsHttpClient : IFunctionsHttpClient
    {
        #region publicMethods        
        public Task<Stream> PutStreamAsync(string requestUri, string content, HttpHeaders requestHeaders, CancellationToken cancellationToken) => PutStreamAsync(requestUri, CreateContent(content, requestHeaders), cancellationToken);
        public Task<Stream> PutStreamAsync(Uri requestUri, string content, HttpHeaders requestHeaders, CancellationToken cancellationToken) => PutStreamAsync(requestUri, CreateContent(content, requestHeaders), cancellationToken);
        public Task<Stream> PutStreamAsync<S>(string requestUri, S content, HttpHeaders requestHeaders, CancellationToken cancellationToken) => PutStreamAsync(requestUri, CreateContent(content, requestHeaders), cancellationToken);
        public Task<Stream> PutStreamAsync<S>(Uri requestUri, S content, HttpHeaders requestHeaders, CancellationToken cancellationToken) => PutStreamAsync(requestUri, CreateContent(content, requestHeaders), cancellationToken);
        public Task<Stream> PutStreamAsync(string requestUri, string content, IDictionary<string, string> requestHeaders, CancellationToken cancellationToken) => PutStreamAsync(requestUri, CreateContent(content, ParseHeaders(requestHeaders)), cancellationToken);
        public Task<Stream> PutStreamAsync(Uri requestUri, string content, IDictionary<string, string> requestHeaders, CancellationToken cancellationToken) => PutStreamAsync(requestUri, CreateContent(content, ParseHeaders(requestHeaders)), cancellationToken);
        public Task<Stream> PutStreamAsync<S>(string requestUri, S content, IDictionary<string, string> requestHeaders, CancellationToken cancellationToken) => PutStreamAsync(requestUri, CreateContent(content, ParseHeaders(requestHeaders)), cancellationToken);
        public Task<Stream> PutStreamAsync<S>(Uri requestUri, S content, IDictionary<string, string> requestHeaders, CancellationToken cancellationToken) => PutStreamAsync(requestUri, CreateContent(content, ParseHeaders(requestHeaders)), cancellationToken);
        public Task<Stream> PutStreamAsync(string requestUri, string content, string requestHeaders, CancellationToken cancellationToken) => PutStreamAsync(requestUri, CreateContent(content, ParseHeaders(requestHeaders)), cancellationToken);
        public Task<Stream> PutStreamAsync(Uri requestUri, string content, string requestHeaders, CancellationToken cancellationToken) => PutStreamAsync(requestUri, CreateContent(content, ParseHeaders(requestHeaders)), cancellationToken);
        public Task<Stream> PutStreamAsync<S>(string requestUri, S content, string requestHeaders, CancellationToken cancellationToken) => PutStreamAsync(requestUri, CreateContent(content, ParseHeaders(requestHeaders)), cancellationToken);
        public Task<Stream> PutStreamAsync<S>(Uri requestUri, S content, string requestHeaders, CancellationToken cancellationToken) => PutStreamAsync(requestUri, CreateContent(content, ParseHeaders(requestHeaders)), cancellationToken);
        public Task<Stream> PutStreamAsync(string requestUri, string content, CancellationToken cancellationToken) => PutStreamAsync(requestUri, CreateContent(content, null), cancellationToken);
        public Task<Stream> PutStreamAsync(Uri requestUri, string content, CancellationToken cancellationToken) => PutStreamAsync(requestUri, CreateContent(content, null), cancellationToken);
        public Task<Stream> PutStreamAsync<S>(string requestUri, S content, CancellationToken cancellationToken) => PutStreamAsync(requestUri, CreateContent(content, null), cancellationToken);
        public Task<Stream> PutStreamAsync<S>(Uri requestUri, S content, CancellationToken cancellationToken) => PutStreamAsync(requestUri, CreateContent(content, null), cancellationToken);
        public Task<Stream> PutStreamAsync(string requestUri, HttpContent content, CancellationToken cancellationToken) => PutStreamAsync(CreateUri(requestUri), content, cancellationToken);
        public Task<Stream> PutStreamAsync(Uri requestUri, HttpContent content, CancellationToken cancellationToken) => CorePutStreamAsync(requestUri, content, cancellationToken);
        #endregion

        #region privateMethods
        private async Task<Stream> CorePutStreamAsync(Uri requestUri, HttpContent content, CancellationToken cancellationToken)
        {
            var response = await CoreSendAsync(HttpMethod.Put, requestUri, content, null, _defaultCompletionOption, cancellationToken);
            return await response.ReadAsStreamAsync();
        }
        #endregion
    }
}
