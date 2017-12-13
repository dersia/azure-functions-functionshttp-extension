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
        public Task<T> GetTAsync<T>(string requestUri, CancellationToken cancellationToken) => GetTAsync<T>(requestUri, _defualtHeaders, _defaultCompletionOption, cancellationToken);
        public Task<T> GetTAsync<T>(Uri requestUri, CancellationToken cancellationToken) => GetTAsync<T>(requestUri, _defualtHeaders, _defaultCompletionOption, cancellationToken);
        public Task<T> GetTAsync<T>(string requestUri, IDictionary<string, string> requestHeaders, CancellationToken cancellationToken) => GetTAsync<T>(requestUri, ParseHeaders(requestHeaders), _defaultCompletionOption, cancellationToken);
        public Task<T> GetTAsync<T>(Uri requestUri, IDictionary<string, string> requestHeaders, CancellationToken cancellationToken) => GetTAsync<T>(requestUri, ParseHeaders(requestHeaders), _defaultCompletionOption, cancellationToken);
        public Task<T> GetTAsync<T>(string requestUri, string requestHeaders, CancellationToken cancellationToken) => GetTAsync<T>(requestUri, ParseHeaders(requestHeaders), _defaultCompletionOption, cancellationToken);
        public Task<T> GetTAsync<T>(Uri requestUri, string requestHeaders, CancellationToken cancellationToken) => GetTAsync<T>(requestUri, ParseHeaders(requestHeaders), _defaultCompletionOption, cancellationToken);
        public Task<T> GetTAsync<T>(string requestUri, HttpHeaders requestHeaders, CancellationToken cancellationToken) => GetTAsync<T>(requestUri, requestHeaders, _defaultCompletionOption, cancellationToken);
        public Task<T> GetTAsync<T>(Uri requestUri, HttpHeaders requestHeaders, CancellationToken cancellationToken) => GetTAsync<T>(requestUri, requestHeaders, _defaultCompletionOption, cancellationToken);
        public Task<T> GetTAsync<T>(string requestUri, HttpCompletionOption completionOption, CancellationToken cancellationToken) => GetTAsync<T>(requestUri, _defualtHeaders, completionOption, cancellationToken);
        public Task<T> GetTAsync<T>(Uri requestUri, HttpCompletionOption completionOption, CancellationToken cancellationToken) => GetTAsync<T>(requestUri, _defualtHeaders, completionOption, cancellationToken);
        public Task<T> GetTAsync<T>(string requestUri, IDictionary<string, string> requestHeaders, HttpCompletionOption completionOption, CancellationToken cancellationToken) => GetTAsync<T>(requestUri, ParseHeaders(requestHeaders), completionOption, cancellationToken);
        public Task<T> GetTAsync<T>(Uri requestUri, IDictionary<string, string> requestHeaders, HttpCompletionOption completionOption, CancellationToken cancellationToken) => GetTAsync<T>(requestUri, ParseHeaders(requestHeaders), completionOption, cancellationToken);
        public Task<T> GetTAsync<T>(string requestUri, string requestHeaders, HttpCompletionOption completionOption, CancellationToken cancellationToken) => GetTAsync<T>(requestUri, ParseHeaders(requestHeaders), completionOption, cancellationToken);
        public Task<T> GetTAsync<T>(Uri requestUri, string requestHeaders, HttpCompletionOption completionOption, CancellationToken cancellationToken) => GetTAsync<T>(requestUri, ParseHeaders(requestHeaders), completionOption, cancellationToken);
        public Task<T> GetTAsync<T>(string requestUri, HttpHeaders requestHeaders, HttpCompletionOption completionOption, CancellationToken cancellationToken) => GetTAsync<T>(CreateUri(requestUri), requestHeaders, completionOption, cancellationToken);
        public Task<T> GetTAsync<T>(Uri requestUri, HttpHeaders requestHeaders, HttpCompletionOption completionOption, CancellationToken cancellationToken) => CoreGetTAsync<T>(requestUri, requestHeaders, completionOption, cancellationToken);
        #endregion

        #region privateMethods
        private async Task<T> CoreGetTAsync<T>(Uri requestUri, HttpHeaders requestHeaders, HttpCompletionOption completionOption, CancellationToken cancellationToken)
        {
            var stringResposne = await CoreGetStringAsync(requestUri, requestHeaders, completionOption, cancellationToken);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(stringResposne);
        }
        #endregion
    }
}
