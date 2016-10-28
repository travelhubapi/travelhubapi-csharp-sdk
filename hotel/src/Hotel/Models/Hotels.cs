using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace TravelHubApi.Sdk.Hotel.Models
{
    [Serializable]
    public class Hotels
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
        public List<Hotel> Items { get; set; }
    }
}
