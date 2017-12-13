using Microsoft.Azure.WebJobs.Description;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.WebJobs.Extensions.FunctionsHttpClient
{
    [AttributeUsage(AttributeTargets.Parameter | AttributeTargets.ReturnValue)]
    [Binding]
    public sealed class FunctionsHttpClientAttribute : Attribute
    {
        public FunctionsHttpClientAttribute() { }
        public FunctionsHttpClientAttribute(string requestUrl, RequestMethod requestType = RequestMethod.Get) { }
        public FunctionsHttpClientAttribute(Uri requestUrl, RequestMethod requestType = RequestMethod.Get) { }

        public Uri RequestUrl { get; set; }

        [AutoResolve]
        public RequestMethod RequestMethod { get; private set; }

        public string Headers { get; set; }
        public string Body { get; set; }
    }
}
