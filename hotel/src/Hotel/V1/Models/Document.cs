using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using TravelHubApi.Sdk.Hotel.V1.Enums;

namespace TravelHubApi.Sdk.Hotel.V1.Models
{
    [Serializable]
    public class Document
    {
        [JsonProperty(Order = 0)]
        public virtual DocumentType Type { get; set; }

        [JsonProperty(Order = 1)]
        public virtual string Number { get; set; }
    }
}
