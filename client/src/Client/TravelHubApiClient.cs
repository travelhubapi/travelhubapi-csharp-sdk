using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using TravelHubApi.Sdk.Common.API;
using TravelHubApi.Sdk.Common.Helpers;
using TravelHubApi.Sdk.Hotel;
using TravelHubApi.Sdk.OAuth;

namespace TravelHubApi.Sdk.Client
{
    public class TravelHubApiClient
    {
        #region Constructors | Destructors
        public TravelHubApiClient(Settings settings, OAuthClient oauth)
        {
            if (string.IsNullOrEmpty(settings.ClientId)
                || string.IsNullOrEmpty(settings.ClientId))
            {
                throw new Exception("ClientId and ClientSecret are required");
            }

            OAuthClient = oauth;
            HotelClient = new Hotel.HotelClient(settings, OAuthClient);
        }

        public TravelHubApiClient(Settings settings)
        {
            if (string.IsNullOrEmpty(settings.ClientId)
                || string.IsNullOrEmpty(settings.ClientId))
            {
                throw new Exception("ClientId and ClientSecret are required");
            }

            OAuthClient = new OAuthClient(settings);
            HotelClient = new HotelClient(settings, OAuthClient);
        }
        #endregion

        #region Properties
        public OAuthClient OAuthClient { get; set; }

        public HotelClient HotelClient { get; set; }
        #endregion

        #region Public Methods
        public Task<HttpResponseMessage> GetAsync(
            string uri,
            HttpContent content = null,
            CancellationToken cancelToken = default(CancellationToken))
        {
            return OAuthClient.RequestAsync(HttpMethods.Get, uri, content);
        }

        public Task<HttpResponseMessage> PostAsync(
            string uri,
            HttpContent content = null,
            CancellationToken cancelToken = default(CancellationToken))
        {
            return OAuthClient.RequestAsync(HttpMethods.Post, uri, content);
        }

        public Task<HttpResponseMessage> DeleteAsync(
            string uri,
            HttpContent content = null,
            CancellationToken cancelToken = default(CancellationToken))
        {
            return OAuthClient.RequestAsync(HttpMethods.Delete, uri, content);
        }
        #endregion
    }
}
