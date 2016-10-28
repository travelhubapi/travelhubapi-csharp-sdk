using System;

namespace TravelHubApi.Sdk.Hotel.Models.Enums
{
    [Serializable]
    public enum LocationType
    {
        /// <summary>
        /// Is undefined.
        /// </summary>
        Undefined = 0,

        /// <summary>
        /// Is an airport.
        /// </summary>
        Airport = 1,

        /// <summary>
        /// Is a city.
        /// </summary>
        City = 2
    }
}
