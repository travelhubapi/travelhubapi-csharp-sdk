using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace TravelHubApi.Sdk.Hotel.V1.Models
{
    [Serializable]
    public class Locator
    {
        #region Propriedades | Campos | Membros
        [JsonProperty(Order = 0)]
        public virtual string Supplier { get; set; }

        [JsonProperty(Order = 1)]
        public virtual string Hotel { get; set; }
        #endregion
    }
}
