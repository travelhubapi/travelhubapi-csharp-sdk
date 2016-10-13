using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using TravelHubApi.Sdk.Hotel.V1.Enums;

namespace TravelHubApi.Sdk.Hotel.V1.Models
{
    [Serializable]
    public class Guest
    {
        #region Propriedades | Campos | Membros
        [JsonProperty(Order = 0)]
        public virtual string FirstName { get; set; }

        [JsonProperty(Order = 1)]
        public virtual string LastName { get; set; }

        [JsonProperty(Order = 2)]
        public virtual Document Document { get; set; }

        [JsonProperty(Order = 3, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public virtual Gender? Gender { get; set; }

        [JsonProperty(Order = 4, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public virtual GuestType? GuestType { get; set; }

        [JsonProperty(Order = 5)]
        public virtual short? Age { get; set; }

        [JsonProperty(Order = 6)]
        public virtual DateTime? BirthDate { get; set; }
        #endregion
    }
}
