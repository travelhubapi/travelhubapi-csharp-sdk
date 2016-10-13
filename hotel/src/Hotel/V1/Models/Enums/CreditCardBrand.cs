using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelHubApi.Sdk.Hotel.V1.Models.Enums
{
    [Serializable]
    public enum CreditCardBrand
    {
        Undefined = 0,
        MasterCard = 1,
        Visa = 2,
        DinersClub = 3,
        AmericanExpress = 4,
        Hipercard = 5,
        Elo = 6
    }
}
