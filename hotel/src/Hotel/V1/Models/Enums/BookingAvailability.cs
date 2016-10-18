using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelHubApi.Sdk.Hotel.V1.Models.Enums
{
    /// <summary>
    /// Define the type of booking availability.
    /// </summary>
    public enum BookingAvailability
    {
        /// <summary>
        /// Is undefined.
        /// </summary>
        Undefined = 0,

        /// <summary>
        /// Is available now.
        /// </summary>
        AvailableNow = 1,

        /// <summary>
        /// Is available now and on request.
        /// </summary>
        AvailableNowAndOnRequest = 2
    }
}
