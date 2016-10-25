using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace TravelHubApi.Sdk.Hotel.V1.Models
{
    [Serializable]
    public class Hotel
    {
        [JsonProperty(Order = 0)]
        public virtual string Id { get; set; }

        [JsonProperty(Order = 1)]
        public virtual string Track { get; set; }

        [JsonProperty(Order = 2)]
        public virtual string Code { get; set; }

        [JsonProperty(Order = 3)]
        public virtual string Name { get; set; }

        [JsonProperty(Order = 4)]
        public virtual decimal? Stars { get; set; }

        [JsonProperty(Order = 5)]
        public virtual string Category { get; set; }

        [JsonProperty(Order = 6)]
        public virtual string Description { get; set; }

        [JsonProperty(Order = 7)]
        public virtual string Broker { get; set; }

        [JsonProperty(Order = 8)]
        public virtual string Supplier { get; set; }

        [JsonProperty(Order = 9)]
        public virtual Address Address { get; set; }

        [JsonProperty(Order = 10)]
        public virtual Contacts Contacts { get; set; }

        [JsonProperty(Order = 11)]
        public virtual Accommodations Accommodations { get; set; }

        [JsonProperty(Order = 12)]
        public virtual Facilities Facilities { get; set; }

        [JsonProperty(Order = 13)]
        public virtual Images Images { get; set; }
    }
}
