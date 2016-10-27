using System;

namespace TravelHubApi.Sdk.Hotel.V1.Enums
{
    [Serializable]
    public enum DocumentType
    {
        /// <summary>
        /// Is undefined or not informed;
        /// </summary>
        Undefined = 0,

        /// <summary>
        /// It is a document like C.P.F. from Brazil and Social Security Number from U.S.A.
        /// </summary>
        IndividualRegistrationCode = 1,

        /// <summary>
        ///  Identity document like R.G. from Brazil.
        /// </summary>
        Id = 2,

        /// <summary>
        /// Is Passport.
        /// </summary>
        Passport = 3
    }
}
