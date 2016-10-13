using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using TravelHubApi.Sdk.Hotel.V1.Enums;
using Newtonsoft.Json.Converters;

namespace TravelHubApi.Sdk.Hotel.V1.Models
{
    [Serializable]
    public class Room
    {
        #region Propriedades | Campos | Membros
        [JsonProperty(Order = 0)]
        public virtual string Code { get; set; }

        [JsonProperty(Order = 1)]
        public virtual string Number { get; set; }

        [JsonProperty(Order = 2, DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonConverter(typeof(StringEnumConverter))]
        public virtual RoomType? Type { get; set; }

        [JsonProperty(Order = 3, DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonConverter(typeof(StringEnumConverter))]
        public virtual Bed? Bed { get; set; }
        #endregion
    }
}
