using System;

namespace TravelHubApi.Sdk.Hotel.Enums
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
