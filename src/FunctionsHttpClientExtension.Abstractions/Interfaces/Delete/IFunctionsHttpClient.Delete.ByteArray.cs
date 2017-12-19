using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.WebJobs.Extensions.FunctionsHttpClient
{
    public partial interface IFunctionsHttpClient : IDisposable
    {
        #region ByteArrayReponse
        Task<byte[]> DeleteByteArrayAsync(string requestUri, CancellationToken cancellationToken);
        Task<byte[]> DeleteByteArrayAsync(Uri requestUri, CancellationToken cancellationToken);

        Task<byte[]> DeleteByteArrayAsync(string requestUri, HttpHeaders requestHeaders, CancellationToken cancellationToken);
        Task<byte[]> DeleteByteArrayAsync(Uri requestUri, HttpHeaders requestHeaders, CancellationToken cancellationToken);

        Task<byte[]> DeleteByteArrayAsync(string requestUri, IDictionary<string, string> requestHeaders, CancellationToken cancellationToken);
        Task<byte[]> DeleteByteArrayAsync(Uri requestUri, IDictionary<string, string> requestHeaders, CancellationToken cancellationToken);

        Task<byte[]> DeleteByteArrayAsync(string requestUri, string requestHeaders, CancellationToken cancellationToken);
        Task<byte[]> DeleteByteArrayAsync(Uri requestUri, string requestHeaders, CancellationToken cancellationToken);

        Task<byte[]> DeleteByteArrayAsync(string requestUri, HttpCompletionOption completionOption, CancellationToken cancellationToken);
        Task<byte[]> DeleteByteArrayAsync(Uri requestUri, HttpCompletionOption completionOption, CancellationToken cancellationToken);

        Task<byte[]> DeleteByteArrayAsync(string requestUri, HttpHeaders requestHeaders, HttpCompletionOption completionOption, CancellationToken cancellationToken);
        Task<byte[]> DeleteByteArrayAsync(Uri requestUri, HttpHeaders requestHeaders, HttpCompletionOption completionOption, CancellationToken cancellationToken);

        Task<byte[]> DeleteByteArrayAsync(string requestUri, IDictionary<string, string> requestHeaders, HttpCompletionOption completionOption, CancellationToken cancellationToken);
        Task<byte[]> DeleteByteArrayAsync(Uri requestUri, IDictionary<string, string> requestHeaders, HttpCompletionOption completionOption, CancellationToken cancellationToken);

        Task<byte[]> DeleteByteArrayAsync(string requestUri, string requestHeaders, HttpCompletionOption completionOption, CancellationToken cancellationToken);
        Task<byte[]> DeleteByteArrayAsync(Uri requestUri, string requestHeaders, HttpCompletionOption completionOption, CancellationToken cancellationToken);
        #endregion
    }
}
