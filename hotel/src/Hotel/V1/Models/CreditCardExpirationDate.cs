using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelHubApi.Sdk.Hotel.V1.Models
{
    public class CreditCardExpirationDate
    {
        #region Properties
        /// <summary>
        /// Gets or sets the month
        /// </summary>
        [JsonProperty(Order = 0)]
        public virtual short? Month { get; set; }

        /// <summary>
        /// Gets or sets the year
        /// </summary>
        [JsonProperty(Order = 1)]
        public virtual short? Year { get; set; }
        #endregion
    }
}
