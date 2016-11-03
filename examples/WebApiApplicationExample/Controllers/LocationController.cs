using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using TravelHubApi.Sdk.Client;
using TravelHubApi.Sdk.Common.API;
using TravelHubApi.Sdk.Hotel.Models;

namespace WebApiApplicationExample.Controllers
{
    public class LocationController : ApiController
    {
        public async Task<Locations> GetAsync(string descriptionAsync)
        {
            var settings = new Settings();

            settings.Environment = TravelHubApi.Sdk.Common.API.Enums.Environment.Homolog;
            settings.ClientId = System.Environment.GetEnvironmentVariable("TRAVELHUBAPI_CLIENT_ID");
            settings.ClientSecret = System.Environment.GetEnvironmentVariable("TRAVELHUBAPI_CLIENT_SECRET");

            var checkIn = DateTime.Now.AddDays(30);
            var checkOut = DateTime.Now.AddDays(37);

            ////-> Client
            var client = new TravelHubApiClient(settings);
            var hotelClient = client.HotelClient;
            var result = await hotelClient.GetLocationsAsync(descriptionAsync);
            var locations = result.Content;
            
            return locations;
        }
        public Locations Get(string description)
        {
            var settings = new Settings();

            settings.Environment = TravelHubApi.Sdk.Common.API.Enums.Environment.Homolog;
            settings.ClientId = System.Environment.GetEnvironmentVariable("TRAVELHUBAPI_CLIENT_ID");
            settings.ClientSecret = System.Environment.GetEnvironmentVariable("TRAVELHUBAPI_CLIENT_SECRET");

            var checkIn = DateTime.Now.AddDays(30);
            var checkOut = DateTime.Now.AddDays(37);

            ////-> Client
            var client = new TravelHubApiClient(settings);
            var hotelClient = client.HotelClient;
            var result = hotelClient.GetLocations(description);
            var locations = result.Content;

            return locations;
        }
    }
}
