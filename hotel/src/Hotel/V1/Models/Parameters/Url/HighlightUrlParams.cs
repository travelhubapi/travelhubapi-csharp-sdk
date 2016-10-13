using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TravelHubApi.Sdk.Hotel.V1.Enums;

namespace TravelHubApi.Sdk.Hotel.Parameters.V1.Url
{
    public class HighlightUrlParams
    {
        public HighlightType HighlightType { get; set; }

        public string Destination { get; set; }

        public DateTime CheckIn { get; set; }

        public DateTime CheckOut { get; set; }
    }
}
