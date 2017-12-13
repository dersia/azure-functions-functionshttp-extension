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
        public Task GetAsync(string requestUri, CancellationToken cancellationToken) => GetAsync(requestUri, _defualtHeaders, _defaultCompletionOption, cancellationToken);
        public Task GetAsync(Uri requestUri, CancellationToken cancellationToken) => GetAsync(requestUri, _defualtHeaders, _defaultCompletionOption, cancellationToken);
        public Task GetAsync(string requestUri, IDictionary<string, string> requestHeaders, CancellationToken cancellationToken) => GetAsync(requestUri, ParseHeaders(requestHeaders), _defaultCompletionOption, cancellationToken);
        public Task GetAsync(Uri requestUri, IDictionary<string, string> requestHeaders, CancellationToken cancellationToken) => GetAsync(requestUri, ParseHeaders(requestHeaders), _defaultCompletionOption, cancellationToken);
        public Task GetAsync(string requestUri, string requestHeaders, CancellationToken cancellationToken) => GetAsync(requestUri, ParseHeaders(requestHeaders), _defaultCompletionOption, cancellationToken);
        public Task GetAsync(Uri requestUri, string requestHeaders, CancellationToken cancellationToken) => GetAsync(requestUri, ParseHeaders(requestHeaders), _defaultCompletionOption, cancellationToken);
        public Task GetAsync(string requestUri, HttpHeaders requestHeaders, CancellationToken cancellationToken) => GetAsync(requestUri, requestHeaders, _defaultCompletionOption, cancellationToken);
        public Task GetAsync(Uri requestUri, HttpHeaders requestHeaders, CancellationToken cancellationToken) => GetAsync(requestUri, requestHeaders, _defaultCompletionOption, cancellationToken);
        public Task GetAsync(string requestUri, HttpCompletionOption completionOption, CancellationToken cancellationToken) => GetAsync(requestUri, _defualtHeaders, completionOption, cancellationToken);
        public Task GetAsync(Uri requestUri, HttpCompletionOption completionOption, CancellationToken cancellationToken) => GetAsync(requestUri, _defualtHeaders, completionOption, cancellationToken);
        public Task GetAsync(string requestUri, IDictionary<string, string> requestHeaders, HttpCompletionOption completionOption, CancellationToken cancellationToken) => GetAsync(requestUri, ParseHeaders(requestHeaders), completionOption, cancellationToken);
        public Task GetAsync(Uri requestUri, IDictionary<string, string> requestHeaders, HttpCompletionOption completionOption, CancellationToken cancellationToken) => GetAsync(requestUri, ParseHeaders(requestHeaders), completionOption, cancellationToken);
        public Task GetAsync(string requestUri, string requestHeaders, HttpCompletionOption completionOption, CancellationToken cancellationToken) => GetAsync(requestUri, ParseHeaders(requestHeaders), completionOption, cancellationToken);
        public Task GetAsync(Uri requestUri, string requestHeaders, HttpCompletionOption completionOption, CancellationToken cancellationToken) => GetAsync(requestUri, ParseHeaders(requestHeaders), completionOption, cancellationToken);
        public Task GetAsync(string requestUri, HttpHeaders requestHeaders, HttpCompletionOption completionOption, CancellationToken cancellationToken) => GetAsync(CreateUri(requestUri), requestHeaders, completionOption, cancellationToken);
        public Task GetAsync(Uri requestUri, HttpHeaders requestHeaders, HttpCompletionOption completionOption, CancellationToken cancellationToken) => CoreGetAsync(requestUri, requestHeaders, completionOption, cancellationToken);
        #endregion

        #region privateMethods
        private async Task CoreGetAsync(Uri requestUri, HttpHeaders requestHeaders, HttpCompletionOption completionOption, CancellationToken cancellationToken)
        {
            var response = await CoreSendAsync(HttpMethod.Get, requestUri, requestHeaders, completionOption, cancellationToken);
        }
        #endregion
    }
}
