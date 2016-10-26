# TravelhubApi SDK - OAuthClient

Client to call endpoints with authentication

---

1. [Definitions](#definitions)
  - [Constructors](#constructors)
  - [Properties](#properties)
    - [Statics](#statics)
      - [HOMOLOG_HOST](#homolog_host)
      - [PRODUCTION_HOST](#production_host)
      - [AUTHORIZE_PATH](#authorize_path)
      - [TOKEN_PATH](#token_path)
    - [Instance](#instance)
      - [Host](#host)
      - [AuthorizeUrl](#authorizeurl)
      - [TokenUrl](#tokenurl)
      - [HttpClient](#httpclient)
  - [Methods](#methods)
    - [RequestAsync](#requestasync)

## Definitions

**Namespace:** TravelHubApi.Sdk.OAuth

### Constructors

#### `new OAuthClient(Settings settings)`

Create a OAuthClient instance

**Parameters**

Name        | Type          |  Description
----------- | ------------- | -----------
`settings`  | [`Settings`](../common/src/Common/Helpers/Settings.cs)| Settings with environment and credentials

#### `new OAuthClient(Settings settings, HttpMessageHandler customHandler)`

Create a OAuthClient instance with a custom http handler

**Parameters**

Name        | Type          |  Description
----------- | ------------- | -----------
`settings`  | [`Settings`](../common/src/Common/Helpers/Settings.cs)| Settings with environment and credentials
`customHandler` | `HttpMessageHandler` | Custom httpHandler to be called before OAuth request

### Properties

#### Statics

##### HOMOLOG_HOST

Url homologation environment

##### PRODUCTION_HOST

Url production environment

##### AUTHORIZE_PATH

Authorization path

##### TOKEN_PATH

Token path

#### Instance

##### Host

Url used in authentication

##### AuthorizeUrl

Authorize url

##### TokenUrl

Create and refresh token url

##### HttpClient

HttpClient with oauth handler

### Methods

#### RequestAsync

Request any travelhubapi endpoint.

**Parameters**

Name        | Type          |  Description
----------- | ------------- | -----------
`method`    | `HttpMethods` | Request method
`uri`       | `string`      | Travelhubapi endpoint
`content`   | `HttpContent` | Request content

**Return**

 Type                        | Description
 --------------------------- | -----------
 `Task<HttpResponseMessage>` | Http response message

---

*For more details about authentication API, check the full [documentation](http://dev.travelhubapi.com.br/documents/auth)*
