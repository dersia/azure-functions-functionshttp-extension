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
        public Task<T> PostTAsync<T>(string requestUri, string content, HttpHeaders requestHeaders, CancellationToken cancellationToken) => PostTAsync<T>(requestUri, CreateContent(content, requestHeaders), cancellationToken);
        public Task<T> PostTAsync<T>(Uri requestUri, string content, HttpHeaders requestHeaders, CancellationToken cancellationToken) => PostTAsync<T>(requestUri, CreateContent(content, requestHeaders), cancellationToken);
        public Task<T> PostTAsync<T, S>(string requestUri, S content, HttpHeaders requestHeaders, CancellationToken cancellationToken) => PostTAsync<T>(requestUri, CreateContent(content, requestHeaders), cancellationToken);
        public Task<T> PostTAsync<T, S>(Uri requestUri, S content, HttpHeaders requestHeaders, CancellationToken cancellationToken) => PostTAsync<T>(requestUri, CreateContent(content, requestHeaders), cancellationToken);
        public Task<T> PostTAsync<T>(string requestUri, string content, IDictionary<string, string> requestHeaders, CancellationToken cancellationToken) => PostTAsync<T>(requestUri, CreateContent(content, ParseHeaders(requestHeaders)), cancellationToken);
        public Task<T> PostTAsync<T>(Uri requestUri, string content, IDictionary<string, string> requestHeaders, CancellationToken cancellationToken) => PostTAsync<T>(requestUri, CreateContent(content, ParseHeaders(requestHeaders)), cancellationToken);
        public Task<T> PostTAsync<T, S>(string requestUri, S content, IDictionary<string, string> requestHeaders, CancellationToken cancellationToken) => PostTAsync<T>(requestUri, CreateContent(content, ParseHeaders(requestHeaders)), cancellationToken);
        public Task<T> PostTAsync<T, S>(Uri requestUri, S content, IDictionary<string, string> requestHeaders, CancellationToken cancellationToken) => PostTAsync<T>(requestUri, CreateContent(content, ParseHeaders(requestHeaders)), cancellationToken);
        public Task<T> PostTAsync<T>(string requestUri, string content, string requestHeaders, CancellationToken cancellationToken) => PostTAsync<T>(requestUri, CreateContent(content, ParseHeaders(requestHeaders)), cancellationToken);
        public Task<T> PostTAsync<T>(Uri requestUri, string content, string requestHeaders, CancellationToken cancellationToken) => PostTAsync<T>(requestUri, CreateContent(content, ParseHeaders(requestHeaders)), cancellationToken);
        public Task<T> PostTAsync<T, S>(string requestUri, S content, string requestHeaders, CancellationToken cancellationToken) => PostTAsync<T>(requestUri, CreateContent(content, ParseHeaders(requestHeaders)), cancellationToken);
        public Task<T> PostTAsync<T, S>(Uri requestUri, S content, string requestHeaders, CancellationToken cancellationToken) => PostTAsync<T>(requestUri, CreateContent(content, ParseHeaders(requestHeaders)), cancellationToken);
        public Task<T> PostTAsync<T>(string requestUri, string content, CancellationToken cancellationToken) => PostTAsync<T>(requestUri, CreateContent(content, null), cancellationToken);
        public Task<T> PostTAsync<T>(Uri requestUri, string content, CancellationToken cancellationToken) => PostTAsync<T>(requestUri, CreateContent(content, null), cancellationToken);
        public Task<T> PostTAsync<T, S>(string requestUri, S content, CancellationToken cancellationToken) => PostTAsync<T>(requestUri, CreateContent(content, null), cancellationToken);
        public Task<T> PostTAsync<T, S>(Uri requestUri, S content, CancellationToken cancellationToken) => PostTAsync<T>(requestUri, CreateContent(content, null), cancellationToken);
        public Task<T> PostTAsync<T>(string requestUri, HttpContent content, CancellationToken cancellationToken) => PostTAsync<T>(CreateUri(requestUri), content, cancellationToken);
        public Task<T> PostTAsync<T>(Uri requestUri, HttpContent content, CancellationToken cancellationToken) => CorePostTAsync<T>(requestUri, content, cancellationToken);
        #endregion

        #region privateMethods
        private async Task<T> CorePostTAsync<T>(Uri requestUri, HttpContent content, CancellationToken cancellationToken)
        {
            var stringResposne = await CorePostStringAsync(requestUri, content, cancellationToken);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(stringResposne);
        }
        #endregion
    }
}
