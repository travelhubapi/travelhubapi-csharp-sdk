using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelHubApi.Sdk.Hotel.V1.Models
{
    public class Remark
    {
        #region Properties
        /// <summary>
        /// Gets or sets the positioning index in the booking remarks list.
        /// </summary>
        [JsonProperty(Order = 0)]
        public virtual short? Index { get; set; }

        /// <summary>
        ///  Gets or sets the remarks content in the booking.
        /// </summary>
        [JsonProperty(Order = 1)]
        public virtual string FreeText { get; set; }
        #endregion
    }
}
