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
        public Task<Stream> DeleteStreamAsync(string requestUri, CancellationToken cancellationToken) => DeleteStreamAsync(requestUri, _defualtHeaders, _defaultCompletionOption, cancellationToken);
        public Task<Stream> DeleteStreamAsync(Uri requestUri, CancellationToken cancellationToken) => DeleteStreamAsync(requestUri, _defualtHeaders, _defaultCompletionOption, cancellationToken);
        public Task<Stream> DeleteStreamAsync(string requestUri, IDictionary<string, string> requestHeaders, CancellationToken cancellationToken) => DeleteStreamAsync(requestUri, ParseHeaders(requestHeaders), _defaultCompletionOption, cancellationToken);
        public Task<Stream> DeleteStreamAsync(Uri requestUri, IDictionary<string, string> requestHeaders, CancellationToken cancellationToken) => DeleteStreamAsync(requestUri, ParseHeaders(requestHeaders), _defaultCompletionOption, cancellationToken);
        public Task<Stream> DeleteStreamAsync(string requestUri, string requestHeaders, CancellationToken cancellationToken) => DeleteStreamAsync(requestUri, ParseHeaders(requestHeaders), _defaultCompletionOption, cancellationToken);
        public Task<Stream> DeleteStreamAsync(Uri requestUri, string requestHeaders, CancellationToken cancellationToken) => DeleteStreamAsync(requestUri, ParseHeaders(requestHeaders), _defaultCompletionOption, cancellationToken);
        public Task<Stream> DeleteStreamAsync(string requestUri, HttpHeaders requestHeaders, CancellationToken cancellationToken) => DeleteStreamAsync(requestUri, requestHeaders, _defaultCompletionOption, cancellationToken);
        public Task<Stream> DeleteStreamAsync(Uri requestUri, HttpHeaders requestHeaders, CancellationToken cancellationToken) => DeleteStreamAsync(requestUri, requestHeaders, _defaultCompletionOption, cancellationToken);
        public Task<Stream> DeleteStreamAsync(string requestUri, HttpCompletionOption completionOption, CancellationToken cancellationToken) => DeleteStreamAsync(requestUri, _defualtHeaders, completionOption, cancellationToken);
        public Task<Stream> DeleteStreamAsync(Uri requestUri, HttpCompletionOption completionOption, CancellationToken cancellationToken) => DeleteStreamAsync(requestUri, _defualtHeaders, completionOption, cancellationToken);
        public Task<Stream> DeleteStreamAsync(string requestUri, IDictionary<string, string> requestHeaders, HttpCompletionOption completionOption, CancellationToken cancellationToken) => DeleteStreamAsync(requestUri, ParseHeaders(requestHeaders), completionOption, cancellationToken);
        public Task<Stream> DeleteStreamAsync(Uri requestUri, IDictionary<string, string> requestHeaders, HttpCompletionOption completionOption, CancellationToken cancellationToken) => DeleteStreamAsync(requestUri, ParseHeaders(requestHeaders), completionOption, cancellationToken);
        public Task<Stream> DeleteStreamAsync(string requestUri, string requestHeaders, HttpCompletionOption completionOption, CancellationToken cancellationToken) => DeleteStreamAsync(requestUri, ParseHeaders(requestHeaders), completionOption, cancellationToken);
        public Task<Stream> DeleteStreamAsync(Uri requestUri, string requestHeaders, HttpCompletionOption completionOption, CancellationToken cancellationToken) => DeleteStreamAsync(requestUri, ParseHeaders(requestHeaders), completionOption, cancellationToken);
        public Task<Stream> DeleteStreamAsync(string requestUri, HttpHeaders requestHeaders, HttpCompletionOption completionOption, CancellationToken cancellationToken) => DeleteStreamAsync(CreateUri(requestUri), requestHeaders, completionOption, cancellationToken);
        public Task<Stream> DeleteStreamAsync(Uri requestUri, HttpHeaders requestHeaders, HttpCompletionOption completionOption, CancellationToken cancellationToken) => CoreDeleteStreamAsync(requestUri, requestHeaders, completionOption, cancellationToken);
        #endregion

        #region privateMethods
        private async Task<Stream> CoreDeleteStreamAsync(Uri requestUri, HttpHeaders requestHeaders, HttpCompletionOption completionOption, CancellationToken cancellationToken)
        {
            var response = await CoreSendAsync(HttpMethod.Delete, requestUri, requestHeaders, completionOption, cancellationToken);
            return await response.ReadAsStreamAsync();
        }
        #endregion
    }
}
