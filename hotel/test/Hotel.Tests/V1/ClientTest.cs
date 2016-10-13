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
using Xunit;
using TravelHubApi.Sdk.Common.V1.Helpers;
using Moq;
using System.Net.Http;
using System.Threading.Tasks;
using TravelHubApi.Sdk.Hotel.V1;
using System.Net;
using TravelHubApi.Sdk.Hotel.Tests.V1.Mock;
using TravelHubApi.Sdk.Common.V1.Extensions;
using FluentAssertions;
using System.Globalization;
using TravelHubApi.Sdk.Hotel.V1.Models.Parameters.Body;
using TravelHubApi.Sdk.Hotel.V1.Models;
#endregion

namespace TravelHub.Infra.Broker.Flytour.Aereo.Testes
{
    public class ClientTest
    {
        #region Fields | Members
        Settings settings { get; set; }
        #endregion

        #region Constructors | Destructors
        public ClientTest()
        {
            settings = new Settings
            {
                Environment = TravelHubApi.Sdk.Common.V1.Helpers.Environment.Homolog,
                ClientId = "ClientId",
                ClientSecret = "ClientSecret"
            };
        }
        #endregion

        [Trait("Hotel", "")]
        [Fact(DisplayName = "Hotel - GetAvailabilities")]
        public void Should_Get_Availabilities()
        {
            var hotelClient = new Client(settings, 
                HotelMock.GetOAuthToAvailabilitiesResponse(settings));
            var checkIn = DateTime.ParseExact("2016-10-10", "yyyy-MM-dd", 
                CultureInfo.InvariantCulture);
            var checkOut = DateTime.ParseExact("2016-10-13", "yyyy-MM-dd", 
                CultureInfo.InvariantCulture);
            var availabilities = hotelClient.GetAvailabilities("sao", checkIn, checkOut);
            var availabilitiesExpected = HotelMock.GetAvailabilitiesResponse();

            availabilities.Should().NotBeNull();
            availabilities.ShouldBeEquivalentTo<Availabilities>(availabilitiesExpected, 
                options => options.AllowingInfiniteRecursion());
            availabilities.ToJson().Should().Be(HotelMock.GetAvailabilitiesJSONResponse());
        }

        [Trait("Hotel", "")]
        [Fact(DisplayName = "Hotel - GetHotel")]
        public void Should_Get_Hotel()
        {
            var hotelClient = new Client(settings,
                HotelMock.GetOAuthToHotelResponse(settings));
            var hotel = hotelClient.GetHotel("broker", "track");
            var hotelExpected = HotelMock.GetHotelResponse();

            hotel.Should().NotBeNull();
            hotel.ShouldBeEquivalentTo<Hotel>(hotelExpected);
            hotel.ToJson().Should().Be(HotelMock.GetHotelJSONResponse());
        }

        [Trait("Hotel", "")]
        [Fact(DisplayName = "Hotel - GetFacilities")]
        public void Should_Get_Facilities()
        {
            var hotelClient = new Client(settings,
                HotelMock.GetOAuthToFacilitiesResponse(settings));
            var facilites = hotelClient.GetFacilities("broker", "track");
            var facilitiesExpected = HotelMock.GetFacilitiesResponse();

            facilites.Should().NotBeNull();
            facilites.ShouldBeEquivalentTo<Facilities>(facilitiesExpected);
            facilites.ToJson().Should().Be(HotelMock.GetFacilitiesJSONResponse());
        }

        [Trait("Hotel", "")]
        [Fact(DisplayName = "Hotel - GetImages")]
        public void Should_Get_Images()
        {
            var hotelClient = new Client(settings,
                HotelMock.GetOAuthToImagesResponse(settings));
            var images = hotelClient.GetImages("broker", "track");
            var imagesExpected = HotelMock.GetImagesResponse();

            images.Should().NotBeNull();
            images.ShouldBeEquivalentTo<Images>(imagesExpected);
            images.ToJson().Should().Be(HotelMock.GetImagesJSONResponse());
        }

        [Trait("Hotel", "")]
        [Fact(DisplayName = "Hotel - Book")]
        public void Should_Book()
        {
            var hotelClient = new Client(settings,
                HotelMock.GetOAuthToBookResponse(settings));
            var bookRequest = HotelMock.GetBookRequest();

            bookRequest.Should().NotBeNull();

            var booking = hotelClient.Book(bookRequest);
            var bookingExpected = HotelMock.GetBookResponse();

            booking.Should().NotBeNull();
            booking.ShouldBeEquivalentTo<Booking>(bookingExpected);
            booking.ToJson().Should().Equals(HotelMock.GetBookJSONResponse());
        }
    }
}
