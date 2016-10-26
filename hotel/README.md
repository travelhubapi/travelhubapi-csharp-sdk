# TravelhubApi SDK - HotelClient

Client to call hotel endpoints

---


1. [Definitions](#definitions)
  - [Constructors](#constructors)
  - [Properties](#properties)
    - [Statics](#statics)
      - [HOMOLOG_HOST](#homolog_host)
      - [PRODUCTION_HOST](#production_host)
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

**Namespace:** TravelHubApi.Sdk.Hotel.V1

### Constructors

#### `new HotelClient(Settings settings, OAuthClient oauth)`

Create a HotelClient instance

**Parameters**

Name        | Type          |  Description
----------- | ------------- | -----------
`settings`  | [`Settings`](../common/src/Common/Helpers/Settings.cs)| Settings with environment and credentials
`oauth`     | [`OAuthClient`](../oauth/src/OAuth/OAuthClient.cs) | OAuthClient Instance

### Properties

#### Statics

##### HOMOLOG_HOST

Url homologation environment

##### PRODUCTION_HOST

Url production environment

### Methods

#### GetLocations

Get the possible locations to availabilities of hotels filtering by description.

**Parameters**

Name        | Type      |  Description
----------- | --------- | -----------
`description`| `string` | Description of a place, can be a part of the city or state name (minimum of 3 characters)
`limit`  | `int`  | Maximum number of items to be returned in response

**Return**

 Type                        | Description
 --------------------------- | -----------
 [`Locations`](src/Hotel/V1/Models/Locations.cs) | A list of locations

#### GetAvailabilities

Check availability of hotels.

**Parameters**

Name        | Type      |  Description
----------- | --------- | -----------
`locationId`| `string`  | Location ID from get locations api
`checkIn`   | `DateTime`| Check-in date (ISO 8601 date with YYYY-MM-DD format)
`checkOut`  | `DateTime`| Check-out date (ISO 8601 date with YYYY-MM-DD format)
`rooms`     | [`RoomParameter`](src/Hotel/V1/Models/Parameters/RoomParameter.cs) | Information about accommodation and guests
`currencyIso` | [`CurrencyIso`](src/Hotel/V1/Models/Enums/CurrencyIso.cs)  | Currency ISO in which they will be returned the hotel rate values
`hotelName` | `string`  | Filter the hotels by the part of name
`minimumStars`| `decimal`| Filter the hotels by minimum stars that hotel must have
`basicInfo`  | `bool`   | Get hotel basic (true) or complete (default or false) information
`bookingAvailability`| [`BookingAvailability`](src/Hotel/V1/Models/Enums/BookingAvailability.cs)  | Booking availability type: <br>**`AvailableNow`** - Hotels available for booking <br> **`AvailableNowAndOnRequest`** - - Hotels available for booking and also booking on request

**Return**

 Type                        | Description
 --------------------------- | -----------
 [`Availabilities`](src/Hotel/V1/Models/Availabilities.cs) | List of availabilities of hotel

#### GetHotel

Get hotel informations.

**Parameters**

Name        | Type      |  Description
----------- | --------- | -----------
`track`     | `string`  | Hotel track code

**Return**

 Type                        | Description
 --------------------------- | -----------
 [`Hotel`](src/Hotel/V1/Models/Hotel.cs) | Hotel Information

#### GetFacilities

Get hotel Facilities.

**Parameters**

Name        | Type      |  Description
----------- | --------- | -----------
`track`     | `string`  | Hotel track code

**Return**

 Type                        | Description
 --------------------------- | -----------
 [`Facilities`](src/Hotel/V1/Models/Facilities.cs) | List of hotel Facilities

#### GetImages

Get hotel Images.

**Parameters**

Name        | Type      |  Description
----------- | --------- | -----------
`track`     | `string`  | Hotel track code

**Return**

 Type                        | Description
 --------------------------- | -----------
 [`Images`](src/Hotel/V1/Models/Images.cs) | List of hotel Images

#### GetCancellationPolicies

Get hotel the cancellation policies.

**Parameters**

Name        | Type      |  Description
----------- | --------- | -----------
`checkIn`   | `DateTime`| Check-in date (ISO 8601 date with YYYY-MM-DD format)
`checkOut`  | `DateTime`| Check-out date (ISO 8601 date with YYYY-MM-DD format)
`hotel`     | [`Hotel`](src/Hotel/V1/Models/Hotel.cs)| Hotel that has the cancellation policies

**Return**

 Type                        | Description
 --------------------------- | -----------
 [`CancellationPolicies`](src/Hotel/V1/Models/CancellationPolicies.cs) | Hotel cancellation policies

#### Book

Book a hotel without payment.

**Parameters**

Name        | Type      |  Description
----------- | --------- | -----------
`bookRequest`| [`BookRequest`](src/Hotel/V1/Models/Parameters/Body/BookRequest.cs)| Booking to be created

**Return**

 Type                        | Description
 --------------------------- | -----------
 [`Booking`](src/Hotel/V1/Models/Booking.cs) | Booking created with locators and expiration date

#### GetBooking

Get booking information.

**Parameters**

Name        | Type      |  Description
----------- | --------- | -----------
`bookingCode`| `string` | Booking code

**Return**

 Type                        | Description
 --------------------------- | -----------
 [`Booking`](src/Hotel/V1/Models/Booking.cs) | Booking information

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
 `void` |


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
|`CacelBooking`      |`DELETE`| [`/v1/bookings/{{track}}/{{vendorId}}`](#)

---

*For more details about Hotel API, check the full [documentation](http://dev.travelhubapi.com.br/documents/hotels)*
