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
        public Task<string> GetAsStringAsync(string requestUri, CancellationToken cancellationToken) => GetAsStringAsync(requestUri, _defualtHeaders, _defaultCompletionOption, cancellationToken);
        public Task<string> GetAsStringAsync(Uri requestUri, CancellationToken cancellationToken) => GetAsStringAsync(requestUri, _defualtHeaders, _defaultCompletionOption, cancellationToken);
        public Task<string> GetAsStringAsync(string requestUri, IDictionary<string, string> requestHeaders, CancellationToken cancellationToken) => GetAsStringAsync(requestUri, ParseHeaders(requestHeaders), _defaultCompletionOption, cancellationToken);
        public Task<string> GetAsStringAsync(Uri requestUri, IDictionary<string, string> requestHeaders, CancellationToken cancellationToken) => GetAsStringAsync(requestUri, ParseHeaders(requestHeaders), _defaultCompletionOption, cancellationToken);
        public Task<string> GetAsStringAsync(string requestUri, string requestHeaders, CancellationToken cancellationToken) => GetAsStringAsync(requestUri, ParseHeaders(requestHeaders), _defaultCompletionOption, cancellationToken);
        public Task<string> GetAsStringAsync(Uri requestUri, string requestHeaders, CancellationToken cancellationToken) => GetAsStringAsync(requestUri, ParseHeaders(requestHeaders), _defaultCompletionOption, cancellationToken);
        public Task<string> GetAsStringAsync(string requestUri, HttpHeaders requestHeaders, CancellationToken cancellationToken) => GetAsStringAsync(requestUri, requestHeaders, _defaultCompletionOption, cancellationToken);
        public Task<string> GetAsStringAsync(Uri requestUri, HttpHeaders requestHeaders, CancellationToken cancellationToken) => GetAsStringAsync(requestUri, requestHeaders, _defaultCompletionOption, cancellationToken);
        public Task<string> GetAsStringAsync(string requestUri, HttpCompletionOption completionOption, CancellationToken cancellationToken) => GetAsStringAsync(requestUri, _defualtHeaders, completionOption, cancellationToken);
        public Task<string> GetAsStringAsync(Uri requestUri, HttpCompletionOption completionOption, CancellationToken cancellationToken) => GetAsStringAsync(requestUri, _defualtHeaders, completionOption, cancellationToken);
        public Task<string> GetAsStringAsync(string requestUri, IDictionary<string, string> requestHeaders, HttpCompletionOption completionOption, CancellationToken cancellationToken) => GetAsStringAsync(requestUri, ParseHeaders(requestHeaders), completionOption, cancellationToken);
        public Task<string> GetAsStringAsync(Uri requestUri, IDictionary<string, string> requestHeaders, HttpCompletionOption completionOption, CancellationToken cancellationToken) => GetAsStringAsync(requestUri, ParseHeaders(requestHeaders), completionOption, cancellationToken);
        public Task<string> GetAsStringAsync(string requestUri, string requestHeaders, HttpCompletionOption completionOption, CancellationToken cancellationToken) => GetAsStringAsync(requestUri, ParseHeaders(requestHeaders), completionOption, cancellationToken);
        public Task<string> GetAsStringAsync(Uri requestUri, string requestHeaders, HttpCompletionOption completionOption, CancellationToken cancellationToken) => GetAsStringAsync(requestUri, ParseHeaders(requestHeaders), completionOption, cancellationToken);
        public Task<string> GetAsStringAsync(string requestUri, HttpHeaders requestHeaders, HttpCompletionOption completionOption, CancellationToken cancellationToken) => GetAsStringAsync(CreateUri(requestUri), requestHeaders, completionOption, cancellationToken);
        public Task<string> GetAsStringAsync(Uri requestUri, HttpHeaders requestHeaders, HttpCompletionOption completionOption, CancellationToken cancellationToken) => CoreGetStringAsync(requestUri, requestHeaders, completionOption, cancellationToken);
        #endregion

        #region privateMethods
        private async Task<string> CoreGetStringAsync(Uri requestUri, HttpHeaders requestHeaders, HttpCompletionOption completionOption, CancellationToken cancellationToken)
        {
            var response = await CoreSendAsync(HttpMethod.Get, requestUri, requestHeaders, completionOption, cancellationToken);
            return await response.ReadAsStringAsync();
        }
        #endregion
    }
}
