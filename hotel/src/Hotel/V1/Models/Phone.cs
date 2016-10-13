using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace TravelHubApi.Sdk.Hotel.V1.Models
{
    [Serializable]
    public class Phone
    {
        #region Propriedades | Campos | Membros
        [JsonProperty(Order = 0)]
        public virtual short? CountryCode { get; set; }

        [JsonProperty(Order = 1)]
        public virtual short? CityCode { get; set; }

        [JsonProperty(Order = 2)]
        public virtual int? Number { get; set; }
        #endregion
    }
}
