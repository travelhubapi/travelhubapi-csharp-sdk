using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace TravelHubApi.Sdk.Hotel.Models
{
    public class ApiResponse
    {
        private string correlationIdKey = "X-Correlation-Id";

        public ApiResponse(HttpResponseMessage response)
        {
            Headers = response.Headers;
            ResponseStatucCode = response.StatusCode;
        }

        public HttpResponseHeaders Headers { get; set; }

        public HttpStatusCode ResponseStatucCode { get; set; }

        public string CorrelationId
        {
            get
            {
                IEnumerable<string> correlationId;
                if (Headers != null &&
                    Headers.TryGetValues(correlationIdKey, out correlationId) &&
                    correlationId.First() != null)
                {
                    return correlationId.First();
                }

                return null;
            }
        }
    }
}
