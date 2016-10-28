using System;
using Newtonsoft.Json;

namespace TravelHubApi.Sdk.Hotel.Models
{
    [Serializable]
    public class Phone
    {
        [JsonProperty(Order = 0)]
        public virtual short? CountryCode { get; set; }

        [JsonProperty(Order = 1)]
        public virtual short? CityCode { get; set; }

        [JsonProperty(Order = 2)]
        public virtual int? Number { get; set; }
    }
}
