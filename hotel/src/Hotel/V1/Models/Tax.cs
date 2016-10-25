using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace TravelHubApi.Sdk.Hotel.V1.Models
{
    [Serializable]
    public class Tax
    {
        [JsonProperty(Order = 0)]
        public string Code { get; set; }

        [JsonProperty(Order = 1)]
        public MonetaryValue BaseFee { get; set; }

        [JsonProperty(Order = 2)]
        public MonetaryValue EquivalentFee { get; set; }
    }
}
