using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelHubApi.Sdk.Hotel.V1.Enums;

namespace TravelHubApi.Sdk.Hotel.V1.Models.Parameters
{
    public class RoomParameter
    {
        #region Propriedades
        /// <summary>
        /// Gets or sets the number of seniors in the accommodation.
        /// </summary>
        [JsonProperty(Order = 0)]
        public short Snr { get; set; }

        /// <summary>
        /// Gets or sets the number of adults in the accommodation.
        /// </summary>
        [JsonProperty(Order = 1)]
        public short Adt { get; set; }

        /// <summary>
        /// Gets or sets the number of children in the accommodation.
        /// </summary>
        [JsonProperty(Order = 2)]
        public short Chd { get; set; }

        /// <summary>
        /// Gets or sets the children age.
        /// </summary>
        [JsonProperty(Order = 3)]
        public List<short> ChdAges { get; set; }

        /// <summary>
        /// Gets or sets the type of bed in the room.
        /// </summary>
        [JsonProperty(Order = 4)]
        public virtual Bed Bed { get; set; }
        #endregion
    }
}
