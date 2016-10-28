using System.Net;
using FluentAssertions;
using RichardSzalay.MockHttp;
using TravelHubApi.Sdk.Common.API;
using TravelHubApi.Sdk.Common.Helpers;
using TravelHubApi.Sdk.OAuth.Tests.Mock;
using Xunit;

namespace TravelHubApi.Sdk.OAuth.Tests
{
    [Collection("OAuthClientMock collection")]
    public class OAuthClientTest
    {
        private OAuthClient _oauth;

        private Settings _settings;

        private MockHttpMessageHandler _mockHttp;

        private OAuthClientMockFixture _oAuthClientMockFixture;

        public OAuthClientTest(OAuthClientMockFixture oAuthClientMockFixture)
        {
            this._oAuthClientMockFixture = oAuthClientMockFixture;
            _settings = new Settings
            {
                Environment = TravelHubApi.Sdk.Common.API.Enums.Environment.Homolog,
                ClientId = "ClientId",
                ClientSecret = "ClientSecret"
            };

            _mockHttp = this._oAuthClientMockFixture.GetMockHandler();
            _oauth = new OAuthClient(_settings, _mockHttp);
        }

        [Trait("OAuth", "")]
        [Trait("OAuth", "Request")]
        [Fact(DisplayName = "OAuth - Request with Authorization header")]
        public void Should_Call_With_Authorization_Header()
        {
            var response = _oauth.RequestAsync(HttpMethods.Get, URLs.ResponseOk);
            var result = response.Result;
            var authorization = result.RequestMessage.Headers.Authorization;

            authorization.Scheme.Should().Be("Bearer");
            authorization.Parameter.Should().Be(_oauth.HttpClient.tokenResponse.AccessToken);
            result.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Trait("OAuth", "")]
        [Trait("OAuth", "Request")]
        [Fact(DisplayName = "OAuth - Refresh token when receive 401")]
        public void Should_RefreshToken_When_401_And_Try_Again()
        {
            var response = _oauth.RequestAsync(HttpMethods.Get, URLs.ResponseUnauthorizedFirstTime);
            var result = response.Result;
            var authorization = result.RequestMessage.Headers.Authorization;

            authorization.Scheme.Should().Be("Bearer");
            authorization.Parameter.Should().Be(_oauth.HttpClient.tokenResponse.AccessToken);
            authorization.Parameter.Should().Be((string)_oAuthClientMockFixture.RefreshedToken.access_token);
            result.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}
