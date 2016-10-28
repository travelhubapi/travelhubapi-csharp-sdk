using System;
using Newtonsoft.Json;

namespace TravelHubApi.Sdk.Hotel.Models
{
    [Serializable]
    public class FareDetail
    {
        [JsonProperty(Order = 0)]
        public virtual string Id { get; set; }

        [JsonProperty(Order = 1)]
        public virtual DateTime? ApplicationDate { get; set; }

        [JsonProperty(Order = 2)]
        public virtual Value Daily { get; set; }
    }
}
