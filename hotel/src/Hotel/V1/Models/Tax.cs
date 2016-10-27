using System;
using Newtonsoft.Json;

namespace TravelHubApi.Sdk.Hotel.V1.Models
{
    [Serializable]
    public class Tax
    {
        [JsonProperty(Order = 0)]
        public string Code { get; set; }

        [JsonProperty(Order = 1)]
        public MonetaryValue BaseTax { get; set; }

        [JsonProperty(Order = 2)]
        public MonetaryValue EquivalentTax { get; set; }
    }
}
