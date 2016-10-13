using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace TravelHubApi.Sdk.Hotel.V1.Models
{
    [Serializable]
    public class Highlight
    {
        #region Propriedades | Campos | Membros
        [JsonProperty(Order = 0)]
        public virtual DateTime? Checkin { get; set; }

        [JsonProperty(Order = 1)]
        public virtual DateTime? Checkout { get; set; }

        [JsonProperty(Order = 2)]
        public virtual string Name { get; set; }

        //[JsonProperty(Order = 3)]
        //public virtual HighlightType Type { get; set; }

        [JsonProperty(Order = 3)]
        public virtual City City { get; set; }

        [JsonProperty(Order = 4)]
        public virtual FareDetail FareDetail { get; set; }

        #endregion
    }
}
