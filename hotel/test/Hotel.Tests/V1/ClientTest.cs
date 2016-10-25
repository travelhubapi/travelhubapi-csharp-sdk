#region Licenca
//-----------------------------------------------------------------------
// <copyright file="ClientTest.cs" company="Travel Hub">
//     Copyright (c) 2016, Flytour.  All Rights Reserved.
// </copyright>
//-----------------------------------------------------------------------
#endregion

#region Referencies
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using TravelHubApi.Sdk.Common.Extensions;
using TravelHubApi.Sdk.Common.Helpers;
using TravelHubApi.Sdk.Hotel.Tests.V1.Mock;
using TravelHubApi.Sdk.Hotel.V1;
using TravelHubApi.Sdk.Hotel.V1.Enums;
using TravelHubApi.Sdk.Hotel.V1.Models;
using TravelHubApi.Sdk.Hotel.V1.Models.Parameters;
using TravelHubApi.Sdk.Hotel.V1.Models.Parameters.Body;
using Xunit;
#endregion

namespace TravelHubApi.Sdk.Hotel.Tests.V1
{
    public class ClientTest
    {
        private Settings settings;

        #region Constructors | Destructors
        public ClientTest()
        {
            settings = new Settings
            {
                Environment = TravelHubApi.Sdk.Common.Helpers.Environment.Homolog,
                ClientId = "ClientId",
                ClientSecret = "ClientSecret"
            };
        }
        #endregion

        [Trait("Hotel", "")]
        [Trait("Hotel", "Availabilities")]
        [Fact(DisplayName = "Hotel - GetAvailabilities")]
        public void Should_Get_Availabilities()
        {
            var hotelClient = new HotelClient(
                settings, 
                HotelMock.GetOAuthToAvailabilitiesResponse(settings));
            var checkIn = DateTime.ParseExact(
                "2016-10-10", 
                "yyyy-MM-dd", 
                CultureInfo.InvariantCulture);
            var checkOut = DateTime.ParseExact(
                "2016-10-13", 
                "yyyy-MM-dd", 
                CultureInfo.InvariantCulture);

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
            var availabilities = hotelClient.GetAvailabilities("locationId", checkIn, checkOut, rooms);
            var availabilitiesExpected = HotelMock.GetAvailabilitiesResponse();

            availabilities.Should().NotBeNull();
            availabilities.ShouldBeEquivalentTo<Availabilities>(
                availabilitiesExpected, 
                options => options.AllowingInfiniteRecursion());
            availabilities.ToJson().Should().Be(HotelMock.GetAvailabilitiesJSONResponse());
        }

        [Trait("Hotel", "")]
        [Trait("Hotel", "Hotel")]
        [Fact(DisplayName = "Hotel - GetHotel")]
        public void Should_Get_Hotel()
        {
            var hotelClient = new HotelClient(
                settings,
                HotelMock.GetOAuthToHotelResponse(settings));
            var hotel = hotelClient.GetHotel("track");
            var hotelExpected = HotelMock.GetHotelResponse();

            hotel.Should().NotBeNull();
            hotel.ShouldBeEquivalentTo<TravelHubApi.Sdk.Hotel.V1.Models.Hotel>(hotelExpected);
            var a = hotel.ToJson();
            hotel.ToJson().Should().Be(HotelMock.GetHotelJSONResponse());
        }

        [Trait("Hotel", "")]
        [Trait("Hotel", "Hotel")]
        [Fact(DisplayName = "Hotel - GetFacilities")]
        public void Should_Get_Facilities()
        {
            var hotelClient = new HotelClient(
                settings,
                HotelMock.GetOAuthToFacilitiesResponse(settings));
            var facilites = hotelClient.GetFacilities("track");
            var facilitiesExpected = HotelMock.GetFacilitiesResponse();

            facilites.Should().NotBeNull();
            facilites.ShouldBeEquivalentTo<Facilities>(facilitiesExpected);
            facilites.ToJson().Should().Be(HotelMock.GetFacilitiesJSONResponse());
        }

        [Trait("Hotel", "")]
        [Trait("Hotel", "Hotel")]
        [Fact(DisplayName = "Hotel - GetImages")]
        public void Should_Get_Images()
        {
            var hotelClient = new HotelClient(
                settings,
                HotelMock.GetOAuthToImagesResponse(settings));
            var images = hotelClient.GetImages("track");
            var imagesExpected = HotelMock.GetImagesResponse();

            images.Should().NotBeNull();
            images.ShouldBeEquivalentTo<Images>(imagesExpected);
            images.ToJson().Should().Be(HotelMock.GetImagesJSONResponse());
        }

        [Trait("Hotel", "")]
        [Trait("Hotel", "Booking")]
        [Fact(DisplayName = "Hotel - Book")]
        public void Should_Book()
        {
            var hotelClient = new HotelClient(
                settings,
                HotelMock.GetOAuthToBookResponse(settings));
            var bookRequest = HotelMock.GetBookRequest();

            bookRequest.Should().NotBeNull();

            var booking = hotelClient.Book(bookRequest);
            var bookingExpected = HotelMock.GetBookResponse();

            booking.Should().NotBeNull();
            booking.ShouldBeEquivalentTo<Booking>(bookingExpected, options => options.AllowingInfiniteRecursion());
            booking.ToJson().Should().Equals(HotelMock.GetBookJSONResponse());
        }

        [Trait("Hotel", "")]
        [Trait("Hotel", "Booking")]
        [Fact(DisplayName = "Hotel - GetCancellationPolicies")]
        public void Should_Get_Cancellation_Policies()
        {
            var hotelClient = new HotelClient(
                settings,
                HotelMock.GetOAuthToGetCancellationPoliciesResponse(settings));
            var getCancellationPoliciesRequest = HotelMock.GetCancellationPoliciesRequest();

            var checkIn = DateTime.ParseExact(
                "2016-10-10", 
                "yyyy-MM-dd",
                CultureInfo.InvariantCulture);

            var checkOut = DateTime.ParseExact(
                "2016-10-13", 
                "yyyy-MM-dd",
                CultureInfo.InvariantCulture);

            getCancellationPoliciesRequest.Should().NotBeNull();

            var cancellationPolicies = hotelClient.GetCancellationPolicies(checkIn, checkOut, getCancellationPoliciesRequest);
            var cancellationPoliciesExpected = HotelMock.GetCancellationPoliciesResponse();

            cancellationPolicies.Should().NotBeNull();
            cancellationPolicies.ShouldBeEquivalentTo<CancellationPolicies>(cancellationPoliciesExpected);
            cancellationPolicies.ToJson().Should().Equals(HotelMock.GetCancellationPoliciesJSONResponse());
        }

        [Trait("Hotel", "")]
        [Trait("Hotel", "Booking")]
        [Fact(DisplayName = "Hotel - GetBooking")]
        public void Should_Get_Booking()
        {
            var hotelClient = new HotelClient(
                settings,
                HotelMock.GetOAuthToBookingResponse(settings));

            var booking = hotelClient.GetBooking("bookingCode");
            var bookingExpected = HotelMock.GetBookingResponse();

            booking.Should().NotBeNull();
            booking.ShouldBeEquivalentTo<Booking>(bookingExpected, options => options.AllowingInfiniteRecursion());
            booking.ToJson().Should().Equals(HotelMock.GetBookingJSONResponse());
        }

        [Trait("Hotel", "")]
        [Trait("Hotel", "Booking")]
        [Fact(DisplayName = "Hotel - CancelBooking")]
        public void Should_Cancel_Booking()
        {
            var hotelClient = new HotelClient(
                settings,
                HotelMock.GetOAuthToCancelBookingResponse(settings));

            hotelClient.CancelBooking("bookingCode", "vendorId");
        }

        [Trait("Hotel", "")]
        [Trait("Hotel", "Locations")]
        [Fact(DisplayName = "Hotel - GetLocations")]
        public void Should_Get_Locations()
        {
            var hotelClient = new HotelClient(
                settings,
                HotelMock.GetOAuthToLocationsResponse(settings));
            var locations = hotelClient.GetLocations("description");
            var locationsExpected = HotelMock.GetLocationsResponse();

            locations.Should().NotBeNull();
            locations.ShouldBeEquivalentTo<Locations>(locationsExpected);
            locations.ToJson().Should().Be(HotelMock.GetLocationsJSONResponse());
        }
    }
}
