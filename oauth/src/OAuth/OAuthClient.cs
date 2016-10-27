using System;
using System.Net.Http;
using System.Threading.Tasks;
using OAuth2ClientHandler;
using OAuth2ClientHandler.Authorizer;
using TravelHubApi.Sdk.Common.Helpers;

namespace TravelHubApi.Sdk.OAuth
{
    public class OAuthClient
    {
        #region Fields | Members
        private AuthorizerOptions _authorizerOptions;

        private OAuthHttpHandlerOptions _options;

        private OAuthHttpHandler _oAuthHttpHandler;
        #endregion

        #region Constructors | Destructors
        public OAuthClient(Settings settings)
        {
            Init(settings);
        }

        public OAuthClient(Settings settings, HttpMessageHandler customHandler)
        {
            Init(settings, customHandler);
        }
        #endregion

        #region Properties
        public static string HomologHost
        {
            get
            {
                return "http://auth.stg.travelhubapi.com.br";
            }
        }

        public static string ProductionHost
        {
            get
            {
                return "http://auth.travelhubapi.com.br";
            }
        }

        public static string AuthorizePath
        {
            get
            {
                return "/oauth2";
            }
        }

        public static string TokenPath
        {
            get
            {
                return "/oauth2/token";
            }
        }

        public string Host { get; set; }

        public string AuthorizeUrl { get; set; }

        public string TokenUrl { get; set; }

        public OAuthHttpClient HttpClient { get; set; }
        #endregion

        public virtual Task<HttpResponseMessage> RequestAsync(HttpMethods method, string uri, HttpContent content = null)
        {
            Task<HttpResponseMessage> response;

            switch (method)
            {
                case HttpMethods.Post:
                    response = HttpClient.PostAsync(uri, content);
                    break;
                case HttpMethods.Get:
                    response = HttpClient.GetAsync(uri);
                    break;
                case HttpMethods.Delete:
                    response = HttpClient.DeleteAsync(uri);
                    break;
                default:
                    throw new NotImplementedException();
            }

            return response;
        }

        private void Init(Settings settings, HttpMessageHandler customHandler = null)
        {
            Host = settings.Environment == Common.Helpers.Environment.Production
                ? ProductionHost
                : HomologHost;

            AuthorizeUrl = Host + OAuthClient.AuthorizePath;
            TokenUrl = Host + OAuthClient.TokenPath;

            _authorizerOptions = new AuthorizerOptions
            {
                AuthorizeEndpointUrl = new Uri(TokenUrl),
                TokenEndpointUrl = new Uri(TokenUrl),
                ClientId = settings.ClientId,
                ClientSecret = settings.ClientSecret,
                GrantType = GrantType.ClientCredentials
            };

            _options = new OAuthHttpHandlerOptions
            {
                AuthorizerOptions = _authorizerOptions,
                InnerHandler = customHandler
            };

            _oAuthHttpHandler = new OAuthHttpHandler(_options);

            HttpClient = OAuthHttpClient.Factory(_options);
        }
    }
}
