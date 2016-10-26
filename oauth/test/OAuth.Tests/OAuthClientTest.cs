using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using FluentAssertions;
using HttpMock;
using RichardSzalay.MockHttp;
using TravelHubApi.Sdk.Common.Helpers;
using TravelHubApi.Sdk.OAuth;
using TravelHubApi.Sdk.OAuth.Tests.Mock;
using Xunit;

namespace TravelHubApi.Sdk.OAuth.Tests
{
    [Collection("OAuthClientMock collection")]
    public class OAuthClientTest
    {
        private OAuthClient oauth;

        private Settings settings;

        private MockHttpMessageHandler mockHttp;

        private OAuthClientMockFixture oAuthClientMockFixture;

        public OAuthClientTest(OAuthClientMockFixture oAuthClientMockFixture)
        {
            this.oAuthClientMockFixture = oAuthClientMockFixture;
            settings = new Settings
            {
                Environment = TravelHubApi.Sdk.Common.Helpers.Environment.Homolog,
                ClientId = "ClientId",
                ClientSecret = "ClientSecret"
            };

            mockHttp = this.oAuthClientMockFixture.GetMockHandler();
            oauth = new OAuthClient(settings, mockHttp);
        }

        [Trait("OAuth", "")]
        [Trait("OAuth", "Request")]
        [Fact(DisplayName = "OAuth - Request with Authorization header")]
        public void Should_Call_With_Authorization_Header()
        {
            var response = oauth.RequestAsync(HttpMethods.Get, URLs.REPONSE_OK);
            var result = response.Result;
            var authorization = result.RequestMessage.Headers.Authorization;

            authorization.Scheme.Should().Be("Bearer");
            authorization.Parameter.Should().Be(oauth.HttpClient.tokenResponse.AccessToken);
            result.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Trait("OAuth", "")]
        [Trait("OAuth", "Request")]
        [Fact(DisplayName = "OAuth - Refresh token when receive 401")]
        public void Should_RefreshToken_When_401_And_Try_Again()
        {
            var response = oauth.RequestAsync(HttpMethods.Get, URLs.REPONSE_UNATHORIZED_FIRST_TIME);
            var result = response.Result;
            var authorization = result.RequestMessage.Headers.Authorization;

            authorization.Scheme.Should().Be("Bearer");
            authorization.Parameter.Should().Be(oauth.HttpClient.tokenResponse.AccessToken);
            authorization.Parameter.Should().Be((string)oAuthClientMockFixture.RefreshedToken.access_token);
            result.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}
