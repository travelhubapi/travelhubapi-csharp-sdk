using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace TravelHubApi.Sdk.Hotel.V1.Models
{
    [Serializable]
    public class Value
    {
        [JsonProperty(Order = 0)]
        public virtual MonetaryValue Base { get; set; }

        [JsonProperty(Order = 1)]
        public virtual MonetaryValue Equivalent { get; set; }
    }
}
