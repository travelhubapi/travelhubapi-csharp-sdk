using System;
using System.IO;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using TravelHubApi.Sdk.Common.API;
using TravelHubApi.Sdk.Common.Extensions;
using TravelHubApi.Sdk.Common.Helpers;
using TravelHubApi.Sdk.Hotel.Models;
using TravelHubApi.Sdk.Hotel.Models.Parameters.Body;
using TravelHubApi.Sdk.OAuth;

namespace TravelHubApi.Sdk.Hotel.Tests.Mock
{
    public static class HotelMock
    {
        private static string currentPath = Directory.GetCurrentDirectory();

        #region Public Methods
        #region GetAvailabilities
        public static OAuthClient GetOAuthToAvailabilitiesResponse(Settings settings)
        {
            return GetOAuth(
                settings,
                HttpMethods.Get,
                "http://hotel.stg.travelhubapi.com.br/v1/availabilities/locationId/2016-10-10/2016-10-13?Rooms[0][Snr]=0&Rooms[0][Adt]=1&Rooms[0][Chd]=1&Rooms[0][ChdAges][0]=2&CurrencyIso=BRL&BasicInfo=False&BookingAvailability=Undefined",
                GetAvailabilitiesJSONResponse(),
                null,
                HttpStatusCode.OK);
        }

        public static string GetAvailabilitiesJSONResponse()
        {
            return LoadFiles.LoadJsonString(GetPath("Json/ResponseAvailabilities.json"));
        }

        public static Availabilities GetAvailabilitiesResponse()
        {
            return GetAvailabilitiesJSONResponse().ToObject<Availabilities>();
        }
        #endregion

        #region GetHotel
        public static OAuthClient GetOAuthToHotelResponse(Settings settings)
        {
            return GetOAuth(
                settings,
                HttpMethods.Get,
                "http://hotel.stg.travelhubapi.com.br/v1/hotels/track",
                GetHotelJSONResponse(),
                null,
                HttpStatusCode.OK);
        }

        public static string GetHotelJSONResponse()
        {
            return LoadFiles.LoadJsonString(GetPath("Json/ResponseHotel.json"));
        }

        public static TravelHubApi.Sdk.Hotel.Models.Hotel GetHotelResponse()
        {
            return GetHotelJSONResponse().ToObject<TravelHubApi.Sdk.Hotel.Models.Hotel>();
        }
        #endregion

        #region GetFacilities
        public static OAuthClient GetOAuthToFacilitiesResponse(Settings settings)
        {
            return GetOAuth(
                settings,
                HttpMethods.Get,
                "http://hotel.stg.travelhubapi.com.br/v1/hotels/track/facilities",
                GetFacilitiesJSONResponse(),
                null,
                HttpStatusCode.OK);
        }

        public static string GetFacilitiesJSONResponse()
        {
            return LoadFiles.LoadJsonString(GetPath("Json/ResponseFacilities.json"));
        }

        public static Facilities GetFacilitiesResponse()
        {
            return GetFacilitiesJSONResponse().ToObject<Facilities>();
        }
        #endregion

        #region GetImages
        public static OAuthClient GetOAuthToImagesResponse(Settings settings)
        {
            return GetOAuth(
                settings,
                HttpMethods.Get,
                "http://hotel.stg.travelhubapi.com.br/v1/hotels/track/images",
                GetImagesJSONResponse(),
                null,
                HttpStatusCode.OK);
        }

        public static string GetImagesJSONResponse()
        {
            return LoadFiles.LoadJsonString(GetPath("Json/ResponseImages.json"));
        }

        public static Images GetImagesResponse()
        {
            return GetImagesJSONResponse().ToObject<Images>();
        }
        #endregion

        #region Book
        public static OAuthClient GetOAuthToBookResponse(Settings settings)
        {
            var bookRequest = GetBookJSONRequest();
            var bookRequestContent = new StringContent(bookRequest, Encoding.UTF8, "application/json");
            
            Func<HttpContent, bool> httpRequestContentCheck = content =>
            {
                var bookRequestString = content.ReadAsStringAsync().Result;
                var bookRequestObj = bookRequestString.ToObject<BookRequest>();
                var bookRequestExpectedObj = bookRequest.ToObject<BookRequest>();
                try
                {
                    bookRequestObj.ShouldBeEquivalentTo<BookRequest>(bookRequestExpectedObj, options => options.AllowingInfiniteRecursion());
                    return true;
                }
                catch
                {
                    return false;
                }
            };

            return GetOAuth(
                settings,
                HttpMethods.Post,
                "http://hotel.stg.travelhubapi.com.br/v1/bookings",
                GetBookJSONResponse(),
                bookRequestContent,
                HttpStatusCode.OK,
                httpRequestContentCheck);
        }

        public static string GetBookJSONResponse()
        {
            return LoadFiles.LoadJsonString(GetPath("Json/ResponseBooking.json"));
        }

        public static string GetBookJSONRequest()
        {
            return LoadFiles.LoadJsonString(GetPath("Json/RequestBooking.json"));
        }

        public static Booking GetBookResponse()
        {
            return GetBookJSONResponse().ToObject<Booking>();
        }

        public static BookRequest GetBookRequest()
        {
            return GetBookJSONRequest().ToObject<BookRequest>();
        }
        #endregion

        #region GetCancellationPolicies
        public static OAuthClient GetOAuthToGetCancellationPoliciesResponse(Settings settings)
        {
            var getCancellationPoliciesRequest = GetCancellationPoliciesJSONRequest();
            var getCancellationPoliciesRequestContent = new StringContent(getCancellationPoliciesRequest, Encoding.UTF8, "application/json");

            Func<HttpContent, bool> httpRequestContentCheck = content =>
            {
                var getCancellationPoliciesRequestString = content.ReadAsStringAsync().Result;
                var getCancellationPoliciesRequestObj = getCancellationPoliciesRequestString.ToObject<TravelHubApi.Sdk.Hotel.Models.Hotel>();
                var getCancellationPoliciesRequestExpectedObj = getCancellationPoliciesRequest.ToObject<TravelHubApi.Sdk.Hotel.Models.Hotel>();
                try
                {
                    getCancellationPoliciesRequestObj.ShouldBeEquivalentTo<TravelHubApi.Sdk.Hotel.Models.Hotel>(getCancellationPoliciesRequestExpectedObj);
                    return true;
                }
                catch
                {
                    return false;
                }
            };

            return GetOAuth(
                settings,
                HttpMethods.Post,
                "http://hotel.stg.travelhubapi.com.br/v1/2016-10-10/2016-10-13/cancellation_policies",
                GetCancellationPoliciesJSONResponse(),
                getCancellationPoliciesRequestContent,
                HttpStatusCode.OK,
                httpRequestContentCheck);
        }

        public static string GetCancellationPoliciesJSONResponse()
        {
            return LoadFiles.LoadJsonString(GetPath("Json/RequestCancellationPolicies.json"));
        }

        public static string GetCancellationPoliciesJSONRequest()
        {
            return LoadFiles.LoadJsonString(GetPath("Json/RequestCancellationPolicies.json"));
        }

        public static CancellationPolicies GetCancellationPoliciesResponse()
        {
            return GetCancellationPoliciesJSONResponse().ToObject<CancellationPolicies>();
        }

        public static TravelHubApi.Sdk.Hotel.Models.Hotel GetCancellationPoliciesRequest()
        {
            return GetCancellationPoliciesJSONRequest().ToObject<TravelHubApi.Sdk.Hotel.Models.Hotel>();
        }
        #endregion

        #region GetBooking
        public static OAuthClient GetOAuthToBookingResponse(Settings settings)
        {
            return GetOAuth(
                settings,
                HttpMethods.Get,
                "http://hotel.stg.travelhubapi.com.br/v1/bookings/bookingCode",
                GetBookingJSONResponse(),
                null,
                HttpStatusCode.OK);
        }

        public static string GetBookingJSONResponse()
        {
            return LoadFiles.LoadJsonString(GetPath("Json/ResponseBooking.json"));
        }

        public static Booking GetBookingResponse()
        {
            return GetBookingJSONResponse().ToObject<Booking>();
        }
        #endregion

        #region CancelBooking
        public static OAuthClient GetOAuthToCancelBookingResponse(Settings settings)
        {
            return GetOAuth(
                settings,
                HttpMethods.Delete,
                "http://hotel.stg.travelhubapi.com.br/v1/bookings/bookingCode/vendorId",
                string.Empty,
                null,
                HttpStatusCode.NoContent);
        }
        #endregion

        #region GetLocations
        public static OAuthClient GetOAuthToLocationsResponse(Settings settings)
        {
            return GetOAuth(
                settings,
                HttpMethods.Get,
                "http://hotel.stg.travelhubapi.com.br/v1/locations/description",
                GetLocationsJSONResponse(),
                null,
                HttpStatusCode.OK);
        }

        public static string GetLocationsJSONResponse()
        {
            return LoadFiles.LoadJsonString(GetPath("Json/ResponseLocations.json"));
        }

        public static Locations GetLocationsResponse()
        {
            return GetLocationsJSONResponse().ToObject<Locations>();
        }
        #endregion
        #endregion

        #region Private Methods
        private static string GetPath(string path)
        {
            return Path.GetFullPath(Path.Combine(currentPath, "Mock", path));
        }

        private static OAuthClient GetOAuth(
            Settings settings,
            HttpMethods method,
            string uri,
            string responseContent,
            HttpContent content,
            HttpStatusCode responseStatusCode = HttpStatusCode.OK,
            Func<HttpContent, bool> httpContentLambda = null)
        {
            Expression<Func<HttpContent, bool>> expression;

            if (httpContentLambda == null)
            {
                expression = i =>
                        i != null ?
                        i.ReadAsStringAsync().Result == content.ReadAsStringAsync().Result :
                        content == null;
            }
            else
            {
                expression = x => httpContentLambda(x);
            }

            var oauthMock = new Mock<OAuthClient>(settings);

            oauthMock
                .Setup(foo => foo.RequestAsync(
                    It.Is<HttpMethods>(
                        i => i.Equals(method)),
                        It.Is<string>(i => i == uri),
                        It.Is<HttpContent>(expression)))
                .Returns(() =>
                {
                    var responseMessage = new HttpResponseMessage(responseStatusCode);
                    responseMessage.Content = new StringContent(responseContent);
                    var task = Task.FromResult(responseMessage);

                    return task;
                });

            return oauthMock.Object;
        }
        #endregion
    }
}