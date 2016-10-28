using System;
using Newtonsoft.Json;

namespace TravelHubApi.Sdk.Hotel.Models
{
    [Serializable]
    public class Contacts
    {
        [JsonProperty(Order = 0)]
        public virtual string Id { get; set; }

        [JsonProperty(Order = 1)]
        public virtual Phone Phone { get; set; }
    }
}
