using System;

namespace TravelHubApi.Sdk.Hotel.Enums
{
    [Serializable]
    public enum Bed
    {
        /// <summary>
        /// Is irrelevant.
        /// </summary>
        Irrelevant = 0,

        /// <summary>
        /// Single Bed.
        /// </summary>
        Single = 1,

        /// <summary>
        /// Double Bed.
        /// </summary>
        Double = 2,

        /// <summary>
        /// Queen Size Bed.
        /// </summary>
        QueenSize = 3,

        /// <summary>
        /// King Size Bed.
        /// </summary>
        KingSize = 4
    }
}
