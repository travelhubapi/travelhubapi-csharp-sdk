using System;
using System.Net;
using System.Net.Http;
using TravelHubApi.Sdk.Common.Helpers;
using TravelHubApi.Sdk.Hotel.Parameters.V1.Url;
using TravelHubApi.Sdk.Hotel.V1.Helpers;
using TravelHubApi.Sdk.Common.Extensions;
using TravelHubApi.Sdk.Hotel.V1.Models.Parameters.Body;
using System.Text;
using TravelHubApi.Sdk.Hotel.V1.Models;
using TravelHubApi.Sdk.OAuth;

namespace TravelHubApi.Sdk.Hotel.V1
{
    public class Client
    {
        private const string VERSION = "v1";

        private string _host;

        private OAuth.OAuthClient _oauth;

        #region Constructors | Destructors
        public Client(Settings settings, OAuthClient oauth)
        {
            _host = settings.Environment == Common.Helpers.Environment.Production
                  ? Hosts.PRODUCTION_HOST
                  : Hosts.HOMOLOG_HOST;

            _oauth = oauth;
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Get hotel
        /// </summary>
        /// <param name="broker"></param>
        /// <param name="track"></param>
        /// <returns></returns>
        public Models.Hotel GetHotel(string broker, string track)
        {
            var uri = string.Format("{0}/{1}/hotels/{2}/{3}", _host, VERSION, broker, track);
            var response = _oauth.RequestAsync(HttpMethods.Get, uri).Result;
            var result = response.Content.ReadAsStringAsync().Result;
            var hotel = result.ToObject<Models.Hotel>();

            return hotel;
        }

        public Facilities GetFacilities(string broker, string track)
        {
            var uri = string.Format("{0}/{1}/hotels/{2}/{3}/facilities", _host, VERSION, broker, track);
            var response = _oauth.RequestAsync(HttpMethods.Get, uri).Result;
            var result = response.Content.ReadAsStringAsync().Result;
            var facilities = result.ToObject<Facilities>();

            return facilities;
        }

        public Images GetImages(string broker, string track)
        {
            var uri = string.Format("{0}/{1}/hotels/{2}/{3}/images", _host, VERSION, broker, track);
            var response = _oauth.RequestAsync(HttpMethods.Get, uri).Result;
            var result = response.Content.ReadAsStringAsync().Result;
            var images = result.ToObject<Images>();

            return images;
        }

        public Availabilities GetAvailabilities(string destination, DateTime checkIn, DateTime checkOut)
        {
            var uri = string.Format("{0}/{1}/availabilities/{2}/{3}/{4}",
                _host, 
                VERSION, 
                destination, 
                checkIn.ToString("yyyy-MM-dd"), 
                checkOut.ToString("yyyy-MM-dd"));
            var response = _oauth.RequestAsync(HttpMethods.Get, uri).Result;
            var result = response.Content.ReadAsStringAsync().Result;
            var availabilities = result.ToObject<Availabilities>();

            return availabilities;
        }
        #endregion

        public Booking Book(BookBody bookrequest)
        {
            var uri = string.Format("{0}/{1}/bookings", _host, VERSION);
            var bookRequestContent = new StringContent(bookrequest.ToJson(), Encoding.UTF8, "application/json");
            var response = _oauth.RequestAsync(HttpMethods.Post, uri, bookRequestContent).Result;
            var result = response.Content.ReadAsStringAsync().Result;
            var booking = result.ToObject<Booking>();

            return booking;
        }
    }
}
