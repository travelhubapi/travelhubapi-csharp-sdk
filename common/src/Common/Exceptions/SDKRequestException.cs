using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TravelHubApi.Sdk.Common.Extensions;

namespace TravelHubApi.Sdk.Common.Exceptions
{
    public class SDKRequestException : Exception
    {
        public string CorrelationId { get; set; }

        public HttpStatusCode ResponseStatusCode { get; set; }

        public SDKRequestException(HttpResponseMessage responseMessage)
            :base(ParseMessage(responseMessage))
        {
            var CorrelationIdStr = "CorrelationId: ";

            if (Message.IndexOf(CorrelationIdStr) >= 0)
            {
                CorrelationId = Message.Substring(
                    Message.LastIndexOf(CorrelationIdStr) + CorrelationIdStr.Length);
            }

            ResponseStatusCode = responseMessage.StatusCode;
        }

        private static string ParseMessage(HttpResponseMessage responseMessage)
        {
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            var error = JsonConvert.DeserializeObject(content) as dynamic;
            return (string)error.message;
        }
    }
}
