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
using FluentAssertions;
using System.Net;

namespace Sdk.OAuth.Tests
{
    [Collection("OAuthClientMock collection")]
    public class OAuthClientTest
    {
        OAuthClient oauth { get; set; }
        Settings settings { get; set; }
        MockHttpMessageHandler mockHttp { get; set; }
        OAuthClientMockFixture oAuthClientMockFixture { get; set; }

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
            authorization.Parameter.Should().Be(oauth.client.tokenResponse.AccessToken);
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
            authorization.Parameter.Should().Be(oauth.client.tokenResponse.AccessToken);
            authorization.Parameter.Should().Be((String)oAuthClientMockFixture.refreshedToken.access_token);
            result.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}
