using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TravelHubApi.Sdk.Hotel.V1.Models
{
    public class Remark
    {
        [JsonProperty(Order = 0)]
        public virtual short? Index { get; set; }

        [JsonProperty(Order = 1)]
        public virtual string FreeText { get; set; }
    }
}
