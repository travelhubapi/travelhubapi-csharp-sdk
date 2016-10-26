using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelHubApi.Sdk.Common.Extensions
{
    public static class DateTimeExtensions
    {
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
