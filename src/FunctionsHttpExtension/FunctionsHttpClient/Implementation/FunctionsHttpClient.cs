using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.WebJobs.Extensions.FunctionsHttpClient.FunctionsHttpClient
{
    public sealed partial class FunctionsHttpClient : IFunctionsHttpClient
    {
        private readonly HttpClient _httpClient;
        private TimeSpan _timeout;
        private readonly FunctionsHttpClientHeaders _defualtHeaders = new FunctionsHttpClientHeaders();
        private const HttpCompletionOption _defaultCompletionOption = HttpCompletionOption.ResponseContentRead;

        internal FunctionsHttpClient(HttpClient staticHttpClient)
        {
            _httpClient = staticHttpClient;
        }

        public TimeSpan Timeout { get => _timeout; set => _timeout = value; }

        #region IDisposable Support
        public void Dispose()
        {
        }
        #endregion

        private void SetHeaders(HttpHeaders httpHeaders)
        {
            _httpClient.DefaultRequestHeaders.Clear();
            if (httpHeaders != null)
            {
                foreach (var httpHeader in httpHeaders)
                {
                    _httpClient.DefaultRequestHeaders.TryAddWithoutValidation(httpHeader.Key, httpHeader.Value);
                }
            }
        }

        private Task<HttpContent> CoreSendAsync(HttpMethod method, Uri requestUri, HttpHeaders requestHeaders, HttpCompletionOption completionOption, CancellationToken cancellationToken)
        {
            return CoreSendAsync(method, requestUri, null, requestHeaders, completionOption, cancellationToken);
        }

        private async Task<HttpContent> CoreSendAsync(HttpMethod method, Uri requestUri, HttpContent content, HttpHeaders requestHeaders, HttpCompletionOption completionOption, CancellationToken cancellationToken)
        {
            var originalHeaders = _httpClient.DefaultRequestHeaders;
            SetHeaders(requestHeaders);
            var requestMessage = new HttpRequestMessage(method, requestUri);
            if (content != null)
            {
                requestMessage.Content = content;
            }
            var response = await _httpClient.SendAsync(requestMessage, completionOption, cancellationToken);
            SetHeaders(originalHeaders);
            response.EnsureSuccessStatusCode();
            return response.Content;
        }

        private Uri CreateUri(string requestUri) => new Uri(requestUri);

        private HttpHeaders ParseHeaders(string headers)
        {
            var keyValuePairs = headers.Split(';').Select(headerPair => new KeyValuePair<string, string>(headerPair.Split('=')[0], headerPair.Split('=')[1])).ToDictionary(x => x.Key, y => y.Value);
            return ParseHeaders(keyValuePairs);
        }

        private HttpHeaders ParseHeaders(IDictionary<string, string> keyValuePairs)
        {
            HttpHeaders headers = new FunctionsHttpClientHeaders();
            foreach(var keyValuePair in keyValuePairs)
            {
                headers.Add(keyValuePair.Key, keyValuePair.Value);
            }
            return headers;
        }

        private HttpContent CreateContent<S>(S content, HttpHeaders requestHeaders)
        {
            return CreateContent(Newtonsoft.Json.JsonConvert.SerializeObject(content), requestHeaders);
        }

        private HttpContent CreateContent(string content, HttpHeaders requestHeaders)
        {
            var httpContent = new StringContent(content, System.Text.Encoding.UTF8);
            if (requestHeaders != null)
            {
                httpContent.Headers.Clear();
                foreach (var httpHeader in requestHeaders)
                {
                    httpContent.Headers.TryAddWithoutValidation(httpHeader.Key, httpHeader.Value);
                }
            }
            return httpContent;
        }
    }
}
