using OAuth2ClientHandler;
using OAuth2ClientHandler.Authorizer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TravelHubApi.Sdk.Common.V1.Helpers;

namespace TravelHubApi.Sdk.OAuth
{
    public class OAuth
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

        private string host { get; set; }
        private const string authorizePath = "/oauth2";
        private const string tokenPath = "/oauth2/token";
        private AuthorizerOptions authorizerOptions { get; set; }
        private OAuthHttpHandlerOptions options { get; set; }
        private OAuthHttpHandler oAuthHttpHandler { get; set; }
        private HttpClient client { get; set; }

        public OAuth(Settings settings)
        {
            host = settings.Environment == Common.V1.Helpers.Environment.Production
                ? PRODUCTION_HOST
                : HOMOLOG_HOST;

            authorizerOptions = new AuthorizerOptions
            {
                AuthorizeEndpointUrl = new Uri(host + authorizePath),
                TokenEndpointUrl = new Uri(host + tokenPath),
                ClientId = settings.ClientId,
                ClientSecret = settings.ClientSecret,
                GrantType = GrantType.ClientCredentials
            };

            options = new OAuthHttpHandlerOptions
            {
                AuthorizerOptions = authorizerOptions
            };

            oAuthHttpHandler = new OAuthHttpHandler(options);
            client = new HttpClient(oAuthHttpHandler);
        }

        public virtual Task<HttpResponseMessage> Request(HttpMethods method, Uri uri, HttpContent content = null)
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
