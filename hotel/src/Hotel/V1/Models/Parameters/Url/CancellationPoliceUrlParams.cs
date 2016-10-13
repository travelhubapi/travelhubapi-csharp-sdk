using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TravelHubApi.Sdk.Hotel.Parameters.V1.Url
{
    public class CancellationPoliceUrlParams
    {
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public string FareType { get; set; }
    }
}
