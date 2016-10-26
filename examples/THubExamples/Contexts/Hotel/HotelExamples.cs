using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelHubApi.Sdk.Client;
using TravelHubApi.Sdk.Common.Helpers;
using TravelHubApi.Sdk.Hotel.V1.Enums;
using TravelHubApi.Sdk.Hotel.V1.Models;
using TravelHubApi.Sdk.Hotel.V1.Models.Parameters;
using TravelHubApi.Sdk.Hotel.V1.Models.Parameters.Body;

namespace THubExamples.Contexts.Hotel
{
    public class HotelExamples
    {
        public static void Run()
        {
            var settings = new Settings();

            settings.Environment = TravelHubApi.Sdk.Common.Helpers.Environment.Homolog;

            settings.ClientId = System.Environment.GetEnvironmentVariable("THUB_CLIENT_ID");
            settings.ClientSecret = System.Environment.GetEnvironmentVariable("THUB_CLIENT_SECRET");

            settings.ClientId = "54e428be-dc19-4258-b368-6d0752a3aaf5";
            settings.ClientSecret = "0d8599b2aba04204ad5c25e0b9d17df14958ebcdc37c4e23898fdf7b2879abe044ce46a3b208408ba2c05ae5215ee984";

            var client = new TravelHubApiClient(settings);
            var hotelClient = client.HotelClient;
            var checkIn = DateTime.Now.AddDays(1);
            var checkOut = DateTime.Now.AddDays(3);
            var locations = hotelClient.GetLocations("fort");

            Console.Write(locations.Count);

            var location = locations.Items.FirstOrDefault();
            var rooms = new RoomParameter[]
            {
                new RoomParameter() 
                {
                    Adt = 1,
                    Bed = Bed.Double,
                    Chd = 1,
                    ChdAges = new List<short>() { 2 }
                }
            };
            var availabilities = hotelClient.GetAvailabilities(
                location.Id,
                checkIn,
                checkOut,
                rooms);

            Console.Write(availabilities.Count);

            var availability = availabilities.Items.FirstOrDefault();
            var hotel = availability.Hotels.Items.FirstOrDefault();
            var accomodation = hotel.Accommodations.Items.FirstOrDefault();

            accomodation.Guests = new Guests();
            accomodation.Guests.Items = new List<Guest>()
            {
                new Guest() 
                {
                    FirstName = "Marcos",
                    LastName = "Rava",
                    Document = new Document() 
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
                new Guest() 
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

            hotel.Accommodations.Items = new List<Accommodation>()
            {
                accomodation
            };

            var bookRequest = new BookRequest()
            {
                CheckIn = checkIn,
                CheckOut = checkOut,
                Hotel = hotel,
                Vendor = new Vendor()
                {
                    Id = ""
                }
            };

            var booking = hotelClient.Book(bookRequest);

            hotelClient.GetBooking(booking.Code);
        }
    }
}
