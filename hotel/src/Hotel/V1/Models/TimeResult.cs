using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace TravelHubApi.Sdk.Hotel.V1.Models
{
    [Serializable]
    public class TimeResult
    {
        #region Propriedades | Campos | Membros
        /// <summary>
        /// Gets or sets the supplier 
        /// </summary>
        [JsonProperty(Order = 0)]
        public virtual string Broker { get; set; }

        /// <summary>
        /// Gets or sets the message
        /// </summary>
        [JsonProperty(Order = 1)]
        public virtual string Message { get; set; }

        /// <summary>
        /// Gets or sets the exception returned
        /// </summary>
        [JsonProperty(Order = 2)]
        public virtual string Exception { get; set; }
        #endregion
    }
}
