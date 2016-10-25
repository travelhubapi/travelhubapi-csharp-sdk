using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TravelHubApi.Sdk.Hotel.V1.Models
{
    public class CreditCardExpirationDate
    {
        [JsonProperty(Order = 0)]
        public virtual short? Month { get; set; }

        [JsonProperty(Order = 1)]
        public virtual short? Year { get; set; }
    }
}
