using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TravelHubApi.Sdk.Hotel.V1.Models
{
    [Serializable]
    public class Period
    {
        public virtual DateTime? Begin { get; set; }

        public virtual DateTime? End { get; set; }
    }
}
