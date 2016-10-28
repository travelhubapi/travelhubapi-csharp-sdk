using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using TravelHubApi.Sdk.Examples.Contexts.Hotel.V1;

namespace TravelHubApi.Sdk.Examples
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Environment.SetEnvironmentVariable(
                "TRAVELHUBAPI_CLIENT_ID",
                "54e428be-dc19-4258-b368-6d0752a3aaf5");
            Environment.SetEnvironmentVariable(
                "TRAVELHUBAPI_CLIENT_SECRET",
                "0d8599b2aba04204ad5c25e0b9d17df14958ebcdc37c4e23898fdf7b2879abe044ce46a3b208408ba2c05ae5215ee984");
            HotelExamples.Run();
        }
    }
}
