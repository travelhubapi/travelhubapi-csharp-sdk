using System.Net;
using System.Net.Http;
using System.Text;
using FluentAssertions;
using TravelHubApi.Sdk.Client.Tests.Mock;
using TravelHubApi.Sdk.Common.Helpers;
using Xunit;

namespace TravelHubApi.Sdk.Client.Tests
{
    public class ClientTest
    {
        private Settings settings;

        #region Constructors | Destructors
        public ClientTest()
        {
            settings = new Settings
            {
                Environment = TravelHubApi.Sdk.Common.Helpers.Environment.Homolog,
                ClientId = "ClientId",
                ClientSecret = "ClientSecret"
            };
        }
        #endregion

        [Trait("Client", "")]
        [Trait("Client", "Request")]
        [Fact(DisplayName = "Client - Get")]
        public void Should_Request_With_Method_Get()
        {
            var client = new TravelHubApiClient(
                settings,
                ClientMock.GetOAuthForGet(settings));
            var response = client.GetAsync(
                "http://hotel.stg.travelhubapi.com.br/v1/locations/description");
            var expected = "OK";

            response.Should().NotBeNull();

            var result = response.Result;

            result.Should().NotBeNull();

            result.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Content.ReadAsStringAsync().Result.Should().Be(expected);
        }

        [Trait("Client", "")]
        [Trait("Client", "Request")]
        [Fact(DisplayName = "Client - Post")]
        public void Should_Request_With_Method_Post()
        {
            var client = new TravelHubApiClient(
                settings,
                ClientMock.GetOAuthForPost(settings));
            var requestContent = new StringContent(
                "{\"example\": true}", 
                Encoding.UTF8, 
                "application/json");
     
            var response = client.PostAsync(
                "http://hotel.stg.travelhubapi.com.br/v1/bookings",
                requestContent);

            var expected = "OK";

            response.Should().NotBeNull();

            var result = response.Result;

            result.Should().NotBeNull();

            result.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Content.ReadAsStringAsync().Result.Should().Be(expected);
        }

        [Trait("Client", "")]
        [Trait("Client", "Request")]
        [Fact(DisplayName = "Client - Delete")]
        public void Should_Request_With_Method_Delete()
        {
            var client = new TravelHubApiClient(
                settings,
                ClientMock.GetOAuthForDelete(settings));
            var response = client.DeleteAsync(
                "http://hotel.stg.travelhubapi.com.br/v1/bookings/bookingCode/vendorId");

            var expected = string.Empty;

            response.Should().NotBeNull();

            var result = response.Result;

            result.Should().NotBeNull();

            result.StatusCode.Should().Be(HttpStatusCode.NoContent);

            result.Content.ReadAsStringAsync().Result.Should().Be(expected);
        }
    }
}
