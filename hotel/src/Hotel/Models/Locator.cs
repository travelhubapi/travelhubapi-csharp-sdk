using System;
using Newtonsoft.Json;

namespace TravelHubApi.Sdk.Hotel.Models
{
    [Serializable]
    public class Locator
    {
        [JsonProperty(Order = 0)]
        public virtual string Broker { get; set; }

        [JsonProperty(Order = 1)]
        public virtual string Hotel { get; set; }
    }
}
