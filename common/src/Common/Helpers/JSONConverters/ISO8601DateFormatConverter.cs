using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Converters;

namespace TravelHubApi.Sdk.Common.Helpers.JSONConverters
{
    public class ISO8601DateFormatConverter : IsoDateTimeConverter
    {
        public ISO8601DateFormatConverter()
        {
            DateTimeFormat = "yyyy-MM-dd";
        }
    }
}
