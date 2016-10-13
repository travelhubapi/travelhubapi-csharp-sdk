using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TravelHubApi.Sdk.Hotel.V1.Enums
{
    public enum DocumentType
    {
        /// <summary>
        /// Is undefined.
        /// </summary>
        Undefined = 0,

        /// <summary>
        /// Is CPF.
        /// </summary>
        Cpf = 1,

        /// <summary>
        /// Is RG.
        /// </summary>
        Rg = 2,

        /// <summary>
        /// Is Passport.
        /// </summary>
        Passport = 3
    }
}
