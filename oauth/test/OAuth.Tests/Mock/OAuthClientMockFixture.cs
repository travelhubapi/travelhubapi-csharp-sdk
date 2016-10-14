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
using Xunit;

namespace Sdk.OAuth.Tests.Mock
{
    public class OAuthClientMockFixture : IDisposable
    {
        string currentPath;
        public dynamic token;
        string tokenStr;
        public dynamic refreshedToken;
        string refreshedTokenStr;

        public OAuthClientMockFixture() { 
        
            currentPath = Directory.GetCurrentDirectory();
            token = LoadFiles.LoadJsonObj(GetPath("Json/ResponseToken.json"));
            tokenStr = LoadFiles.LoadJsonString(GetPath("Json/ResponseToken.json"));
            refreshedToken = LoadFiles.LoadJsonObj(GetPath("Json/ResponseRefreshToken.json"));
            refreshedTokenStr = LoadFiles.LoadJsonString(GetPath("Json/ResponseRefreshToken.json"));
        }

        #region Public methods
        public MockHttpMessageHandler GetMockHandler()
        {
            var mockHttp = new MockHttpMessageHandler();

            CreateTokenMock(mockHttp);
            CreateResponseOK(URLs.REPONSE_OK, mockHttp);
            CreateResponseUnathorized(URLs.REPONSE_UNATHORIZED_FIRST_TIME, mockHttp);
            CreateRefreshTokenMock(mockHttp);
            CreateResponseOKWithRefreshedToken(URLs.REPONSE_UNATHORIZED_FIRST_TIME, mockHttp);

            return mockHttp;
        }

        public void Dispose()
        {

        } 
        #endregion

        #region Private methods
        private MockHttpMessageHandler CreateTokenMock(
            MockHttpMessageHandler mockHttp, int times = 1)
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
            MockHttpMessageHandler mockHttp, int times = 1)
        {
            for (var i = 0; i < times; i++)
            {
                mockHttp.When(HttpMethod.Post, OAuthClient.HOMOLOG_HOST + OAuthClient.TOKEN_PATH)
                    .WithFormData("grant_type=refresh_token&refresh_token=" + (String)token.refresh_token)
                    .Respond("application/json", refreshedTokenStr);
            }
            return mockHttp;
        }

        private MockHttpMessageHandler CreateResponseUnathorized(
            string url,
            MockHttpMessageHandler mockHttp, int times = 1)
        {
            for (var i = 0; i < times; i++)
            {
                mockHttp.When(HttpMethod.Get, url)
                    .WithHeaders("Authorization", "Bearer " + (String)token.access_token)
                    .Respond(HttpStatusCode.Unauthorized, "application/json", "{}");

            }
            return mockHttp;
        }

        private MockHttpMessageHandler CreateResponseOK(
            string url,
            MockHttpMessageHandler mockHttp, int times = 1)
        {
            for (var i = 0; i < times; i++)
            {
                mockHttp.When(HttpMethod.Get, url)
                    .WithHeaders("Authorization", "Bearer " + (String)token.access_token)
                    .Respond("application/json", "{}");
            }
            return mockHttp;
        }

        private MockHttpMessageHandler CreateResponseOKWithRefreshedToken(
            string url,
            MockHttpMessageHandler mockHttp, int times = 1)
        {
            for (var i = 0; i < times; i++)
            {
                mockHttp.When(HttpMethod.Get, url)
                    .WithHeaders("Authorization", "Bearer " + (String)refreshedToken.access_token)
                    .Respond("application/json", "{}");
            }
            return mockHttp;
        }

        private string GetPath(string path)
        {
            return Path.GetFullPath(Path.Combine(currentPath, "../../Mock", path));
        }
        #endregion
    }

    [CollectionDefinition("OAuthClientMock collection")]
    public class OAuthClientMockCollection : ICollectionFixture<OAuthClientMockFixture>
    {
        // This class has no code, and is never created. Its purpose is simply
        // to be the place to apply [CollectionDefinition] and all the
        // ICollectionFixture<> interfaces.
    }
}
