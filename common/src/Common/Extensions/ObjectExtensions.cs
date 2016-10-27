using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using TravelHubApi.Sdk.Common.Helpers.JSONConverters;

namespace TravelHubApi.Sdk.Common.Extensions
{
    public static class ObjectExtensions
    {
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
    }
}
