using System;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using TravelHubApi.Sdk.Common.API;
using TravelHubApi.Sdk.Common.Helpers;
using TravelHubApi.Sdk.OAuth;

namespace TravelHubApi.Sdk.Client.Tests.Mock
{
    public class ClientMock
    {
        internal static OAuthClient GetOAuthForGet(Settings settings)
        {
            return GetOAuth(
                settings,
                HttpMethods.Get,
                "http://hotel.stg.travelhubapi.com.br/v1/locations/description",
                "OK",
                null,
                HttpStatusCode.OK);
        }

        internal static OAuthClient GetOAuthForPost(Settings settings)
        {
            var requestContent = new StringContent(
                "{\"example\": true}",
                Encoding.UTF8,
                "application/json");

            return GetOAuth(
                settings,
                HttpMethods.Post,
                "http://hotel.stg.travelhubapi.com.br/v1/bookings",
                "OK",
                requestContent,
                HttpStatusCode.OK);
        }

        internal static OAuthClient GetOAuthForDelete(Settings settings)
        {
            return GetOAuth(
                settings,
                HttpMethods.Delete,
                "http://hotel.stg.travelhubapi.com.br/v1/bookings/bookingCode/vendorId",
                string.Empty,
                null,
                HttpStatusCode.NoContent);
        }

        #region Private Methods
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
                        It.Is<HttpContent>(expression),
                        It.Is<CancellationToken>(c => c == default(CancellationToken))))
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
