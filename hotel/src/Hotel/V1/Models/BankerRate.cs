using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace TravelHubApi.Sdk.Hotel.V1.Models
{
    [Serializable]
    public class BankerRate
    {
        [JsonProperty(Order = 0)]
        public virtual string Id { get; set; }

        [JsonProperty(Order = 1)]
        public virtual decimal? Amount { get; set; }

        [JsonProperty(Order = 2)]
        public virtual CurrencyCode CurrencyCode { get; set; }

        [JsonProperty(Order = 3)]
        public virtual DateTime? Date { get; set; }
    }
}
