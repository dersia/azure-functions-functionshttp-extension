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
        public Task DeleteAsync(string requestUri, CancellationToken cancellationToken) => DeleteAsync(requestUri, _defualtHeaders, _defaultCompletionOption, cancellationToken);
        public Task DeleteAsync(Uri requestUri, CancellationToken cancellationToken) => DeleteAsync(requestUri, _defualtHeaders, _defaultCompletionOption, cancellationToken);
        public Task DeleteAsync(string requestUri, IDictionary<string, string> requestHeaders, CancellationToken cancellationToken) => DeleteAsync(requestUri, ParseHeaders(requestHeaders), _defaultCompletionOption, cancellationToken);
        public Task DeleteAsync(Uri requestUri, IDictionary<string, string> requestHeaders, CancellationToken cancellationToken) => DeleteAsync(requestUri, ParseHeaders(requestHeaders), _defaultCompletionOption, cancellationToken);
        public Task DeleteAsync(string requestUri, string requestHeaders, CancellationToken cancellationToken) => DeleteAsync(requestUri, ParseHeaders(requestHeaders), _defaultCompletionOption, cancellationToken);
        public Task DeleteAsync(Uri requestUri, string requestHeaders, CancellationToken cancellationToken) => DeleteAsync(requestUri, ParseHeaders(requestHeaders), _defaultCompletionOption, cancellationToken);
        public Task DeleteAsync(string requestUri, HttpHeaders requestHeaders, CancellationToken cancellationToken) => DeleteAsync(requestUri, requestHeaders, _defaultCompletionOption, cancellationToken);
        public Task DeleteAsync(Uri requestUri, HttpHeaders requestHeaders, CancellationToken cancellationToken) => DeleteAsync(requestUri, requestHeaders, _defaultCompletionOption, cancellationToken);
        public Task DeleteAsync(string requestUri, HttpCompletionOption completionOption, CancellationToken cancellationToken) => DeleteAsync(requestUri, _defualtHeaders, completionOption, cancellationToken);
        public Task DeleteAsync(Uri requestUri, HttpCompletionOption completionOption, CancellationToken cancellationToken) => DeleteAsync(requestUri, _defualtHeaders, completionOption, cancellationToken);
        public Task DeleteAsync(string requestUri, IDictionary<string, string> requestHeaders, HttpCompletionOption completionOption, CancellationToken cancellationToken) => DeleteAsync(requestUri, ParseHeaders(requestHeaders), completionOption, cancellationToken);
        public Task DeleteAsync(Uri requestUri, IDictionary<string, string> requestHeaders, HttpCompletionOption completionOption, CancellationToken cancellationToken) => DeleteAsync(requestUri, ParseHeaders(requestHeaders), completionOption, cancellationToken);
        public Task DeleteAsync(string requestUri, string requestHeaders, HttpCompletionOption completionOption, CancellationToken cancellationToken) => DeleteAsync(requestUri, ParseHeaders(requestHeaders), completionOption, cancellationToken);
        public Task DeleteAsync(Uri requestUri, string requestHeaders, HttpCompletionOption completionOption, CancellationToken cancellationToken) => DeleteAsync(requestUri, ParseHeaders(requestHeaders), completionOption, cancellationToken);
        public Task DeleteAsync(string requestUri, HttpHeaders requestHeaders, HttpCompletionOption completionOption, CancellationToken cancellationToken) => DeleteAsync(CreateUri(requestUri), requestHeaders, completionOption, cancellationToken);
        public Task DeleteAsync(Uri requestUri, HttpHeaders requestHeaders, HttpCompletionOption completionOption, CancellationToken cancellationToken) => CoreDeleteAsync(requestUri, requestHeaders, completionOption, cancellationToken);
        #endregion

        #region privateMethods
        private async Task CoreDeleteAsync(Uri requestUri, HttpHeaders requestHeaders, HttpCompletionOption completionOption, CancellationToken cancellationToken)
        {
            var response = await CoreSendAsync(HttpMethod.Delete, requestUri, requestHeaders, completionOption, cancellationToken);
        }
        #endregion
    }
}
