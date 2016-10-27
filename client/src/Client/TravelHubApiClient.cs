using System.Net.Http;
using System.Threading.Tasks;
using TravelHubApi.Sdk.Common.Helpers;
using TravelHubApi.Sdk.Hotel.V1;
using TravelHubApi.Sdk.OAuth;

namespace TravelHubApi.Sdk.Client
{
    public class TravelHubApiClient
    {
        #region Constructors | Destructors
        public TravelHubApiClient(Settings settings, OAuthClient oauth)
        {
            OAuthClient = oauth;
            HotelClient = new Hotel.V1.HotelClient(settings, OAuthClient);
        }

        public TravelHubApiClient(Settings settings)
        {
            OAuthClient = new OAuthClient(settings);
            HotelClient = new HotelClient(settings, OAuthClient);
        }
        #endregion

        #region Properties
        public OAuthClient OAuthClient { get; set; }

        public HotelClient HotelClient { get; set; }
        #endregion

        #region Public Methods
        public Task<HttpResponseMessage> GetAsync(string uri, HttpContent content = null)
        {
            return OAuthClient.RequestAsync(HttpMethods.Get, uri, content);
        }

        public Task<HttpResponseMessage> PostAsync(string uri, HttpContent content = null)
        {
            return OAuthClient.RequestAsync(HttpMethods.Post, uri, content);
        }

        public Task<HttpResponseMessage> DeleteAsync(string uri, HttpContent content = null)
        {
            return OAuthClient.RequestAsync(HttpMethods.Delete, uri, content);
        }
        #endregion
    }
}
