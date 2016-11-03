# TravelhubApi SDK - HotelClient

Client to call hotel endpoints

---


1. [Definitions](#definitions)
  - [Constructors](#constructors)
  - [Properties](#properties)
    - [Statics](#statics)
      - [HomologHost](#homologhost)
      - [ProductionHost](#productionhost)
  - [Methods](#methods)
    - [GetLocations](#getlocations)
    - [GetAvailabilities](#getavailabilities)
    - [GetHotel](#gethotel)
    - [GetFacilities](#getfacilities)
    - [GetImages](#getimages)
    - [GetCancellationPolicies](#getcancellationpolicies)
    - [Book](#book)
    - [GetBooking](#getbooking)
    - [CancelBooking](#cancelbooking)
2. [Referencies](#referencies)
  - [Methods - Endpoints](#methods-endpoints)

## Definitions

**Namespace:** TravelHubApi.Sdk.Hotel

### Constructors

#### `new HotelClient(Settings settings, OAuthClient oauth)`

Create a HotelClient instance

**Parameters**

Name        | Type          |  Description
----------- | ------------- | -----------
`settings`  | [`Settings`](../common/src/Common/API/Settings.cs)| Settings with environment and credentials
`oauth`     | [`OAuthClient`](../oauth/src/OAuth/OAuthClient.cs) | OAuthClient Instance

### Properties

#### Statics

##### HomologHost

Url homologation environment

##### ProductionHost

Url production environment

### Methods

#### GetLocationsAsync

Get the possible locations to availabilities of hotels filtering by description.

**Parameters**

Name        | Type      |  Description
----------- | --------- | -----------
`description`| `string` | Description of a place, can be a part of the city or state name (minimum of 3 characters)
`limit`  | `int`  | Maximum number of items to be returned in response
`countryCode`  | `string`  | Filter locations by country code (ISO 3166)
`cancelToken`   | `CancellationToken` | Cancellation token

**Return**

 Type                        | Description
 --------------------------- | -----------
 `Task<ApiResponse<`[`Locations`](src/Hotel/Models/Locations.cs)`>>` | A list of locations


#### GetLocations

Get the possible locations to availabilities of hotels filtering by description.

**Parameters**

Name        | Type      |  Description
----------- | --------- | -----------
`description`| `string` | Description of a place, can be a part of the city or state name (minimum of 3 characters)
`limit`  | `int`  | Maximum number of items to be returned in response
`countryCode`  | `string`  | Filter locations by country code (ISO 3166)

**Return**

 Type                        | Description
 --------------------------- | -----------
 `ApiResponse<`[`Locations`](src/Hotel/Models/Locations.cs)`>` | A list of locations

#### GetAvailabilitiesAsync

Check availability of hotels.

**Parameters**

Name        | Type      |  Description
----------- | --------- | -----------
`locationId`| `string`  | Location ID from get locations api
`checkIn`   | `DateTime`| Check-in date (ISO 8601 date with YYYY-MM-DD format)
`checkOut`  | `DateTime`| Check-out date (ISO 8601 date with YYYY-MM-DD format)
`rooms`     | [`RoomParameter`](src/Hotel/Models/Parameters/RoomParameter.cs) | Information about accommodation and guests
`currencyIso` | [`CurrencyIso`](src/Hotel/Models/Enums/CurrencyIso.cs)  | Currency ISO in which they will be returned the hotel rate values
`hotelName` | `string`  | Filter the hotels by the part of name
`minimumStars`| `decimal`| Filter the hotels by minimum stars that hotel must have
`basicInfo`  | `bool`   | Get hotel basic (true) or complete (default or false) information
`bookingAvailability`| [`BookingAvailability`](src/Hotel/Models/Enums/BookingAvailability.cs)  | Booking availability type: <br>**`AvailableNow`** - Hotels available for booking <br> **`AvailableNowAndOnRequest`** - - Hotels available for booking and also booking on request
`cancelToken`   | `CancellationToken` | Cancellation token

**Return**

 Type                        | Description
 --------------------------- | -----------
 `Task<ApiResponse<`[`Availabilities`](src/Hotel/Models/Availabilities.cs)`>>` | List of availabilities of hotel


#### GetAvailabilities

Check availability of hotels.

**Parameters**

Name        | Type      |  Description
----------- | --------- | -----------
`locationId`| `string`  | Location ID from get locations api
`checkIn`   | `DateTime`| Check-in date (ISO 8601 date with YYYY-MM-DD format)
`checkOut`  | `DateTime`| Check-out date (ISO 8601 date with YYYY-MM-DD format)
`rooms`     | [`RoomParameter`](src/Hotel/Models/Parameters/RoomParameter.cs) | Information about accommodation and guests
`currencyIso` | [`CurrencyIso`](src/Hotel/Models/Enums/CurrencyIso.cs)  | Currency ISO in which they will be returned the hotel rate values
`hotelName` | `string`  | Filter the hotels by the part of name
`minimumStars`| `decimal`| Filter the hotels by minimum stars that hotel must have
`basicInfo`  | `bool`   | Get hotel basic (true) or complete (default or false) information
`bookingAvailability`| [`BookingAvailability`](src/Hotel/Models/Enums/BookingAvailability.cs)  | Booking availability type: <br>**`AvailableNow`** - Hotels available for booking <br> **`AvailableNowAndOnRequest`** - - Hotels available for booking and also booking on request

**Return**

 Type                        | Description
 --------------------------- | -----------
 `ApiResponse<`[`Availabilities`](src/Hotel/Models/Availabilities.cs)`>` | List of availabilities of hotel

#### GetHotelAsync

Get hotel informations.

**Parameters**

Name        | Type      |  Description
----------- | --------- | -----------
`track`     | `string`  | Hotel track code
`cancelToken`   | `CancellationToken` | Cancellation token

**Return**

 Type                        | Description
 --------------------------- | -----------
 `Task<ApiResponse<`[`Hotel`](src/Hotel/Models/Hotel.cs)`>>` | Hotel Information

#### GetHotel

Get hotel informations.

**Parameters**

Name        | Type      |  Description
----------- | --------- | -----------
`track`     | `string`  | Hotel track code

**Return**

 Type                        | Description
 --------------------------- | -----------
 `ApiResponse<`[`Hotel`](src/Hotel/Models/Hotel.cs)`>` | Hotel Information

#### GetFacilitiesAsync

Get hotel Facilities.

**Parameters**

Name        | Type      |  Description
----------- | --------- | -----------
`track`     | `string`  | Hotel track code
`cancelToken`   | `CancellationToken` | Cancellation token

**Return**

 Type                        | Description
 --------------------------- | -----------
 `Task<ApiResponse<`[`Facilities`](src/Hotel/Models/Facilities.cs)`>>` | List of hotel Facilities

#### GetFacilities

Get hotel Facilities.

**Parameters**

Name        | Type      |  Description
----------- | --------- | -----------
`track`     | `string`  | Hotel track code

**Return**

 Type                        | Description
 --------------------------- | -----------
 `ApiResponse<`[`Facilities`](src/Hotel/Models/Facilities.cs)`>` | List of hotel Facilities

#### GetImagesAsync

Get hotel Images.

**Parameters**

Name        | Type      |  Description
----------- | --------- | -----------
`track`     | `string`  | Hotel track code
`cancelToken`   | `CancellationToken` | Cancellation token

**Return**

 Type                        | Description
 --------------------------- | -----------
 `Task<ApiResponse<`[`Images`](src/Hotel/Models/Images.cs)`>>` | List of hotel Images

#### GetImages

Get hotel Images.

**Parameters**

Name        | Type      |  Description
----------- | --------- | -----------
`track`     | `string`  | Hotel track code

**Return**

 Type                        | Description
 --------------------------- | -----------
 `ApiResponse<`[`Images`](src/Hotel/Models/Images.cs)`>` | List of hotel Images

#### GetCancellationPoliciesAsync

Get hotel the cancellation policies.

**Parameters**

Name        | Type      |  Description
----------- | --------- | -----------
`checkIn`   | `DateTime`| Check-in date (ISO 8601 date with YYYY-MM-DD format)
`checkOut`  | `DateTime`| Check-out date (ISO 8601 date with YYYY-MM-DD format)
`hotel`     | [`Hotel`](src/Hotel/Models/Hotel.cs)| Hotel that has the cancellation policies
`cancelToken`   | `CancellationToken` | Cancellation token

**Return**

 Type                        | Description
 --------------------------- | -----------
 `Task<ApiResponse<`[`CancellationPolicies`](src/Hotel/Models/CancellationPolicies.cs)`>>` | Hotel cancellation policies

#### GetCancellationPolicies

Get hotel the cancellation policies.

**Parameters**

Name        | Type      |  Description
----------- | --------- | -----------
`checkIn`   | `DateTime`| Check-in date (ISO 8601 date with YYYY-MM-DD format)
`checkOut`  | `DateTime`| Check-out date (ISO 8601 date with YYYY-MM-DD format)
`hotel`     | [`Hotel`](src/Hotel/Models/Hotel.cs)| Hotel that has the cancellation policies

**Return**

 Type                        | Description
 --------------------------- | -----------
 `ApiResponse<`[`CancellationPolicies`](src/Hotel/Models/CancellationPolicies.cs)`>` | Hotel cancellation policies

#### BookAsync

Book a hotel without payment.

**Parameters**

Name        | Type      |  Description
----------- | --------- | -----------
`bookRequest`| [`BookRequest`](src/Hotel/Models/Parameters/Body/BookRequest.cs)| Booking to be created
`cancelToken`   | `CancellationToken` | Cancellation token

**Return**

 Type                        | Description
 --------------------------- | -----------
 `Task<ApiResponse<`[`Booking`](src/Hotel/Models/Booking.cs)`>>` | Booking created with locators and expiration date

#### Book

Book a hotel without payment.

**Parameters**

Name        | Type      |  Description
----------- | --------- | -----------
`bookRequest`| [`BookRequest`](src/Hotel/Models/Parameters/Body/BookRequest.cs)| Booking to be created

**Return**

 Type                        | Description
 --------------------------- | -----------
 `ApiResponse<`[`Booking`](src/Hotel/Models/Booking.cs)`>` | Booking created with locators and expiration date

#### GetBookingAsync

Get booking information.

**Parameters**

Name        | Type      |  Description
----------- | --------- | -----------
`bookingCode`| `string` | Booking code
`cancelToken`   | `CancellationToken` | Cancellation token

**Return**

 Type                        | Description
 --------------------------- | -----------
 `Task<ApiResponse<`[`Booking`](src/Hotel/Models/Booking.cs)`>>` | Booking information

#### GetBooking

Get booking information.

**Parameters**

Name        | Type      |  Description
----------- | --------- | -----------
`bookingCode`| `string` | Booking code

**Return**

 Type                        | Description
 --------------------------- | -----------
 `ApiResponse<`[`Booking`](src/Hotel/Models/Booking.cs)`>` | Booking information

#### CancelBookingAsync

Cancel booking.

**Parameters**

Name        | Type      |  Description
----------- | --------- | -----------
`bookingCode`| `string` | Booking code
`vendorId`  | `string`  | Vendor Id
`cancelToken`   | `CancellationToken` | Cancellation token

**Return**

 Type                        | Description
 --------------------------- | -----------
 Task<[`ApiResponse`](src/Hotel/Models/ApiResponse.cs)> | Response info

#### CancelBooking

Cancel booking.

**Parameters**

Name        | Type      |  Description
----------- | --------- | -----------
`bookingCode`| `string` | Booking code
`vendorId`  | `string`  | Vendor Id

**Return**

 Type                        | Description
 --------------------------- | -----------
 [`ApiResponse`](src/Hotel/Models/ApiResponse.cs) | Response info


## Referencies

### Methods - Endpoints

| Method                        | verb | Endpoint
|:------------------------------|:-----|:------------------------------------------------
|`GetLocations`      |`GET`| [`/v1/locations/{{description}}`](#)
|`GetAvailabilities` |`GET`| [`/v1/availabilities/{{locationId}}/{{checkIn}}/{{checkOut}}`](#)
|`GetHotel`          |`GET`| [`/v1/hotels/{{track}}`](#) |
|`GetFacilities`     |`GET`| [`/v1/hotels/{{track}}/facilities`](#)
|`GetImages`         |`GET`| [`/v1/hotels/{{track}}/images`](#)
|`GetCancellationPolicies` |`POST`| [`/v1/bookings/{{checkIn}}/{{checkOut}}/cancellationPolicies`](#)
|`Book`              |`POST`| [`/v1/bookings`](#)
|`GetBooking`        |`GET`| [`/v1/bookings/{{track}}`](#)
|`CancelBooking`      |`DELETE`| [`/v1/bookings/{{track}}/{{vendorId}}`](#)

---

*For more details about Hotel API, check the full [documentation](http://dev.travelhubapi.com.br/documents/hotels)*
