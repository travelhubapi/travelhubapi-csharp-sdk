using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace TravelHubApi.Sdk.Hotel.V1.Models
{
   [Serializable]
    public class Availability
    {
        #region Propriedades | Campos | Membros

        /// <summary>
        /// Gets or sets the time result
        /// </summary>
        [JsonProperty(Order = 1)]
        public virtual TimeResults TimeResults { get; set; }

        /// <summary>
        /// Gets or sets the hotel objects
        /// </summary>
        [JsonProperty(Order = 2)]
        public virtual Hotels Hotels { get; set; }
        #endregion
    }
}
