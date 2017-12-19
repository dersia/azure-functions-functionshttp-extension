using Microsoft.Azure.WebJobs.Extensions.FunctionsHttpClient.Bindings;
using Microsoft.Azure.WebJobs.Extensions.FunctionsHttpClient.Converter;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Azure.WebJobs.Host.Config;
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace Microsoft.Azure.WebJobs.Extensions.FunctionsHttpClient.Config
{
    public class FunctionsHttpClientConfig : IExtensionConfigProvider
    {
        private readonly static HttpClient _httpClient = new HttpClient();
        private TraceWriter _trace;
        public void Initialize(ExtensionConfigContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            _trace = context.Trace;
            var factory = new BindingFactory(context.Config.GetService<INameResolver>(), context.Config.GetService<IConverterManager>());

            IExtensionRegistry extensions = context.Config.GetService<IExtensionRegistry>();
            extensions.RegisterBindingRules<FunctionsHttpClientAttribute>(CreateBindings(factory));
        }

        private IBindingProvider[] CreateBindings(BindingFactory factory)
        {
            return new IBindingProvider[] {
                factory.BindToCollector<FunctionsHttpClientAttribute, OpenType>(typeof(AsyncCollectorConverter<>), this),
                factory.BindToInput<FunctionsHttpClientAttribute, IFunctionsHttpClient>(typeof(FunctionsHttpClientBinder), CreateClient()),
                factory.BindToInput<FunctionsHttpClientAttribute, string>(typeof(FunctionsHttpClientStringBinder), CreateClient()),
                factory.BindToInput<FunctionsHttpClientAttribute, byte[]>(typeof(FunctionsHttpClientByteArrayBinder), CreateClient()),
                factory.BindToInput<FunctionsHttpClientAttribute, Stream>(typeof(FunctionsHttpClientStreamBinder), CreateClient()),
                factory.BindToInput<FunctionsHttpClientAttribute, OpenType>(typeof(FunctionsHttpClientItemValueInputBinder<>), CreateClient()),
                //factory.BindToGenericValueProvider<FunctionsHttpClientAttribute>(BindForItemAsync)
            };
        }

        internal Task<IValueBinder> BindForItemAsync(FunctionsHttpClientAttribute attribute, Type type)
        {
            if (string.IsNullOrWhiteSpace(attribute?.RequestUrl))
            {
                throw new InvalidOperationException($"{nameof(attribute.RequestUrl)} cannot be null");
            }

            FunctionsHttpClientContext context = CreateContext(attribute);
            if(type == typeof(string))
            {
                return Task.FromResult<IValueBinder>(new FunctionsHttpClientItemValueBinderString(CreateContext(attribute)));
            }

            Type genericType = typeof(FunctionsHttpClientItemValueBinder<>).MakeGenericType(type);
            IValueBinder binder = (IValueBinder)Activator.CreateInstance(genericType, context);

            return Task.FromResult(binder);
        }

        internal FunctionsHttpClientContext CreateContext(FunctionsHttpClientAttribute attribute)
        {
            return new FunctionsHttpClientContext
            {
                FunctionsHttpClient = CreateClient(),
                TraceWriter = _trace,
                ResolvedAttribute = attribute,
            };
        }

        internal FunctionsHttpClient.FunctionsHttpClient CreateClient()
        {
            return new FunctionsHttpClient.FunctionsHttpClient(_httpClient);
        }
    }
}
