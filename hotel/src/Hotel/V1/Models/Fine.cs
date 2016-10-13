﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace TravelHubApi.Sdk.Hotel.V1.Models
{
    [Serializable]
    public class Fine
    {
        #region Propriedades | Campos | Membros
        [JsonProperty(Order = 0)]
        public string Code { get; set; }

        [JsonProperty(Order = 0)]
        public Period Period { get; set; }

        [JsonProperty(Order = 1)]
        public MonetaryValue BaseFine { get; set; }

        [JsonProperty(Order = 2)]
        public MonetaryValue EquivalentFine { get; set; }
        #endregion
    }
}
