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
        public Task<string> DeleteAsStringAsync(string requestUri, CancellationToken cancellationToken) => DeleteAsStringAsync(requestUri, _defualtHeaders, _defaultCompletionOption, cancellationToken);
        public Task<string> DeleteAsStringAsync(Uri requestUri, CancellationToken cancellationToken) => DeleteAsStringAsync(requestUri, _defualtHeaders, _defaultCompletionOption, cancellationToken);
        public Task<string> DeleteAsStringAsync(string requestUri, IDictionary<string, string> requestHeaders, CancellationToken cancellationToken) => DeleteAsStringAsync(requestUri, ParseHeaders(requestHeaders), _defaultCompletionOption, cancellationToken);
        public Task<string> DeleteAsStringAsync(Uri requestUri, IDictionary<string, string> requestHeaders, CancellationToken cancellationToken) => DeleteAsStringAsync(requestUri, ParseHeaders(requestHeaders), _defaultCompletionOption, cancellationToken);
        public Task<string> DeleteAsStringAsync(string requestUri, string requestHeaders, CancellationToken cancellationToken) => DeleteAsStringAsync(requestUri, ParseHeaders(requestHeaders), _defaultCompletionOption, cancellationToken);
        public Task<string> DeleteAsStringAsync(Uri requestUri, string requestHeaders, CancellationToken cancellationToken) => DeleteAsStringAsync(requestUri, ParseHeaders(requestHeaders), _defaultCompletionOption, cancellationToken);
        public Task<string> DeleteAsStringAsync(string requestUri, HttpHeaders requestHeaders, CancellationToken cancellationToken) => DeleteAsStringAsync(requestUri, requestHeaders, _defaultCompletionOption, cancellationToken);
        public Task<string> DeleteAsStringAsync(Uri requestUri, HttpHeaders requestHeaders, CancellationToken cancellationToken) => DeleteAsStringAsync(requestUri, requestHeaders, _defaultCompletionOption, cancellationToken);
        public Task<string> DeleteAsStringAsync(string requestUri, HttpCompletionOption completionOption, CancellationToken cancellationToken) => DeleteAsStringAsync(requestUri, _defualtHeaders, completionOption, cancellationToken);
        public Task<string> DeleteAsStringAsync(Uri requestUri, HttpCompletionOption completionOption, CancellationToken cancellationToken) => DeleteAsStringAsync(requestUri, _defualtHeaders, completionOption, cancellationToken);
        public Task<string> DeleteAsStringAsync(string requestUri, IDictionary<string, string> requestHeaders, HttpCompletionOption completionOption, CancellationToken cancellationToken) => DeleteAsStringAsync(requestUri, ParseHeaders(requestHeaders), completionOption, cancellationToken);
        public Task<string> DeleteAsStringAsync(Uri requestUri, IDictionary<string, string> requestHeaders, HttpCompletionOption completionOption, CancellationToken cancellationToken) => DeleteAsStringAsync(requestUri, ParseHeaders(requestHeaders), completionOption, cancellationToken);
        public Task<string> DeleteAsStringAsync(string requestUri, string requestHeaders, HttpCompletionOption completionOption, CancellationToken cancellationToken) => DeleteAsStringAsync(requestUri, ParseHeaders(requestHeaders), completionOption, cancellationToken);
        public Task<string> DeleteAsStringAsync(Uri requestUri, string requestHeaders, HttpCompletionOption completionOption, CancellationToken cancellationToken) => DeleteAsStringAsync(requestUri, ParseHeaders(requestHeaders), completionOption, cancellationToken);
        public Task<string> DeleteAsStringAsync(string requestUri, HttpHeaders requestHeaders, HttpCompletionOption completionOption, CancellationToken cancellationToken) => DeleteAsStringAsync(CreateUri(requestUri), requestHeaders, completionOption, cancellationToken);
        public Task<string> DeleteAsStringAsync(Uri requestUri, HttpHeaders requestHeaders, HttpCompletionOption completionOption, CancellationToken cancellationToken) => CoreDeleteStringAsync(requestUri, requestHeaders, completionOption, cancellationToken);
        #endregion

        #region privateMethods
        private async Task<string> CoreDeleteStringAsync(Uri requestUri, HttpHeaders requestHeaders, HttpCompletionOption completionOption, CancellationToken cancellationToken)
        {
            var response = await CoreSendAsync(HttpMethod.Delete, requestUri, requestHeaders, completionOption, cancellationToken);
            return await response.ReadAsStringAsync();
        }
        #endregion
    }
}
