using System;
using Newtonsoft.Json;

namespace TravelHubApi.Sdk.Hotel.V1.Models
{
    [Serializable]
    public class City
    {
        [JsonProperty(Order = 0)]
        public virtual string Id { get; set; }

        [JsonProperty(Order = 1)]
        public virtual string PrefixCode { get; set; }

        [JsonProperty(Order = 2)]
        public virtual string Name { get; set; }

        [JsonProperty(Order = 3)]
        public virtual DateTime? CreationDate { get; set; }

        [JsonProperty(Order = 4)]
        public virtual bool? National { get; set; }

        [JsonProperty(Order = 5)]
        public virtual State State { get; set; }

        [JsonProperty(Order = 6)]
        public virtual Country Country { get; set; }
    }
}
