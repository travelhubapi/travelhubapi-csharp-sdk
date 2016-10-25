using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelHubApi.Sdk.Hotel.V1.Models.Enums;

namespace TravelHubApi.Sdk.Hotel.V1.Models.Parameters.Url
{
    internal class AvailabilitiesParams : IUrlParams
    {
        public AvailabilitiesParams(
            RoomParameter[] rooms,
            CurrencyIso currencyIso,
            string hotelName,
            decimal? minimumStars,
            bool? basicInfo)
        {
            Rooms = rooms;
            CurrencyIso = currencyIso;
            HotelName = hotelName;
            MinimumStars = minimumStars;
            BasicInfo = basicInfo;
            BookingAvailability = BookingAvailability;
        }

        public RoomParameter[] Rooms { get; set; }

        public CurrencyIso CurrencyIso { get; set; }

        public string HotelName { get; set; }

        public decimal? MinimumStars { get; set; }

        public bool? BasicInfo { get; set; }

        public BookingAvailability BookingAvailability { get; set; }

        public bool HasParams()
        {
            return Rooms != null ||
                CurrencyIso != CurrencyIso.BRL ||
                !string.IsNullOrEmpty(HotelName) ||
                MinimumStars.HasValue ||
                BasicInfo == true ||
                BookingAvailability != BookingAvailability.Undefined;
        }
    }
}
