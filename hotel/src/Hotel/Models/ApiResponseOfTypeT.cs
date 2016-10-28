using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TravelHubApi.Sdk.Common.Extensions;

namespace TravelHubApi.Sdk.Hotel.Models
{
    public class ApiResponse<T> : ApiResponse
        where T : class, new()
    {
        public ApiResponse(HttpResponseMessage response)
            : base(response)
        {
            Content = response.Content.ReadAsStringAsync().Result.ToObject<T>();
        }

        public T Content { get; set; }
    }
}
