using System;
using Newtonsoft.Json;

namespace TravelHubApi.Sdk.Hotel.V1.Models
{
    public class CancellationPolicies
    {
        [JsonProperty(Order = 0)]
        public virtual string Description { get; set; }

        [JsonProperty(Order = 1)]
        public virtual Fines Fines { get; set; }     
    }
}
