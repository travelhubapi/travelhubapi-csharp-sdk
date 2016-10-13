using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelHubApi.Sdk.Hotel.V1.Models.Enums;

namespace TravelHubApi.Sdk.Hotel.V1.Models
{
    public class CreditCardPaymentMethod
    {
        #region Properties
        /// <summary>
        /// Gets or sets the credit card origin
        /// </summary>
        [JsonProperty(Order = 0)]
        [JsonConverter(typeof(StringEnumConverter))]
        public virtual CreditCardOrigin? Origin { get; set; }

        /// <summary>
        /// Gets or sets the credit card ownership
        /// </summary>
        [JsonProperty(Order = 1)]

        [JsonConverter(typeof(StringEnumConverter))]
        public virtual CreditCardOwnership? Ownership { get; set; }

        /// <summary>
        /// Gets or sets the credit card brand
        /// </summary>
        [JsonProperty(Order = 2)]
        [JsonConverter(typeof(StringEnumConverter))]
        public virtual CreditCardBrand? Brand { get; set; }

        /// <summary>
        /// Gets or sets the number
        /// </summary>
        [JsonProperty(Order = 3)]
        public virtual string Number { get; set; }

        /// <summary>
        /// Gets or sets the credit card expiration date
        /// </summary>
        [JsonProperty(Order = 4)]
        public virtual CreditCardExpirationDate ExpirationDate { get; set; }

        /// <summary>
        /// Gets or sets the name on the card
        /// </summary>
        [JsonProperty(Order = 5)]
        public virtual string NameOnCard { get; set; }

        /// <summary>
        /// Gets or sets the security code
        /// </summary>
        [JsonProperty(Order = 6)]
        public virtual string SecurityCode { get; set; }

        /// <summary>
        /// Gets or sets the installment option
        /// </summary>
        [JsonProperty(Order = 7)]
        public virtual short? InstallmentOption { get; set; }

        /// <summary>
        /// Gets or sets the cost center
        /// </summary>
        [JsonProperty(Order = 8)]
        public virtual string CostCenter { get; set; }

        /// <summary>
        /// Gets or sets the enrollment
        /// </summary>
        [JsonProperty(Order = 9)]
        public virtual string Enrollment { get; set; }

        /// <summary>
        /// Gets or sets the department
        /// </summary>
        [JsonProperty(Order = 10)]
        public virtual string Department { get; set; }

        /// <summary>
        /// Gets or sets the travel request
        /// </summary>
        [JsonProperty(Order = 11)]
        public virtual string TravelRequest { get; set; }
        #endregion
    }
}
