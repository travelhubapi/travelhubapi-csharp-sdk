using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using OAuth2ClientHandler;
using OAuth2ClientHandler.Authorizer;
using TravelHubApi.Sdk.Common.Helpers;

namespace TravelHubApi.Sdk.OAuth
{
    public class OAuthClient
    {
        #region Private Fields
        private AuthorizerOptions authorizerOptions;

        private OAuthHttpHandlerOptions options;

        private OAuthHttpHandler oAuthHttpHandler;
        #endregion

        #region
        public OAuthClient(Settings settings)
        {
            Init(settings);
        }

        public OAuthClient(Settings settings, HttpMessageHandler customHandler)
        {
            Init(settings, customHandler);
        }
        #endregion

        #region Static Properties
        public static string HOMOLOG_HOST
        {
            get
            {
                return "http://auth.stg.travelhubapi.com.br";
            }
        }

        public static string PRODUCTION_HOST
        {
            get
            {
                return "http://auth.travelhubapi.com.br";
            }
        }

        public static string AUTHORIZE_PATH
        {
            get
            {
                return "/oauth2";
            }
        }

        public static string TOKEN_PATH
        {
            get
            {
                return "/oauth2/token";
            }
        }
        #endregion

        #region Public Properties
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
                ? PRODUCTION_HOST
                : HOMOLOG_HOST;

            AuthorizeUrl = Host + OAuthClient.AUTHORIZE_PATH;
            TokenUrl = Host + OAuthClient.TOKEN_PATH;

            authorizerOptions = new AuthorizerOptions
            {
                AuthorizeEndpointUrl = new Uri(TokenUrl),
                TokenEndpointUrl = new Uri(TokenUrl),
                ClientId = settings.ClientId,
                ClientSecret = settings.ClientSecret,
                GrantType = GrantType.ClientCredentials
            };

            options = new OAuthHttpHandlerOptions
            {
                AuthorizerOptions = authorizerOptions,
                InnerHandler = customHandler
            };

            oAuthHttpHandler = new OAuthHttpHandler(options);

            HttpClient = OAuthHttpClient.Factory(options);
        }
    }
}
