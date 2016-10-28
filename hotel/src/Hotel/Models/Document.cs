using System;
using Newtonsoft.Json;
using TravelHubApi.Sdk.Hotel.Enums;

namespace TravelHubApi.Sdk.Hotel.Models
{
    [Serializable]
    public class Document
    {
        [JsonProperty(Order = 0)]
        public virtual DocumentType Type { get; set; }

        [JsonProperty(Order = 1)]
        public virtual string Number { get; set; }
    }
}
