using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.WebJobs.Extensions.FunctionsHttpClient.Bindings
{
    public class FunctionsHttpClientCollectorBinder<T> : IAsyncCollector<T>
    {
        private readonly IList<T> _items = new List<T>();
        private readonly FunctionsHttpClientContext _context;

        public FunctionsHttpClientCollectorBinder(FunctionsHttpClientContext context)
        {
            _context = context;
        }

        public Task AddAsync(T item, CancellationToken cancellationToken = default(CancellationToken))
        {
            _items.Add(item);
            return Task.FromResult(0);
        }

        public async Task FlushAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            foreach (var item in _items)
            {
                if (string.IsNullOrWhiteSpace(_context.ResolvedAttribute?.RequestUrl))
                {
                    throw new InvalidOperationException($"{nameof(_context.ResolvedAttribute.RequestUrl)} cannot be null");
                }
                switch (_context.ResolvedAttribute.RequestMethod)
                {
                    case RequestMethod.Get:
                        await _context.FunctionsHttpClient.GetAsync(_context.ResolvedAttribute.RequestUrl, _context.ResolvedAttribute.Headers, CancellationToken.None);
                        break;
                    case RequestMethod.Post:
                        await _context.FunctionsHttpClient.PostAsync(_context.ResolvedAttribute.RequestUrl, item, _context.ResolvedAttribute.Headers, CancellationToken.None);
                        break;
                    case RequestMethod.Put:
                        await _context.FunctionsHttpClient.PutAsync(_context.ResolvedAttribute.RequestUrl, item, _context.ResolvedAttribute.Headers, CancellationToken.None);
                        break;
                    case RequestMethod.Delete:
                        await _context.FunctionsHttpClient.DeleteAsync(_context.ResolvedAttribute.RequestUrl, _context.ResolvedAttribute.Headers, CancellationToken.None);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(_context.ResolvedAttribute.RequestMethod));
                }
            }
        }
    }
}
