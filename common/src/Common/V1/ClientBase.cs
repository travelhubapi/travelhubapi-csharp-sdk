using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using TravelHubApi.Sdk.Common.V1.Helpers;


namespace TravelHubApi.Sdk.Common.V1
{
    public class ClientBase
    {
        #region Membros privados | Membros protegidos
        ////protected Credentials _credentials;
        ////private IEndPoint _endPoint;
        protected bool _automaticTokenRefresh;
        private const string EndPointAuthProd = "http://auth.travelhubapi.com.br/oauth2/token";
        private const string EndPointAuthHomolog = "http://auth.stg.travelhubapi.com.br/oauth2/token";
        ////protected AuthenticationResultDto AuthenticationData;
        #endregion

        #region Constructors | Destructors
        public ClientBase(Settings settings)
            : base()
        {
            ////if (credentials.IsNotNull())
            ////{
            ////    _credentials = credentials;
            ////    _automaticTokenRefresh = true;
            ////    return;
            ////}

            _automaticTokenRefresh = false;
        }
        #endregion

        /////// <summary>
        /////// Realiza uma chamada HTTP aos serviços do TravelHub
        /////// </summary>
        /////// <param name="optionalEndPoint">EndPoint opcional. Caso não seja passado, será utilizado o endponint definido globalmente</param>
        /////// <param name="method">Método HTTP utilizado na chamada</param>
        /////// <param name="path">Path passado na URL</param>
        /////// <param name="body">Dados passados no corpo de uma requisição do tipo "POST" ou "PUT"</param>
        /////// <param name="useToken">Informa se o token atual precisa ser passado no header do request</param>
        ////protected string CallHttpService(HttpMethods method, string path, string body, string token)
        ////{
        ////    Uri baseUri;

        ////    baseUri = _credentials.EnvironmentType == EnvironmentType.Prod
        ////            ? new Uri(_endPoint.GetEndPointProd().Trim())
        ////            : new Uri(_endPoint.GetEndPointHomolog().Trim());

            


        ////    Uri uri = !String.IsNullOrEmpty(path) ? new Uri(baseUri, path) : new Uri(baseUri, String.Empty);

        ////    //criação do request setando o content-lenght quando for "GET" ou "POST"
        ////    WebRequest webRequest = WebRequest.Create(uri);

        ////    switch (method)
        ////    {
        ////        case (HttpMethods.Post):
        ////            {
        ////                webRequest.Method = "POST";
        ////                break;
        ////            }
        ////        case (HttpMethods.Get):
        ////            {
        ////                webRequest.Method = "GET";
        ////                break;
        ////            }
        ////        case (HttpMethods.Put):
        ////            {
        ////                webRequest.Method = "PUT";

        ////                if (!String.IsNullOrEmpty(body))
        ////                    webRequest.ContentLength = body.Length;

        ////                break;
        ////            }
        ////        case (HttpMethods.Delete):
        ////            {
        ////                webRequest.Method = "DELETE";
        ////                break;
        ////            }
        ////    }

        ////    webRequest.ContentType = "application/json";

        ////    webRequest.Headers.Remove("Authorization");
        ////    webRequest.Headers.Add("Authorization", "bearer " + token);
            
        ////    if (method == HttpMethods.Put || method == HttpMethods.Post)
        ////    {
        ////        using (var dataStream = webRequest.GetRequestStream())
        ////        {
        ////            byte[] bufDataReq = Encoding.UTF8.GetBytes(body);
        ////            dataStream.WriteTimeout = 10000;
        ////            dataStream.Write(bufDataReq, 0, bufDataReq.Length);
        ////            dataStream.Close();
        ////        }
        ////    }

        ////    WebResponse resp = webRequest.GetResponse();
        ////    using (var respStream = resp.GetResponseStream())
        ////    {
        ////        var reader = new StreamReader(respStream);
        ////        return reader.ReadToEnd();
        ////    }
        ////}

        /////// <summary>
        /////// Realiza uma chamada HTTP POST utilizando uma lista de par "chave/valor" no corpo
        /////// </summary>
        /////// <param name="optionalEndPoint">EndPoint opcional. Caso não seja passado, será utilizado o endponint definido globalmente</param>
        /////// <param name="path"></param>
        /////// <param name="keyValueListBody"></param>
        ////protected string CallHttpServicePost(string optionalEndPoint, string path, Dictionary<string, string> keyValueListBody, string contentType, bool useToken)
        ////{
        ////    Uri baseUri;

        ////    if (String.IsNullOrEmpty(optionalEndPoint))
        ////    {
        ////        baseUri = _credentials.EnvironmentType == EnvironmentType.Prod
        ////            ? new Uri(_endPoint.GetEndPointProd().Trim())
        ////            : new Uri(_endPoint.GetEndPointHomolog().Trim());
        ////    }
        ////    else
        ////    {
        ////        baseUri = new Uri(optionalEndPoint.Trim());
        ////    }


        ////    Uri uri = !String.IsNullOrEmpty(path) ? new Uri(baseUri, path) : new Uri(baseUri, String.Empty);

        ////    StringBuilder strParams = new StringBuilder();
        ////    foreach (var item in keyValueListBody)
        ////    {
        ////        strParams.Append(item.Key + "=" + item.Value).Append('&');
        ////    }

        ////    if (strParams.Length > 0)
        ////    {
        ////        WebRequest webRequest = WebRequest.Create(uri);
        ////        webRequest.Method = "POST";
        ////        webRequest.ContentType = contentType;
        ////        //webRequest.ContentLength = strParams.Length;

        ////        if ((useToken) && (AuthenticationData.IsNotNull()) && (!String.IsNullOrEmpty(AuthenticationData.AccessToken)))
        ////        {
        ////            webRequest.Headers.Add("Authorization", "bearer " + AuthenticationData.AccessToken.Trim());
        ////        }

        ////        using (var dataStream = webRequest.GetRequestStream())
        ////        {
        ////            //preparo o buffer com os dados a serem enviados
        ////            byte[] bufDataReq = Encoding.UTF8.GetBytes(strParams.ToString());
        ////            dataStream.Write(bufDataReq, 0, bufDataReq.Length);
        ////            dataStream.Close();

        ////            WebResponse resp = webRequest.GetResponse();
        ////            using (var respStream = resp.GetResponseStream())
        ////            {
        ////                if (respStream != null)
        ////                {
        ////                    var reader = new StreamReader(respStream);
        ////                    return reader.ReadToEnd();
        ////                }
        ////            }
        ////        }
        ////    }

        ////    return String.Empty;
        ////}

        /////// <summary>
        /////// Verifica se existe um token válido já obtido para ser utilizado
        /////// </summary>
        /////// <returns></returns>
        ////protected bool CheckToken()
        ////{
        ////    if (_automaticTokenRefresh)
        ////    {
        ////        return true;
        ////    }
        ////    else
        ////    {
        ////        return !String.IsNullOrEmpty(this.GetCurrentToken());
        ////    }
        ////}
    }
}
