using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelHubApi.Sdk.Hotel.V1.Models.Enums;

namespace TravelHubApi.Sdk.Hotel.V1.Models.Parameters.Url
{

    internal class AvailabilitiesParams : UrlParams
    {
        public RoomParameter[] rooms { get; set; }
        public CurrencyIso currencyIso { get; set; }
        public string hotelName { get; set; }
        public decimal? minimumStars { get; set; }
        public bool? basicInfo { get; set; }
        public BookingAvailability bookingAvailability { get; set; }

        public AvailabilitiesParams(
            RoomParameter[] rooms,
            CurrencyIso currencyIso,
            string hotelName,
            decimal? minimumStars,
            bool? basicInfo)
        {
            this.rooms = rooms;
            this.currencyIso = currencyIso;
            this.hotelName = hotelName;
            this.minimumStars = minimumStars;
            this.basicInfo = basicInfo;
            this.bookingAvailability = bookingAvailability;
        }

        public bool HasParams()
        {
            return rooms != null ||
                currencyIso != CurrencyIso.BRL ||
                !String.IsNullOrEmpty(hotelName) ||
                minimumStars.HasValue ||
                basicInfo == true ||
                bookingAvailability != BookingAvailability.Undefined;
        }
    }
}
