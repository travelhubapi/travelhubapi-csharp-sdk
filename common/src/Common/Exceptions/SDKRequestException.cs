using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TravelHubApi.Sdk.Common.Extensions;

namespace TravelHubApi.Sdk.Common.Exceptions
{
    public class SDKRequestException : Exception
    {
        public SDKRequestException(HttpResponseMessage responseMessage)
            : base(ParseMessage(responseMessage))
        {
            var correlationIdStr = "CorrelationId: ";

            if (Message.IndexOf(correlationIdStr) >= 0)
            {
                CorrelationId = Message.Substring(
                    Message.LastIndexOf(correlationIdStr) + correlationIdStr.Length);
            }

            ResponseStatusCode = responseMessage.StatusCode;
        }

        public string CorrelationId { get; set; }

        public HttpStatusCode ResponseStatusCode { get; set; }

        private static string ParseMessage(HttpResponseMessage responseMessage)
        {
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            var error = JsonConvert.DeserializeObject(content) as dynamic;
            return (string)error.message;
        }
    }
}
