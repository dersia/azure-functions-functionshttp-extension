namespace Microsoft.Azure.WebJobs.Extensions.FunctionsHttpClient.Bindings
{
    public class FunctionsHttpClientBinder : IConverter<FunctionsHttpClientAttribute, IFunctionsHttpClient>
    {
        private readonly IFunctionsHttpClient _functionsHttpClient;

        public FunctionsHttpClientBinder(IFunctionsHttpClient functionsHttpClient)
        {
            _functionsHttpClient = functionsHttpClient;
        }

        public IFunctionsHttpClient Convert(FunctionsHttpClientAttribute input) => _functionsHttpClient;
    }
}
