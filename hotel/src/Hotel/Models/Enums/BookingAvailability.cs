using System;

namespace TravelHubApi.Sdk.Hotel.Models.Enums
{
    /// <summary>
    /// Define the type of booking availability.
    /// </summary>
    [Serializable]
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
