using System;
using Newtonsoft.Json;

namespace TravelHubApi.Sdk.Hotel.Models
{
    [Serializable]
    public class Value
    {
        [JsonProperty(Order = 0)]
        public virtual MonetaryValue Base { get; set; }

        [JsonProperty(Order = 1)]
        public virtual MonetaryValue Equivalent { get; set; }
    }
}
