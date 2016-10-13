using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelHubApi.Sdk.Hotel.V1.Models
{
    public class Payments
    {
        #region Properties
        /// <summary>
        /// Define the items count.
        /// </summary>
        [JsonProperty(Order = 0)]
        public int Count { get { return Items != null ? Items.Count : 0; } set { } }


        /// <summary>
        /// Define a list of payments.
        /// </summary>
        [JsonProperty(Order = 1)]
        public List<Payment> Items { get; set; }
        #endregion
    }
}
