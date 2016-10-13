using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace TravelHubApi.Sdk.Hotel.V1.Models
{
    [Serializable]
    public class FareDetails
    {
        #region Propriedades | Campos | Membros
        [JsonProperty(Order = 0)]
        public int Count { get { return Items != null ? Items.Count : 0; } set { } }

        [JsonProperty(Order = 1)]
        public List<FareDetail> Items { get; set; }
        #endregion
    }
}
