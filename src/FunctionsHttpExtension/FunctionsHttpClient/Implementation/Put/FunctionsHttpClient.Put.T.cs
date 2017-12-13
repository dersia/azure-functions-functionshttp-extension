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
        public Task<T> PutTAsync<T>(string requestUri, string content, HttpHeaders requestHeaders, CancellationToken cancellationToken) => PutTAsync<T>(requestUri, CreateContent(content, requestHeaders), cancellationToken);
        public Task<T> PutTAsync<T>(Uri requestUri, string content, HttpHeaders requestHeaders, CancellationToken cancellationToken) => PutTAsync<T>(requestUri, CreateContent(content, requestHeaders), cancellationToken);
        public Task<T> PutTAsync<T, S>(string requestUri, S content, HttpHeaders requestHeaders, CancellationToken cancellationToken) => PutTAsync<T>(requestUri, CreateContent(content, requestHeaders), cancellationToken);
        public Task<T> PutTAsync<T, S>(Uri requestUri, S content, HttpHeaders requestHeaders, CancellationToken cancellationToken) => PutTAsync<T>(requestUri, CreateContent(content, requestHeaders), cancellationToken);
        public Task<T> PutTAsync<T>(string requestUri, string content, IDictionary<string, string> requestHeaders, CancellationToken cancellationToken) => PutTAsync<T>(requestUri, CreateContent(content, ParseHeaders(requestHeaders)), cancellationToken);
        public Task<T> PutTAsync<T>(Uri requestUri, string content, IDictionary<string, string> requestHeaders, CancellationToken cancellationToken) => PutTAsync<T>(requestUri, CreateContent(content, ParseHeaders(requestHeaders)), cancellationToken);
        public Task<T> PutTAsync<T, S>(string requestUri, S content, IDictionary<string, string> requestHeaders, CancellationToken cancellationToken) => PutTAsync<T>(requestUri, CreateContent(content, ParseHeaders(requestHeaders)), cancellationToken);
        public Task<T> PutTAsync<T, S>(Uri requestUri, S content, IDictionary<string, string> requestHeaders, CancellationToken cancellationToken) => PutTAsync<T>(requestUri, CreateContent(content, ParseHeaders(requestHeaders)), cancellationToken);
        public Task<T> PutTAsync<T>(string requestUri, string content, string requestHeaders, CancellationToken cancellationToken) => PutTAsync<T>(requestUri, CreateContent(content, ParseHeaders(requestHeaders)), cancellationToken);
        public Task<T> PutTAsync<T>(Uri requestUri, string content, string requestHeaders, CancellationToken cancellationToken) => PutTAsync<T>(requestUri, CreateContent(content, ParseHeaders(requestHeaders)), cancellationToken);
        public Task<T> PutTAsync<T, S>(string requestUri, S content, string requestHeaders, CancellationToken cancellationToken) => PutTAsync<T>(requestUri, CreateContent(content, ParseHeaders(requestHeaders)), cancellationToken);
        public Task<T> PutTAsync<T, S>(Uri requestUri, S content, string requestHeaders, CancellationToken cancellationToken) => PutTAsync<T>(requestUri, CreateContent(content, ParseHeaders(requestHeaders)), cancellationToken);
        public Task<T> PutTAsync<T>(string requestUri, string content, CancellationToken cancellationToken) => PutTAsync<T>(requestUri, CreateContent(content, null), cancellationToken);
        public Task<T> PutTAsync<T>(Uri requestUri, string content, CancellationToken cancellationToken) => PutTAsync<T>(requestUri, CreateContent(content, null), cancellationToken);
        public Task<T> PutTAsync<T, S>(string requestUri, S content, CancellationToken cancellationToken) => PutTAsync<T>(requestUri, CreateContent(content, null), cancellationToken);
        public Task<T> PutTAsync<T, S>(Uri requestUri, S content, CancellationToken cancellationToken) => PutTAsync<T>(requestUri, CreateContent(content, null), cancellationToken);
        public Task<T> PutTAsync<T>(string requestUri, HttpContent content, CancellationToken cancellationToken) => PutTAsync<T>(CreateUri(requestUri), content, cancellationToken);
        public Task<T> PutTAsync<T>(Uri requestUri, HttpContent content, CancellationToken cancellationToken) => CorePutTAsync<T>(requestUri, content, cancellationToken);
        #endregion

        #region privateMethods
        private async Task<T> CorePutTAsync<T>(Uri requestUri, HttpContent content, CancellationToken cancellationToken)
        {
            var stringResposne = await CorePutStringAsync(requestUri, content, cancellationToken);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(stringResposne);
        }
        #endregion
    }
}
