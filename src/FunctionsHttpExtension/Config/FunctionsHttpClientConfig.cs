using Microsoft.Azure.WebJobs.Extensions.FunctionsHttpClient.Bindings;
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

            INameResolver nameResolver = context.Config.GetService<INameResolver>();

            IConverterManager converterManager = context.Config.GetService<IConverterManager>();
            BindingFactory factory = new BindingFactory(nameResolver, converterManager);

            IBindingProvider tOutputBindingProvider = factory.BindToGenericValueProvider<FunctionsHttpClientAttribute>(BindForItemAsync);
            IBindingProvider stringInputProvider = factory.BindToInput<FunctionsHttpClientAttribute, string>(typeof(FunctionsHttpClientStringBinder), CreateClient());
            IBindingProvider byteArrayInputProvider = factory.BindToInput<FunctionsHttpClientAttribute, byte[]>(typeof(FunctionsHttpClientByteArrayBinder), CreateClient());
            IBindingProvider streamInputProvider = factory.BindToInput<FunctionsHttpClientAttribute, Stream>(typeof(FunctionsHttpClientStreamBinder), CreateClient());
            IBindingProvider clientInputProvider = factory.BindToInput<FunctionsHttpClientAttribute, IFunctionsHttpClient>(typeof(FunctionsHttpClientBinder), CreateClient());

            IExtensionRegistry extensions = context.Config.GetService<IExtensionRegistry>();
            extensions.RegisterBindingRules<FunctionsHttpClientAttribute>(clientInputProvider, stringInputProvider, byteArrayInputProvider, streamInputProvider, tOutputBindingProvider);
        }

        internal IFunctionsHttpClient FunctionsHttpClient { get; set; }
        public FunctionsHttpClientAttribute HttpClientAttribute { get; set; }

        internal Task<IValueBinder> BindForItemAsync(FunctionsHttpClientAttribute attribute, Type type)
        {
            if (string.IsNullOrWhiteSpace(attribute?.RequestUrl))
            {
                throw new InvalidOperationException($"{nameof(attribute.RequestUrl)} cannot be null");
            }

            FunctionsHttpClientContext context = CreateContext(attribute);

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
