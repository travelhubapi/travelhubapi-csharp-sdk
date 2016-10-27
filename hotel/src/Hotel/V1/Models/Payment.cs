using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using TravelHubApi.Sdk.Hotel.V1.Models.Enums;

namespace TravelHubApi.Sdk.Hotel.V1.Models
{
    public class Payment
    {
        /// <summary>
        /// Gets or sets the monetary value
        /// </summary>
        [JsonProperty(Order = 0)]
        public virtual MonetaryValue Value { get; set; }

        /// <summary>
        /// Gets or sets the payment method
        /// </summary>
        [JsonProperty(Order = 1)]
        [JsonConverter(typeof(StringEnumConverter))]
        public virtual PaymentMethod? Method { get; set; }

        /// <summary>
        /// Gets or sets the Creditcard payment method model
        /// </summary>
        [JsonProperty(Order = 3)]
        public virtual CreditCardPaymentMethod CreditCardPaymentMethod { get; set; }
    }
}
