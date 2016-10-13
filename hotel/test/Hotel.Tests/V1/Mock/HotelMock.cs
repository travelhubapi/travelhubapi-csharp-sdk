using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using TravelHubApi.Sdk.Common.V1.Helpers;
using TravelHubApi.Sdk.Common.V1.Extensions;
using Newtonsoft.Json;
using TravelHubApi.Sdk.Hotel.V1.Models.Parameters.Body;
using System.Linq.Expressions;
using TravelHubApi.Sdk.Hotel.V1.Models;

namespace TravelHubApi.Sdk.Hotel.Tests.V1.Mock
{
    public static class HotelMock
    {
        private static string LoadJson(string path)
        {
            string json = string.Empty;
            var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            var jsonPath = Path.Combine(Directory.GetCurrentDirectory(), "..\\..\\", path);
            using (StreamReader r = new StreamReader(jsonPath))
            {
                json = r.ReadToEnd();;
            }
            var obj = JsonConvert.DeserializeObject(json);
            return obj.ToJson();
        }

        private static OAuth.OAuth GetOAuth(Settings settings, HttpMethods method,
            string uri, string responseContent, HttpContent content,
            HttpStatusCode responseStatusCode = HttpStatusCode.OK,
            Func<HttpContent, bool> httpContentLambda = null
            )
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
            var oauthMock = new Mock<OAuth.OAuth>(settings);

            oauthMock
                .Setup(foo => foo.Request(It.Is<HttpMethods>(
                    i => i.Equals(method)),
                    It.Is<Uri>(i => i.AbsoluteUri == uri),
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

        #region GetAvailabilities
        public static OAuth.OAuth GetOAuthToAvailabilitiesResponse(Settings settings)
        {
            return GetOAuth(settings,
                HttpMethods.Get,
                "http://hotel.stg.travelhubapi.com.br/v1/availabilities/sao/2016-10-10/2016-10-13",
                GetAvailabilitiesJSONResponse(),
                null,
                HttpStatusCode.OK);
        }

        public static string GetAvailabilitiesJSONResponse()
        {
            return LoadJson("V1/Mock/Json/ResponseAvailabilities.json");
        }

        public static Availabilities GetAvailabilitiesResponse()
        {
            return GetAvailabilitiesJSONResponse().ToObject<Availabilities>();
        }
        #endregion

        #region GetHotel
        public static OAuth.OAuth GetOAuthToHotelResponse(Settings settings)
        {
            return GetOAuth(settings,
                HttpMethods.Get,
                "http://hotel.stg.travelhubapi.com.br/v1/hotels/broker/track",
                GetHotelJSONResponse(),
                null,
                HttpStatusCode.OK);
        }

        public static string GetHotelJSONResponse()
        {
            return LoadJson("V1/Mock/Json/ResponseHotel.json");
        }

        public static TravelHubApi.Sdk.Hotel.V1.Models.Hotel GetHotelResponse()
        {
            return GetHotelJSONResponse().ToObject<TravelHubApi.Sdk.Hotel.V1.Models.Hotel>();
        }
        #endregion

        #region GetFacilities
        public static OAuth.OAuth GetOAuthToFacilitiesResponse(Settings settings)
        {
            return GetOAuth(settings,
                HttpMethods.Get,
                "http://hotel.stg.travelhubapi.com.br/v1/hotels/broker/track/facilities",
                GetFacilitiesJSONResponse(),
                null,
                HttpStatusCode.OK);
        }

        public static string GetFacilitiesJSONResponse()
        {
            return LoadJson("V1/Mock/Json/ResponseFacilities.json");
        }

        public static Facilities GetFacilitiesResponse()
        {
            return GetFacilitiesJSONResponse().ToObject<Facilities>();
        }
        #endregion

        #region GetImages
        public static OAuth.OAuth GetOAuthToImagesResponse(Settings settings)
        {
            return GetOAuth(settings,
                HttpMethods.Get,
                "http://hotel.stg.travelhubapi.com.br/v1/hotels/broker/track/images",
                GetImagesJSONResponse(),
                null,
                HttpStatusCode.OK);
        }

        public static string GetImagesJSONResponse()
        {
            return LoadJson("V1/Mock/Json/ResponseImages.json");
        }

        public static Images GetImagesResponse()
        {
            return GetImagesJSONResponse().ToObject<Images>();
        }
        #endregion

        #region GetBook
        public static OAuth.OAuth GetOAuthToBookResponse(Settings settings)
        {
            var bookRequest = GetBookJSONRequest();
            var bookRequestContent = new StringContent(bookRequest, Encoding.UTF8, "application/json");


            Func<HttpContent, bool> httpRequestContentCheck = content =>
            {
                var bookRequestString = content.ReadAsStringAsync().Result;
                var bookRequestObj = bookRequestString.ToObject<BookBody>();
                var bookRequestExpectedObj = bookRequest.ToObject<BookBody>();
                try
                {
                    bookRequestObj.ShouldBeEquivalentTo<BookBody>(bookRequestExpectedObj);
                    return true;
                }
                catch
                {
                    return false;
                }
            }; 
            
            return GetOAuth(settings,
                HttpMethods.Post,
                "http://hotel.stg.travelhubapi.com.br/v1/bookings",
                GetBookJSONResponse(),
                bookRequestContent,
                HttpStatusCode.OK,
                httpRequestContentCheck);
        }

        public static string GetBookJSONResponse()
        {
            return LoadJson("V1/Mock/Json/ResponseBooking.json");
        }

        public static string GetBookJSONRequest()
        {
            return LoadJson("V1/Mock/Json/RequestBooking.json");
        }

        public static Booking GetBookResponse()
        {
            return GetBookJSONResponse().ToObject<Booking>();
        }

        public static BookBody GetBookRequest()
        {
            return GetBookJSONRequest().ToObject<BookBody>();
        }
        #endregion


    }
}
