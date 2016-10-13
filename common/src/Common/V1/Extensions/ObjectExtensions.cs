using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelHubApi.Sdk.Common.V1.Extensions
{
    public static class ObjectExtensions
    {
        /// <summary>
        /// Deserialize an object to the informed type
        /// </summary>
        /// <typeparam name="TClass">Type to be used to conversion</typeparam>
        /// <param name="value">String JSON to be converted to an object</param>
        /// <returns></returns>
        public static TClass ToObject<TClass>(this string value)
            where TClass : class
        {
            if (!String.IsNullOrEmpty(value))
            {
                return JsonConvert.DeserializeObject<TClass>(value);
            }

            return null;
        }

        /// <summary>
        /// Serializa um objeto para o tipo informado
        /// </summary>
        /// <typeparam name="TClass">Type to be used to conversion</typeparam>
        /// <param name="obj">Object to be serialized to a JSON string</param>
        /// <returns></returns>
        public static string ToJson<TClass>(this TClass obj)
        {
            var serializeSettings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                NullValueHandling = NullValueHandling.Ignore // ignore null values
            };
            return JsonConvert.SerializeObject(obj, serializeSettings);
        }

        /// <summary>
        /// Converts a date to the format yyyy-MM-dd
        /// </summary>
        /// <param name="value">Date to be formated</param>
        /// <returns></returns>
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
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
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

    public class Iso8601DateFormatConverter : IsoDateTimeConverter
    {
        public Iso8601DateFormatConverter()
        {
            DateTimeFormat = "yyyy-MM-dd";
        }
    }
}
