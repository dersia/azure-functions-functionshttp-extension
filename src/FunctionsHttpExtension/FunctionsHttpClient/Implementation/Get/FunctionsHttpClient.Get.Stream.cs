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
        public Task<Stream> GetStreamAsync(string requestUri, CancellationToken cancellationToken) => GetStreamAsync(requestUri, _defualtHeaders, _defaultCompletionOption, cancellationToken);
        public Task<Stream> GetStreamAsync(Uri requestUri, CancellationToken cancellationToken) => GetStreamAsync(requestUri, _defualtHeaders, _defaultCompletionOption, cancellationToken);
        public Task<Stream> GetStreamAsync(string requestUri, IDictionary<string, string> requestHeaders, CancellationToken cancellationToken) => GetStreamAsync(requestUri, ParseHeaders(requestHeaders), _defaultCompletionOption, cancellationToken);
        public Task<Stream> GetStreamAsync(Uri requestUri, IDictionary<string, string> requestHeaders, CancellationToken cancellationToken) => GetStreamAsync(requestUri, ParseHeaders(requestHeaders), _defaultCompletionOption, cancellationToken);
        public Task<Stream> GetStreamAsync(string requestUri, string requestHeaders, CancellationToken cancellationToken) => GetStreamAsync(requestUri, ParseHeaders(requestHeaders), _defaultCompletionOption, cancellationToken);
        public Task<Stream> GetStreamAsync(Uri requestUri, string requestHeaders, CancellationToken cancellationToken) => GetStreamAsync(requestUri, ParseHeaders(requestHeaders), _defaultCompletionOption, cancellationToken);
        public Task<Stream> GetStreamAsync(string requestUri, HttpHeaders requestHeaders, CancellationToken cancellationToken) => GetStreamAsync(requestUri, requestHeaders, _defaultCompletionOption, cancellationToken);
        public Task<Stream> GetStreamAsync(Uri requestUri, HttpHeaders requestHeaders, CancellationToken cancellationToken) => GetStreamAsync(requestUri, requestHeaders, _defaultCompletionOption, cancellationToken);
        public Task<Stream> GetStreamAsync(string requestUri, HttpCompletionOption completionOption, CancellationToken cancellationToken) => GetStreamAsync(requestUri, _defualtHeaders, completionOption, cancellationToken);
        public Task<Stream> GetStreamAsync(Uri requestUri, HttpCompletionOption completionOption, CancellationToken cancellationToken) => GetStreamAsync(requestUri, _defualtHeaders, completionOption, cancellationToken);
        public Task<Stream> GetStreamAsync(string requestUri, IDictionary<string, string> requestHeaders, HttpCompletionOption completionOption, CancellationToken cancellationToken) => GetStreamAsync(requestUri, ParseHeaders(requestHeaders), completionOption, cancellationToken);
        public Task<Stream> GetStreamAsync(Uri requestUri, IDictionary<string, string> requestHeaders, HttpCompletionOption completionOption, CancellationToken cancellationToken) => GetStreamAsync(requestUri, ParseHeaders(requestHeaders), completionOption, cancellationToken);
        public Task<Stream> GetStreamAsync(string requestUri, string requestHeaders, HttpCompletionOption completionOption, CancellationToken cancellationToken) => GetStreamAsync(requestUri, ParseHeaders(requestHeaders), completionOption, cancellationToken);
        public Task<Stream> GetStreamAsync(Uri requestUri, string requestHeaders, HttpCompletionOption completionOption, CancellationToken cancellationToken) => GetStreamAsync(requestUri, ParseHeaders(requestHeaders), completionOption, cancellationToken);
        public Task<Stream> GetStreamAsync(string requestUri, HttpHeaders requestHeaders, HttpCompletionOption completionOption, CancellationToken cancellationToken) => GetStreamAsync(CreateUri(requestUri), requestHeaders, completionOption, cancellationToken);
        public Task<Stream> GetStreamAsync(Uri requestUri, HttpHeaders requestHeaders, HttpCompletionOption completionOption, CancellationToken cancellationToken) => CoreGetStreamAsync(requestUri, requestHeaders, completionOption, cancellationToken);
        #endregion

        #region privateMethods
        private async Task<Stream> CoreGetStreamAsync(Uri requestUri, HttpHeaders requestHeaders, HttpCompletionOption completionOption, CancellationToken cancellationToken)
        {
            var response = await CoreSendAsync(HttpMethod.Get, requestUri, requestHeaders, completionOption, cancellationToken);
            return await response.ReadAsStreamAsync();
        }
        #endregion
    }
}
