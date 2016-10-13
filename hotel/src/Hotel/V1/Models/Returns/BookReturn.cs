using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using TravelHubApi.Sdk.Hotel.V1.Models;
using TravelHubApi.Sdk.Common.V1.Extensions;

namespace TravelHubApi.Sdk.Hotel.V1.Models.Returns
{
    [Serializable]
    public class BookReturn
    {
        #region Propriedades | Campos | Membros
        [JsonProperty(Order = 0)]
        public virtual string Id { get; set; }

        [JsonProperty(Order = 1)]
        public virtual string BookingGroup { get; set; }

        [JsonProperty(Order = 2)]
        public virtual int? SalesType { get; set; }

        [JsonProperty(Order = 3)]
        public virtual DateTime ExpireDate { get; set; }

        [JsonProperty(Order = 4)]
        [JsonConverter(typeof(Iso8601DateFormatConverter))]
        public virtual DateTime CheckIn { get; set; }

        [JsonProperty(Order = 5)]
        [JsonConverter(typeof(Iso8601DateFormatConverter))]
        public virtual DateTime CheckOut { get; set; }

        /// <summary>
        /// Gets or sets the user model
        /// </summary>
        [JsonProperty(Order = 6)]
        public virtual Vendor Vendor { get; set; }

        [JsonProperty(Order = 7)]
        public virtual Hotel Hotel { get; set; }
        #endregion
    }
}
