using System;
using Newtonsoft.Json;

namespace TravelHubApi.Sdk.Hotel.Models
{
    [Serializable]
    public class State
    {
        [JsonProperty(Order = 0)]
        public virtual string Id { get; set; }

        [JsonProperty(Order = 2)]
        public virtual string Code { get; set; }

        [JsonProperty(Order = 3)]
        public virtual string Name { get; set; }

        [JsonProperty(Order = 4)]
        public virtual Country Country { get; set; }
    }
}
