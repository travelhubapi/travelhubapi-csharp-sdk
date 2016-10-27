using System;
using Newtonsoft.Json;

namespace TravelHubApi.Sdk.Common.Helpers.JSONConverters
{
    public class FloatJsonConverter : JsonConverter
    {
        #region Constructors | Destructors
        public FloatJsonConverter()
        {
        } 
        #endregion

        #region Properties
        public override bool CanRead
        {
            get
            {
                return false;
            }
        } 
        #endregion

        #region Public Methods
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException("Unnecessary because CanRead is false. The type will skip the converter.");
        }

        public override bool CanConvert(Type objectType)
        {
            Type nullable = Nullable.GetUnderlyingType(objectType);
            return objectType == typeof(decimal) ||
                objectType == typeof(float) ||
                objectType == typeof(double) ||
                nullable == typeof(decimal) ||
                nullable == typeof(float) ||
                nullable == typeof(double);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (FloatJsonConverter.IsWholeValue(value))
            {
                writer.WriteRawValue(JsonConvert.ToString(Convert.ToInt64(value)));
            }
            else
            {
                writer.WriteRawValue(JsonConvert.ToString(value));
            }
        } 
        #endregion

        #region Private Methods
        private static bool IsWholeValue(object value)
        {
            if (value is decimal)
            {
                decimal decimalValue = (decimal)value;
                int precision = (decimal.GetBits(decimalValue)[3] >> 16) & 0x000000FF;
                return precision == 0;
            }
            else if (value is float || value is double)
            {
                double doubleValue = (double)value;
                return doubleValue == Math.Truncate(doubleValue);
            }

            return false;
        } 
        #endregion
    }
}
