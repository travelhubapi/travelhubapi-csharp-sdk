using System;
using Newtonsoft.Json;

namespace TravelHubApi.Sdk.Hotel.V1.Models
{
   [Serializable]
    public class Availability
    {
        [JsonProperty(Order = 1)]
        public virtual TimeResults TimeResults { get; set; }

        [JsonProperty(Order = 2)]
        public virtual Hotels Hotels { get; set; }
    }
}
