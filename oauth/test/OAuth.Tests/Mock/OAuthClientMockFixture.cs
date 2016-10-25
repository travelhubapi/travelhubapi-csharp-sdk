using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using RichardSzalay.MockHttp;
using TravelHubApi.Sdk.Common.Helpers;
using TravelHubApi.Sdk.OAuth;
using Xunit;

namespace TravelHubApi.Sdk.OAuth.Tests.Mock
{
    public class OAuthClientMockFixture : IDisposable
    {
        #region Fields
        private string currentPath;

        private string tokenStr;

        private string refreshedTokenStr;
        #endregion

        public OAuthClientMockFixture()
        {
            currentPath = Directory.GetCurrentDirectory();
            Token = LoadFiles.LoadJsonObj(GetPath("Json/ResponseToken.json"));
            tokenStr = LoadFiles.LoadJsonString(GetPath("Json/ResponseToken.json"));
            RefreshedToken = LoadFiles.LoadJsonObj(GetPath("Json/ResponseRefreshToken.json"));
            refreshedTokenStr = LoadFiles.LoadJsonString(GetPath("Json/ResponseRefreshToken.json"));
        }

        #region Properties
        public dynamic Token { get; set; }

        public dynamic RefreshedToken { get; set; }
        #endregion

        #region Public methods
        public MockHttpMessageHandler GetMockHandler()
        {
            var mockHttp = new MockHttpMessageHandler();

            CreateTokenMock(mockHttp);
            CreateResponseOKMock(URLs.REPONSE_OK, mockHttp);
            CreateResponseUnathorizedMock(URLs.REPONSE_UNATHORIZED_FIRST_TIME, mockHttp);
            CreateRefreshTokenMock(mockHttp);
            CreateResponseOKWithRefreshedTokenMock(URLs.REPONSE_UNATHORIZED_FIRST_TIME, mockHttp);

            return mockHttp;
        }

        public void Dispose() 
        { 
        } 
        #endregion

        #region Private methods
        private MockHttpMessageHandler CreateTokenMock(
            MockHttpMessageHandler mockHttp, 
            int times = 1)
        {
            for (var i = 0; i < times; i++)
            {
                mockHttp.When(HttpMethod.Post, OAuthClient.HOMOLOG_HOST + OAuthClient.TOKEN_PATH)
                    .WithFormData("grant_type=client_credentials")
                    .Respond("application/json", tokenStr);
            }

            return mockHttp;
        }

        private MockHttpMessageHandler CreateRefreshTokenMock(
            MockHttpMessageHandler mockHttp, 
            int times = 1)
        {
            for (var i = 0; i < times; i++)
            {
                mockHttp.When(HttpMethod.Post, OAuthClient.HOMOLOG_HOST + OAuthClient.TOKEN_PATH)
                    .WithFormData("grant_type=refresh_token&refresh_token=" + (string)Token.refresh_token)
                    .Respond("application/json", refreshedTokenStr);
            }

            return mockHttp;
        }

        private MockHttpMessageHandler CreateResponseUnathorizedMock(
            string url,
            MockHttpMessageHandler mockHttp, 
            int times = 1)
        {
            for (var i = 0; i < times; i++)
            {
                mockHttp.When(HttpMethod.Get, url)
                    .WithHeaders("Authorization", "Bearer " + (string)Token.access_token)
                    .Respond(HttpStatusCode.Unauthorized, "application/json", "{}");
            }

            return mockHttp;
        }

        private MockHttpMessageHandler CreateResponseOKMock(
            string url,
            MockHttpMessageHandler mockHttp, 
            int times = 1)
        {
            for (var i = 0; i < times; i++)
            {
                mockHttp.When(HttpMethod.Get, url)
                    .WithHeaders("Authorization", "Bearer " + (string)Token.access_token)
                    .Respond("application/json", "{}");
            }

            return mockHttp;
        }

        private MockHttpMessageHandler CreateResponseOKWithRefreshedTokenMock(
            string url,
            MockHttpMessageHandler mockHttp, 
            int times = 1)
        {
            for (var i = 0; i < times; i++)
            {
                mockHttp.When(HttpMethod.Get, url)
                    .WithHeaders("Authorization", "Bearer " + (string)RefreshedToken.access_token)
                    .Respond("application/json", "{}");
            }

            return mockHttp;
        }

        private string GetPath(string path)
        {
            return Path.GetFullPath(Path.Combine(currentPath, "Mock", path));
        }
        #endregion
    }
}
