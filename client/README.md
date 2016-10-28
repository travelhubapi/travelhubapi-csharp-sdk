# TravelhubApi SDK - TravelHubApiClient

Client to call endpoints with authentication and provide facilitators

---

1. [Definitions](#definitions)
  - [Constructors](#constructors)
  - [Properties](#properties)
    - [Instance](#instance)
      - [HotelClient](#hotelclient)
      - [OAuthClient](#oauthclient)
  - [Methods](#methods)
    - [GetAsync](#getasync)
    - [PostAsync](#postasync)
    - [DeleteAsync](#deleteasync)

## Definitions

**Namespace:** TravelHubApi.Sdk.Client

### Constructors

#### `new TravelHubApiClient(Settings settings)`

Create a TravelHubApiClient instance

**Parameters**

Name        | Type          |  Description
----------- | ------------- | -----------
`settings`  | [`Settings`](../common/src/Common/API/Settings.cs)| Settings with environment and credentials

#### `new TravelHubApiClient(Settings settings, OAuthClient oauth)`

Create a TravelHubApiClient instance with a custom OAuthClient instance

**Parameters**

Name        | Type          |  Description
----------- | ------------- | -----------
`settings`  | [`Settings`](../common/src/Common/API/Settings.cs)| Settings with environment and credentials
`oauth`     | [`OAuthClient`](../oauth/src/OAuth/OAuthClient.cs) | OAuthClient Instance

### Properties

#### Instance

##### HotelClient

Facilitator to call hotel endpoints, see [documentation](../hotel/README.md) for more details

##### OAuthClient

Facilitator to call authorized endpoints, see [documentation](../oauth/README.md) for more details

### Methods

#### GetAsync

Request any travelhubapi endpoint with verb `GET`.

**Parameters**

Name        | Type          |  Description
----------- | ------------- | -----------
`uri`       | `string`      | Travelhubapi endpoint
`content`   | `HttpContent` | Request content

**Return**

 Type                        | Description
 --------------------------- | -----------
 `Task<HttpResponseMessage>` | Http response message

#### PostAsync

Request any travelhubapi endpoint with verb `POST`.

**Parameters**

Name        | Type          |  Description
----------- | ------------- | -----------
`uri`       | `string`      | Travelhubapi endpoint
`content`   | `HttpContent` | Request content

**Return**

 Type                        | Description
 --------------------------- | -----------
 `Task<HttpResponseMessage>` | Http response message

#### DeleteAsync

Request any travelhubapi endpoint with verb `DELETE`.

**Parameters**

Name        | Type          |  Description
----------- | ------------- | -----------
`uri`       | `string`      | Travelhubapi endpoint
`content`   | `HttpContent` | Request content

**Return**

 Type                        | Description
 --------------------------- | -----------
 `Task<HttpResponseMessage>` | Http response message

---

*For more details about API, check the full [documentation](http://dev.travelhubapi.com.br/)*
