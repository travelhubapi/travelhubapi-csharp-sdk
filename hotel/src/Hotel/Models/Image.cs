﻿using System;
using Newtonsoft.Json;

namespace TravelHubApi.Sdk.Hotel.Models
{
    [Serializable]
    public class Image
    {
        [JsonProperty(Order = 0)]
        public virtual string Id { get; set; }

        [JsonProperty(Order = 1)]
        public virtual int Order { get; set; }

        [JsonProperty(Order = 2)]
        public virtual string Title { get; set; }

        [JsonProperty(Order = 3)]
        public virtual string Link { get; set; }
    }
}
