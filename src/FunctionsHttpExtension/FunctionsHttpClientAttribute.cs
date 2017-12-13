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
        public FunctionsHttpClientAttribute() => RequestMethod = RequestMethod.Get;
        public FunctionsHttpClientAttribute(string requestUrl, RequestMethod requestMethod = RequestMethod.Get)
        {
            RequestUrl = requestUrl;
        }

        public string RequestUrl { get; set; }

        public RequestMethod RequestMethod { get; private set; }

        public string Headers { get; set; }
        public string Body { get; set; }
    }
}
