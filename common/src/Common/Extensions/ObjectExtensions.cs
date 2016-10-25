using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using TravelHubApi.Sdk.Common.Helpers;
using TravelHubApi.Sdk.Common.Helpers.JSONConverters;

namespace TravelHubApi.Sdk.Common.Extensions
{
    public static class ObjectExtensions
    {
        /// <summary>
        /// Deserialize an object to the informed type
        /// </summary>
        /// <typeparam name="TClass">Type to be used to conversion</typeparam>
        /// <param name="value">String JSON to be converted to an object</param>
        /// <returns>Converted class</returns>
        public static TClass ToObject<TClass>(this string value)
            where TClass : class
        {
            if (!string.IsNullOrEmpty(value))
            {
                return JsonConvert.DeserializeObject<TClass>(value);
            }

            return null;
        }

        /// <summary>
        /// Sreialize a object to a given type.
        /// </summary>
        /// <typeparam name="TClass">Type to be used to conversion</typeparam>
        /// <param name="obj">Object to be serialized to a JSON string</param>
        /// <returns>String with serialized object</returns>
        public static string ToJson<TClass>(this TClass obj)
        {
            var serializeSettings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                NullValueHandling = NullValueHandling.Ignore // ignore null values
            };
            serializeSettings.Converters.Add(new FloatJsonConverter());
            return JsonConvert.SerializeObject(obj, serializeSettings);
        }

        /// <summary>
        /// Converts a date to ISO 8601 date with YYYY-MM-DD format
        /// </summary>
        /// <param name="value">Date to be formated</param>
        /// <returns>ISO 8601 string</returns>
        public static string ToIso8601DateFormat(this DateTime value)
        {
            if (value == null)
            {
                return string.Empty;
            }
            else
            {
                return value.ToString("yyyy-MM-dd");
            }
        }

        /// <summary>
        /// Converts a datetime to ISO 8601 date with YYYY-MM-DD format
        /// </summary>
        /// <param name="value">DateTime to be formated</param>
        /// <returns>ISO 8601 string</returns>
        public static string ToIso8601DatetimeFormat(this DateTime value)
        {
            if (value == null)
            {
                return string.Empty;
            }
            else
            {
                return value.ToString("yyyy-MM-ddTHH:mm");
            }
        }
    }
}
