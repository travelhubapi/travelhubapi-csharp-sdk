using System;
using System.Net.Http;
using System.Text;
using QueryString;
using TravelHubApi.Sdk.Common.API;
using TravelHubApi.Sdk.Common.Exceptions;
using TravelHubApi.Sdk.Common.Extensions;
using TravelHubApi.Sdk.Common.Helpers;
using TravelHubApi.Sdk.Hotel.Models;
using TravelHubApi.Sdk.Hotel.Models.Enums;
using TravelHubApi.Sdk.Hotel.Models.Parameters;
using TravelHubApi.Sdk.Hotel.Models.Parameters.Body;
using TravelHubApi.Sdk.Hotel.Models.Parameters.Url;
using TravelHubApi.Sdk.OAuth;

namespace TravelHubApi.Sdk.Hotel
{
    public class HotelClient
    {
        #region Fields | Members
        private const string VERSION = "v1";

        private string _host;

        private OAuth.OAuthClient _oauth;
        #endregion

        #region Constructors | Destructors
        public HotelClient(Settings settings, OAuthClient oauth)
        {
            _host = settings.Environment == Common.API.Enums.Environment.Production
                  ? HotelClient.ProductionHost
                  : HotelClient.HomologHost;

            _oauth = oauth;
        }
        #endregion

        #region Properties
        public static string HomologHost
        {
            get
            {
                return "http://hotel.stg.travelhubapi.com.br";
            }
        }

        public static string ProductionHost
        {
            get
            {
                return "http://hotel.travelhubapi.com.br";
            }
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Get hotel.
        /// </summary>
        /// <param name="track">Hotel track code.</param>
        /// <returns>Hotel information</returns>
        public ApiResponse<Models.Hotel> GetHotel(string track)
        {
            var uri = string.Format("{0}/{1}/hotels/{2}", _host, VERSION, track);
            var response = _oauth.RequestAsync(HttpMethods.Get, uri).Result;
            var apiResponse = GenerateApiResponse<Models.Hotel>(response);
            return apiResponse;
        }

        /// <summary>
        /// Get Hotel Facilities.
        /// </summary>
        /// <param name="track">Hotel track code.</param>
        /// <returns>Hotel Facilities</returns>
        public ApiResponse<Facilities> GetFacilities(string track)
        {
            var uri = string.Format("{0}/{1}/hotels/{2}/facilities", _host, VERSION, track);
            var response = _oauth.RequestAsync(HttpMethods.Get, uri).Result;
            var apiResponse = GenerateApiResponse<Facilities>(response);
            return apiResponse;
        }

        /// <summary>
        /// Get Hotel Images.
        /// </summary>
        /// <param name="track">Hotel track code.</param>
        /// <returns>Hotel Images</returns>
        public ApiResponse<Images> GetImages(string track)
        {
            var uri = string.Format("{0}/{1}/hotels/{2}/images", _host, VERSION, track);
            var response = _oauth.RequestAsync(HttpMethods.Get, uri).Result;
            var apiResponse = GenerateApiResponse<Images>(response);
            return apiResponse;
        }

        /// <summary>
        /// Check availability of hotels.
        /// </summary>
        /// <param name="locationId">Location ID from get locations api.</param>
        /// <param name="checkIn">Check-in date (ISO 8601 date with YYYY-MM-DD format).</param>
        /// <param name="checkOut">Check-out date (ISO 8601 date with YYYY-MM-DD format).</param>
        /// <param name="rooms">Information about accommodation and guests.</param>
        /// <param name="currencyIso">Currency ISO in which they will be returned the hotel rate values.</param>
        /// <param name="hotelName">Filter the hotels by the part of name.</param>
        /// <param name="minimumStars">Filter the hotels by minimum stars that hotel must have.</param>
        /// <param name="basicInfo">Get hotel basic (true) or complete (default or false) information.</param>
        /// <param name="bookingAvailability">Booking availability type:<br/>
        ///     <para> * 'AvailableNow' - Hotels available for booking;<br/></para>
        ///     <para> * 'AvailableNowAndOnRequest' - Hotels available for booking and also booking on request.</para>
        /// </param>
        /// <returns>Availabilities of hotels.</returns>
        public ApiResponse<Availabilities> GetAvailabilities(
            string locationId, 
            DateTime checkIn, 
            DateTime checkOut,
            RoomParameter[] rooms,
            CurrencyIso currencyIso = CurrencyIso.BRL,
            string hotelName = null,
            decimal? minimumStars = null,
            bool? basicInfo = false,
            BookingAvailability bookingAvailability = BookingAvailability.Undefined)
        {
            var uri = string.Format(
                "{0}/{1}/availabilities/{2}/{3}/{4}",
                _host,
                VERSION,
                locationId,
                checkIn.ToIso8601DateFormat(),
                checkOut.ToIso8601DateFormat());
            
            var urlParams = new AvailabilitiesParams(
                rooms,
                currencyIso,
                hotelName,
                minimumStars,
                basicInfo);

            if (urlParams.HasParams()) 
            {
                uri += "?" + QS.Stringify(urlParams);
            }

            var response = _oauth.RequestAsync(HttpMethods.Get, uri).Result;
            var apiResponse = GenerateApiResponse<Availabilities>(response);
            return apiResponse;
        }

        /// <summary>
        /// Book a hotel without payment.
        /// In this case is possible to send the payment later, 
        /// but before the expiration date.
        /// </summary>
        /// <param name="bookRequest">Booking to be created.</param>
        /// <returns>Booking created with locators and expiration date.</returns>
        public ApiResponse<Booking> Book(BookRequest bookRequest)
        {
            var uri = string.Format("{0}/{1}/bookings", _host, VERSION);
            var bookRequestContent = new StringContent(bookRequest.ToJson(), Encoding.UTF8, "application/json");
            var response = _oauth.RequestAsync(HttpMethods.Post, uri, bookRequestContent).Result;
            var apiResponse = GenerateApiResponse<Booking>(response);
            return apiResponse;
        }

        /// <summary>
        /// Get the cancellation policies.
        /// </summary>
        /// <param name="checkIn">Check-in date (ISO 8601 date with YYYY-MM-DD format).</param>
        /// <param name="checkOut">Check-out date (ISO 8601 date with YYYY-MM-DD format).</param>
        /// <param name="hotel">Hotel that has the cancellation policies.</param>
        /// <returns>Hotel cancellation policies.</returns>
        public ApiResponse<CancellationPolicies> GetCancellationPolicies(DateTime checkIn, DateTime checkOut, Models.Hotel hotel)
        {
            var uri = string.Format(
                "{0}/{1}/{2}/{3}/cancellation_policies",
                _host,
                VERSION,
                checkIn.ToIso8601DateFormat(),
                checkOut.ToIso8601DateFormat());

            var getCancellationPoliciesRequestContent = new StringContent(hotel.ToJson(), Encoding.UTF8, "application/json");
            var response = _oauth.RequestAsync(HttpMethods.Post, uri, getCancellationPoliciesRequestContent).Result;
            var apiResponse = GenerateApiResponse<CancellationPolicies>(response);
            return apiResponse;
        }

        /// <summary>
        /// Get booking information.
        /// </summary>
        /// <param name="bookingCode">Booking code.</param>
        /// <returns>Booking information.</returns>
        public ApiResponse<Booking> GetBooking(string bookingCode)
        {
            var uri = string.Format("{0}/{1}/bookings/{2}", _host, VERSION, bookingCode);
            var response = _oauth.RequestAsync(HttpMethods.Get, uri).Result;
            var apiResponse = GenerateApiResponse<Booking>(response);
            return apiResponse;
        }

        /// <summary>
        /// Cancel booking.
        /// </summary>
        /// <param name="bookingCode">Booking code.</param>
        /// <param name="vendorId">Vendor Id.</param>
        /// <returns>Response Headers</returns>
        public ApiResponse CancelBooking(string bookingCode, string vendorId)
        {
            var uri = string.Format("{0}/{1}/bookings/{2}/{3}", _host, VERSION, bookingCode, vendorId);
            var response = _oauth.RequestAsync(HttpMethods.Delete, uri).Result;
            var apiResponse = GenerateApiResponse(response);
            return apiResponse;
        }

        /// <summary>
        /// Get the possible locations to availabilities of hotels filtering by description.
        /// </summary>
        /// <param name="description">Description of a place, can be a part of the city or state name (minimum of 3 characters).</param>
        /// <param name="limit">Maximum number of items to be returned in response.</param>
        /// <returns>Locations list.</returns>
        public ApiResponse<Locations> GetLocations(string description, int? limit = null)
        {
            var uri = string.Format("{0}/{1}/locations/{2}", _host, VERSION, description);

            if (limit.HasValue)
            {
                uri += string.Format("?limit={0}", limit);
            }

            var response = _oauth.RequestAsync(HttpMethods.Get, uri).Result;
            var apiResponse = GenerateApiResponse<Locations>(response);
            return apiResponse;
        }
        #endregion

        private ApiResponse<T> GenerateApiResponse<T>(HttpResponseMessage response)
            where T : class, new()
        {
            VerifyStatusCode(response);

            var apiResponse = new ApiResponse<T>(response);

            return apiResponse;
        }

        private ApiResponse GenerateApiResponse(HttpResponseMessage response)
        {
            VerifyStatusCode(response);

            var apiResponse = new ApiResponse(response);

            return apiResponse;
        }

        private void VerifyStatusCode(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
            {
                return;
            }

            throw new SDKRequestException(response);
        }
    }
}
