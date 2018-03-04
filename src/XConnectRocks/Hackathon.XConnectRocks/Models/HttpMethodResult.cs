using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XConnectRocks.Models
{
    /// <summary>
    /// Model to hold Web API response
    /// </summary>
    public class HttpMethodResult
    {
        public enum HttpMethodResultStatus
        {
            OK,
            Failed
        }
        public HttpMethodResultStatus ResultStatus { get; set; }

        public string ResultPayLoad { get; set; }

        public Exception ResultException { get; set; }
    }
}
