using OAuth2ClientHandler;
using OAuth2ClientHandler.Authorizer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TravelHubApi.Sdk.Common.Helpers;

namespace TravelHubApi.Sdk.OAuth
{
    public class OAuthClient
    {
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

        public static string AUTHORIZE_PATH { get { return "/oauth2"; } }
        public static string TOKEN_PATH { get { return "/oauth2/token"; } }

        public string host { get; set; }
        public string authorizeUrl { get; set; }
        public string tokenUrl { get; set; }

        private AuthorizerOptions authorizerOptions { get; set; }
        private OAuthHttpHandlerOptions options { get; set; }
        private OAuthHttpHandler oAuthHttpHandler { get; set; }
        private HttpClient client { get; set; }

        public OAuthClient(Settings settings)
        {
            Init(settings);
        }
            
        public OAuthClient(Settings settings, HttpMessageHandler customHandler)
        {
            Init(settings, customHandler);
        }

        private void Init(Settings settings, HttpMessageHandler customHandler = null)
        {
            host = settings.Environment == Common.Helpers.Environment.Production
                ? PRODUCTION_HOST
                : HOMOLOG_HOST;

            authorizeUrl = host + OAuthClient.AUTHORIZE_PATH;
            tokenUrl = host + OAuthClient.TOKEN_PATH;

            authorizerOptions = new AuthorizerOptions
            {
                AuthorizeEndpointUrl = new Uri(tokenUrl),
                TokenEndpointUrl = new Uri(tokenUrl),
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

            client = 
                //customHandler != null ?
                //HttpClientFactory.Create(customHandler, oAuthHttpHandler) :
                new HttpClient(oAuthHttpHandler);


        }

        public virtual Task<HttpResponseMessage> RequestAsync(HttpMethods method, Uri uri, HttpContent content = null)
        {
            Task<HttpResponseMessage> response;

            switch (method)
            {
                case HttpMethods.Post:
                    response = client.PostAsync(uri, content);
                    break;
                case HttpMethods.Get:
                    response = client.GetAsync(uri);
                    break;
                case HttpMethods.Delete:
                    response = client.DeleteAsync(uri);
                    break;
                default:
                    throw new NotImplementedException();
            }

            return response;
        }
    }
}
