using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TravelHubApi.Sdk.Hotel.V1.Enums
{
    public enum Bed
    {
        /// <summary>
        /// Irrelevant.
        /// </summary>
        Irrelevant = 0,

        /// <summary>
        /// Cama, quarto duplo (twin room). 
        /// Cama de hotel para uma pessoa, geralmente com um colchão de tamanho 90 cm x 190-200 cm.
        /// </summary>
        Single = 1,

        /// <summary>
        /// Double.
        /// </summary>
        Double = 2,

        /// <summary>
        /// Queen Size.
        /// </summary>
        QueenSize = 3,

        /// <summary>
        /// King Size.
        /// </summary>
        KingSize = 4,
    }
}
