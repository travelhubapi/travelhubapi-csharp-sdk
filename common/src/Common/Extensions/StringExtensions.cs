using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TravelHubApi.Sdk.Common.Extensions
{
    public static class StringExtensions
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
    }
}
