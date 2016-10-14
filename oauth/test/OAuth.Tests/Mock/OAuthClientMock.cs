using RichardSzalay.MockHttp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TravelHubApi.Sdk.Common.Helpers;
using TravelHubApi.Sdk.OAuth;

namespace Sdk.OAuth.Tests.Mock
{
    public static class OAuthClientMock
    {
        static string currentPath = Directory.GetCurrentDirectory();
        static dynamic token = LoadFiles.LoadJsonObj(GetPath("Json/ResponseToken.json"));
        static string tokenStr = LoadFiles.LoadJsonString(GetPath("Json/ResponseToken.json"));
        static dynamic refreshedToken = LoadFiles.LoadJsonObj(GetPath("Json/ResponseRefreshToken.json"));
        static string refreshedTokenStr = LoadFiles.LoadJsonString(GetPath("Json/ResponseRefreshToken.json"));
        #region Private methods
        private static string GetPath(string path)
        {
            return Path.GetFullPath(Path.Combine(currentPath, "../../Mock", path));
        }
        #endregion

        public static MockHttpMessageHandler GetMockHandler()
        {
            var mockHttp = new MockHttpMessageHandler();

            CreateTokenMock(mockHttp, 2);
            CreateResponseUnathorized("http://www.unathorized.com", mockHttp);
            CreateRefreshTokenMock(mockHttp);
            CreateResponseOK("http://www.unathorized.com", mockHttp);

            return mockHttp;
        }

        private static MockHttpMessageHandler CreateTokenMock(
            MockHttpMessageHandler mockHttp, int times = 1)
        {
            for (var i = 0; i < times; i++)
            {
                mockHttp.When(HttpMethod.Post, OAuthClient.HOMOLOG_HOST + OAuthClient.TOKEN_PATH)
                    .WithFormData("grant_type=client_credentials")

                                        .With(req =>
                                        {

                                            return true;
                                        })
                    .Respond("application/json", tokenStr);
            }
            return mockHttp;
        }

        private static MockHttpMessageHandler CreateRefreshTokenMock(
            MockHttpMessageHandler mockHttp, int times = 1)
        {
            for (var i = 0; i < times; i++)
            {
                mockHttp.When(HttpMethod.Post, OAuthClient.HOMOLOG_HOST + OAuthClient.TOKEN_PATH)
                    .WithFormData("grant_type=refresh_token&refresh_token=" + (String)token.refresh_token)

                                        .With(req =>
                                        {

                                            return true;
                                        })
                    .Respond("application/json", refreshedTokenStr);
            }
            return mockHttp;
        }

        private static MockHttpMessageHandler CreateResponseUnathorized(
            string url,
            MockHttpMessageHandler mockHttp, int times = 1)
        {
            for (var i = 0; i < times; i++)
            {
                mockHttp.When(HttpMethod.Get, url)
                    .WithHeaders("Authorization", "Bearer " + (String)token.access_token)
                    .With(req =>
                    {

                        return true;
                    })
                    .Respond(HttpStatusCode.Unauthorized, "application/json", "{}");

            }
            return mockHttp;
        }

        private static MockHttpMessageHandler CreateResponseOK(
            string url,
            MockHttpMessageHandler mockHttp, int times = 1)
        {
            for (var i = 0; i < times; i++)
            {
                mockHttp.When(HttpMethod.Get, url)
                    .WithHeaders("Authorization", "Bearer " + (String)refreshedToken.access_token)
                                       .With(req =>
                                       {

                                           return true;
                                       })
                    .Respond("application/json", "{}");
            }
            return mockHttp;
        }
    }
}
