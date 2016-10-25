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
        ///   Senior guest.
        /// </summary>
        Snr = 1,

        /// <summary>
        ///   Adult guest.
        /// </summary>
        Adt = 2,

        /// <summary>
        ///   Child guest.
        /// </summary>
        Chd = 3
    }
}
