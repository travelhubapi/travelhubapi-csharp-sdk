using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace TravelHubApi.Sdk.Hotel.V1.Models
{
    [Serializable]
    public class MonetaryValue
    {
        [JsonProperty(Order = 0)]
        public virtual decimal Amount { get; set; }

        [JsonProperty(Order = 1)]
        public virtual CurrencyCode CurrencyCode { get; set; }
    }
}
