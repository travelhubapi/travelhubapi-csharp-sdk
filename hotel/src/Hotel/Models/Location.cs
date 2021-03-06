﻿using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using TravelHubApi.Sdk.Hotel.Models.Enums;

namespace TravelHubApi.Sdk.Hotel.Models
{
    [Serializable]
    public class Location
    {
        [JsonProperty(Order = 0)]
        public virtual string Id { get; set; }

        [JsonProperty(Order = 1), JsonConverter(typeof(StringEnumConverter))]
        public virtual LocationType Type { get; set; }

        [JsonProperty(Order = 2)]
        public virtual string PrefixCode { get; set; }

        [JsonProperty(Order = 3)]
        public virtual string Name { get; set; }

        [JsonProperty(Order = 4)]
        public virtual City City { get; set; }
    }
}
