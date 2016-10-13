﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace TravelHubApi.Sdk.Hotel.V1.Models
{
    [Serializable]
    public class CurrencyCode
    {
        #region Propriedades
        [JsonProperty(Order = 0)]
        public string Iso { get; set; }

        [JsonProperty(Order = 1)]
        public string Symbol { get; set; }
        #endregion
    }
}
