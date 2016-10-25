using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace TravelHubApi.Sdk.Hotel.V1.Models
{
    [Serializable]
    public class FareDetail
    {
        [JsonProperty(Order = 0)]
        public virtual string Id { get; set; }

        [JsonProperty(Order = 1)]
        public virtual DateTime? ApplicationDate { get; set; }

        [JsonProperty(Order = 2)]
        public virtual Value Daily { get; set; }
    }
}
