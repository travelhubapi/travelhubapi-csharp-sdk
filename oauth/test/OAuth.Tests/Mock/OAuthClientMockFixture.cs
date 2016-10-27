using System;
using System.IO;
using System.Net;
using System.Net.Http;
using RichardSzalay.MockHttp;
using TravelHubApi.Sdk.Common.Helpers;

namespace TravelHubApi.Sdk.OAuth.Tests.Mock
{
    public class OAuthClientMockFixture : IDisposable
    {
        #region Fields
        private string _currentPath;

        private string _tokenStr;

        private string _refreshedTokenStr;
        #endregion

        public OAuthClientMockFixture()
        {
            _currentPath = Directory.GetCurrentDirectory();
            _tokenStr = LoadFiles.LoadJsonString(GetPath("Json/ResponseToken.json"));
            _refreshedTokenStr = LoadFiles.LoadJsonString(GetPath("Json/ResponseRefreshToken.json"));

            Token = LoadFiles.LoadJsonObj(GetPath("Json/ResponseToken.json"));
            RefreshedToken = LoadFiles.LoadJsonObj(GetPath("Json/ResponseRefreshToken.json"));
        }

        #region Properties
        public dynamic Token { get; set; }

        public dynamic RefreshedToken { get; set; }
        #endregion

        #region Public Methods
        public MockHttpMessageHandler GetMockHandler()
        {
            var mockHttp = new MockHttpMessageHandler();

            CreateTokenMock(mockHttp);
            CreateResponseOKMock(URLs.ResponseOk, mockHttp);
            CreateResponseUnathorizedMock(URLs.ResponseUnauthorizedFirstTime, mockHttp);
            CreateRefreshTokenMock(mockHttp);
            CreateResponseOKWithRefreshedTokenMock(URLs.ResponseUnauthorizedFirstTime, mockHttp);

            return mockHttp;
        }

        public void Dispose() 
        { 
        } 
        #endregion

        #region Private Methods
        private MockHttpMessageHandler CreateTokenMock(
            MockHttpMessageHandler mockHttp, 
            int times = 1)
        {
            for (var i = 0; i < times; i++)
            {
                mockHttp.When(HttpMethod.Post, OAuthClient.HomologHost + OAuthClient.TokenPath)
                    .WithFormData("grant_type=client_credentials")
                    .Respond("application/json", _tokenStr);
            }

            return mockHttp;
        }

        private MockHttpMessageHandler CreateRefreshTokenMock(
            MockHttpMessageHandler mockHttp, 
            int times = 1)
        {
            for (var i = 0; i < times; i++)
            {
                mockHttp.When(HttpMethod.Post, OAuthClient.HomologHost + OAuthClient.TokenPath)
                    .WithFormData("grant_type=refresh_token&refresh_token=" + (string)Token.refresh_token)
                    .Respond("application/json", _refreshedTokenStr);
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
            return Path.GetFullPath(Path.Combine(_currentPath, "Mock", path));
        }
        #endregion
    }
}
