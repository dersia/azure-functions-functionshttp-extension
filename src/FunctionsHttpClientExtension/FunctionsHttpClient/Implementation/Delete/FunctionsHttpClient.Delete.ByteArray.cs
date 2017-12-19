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
        public Task<byte[]> DeleteByteArrayAsync(string requestUri, CancellationToken cancellationToken) => DeleteByteArrayAsync(requestUri, _defualtHeaders, _defaultCompletionOption, cancellationToken);
        public Task<byte[]> DeleteByteArrayAsync(Uri requestUri, CancellationToken cancellationToken) => DeleteByteArrayAsync(requestUri, _defualtHeaders, _defaultCompletionOption, cancellationToken);
        public Task<byte[]> DeleteByteArrayAsync(string requestUri, IDictionary<string, string> requestHeaders, CancellationToken cancellationToken) => DeleteByteArrayAsync(requestUri, ParseHeaders(requestHeaders), _defaultCompletionOption, cancellationToken);
        public Task<byte[]> DeleteByteArrayAsync(Uri requestUri, IDictionary<string, string> requestHeaders, CancellationToken cancellationToken) => DeleteByteArrayAsync(requestUri, ParseHeaders(requestHeaders), _defaultCompletionOption, cancellationToken);
        public Task<byte[]> DeleteByteArrayAsync(string requestUri, string requestHeaders, CancellationToken cancellationToken) => DeleteByteArrayAsync(requestUri, ParseHeaders(requestHeaders), _defaultCompletionOption, cancellationToken);
        public Task<byte[]> DeleteByteArrayAsync(Uri requestUri, string requestHeaders, CancellationToken cancellationToken) => DeleteByteArrayAsync(requestUri, ParseHeaders(requestHeaders), _defaultCompletionOption, cancellationToken);
        public Task<byte[]> DeleteByteArrayAsync(string requestUri, HttpHeaders requestHeaders, CancellationToken cancellationToken) => DeleteByteArrayAsync(requestUri, requestHeaders, _defaultCompletionOption, cancellationToken);
        public Task<byte[]> DeleteByteArrayAsync(Uri requestUri, HttpHeaders requestHeaders, CancellationToken cancellationToken) => DeleteByteArrayAsync(requestUri, requestHeaders, _defaultCompletionOption, cancellationToken);
        public Task<byte[]> DeleteByteArrayAsync(string requestUri, HttpCompletionOption completionOption, CancellationToken cancellationToken) => DeleteByteArrayAsync(requestUri, _defualtHeaders, completionOption, cancellationToken);
        public Task<byte[]> DeleteByteArrayAsync(Uri requestUri, HttpCompletionOption completionOption, CancellationToken cancellationToken) => DeleteByteArrayAsync(requestUri, _defualtHeaders, completionOption, cancellationToken);
        public Task<byte[]> DeleteByteArrayAsync(string requestUri, IDictionary<string, string> requestHeaders, HttpCompletionOption completionOption, CancellationToken cancellationToken) => DeleteByteArrayAsync(requestUri, ParseHeaders(requestHeaders), completionOption, cancellationToken);
        public Task<byte[]> DeleteByteArrayAsync(Uri requestUri, IDictionary<string, string> requestHeaders, HttpCompletionOption completionOption, CancellationToken cancellationToken) => DeleteByteArrayAsync(requestUri, ParseHeaders(requestHeaders), completionOption, cancellationToken);
        public Task<byte[]> DeleteByteArrayAsync(string requestUri, string requestHeaders, HttpCompletionOption completionOption, CancellationToken cancellationToken) => DeleteByteArrayAsync(requestUri, ParseHeaders(requestHeaders), completionOption, cancellationToken);
        public Task<byte[]> DeleteByteArrayAsync(Uri requestUri, string requestHeaders, HttpCompletionOption completionOption, CancellationToken cancellationToken) => DeleteByteArrayAsync(requestUri, ParseHeaders(requestHeaders), completionOption, cancellationToken);
        public Task<byte[]> DeleteByteArrayAsync(string requestUri, HttpHeaders requestHeaders, HttpCompletionOption completionOption, CancellationToken cancellationToken) => DeleteByteArrayAsync(CreateUri(requestUri), requestHeaders, completionOption, cancellationToken);
        public Task<byte[]> DeleteByteArrayAsync(Uri requestUri, HttpHeaders requestHeaders, HttpCompletionOption completionOption, CancellationToken cancellationToken) => CoreDeleteByteArrayAsync(requestUri, requestHeaders, completionOption, cancellationToken);
        #endregion

        #region privateMethods
        private async Task<byte[]> CoreDeleteByteArrayAsync(Uri requestUri, HttpHeaders requestHeaders, HttpCompletionOption completionOption, CancellationToken cancellationToken)
        {
            var response = await CoreSendAsync(HttpMethod.Delete, requestUri, requestHeaders, completionOption, cancellationToken);
            return await response.ReadAsByteArrayAsync();
        }
        #endregion
    }
}
