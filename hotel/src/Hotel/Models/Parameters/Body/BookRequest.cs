using System;
using Newtonsoft.Json;

namespace TravelHubApi.Sdk.Hotel.Models.Parameters.Body
{
    [Serializable]
    public class BookRequest
    {
        #region Properties
        [JsonProperty(Order = 0)]
        public virtual string Id { get; set; }

        [JsonProperty(Order = 1)]
        public virtual string BookingGroup { get; set; }

        [JsonProperty(Order = 2)]
        public virtual int? SalesModule { get; set; }

        [JsonProperty(Order = 3)]
        public virtual DateTime ExpireDate { get; set; }

        [JsonProperty(Order = 4)]
        public virtual DateTime CheckIn { get; set; }

        [JsonProperty(Order = 5)]
        public virtual DateTime CheckOut { get; set; }

        [JsonProperty(Order = 6)]
        public virtual Vendor Vendor { get; set; }

        [JsonProperty(Order = 7)]
        public virtual Hotel Hotel { get; set; }
        #endregion
    }
}
