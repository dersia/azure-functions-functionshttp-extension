﻿using Microsoft.Azure.WebJobs.Host.Bindings;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.WebJobs.Extensions.FunctionsHttpClient.Bindings
{
    public class FunctionsHttpClientItemValueBinder<T> : IValueBinder where T : class, new()
    {
        private FunctionsHttpClientContext _context;

        public FunctionsHttpClientItemValueBinder(FunctionsHttpClientContext context)
        {
            _context = context;
        }

        public Type Type => typeof(T);

        public async Task<object> GetValueAsync() => new T();
        public string ToInvokeString() => string.Empty;
        public async Task SetValueAsync(object value, CancellationToken cancellationToken)
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
                    await _context.FunctionsHttpClient.PostAsync<T>(_context.ResolvedAttribute.RequestUrl, (T)value, _context.ResolvedAttribute.Headers, CancellationToken.None);
                    break;
                case RequestMethod.Put:
                    await _context.FunctionsHttpClient.PutAsync<T>(_context.ResolvedAttribute.RequestUrl, (T)value, _context.ResolvedAttribute.Headers, CancellationToken.None);
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
