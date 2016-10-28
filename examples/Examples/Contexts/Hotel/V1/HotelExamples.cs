using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Newtonsoft.Json;
using TravelHubApi.Sdk.Client;
using TravelHubApi.Sdk.Common.Helpers;
using TravelHubApi.Sdk.Hotel;
using TravelHubApi.Sdk.Hotel.Enums;
using TravelHubApi.Sdk.Hotel.Models;
using TravelHubApi.Sdk.Hotel.Models.Parameters;
using TravelHubApi.Sdk.Hotel.Models.Parameters.Body;

namespace TravelHubApi.Sdk.Examples.Contexts.Hotel.V1
{
    public class HotelExamples
    {
        public enum Block
        {
            Starting,
            Ending
        }

        public static void Run()
        {
            ////-> Settings
            var settings = new Settings();

            settings.Environment = TravelHubApi.Sdk.Common.Helpers.Environment.Homolog;
            settings.ClientId = System.Environment.GetEnvironmentVariable("TRAVELHUBAPI_CLIENT_ID");
            settings.ClientSecret = System.Environment.GetEnvironmentVariable("TRAVELHUBAPI_CLIENT_SECRET");

            var checkIn = DateTime.Now.AddDays(30);
            var checkOut = DateTime.Now.AddDays(37);

            ////-> Client
            var client = new TravelHubApiClient(settings);
            var hotelClient = client.HotelClient;
            
            ////-> GetLocation
            var locationId = GetLocationId(hotelClient);

            ////-> GetAvailabilities
            var hotel = GetHotelAvailable(hotelClient, locationId, checkIn, checkOut);

            ////-> Book
            var booking = Book(hotelClient, hotel, checkIn, checkOut);

            ////-> GetBooking
            var bookingData = GetBooking(hotelClient, booking.Code);

            ////-> CancelBooking
            CancelBooking(hotelClient, bookingData.Code);
            
            RecordOutputWriteLine();

            RecordOutput("Flow completed...");
            RecordOutput("Press any key to exit.");
            Console.ReadKey();
        }

        public static string GetLocationId(HotelClient client)
        {
            var description = "fort";

            RecordOutput("GetLocations", Block.Starting);

            RecordOutputWriteLine();

            RecordOutput(string.Format("Getting locations with description = '{0}'...", description));
            var locationsResponse = client.GetLocations(description);
            var locations = locationsResponse.Content;
            RecordOutput(string.Format("{0} locations returned.", locations.Count));

            RecordOutputWriteLine();

            RecordOutput("Getting first location...");
            var location = locations.Items.FirstOrDefault();
            RecordOutput(JsonConvert.SerializeObject(location));

            RecordOutputWriteLine();

            RecordOutput(string.Format("Getting location id {0} to be used.", location.Id), Block.Ending);

            return location.Id;
        }

        public static Sdk.Hotel.Models.Hotel GetHotelAvailable(
            HotelClient client,
            string locationId,
            DateTime checkIn,
            DateTime checkOut)
        {
            var roomParameters = new RoomParameter[]
            {
                new RoomParameter
                {
                    Adt = 1,
                    Chd = 1,
                    ChdAges = new List<short> { 2 }
                }
            };

            RecordOutput("GetAvailabilities", Block.Starting);

            RecordOutputWriteLine();

            RecordOutput("Preparing the room parameters...");
            RecordOutput(JsonConvert.SerializeObject(roomParameters));

            RecordOutputWriteLine();

            RecordOutput("Getting availabilities...");
            var availabilitiesResponse = client.GetAvailabilities(
                locationId,
                checkIn,
                checkOut,
                roomParameters);
            ////RecordOutput(JsonConvert.SerializeObject(availabilities));

            var availabilities = availabilitiesResponse.Content;
            var availability = availabilities.Items.FirstOrDefault();
            RecordOutput(string.Format("{0} hotels available returned.", availability.Hotels.Count));

            RecordOutputWriteLine();

            var hotel = availability.Hotels.Items.FirstOrDefault();
            RecordOutput(string.Format("Getting first hotel code {0} and name {1} to be used.", hotel.Code, hotel.Name), Block.Ending);
            
            return hotel;
        }

        public static Sdk.Hotel.Models.Booking Book(
            HotelClient client, 
            Sdk.Hotel.Models.Hotel hotel,
            DateTime checkIn,
            DateTime checkOut)
        {
            var guests = new List<Guest>
            {
                new Guest
                {
                    FirstName = "Marcos",
                    LastName = "Rava",
                    Document = new Document
                    {
                        Number = "000000000000",
                        Type = DocumentType.IndividualRegistrationCode
                    },
                    Gender = Gender.Male,
                    GuestType = GuestType.Adt,
                    BirthDate = DateTime.ParseExact(
                        "1986-07-31", 
                        "yyyy-MM-dd",
                        CultureInfo.InvariantCulture)
                },
                new Guest
                {
                    FirstName = "Baby",
                    LastName = "Rava",
                    Gender = Gender.Male,
                    GuestType = GuestType.Chd,
                    BirthDate = DateTime.ParseExact(
                        "2016-10-13", 
                        "yyyy-MM-dd",
                        CultureInfo.InvariantCulture)
                }
            };

            RecordOutput("Book", Block.Starting);

            RecordOutputWriteLine();

            RecordOutput("Getting accommodations...");
            ////-> Could be more than one accommodation
            var accomodation = hotel.Accommodations.Items.FirstOrDefault();
            RecordOutput(string.Format("{0} Accommodation code got.", accomodation.Code));
            
            RecordOutputWriteLine();

            RecordOutput("Preparing guests...");
            RecordOutput(JsonConvert.SerializeObject(guests));

            RecordOutputWriteLine();

            RecordOutput("Setting guests...");
            accomodation.Guests = new Guests();
            accomodation.Guests.Items = guests;

            RecordOutputWriteLine();

            RecordOutput("Setting accommodations to booking...");
            hotel.Accommodations.Items.Clear();
            hotel.Accommodations.Items.Add(accomodation);

            RecordOutputWriteLine();

            RecordOutput("Booking...");
            var bookRequest = new BookRequest
            {
                CheckIn = checkIn,
                CheckOut = checkOut,
                Hotel = hotel,
                Vendor = new Vendor
                {
                    Id = "vendor@domain.com"
                }
            };

            ////RecordOutput(JsonConvert.SerializeObject(bookRequest));
            var bookingResponse = client.Book(bookRequest);
            var booking = bookingResponse.Content;
            ////RecordOutput(JsonConvert.SerializeObject(booking));

            RecordOutput(string.Format("{0} booking code returned.", booking.Code), Block.Ending);
            
            return booking;
        }

        public static Sdk.Hotel.Models.Booking GetBooking(HotelClient client, string bookingCode)
        {
            RecordOutput("GetBooking", Block.Starting);

            RecordOutputWriteLine();

            RecordOutput(string.Format("Getting booking with code = '{0}'...", bookingCode));
            var booking = new Sdk.Hotel.Models.Booking { Code = bookingCode };
            ////var bookingResponse = client.GetBooking(bookingCode);
            ////var booking = bookingResponse.content;
            ////RecordOutput(JsonConvert.SerializeObject(booking));
            RecordOutput("Booking got.", Block.Ending);

            return booking;
        }

        public static void CancelBooking(HotelClient client, string bookingCode)
        {
            RecordOutput("CancelBooking", Block.Starting);

            RecordOutputWriteLine();

            RecordOutput(string.Format("Canceling booking with code = '{0}'...", bookingCode));
            ////client.CancelBooking(bookingCode, "vendor@domain.com");
            RecordOutput("Booking canceled.", Block.Ending);
        }
    
        public static void RecordOutput(string text, Block? block = null)
        {
            RecordBlock(block == Block.Starting);
            Console.WriteLine(text);

            if (block == Block.Ending)
            {
                RecordBlock(true);
                RecordOutputWriteLine();
            }
        }

        public static void RecordOutputWriteLine()
        {
            Console.WriteLine(string.Empty);
        }

        public static void RecordBlock(bool block)
        {
            if (block)
            {
                Console.WriteLine("======================================================================");
            }
        }
    }
}
