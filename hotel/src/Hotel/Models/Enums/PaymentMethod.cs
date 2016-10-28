using System;

namespace TravelHubApi.Sdk.Hotel.Models.Enums
{
    [Serializable]
    public enum PaymentMethod
    {
        Undefined = 0,

        Invoice = 1,

        CreditCard = 2
    }
}
