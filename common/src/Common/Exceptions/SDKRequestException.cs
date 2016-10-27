using System;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;

namespace TravelHubApi.Sdk.Common.Exceptions
{
    public class SDKRequestException : Exception
    {
        #region Constructors | Destructors
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
        #endregion

        #region Properties
        public string CorrelationId { get; set; }

        public HttpStatusCode ResponseStatusCode { get; set; } 
        #endregion

        #region Private Methods
        private static string ParseMessage(HttpResponseMessage responseMessage)
        {
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            var error = JsonConvert.DeserializeObject(content) as dynamic;
            return (string)error.message;
        } 
        #endregion
    }
}
