using Microsoft.Azure.WebJobs.Host;

namespace Microsoft.Azure.WebJobs.Extensions.FunctionsHttpClient
{
    public class FunctionsHttpClientContext
    {
        public FunctionsHttpClientAttribute ResolvedAttribute { get; set; }
        public IFunctionsHttpClient FunctionsHttpClient { get; set; }
        public TraceWriter TraceWriter { get; set; }
    }
}
