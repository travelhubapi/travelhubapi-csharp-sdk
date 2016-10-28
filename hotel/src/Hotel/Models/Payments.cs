using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace TravelHubApi.Sdk.Hotel.Models
{
    public class Payments
    {
        [JsonProperty(Order = 0)]
        public int Count
        {
            get
            {
                return Items != null ? Items.Count : 0;
            }
        }

        [JsonProperty(Order = 1)]
        public List<Payment> Items { get; set; }
    }
}
