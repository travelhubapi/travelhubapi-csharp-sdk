using System;
using Newtonsoft.Json;

namespace TravelHubApi.Sdk.Hotel.V1.Models
{
    [Serializable]
    public class Accommodation
    {
        [JsonProperty(Order = 0)]
        public virtual string Code { get; set; }

        [JsonProperty(Order = 1)]
        public virtual Locator Locator { get; set; }

        [JsonProperty(Order = 2)]
        public virtual string Name { get; set; }

        [JsonProperty(Order = 3)]
        public virtual Room Room { get; set; }

        [JsonProperty(Order = 4)]
        public virtual Guests Guests { get; set; }

        [JsonProperty(Order = 5)]
        public virtual int? Seniors { get; set; }

        [JsonProperty(Order = 6)]
        public virtual int? Adults { get; set; }

        [JsonProperty(Order = 7)]
        public virtual int? Children { get; set; }

        [JsonProperty(Order = 8)]
        public virtual short? AvailableRooms { get; set; }

        [JsonProperty(Order = 9)]
        public virtual Fares Fares { get; set; }
    }
}
