using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelHubApi.Sdk.Hotel.V1.Models.Enums
{
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
