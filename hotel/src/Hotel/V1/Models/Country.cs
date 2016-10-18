using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace TravelHubApi.Sdk.Hotel.V1.Models
{
    [Serializable]
    public class Country
    {
        #region Propriedades
        [JsonProperty(Order = 0)]
        public virtual string Id { get; set; }
        /// <summary>
        /// Gets or sets the prefix code.
        /// </summary>
        [JsonProperty(Order = 1)]
        public virtual string PrefixCode { get; set; }

        [JsonProperty(Order = 2)]
        public virtual string Name { get; set; }
        #endregion
    }
}
