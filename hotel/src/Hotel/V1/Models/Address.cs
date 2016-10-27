using System;
using Newtonsoft.Json;

namespace TravelHubApi.Sdk.Hotel.V1.Models
{
    [Serializable]
    public class Address
    {
        [JsonProperty(Order = 0)]
        public virtual string Id { get; set; }

        [JsonProperty(Order = 1)]
        public virtual string Street { get; set; }

        [JsonProperty(Order = 2)]
        public virtual string Number { get; set; }

        [JsonProperty(Order = 3)]
        public virtual string Addition { get; set; }

        [JsonProperty(Order = 4)]
        public virtual string Neighborhood { get; set; }

        [JsonProperty(Order = 5)]
        public virtual string ZipCode { get; set; }

        [JsonProperty(Order = 6)]
        public virtual City City { get; set; }

        [JsonProperty(Order = 7)]
        public virtual decimal Latitude { get; set; }

        [JsonProperty(Order = 8)]
        public virtual decimal Longitude { get; set; }
    }
}
