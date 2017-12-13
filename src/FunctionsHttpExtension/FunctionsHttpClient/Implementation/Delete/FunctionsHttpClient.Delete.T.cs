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
        public Task<T> DeleteTAsync<T>(string requestUri, CancellationToken cancellationToken) => DeleteTAsync<T>(requestUri, _defualtHeaders, _defaultCompletionOption, cancellationToken);
        public Task<T> DeleteTAsync<T>(Uri requestUri, CancellationToken cancellationToken) => DeleteTAsync<T>(requestUri, _defualtHeaders, _defaultCompletionOption, cancellationToken);
        public Task<T> DeleteTAsync<T>(string requestUri, IDictionary<string, string> requestHeaders, CancellationToken cancellationToken) => DeleteTAsync<T>(requestUri, ParseHeaders(requestHeaders), _defaultCompletionOption, cancellationToken);
        public Task<T> DeleteTAsync<T>(Uri requestUri, IDictionary<string, string> requestHeaders, CancellationToken cancellationToken) => DeleteTAsync<T>(requestUri, ParseHeaders(requestHeaders), _defaultCompletionOption, cancellationToken);
        public Task<T> DeleteTAsync<T>(string requestUri, string requestHeaders, CancellationToken cancellationToken) => DeleteTAsync<T>(requestUri, ParseHeaders(requestHeaders), _defaultCompletionOption, cancellationToken);
        public Task<T> DeleteTAsync<T>(Uri requestUri, string requestHeaders, CancellationToken cancellationToken) => DeleteTAsync<T>(requestUri, ParseHeaders(requestHeaders), _defaultCompletionOption, cancellationToken);
        public Task<T> DeleteTAsync<T>(string requestUri, HttpHeaders requestHeaders, CancellationToken cancellationToken) => DeleteTAsync<T>(requestUri, requestHeaders, _defaultCompletionOption, cancellationToken);
        public Task<T> DeleteTAsync<T>(Uri requestUri, HttpHeaders requestHeaders, CancellationToken cancellationToken) => DeleteTAsync<T>(requestUri, requestHeaders, _defaultCompletionOption, cancellationToken);
        public Task<T> DeleteTAsync<T>(string requestUri, HttpCompletionOption completionOption, CancellationToken cancellationToken) => DeleteTAsync<T>(requestUri, _defualtHeaders, completionOption, cancellationToken);
        public Task<T> DeleteTAsync<T>(Uri requestUri, HttpCompletionOption completionOption, CancellationToken cancellationToken) => DeleteTAsync<T>(requestUri, _defualtHeaders, completionOption, cancellationToken);
        public Task<T> DeleteTAsync<T>(string requestUri, IDictionary<string, string> requestHeaders, HttpCompletionOption completionOption, CancellationToken cancellationToken) => DeleteTAsync<T>(requestUri, ParseHeaders(requestHeaders), completionOption, cancellationToken);
        public Task<T> DeleteTAsync<T>(Uri requestUri, IDictionary<string, string> requestHeaders, HttpCompletionOption completionOption, CancellationToken cancellationToken) => DeleteTAsync<T>(requestUri, ParseHeaders(requestHeaders), completionOption, cancellationToken);
        public Task<T> DeleteTAsync<T>(string requestUri, string requestHeaders, HttpCompletionOption completionOption, CancellationToken cancellationToken) => DeleteTAsync<T>(requestUri, ParseHeaders(requestHeaders), completionOption, cancellationToken);
        public Task<T> DeleteTAsync<T>(Uri requestUri, string requestHeaders, HttpCompletionOption completionOption, CancellationToken cancellationToken) => DeleteTAsync<T>(requestUri, ParseHeaders(requestHeaders), completionOption, cancellationToken);
        public Task<T> DeleteTAsync<T>(string requestUri, HttpHeaders requestHeaders, HttpCompletionOption completionOption, CancellationToken cancellationToken) => DeleteTAsync<T>(CreateUri(requestUri), requestHeaders, completionOption, cancellationToken);
        public Task<T> DeleteTAsync<T>(Uri requestUri, HttpHeaders requestHeaders, HttpCompletionOption completionOption, CancellationToken cancellationToken) => CoreDeleteTAsync<T>(requestUri, requestHeaders, completionOption, cancellationToken);
        #endregion

        #region privateMethods
        private async Task<T> CoreDeleteTAsync<T>(Uri requestUri, HttpHeaders requestHeaders, HttpCompletionOption completionOption, CancellationToken cancellationToken)
        {
            var stringResposne = await CoreDeleteStringAsync(requestUri, requestHeaders, completionOption, cancellationToken);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(stringResposne);
        }
        #endregion
    }
}
