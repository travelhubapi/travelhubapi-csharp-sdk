using HttpMock;
using RichardSzalay.MockHttp;
using Sdk.OAuth.Tests.Mock;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using TravelHubApi.Sdk.Common.Helpers;
using TravelHubApi.Sdk.OAuth;
using Xunit;

namespace Sdk.OAuth.Tests
{
    public class OAuthClientTest
    {
        OAuthClient oauth { get; set; }
        Settings settings { get; set; }
        MockHttpMessageHandler mockHttp { get; set; }

        public OAuthClientTest()
        {

            settings = new Settings
            {
                Environment = TravelHubApi.Sdk.Common.Helpers.Environment.Homolog,
                ClientId = "ClientId",
                ClientSecret = "ClientSecret"
            };

            mockHttp = OAuthClientMock.GetMockHandler();
            oauth = new OAuthClient(settings, mockHttp);
        }

        [Trait("OAuth", "")]
        [Fact(DisplayName = "OAuth - GetAvailabilities")]
        public void Should()
        {
            var response = oauth.RequestAsync(HttpMethods.Get, new Uri("http://www.unathorized.com"));
            var result = response.Result;

            mockHttp.VerifyNoOutstandingExpectation();
        }
    }
}
