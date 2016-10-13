using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelHubApi.Sdk.Hotel.V1.Models.Enums
{
    [Serializable]
    public enum PaymentMethod
    {
        Undefined = 0,

        Invoice = 1,

        CreditCard = 2
    }
}
