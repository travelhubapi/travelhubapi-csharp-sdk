using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TravelHubApi.Sdk.Hotel.V1.Enums;

namespace TravelHubApi.Sdk.Hotel.Parameters.V1.Url
{
    public class RoomParameter
    {
        public int Snr { get; set; }
        public int Adt { get; set; }
        public int Chd { get; set; }
        public List<short> Ages { get; set; }
        public Bed Bed { get; set; }
    }

    public class RoomParams
    {
        public RoomParams()
        {
            Items = new List<RoomParameter>();
        }

        public int Count { get
            {
                return (this.Items == null) ? 0 : (this.Items.Count);
            }
        }

        public List<RoomParameter> Items { get; set; }    
    }

    public class AvailabilitiesUrlParams
    {
        public string Destination { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public RoomParams Rooms { get; set; }
        public string FareType { get; set; }
        public string SalesModule { get; set; }
        public string Currency { get; set; }
        public int MinimunStarts { get; set; }
        public string BasicInfo { get; set; }
        public string BookingAvailability { get; set; }
        public string Agreement { get; set; }


    }
}
