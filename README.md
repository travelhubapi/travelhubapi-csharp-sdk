# TravelhubApi SDK

**C# Sdk for [TravelhubApi](http://www.travelhubapi.com.br/)**

---

1. [Installation](#installation)
2. [Usage](#usage)
  - [Creating Client](#creating-client)
  - [Using as a HttpClient](#using-as-a-httpclient)
  - [Using facilitators](#using-facilitators)
    - [Hotel Client](#hotel-client)

## Installation

```
 Install-Package TravelHubApiSDK
```


## Usage

### Creating client

```cs
var settings = new TravelHubApi.Sdk.Common.API.Settings();

settings.Environment = TravelHubApi.Sdk.Common.API.Enums.Environment.Homolog;
settings.ClientId = System.Environment.GetEnvironmentVariable("TRAVELHUBAPI_CLIENT_ID");
settings.ClientSecret = System.Environment.GetEnvironmentVariable("TRAVELHUBAPI_CLIENT_SECRET");

var client = new TravelHubApiClient(settings);
```

### Using as a HttpClient

```cs
var response = await client.GetAsync("http://hotel.stg.travelhubapi.com.br/v1/locations/sao");

Console.Write(response.StatusCode);

if (response.IsSuccessStatusCode) {
  var result = await response.Content.ReadAsStringAsync();
}

```
[See documentation](client/README.md)

### Using facilitators

#### Hotel Client

```cs
var hotelClient = client.HotelClient;
var locations = hotelClient.GetLocations("fort").Content;
var checkIn = DateTime.Now.AddDays(1);
var checkOut = DateTime.Now.AddDays(3);
var location = locations.Items.FirstOrDefault();
var rooms = new RoomParameter[]
{
  new RoomParameter()
  {
    Adt = 1
  }
};
var availabilities = hotelClient.GetAvailabilities(
  location.Id,
  checkIn,
  checkOut,
  rooms).Content;
var availability = availabilities.Items.FirstOrDefault();
var hotel = availability.Hotels.Items.FirstOrDefault();
var accomodation = hotel.Accommodations.Items.FirstOrDefault();

accomodation.Guests = new Guests();
accomodation.Guests.Items = new List<Guest>()
{
  new Guest()
  {
    FirstName = "Marcos",
    LastName = "Rava",
    Document = new Document()
    {
      Number = "000000000000",
      Type = DocumentType.IndividualRegistrationCode
    },
    Gender = Gender.Male,
    GuestType = GuestType.Adt,
    BirthDate = DateTime.ParseExact(
      "1986-07-31",
      "yyyy-MM-dd",
      CultureInfo.InvariantCulture)
  },
  new Guest()
  {
    FirstName = "Baby",
    LastName = "Rava",
    Gender = Gender.Male,
    GuestType = GuestType.Chd,
    BirthDate = DateTime.ParseExact(
      "2016-10-13",
      "yyyy-MM-dd",
      CultureInfo.InvariantCulture)
  }
};

hotel.Accommodations.Items = new List<Accommodation>()
{
  accomodation
};

var bookRequest = new BookRequest()
{
  CheckIn = checkIn,
  CheckOut = checkOut,
  Hotel = hotel
};

var booking = hotelClient.Book(bookRequest).Content;
```

[See documentation](hotel/README.md)

---

*For more details about API, check the full [documentation](http://dev.travelhubapi.com.br/)*
