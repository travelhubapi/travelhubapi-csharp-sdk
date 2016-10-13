using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TravelHubApi.Sdk.Hotel.V1.Enums
{
    [Serializable]
    public enum GuestType
    {
        /// <summary>
        ///   Senior.
        /// </summary>
        Snr = 1,

        /// <summary>
        ///   Adult.
        /// </summary>
        Adt = 2,

        /// <summary>
        ///   Child.
        /// </summary>
        Chd = 3
    }
}
