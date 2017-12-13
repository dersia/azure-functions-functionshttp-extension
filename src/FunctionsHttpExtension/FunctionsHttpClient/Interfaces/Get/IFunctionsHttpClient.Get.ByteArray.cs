using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.WebJobs.Extensions.FunctionsHttpClient
{
    public partial interface IFunctionsHttpClient : IDisposable
    {
        #region ByteArrayResponse
        Task<byte[]> GetByteArrayAsync(string requestUri, CancellationToken cancellationToken);
        Task<byte[]> GetByteArrayAsync(Uri requestUri, CancellationToken cancellationToken);

        Task<byte[]> GetByteArrayAsync(string requestUri, HttpHeaders requestHeaders, CancellationToken cancellationToken);
        Task<byte[]> GetByteArrayAsync(Uri requestUri, HttpHeaders requestHeaders, CancellationToken cancellationToken);

        Task<byte[]> GetByteArrayAsync(string requestUri, IDictionary<string, string> requestHeaders, CancellationToken cancellationToken);
        Task<byte[]> GetByteArrayAsync(Uri requestUri, IDictionary<string, string> requestHeaders, CancellationToken cancellationToken);

        Task<byte[]> GetByteArrayAsync(string requestUri, string requestHeaders, CancellationToken cancellationToken);
        Task<byte[]> GetByteArrayAsync(Uri requestUri, string requestHeaders, CancellationToken cancellationToken);

        Task<byte[]> GetByteArrayAsync(string requestUri, HttpCompletionOption completionOption, CancellationToken cancellationToken);
        Task<byte[]> GetByteArrayAsync(Uri requestUri, HttpCompletionOption completionOption, CancellationToken cancellationToken);

        Task<byte[]> GetByteArrayAsync(string requestUri, HttpHeaders requestHeaders, HttpCompletionOption completionOption, CancellationToken cancellationToken);
        Task<byte[]> GetByteArrayAsync(Uri requestUri, HttpHeaders requestHeaders, HttpCompletionOption completionOption, CancellationToken cancellationToken);

        Task<byte[]> GetByteArrayAsync(string requestUri, IDictionary<string, string> requestHeaders, HttpCompletionOption completionOption, CancellationToken cancellationToken);
        Task<byte[]> GetByteArrayAsync(Uri requestUri, IDictionary<string, string> requestHeaders, HttpCompletionOption completionOption, CancellationToken cancellationToken);

        Task<byte[]> GetByteArrayAsync(string requestUri, string requestHeaders, HttpCompletionOption completionOption, CancellationToken cancellationToken);
        Task<byte[]> GetByteArrayAsync(Uri requestUri, string requestHeaders, HttpCompletionOption completionOption, CancellationToken cancellationToken);
        #endregion
    }
}
