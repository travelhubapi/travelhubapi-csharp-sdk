using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace TravelHubApi.Sdk.Hotel.V1.Models
{
    [Serializable]
    public class Fare
    {
        #region Propriedades | Campos | Membros
        [JsonProperty(Order = 0)]
        public virtual string Id { get; set; }

        [JsonProperty(Order = 1)]
        public virtual string RateCode { get; set; }

        [JsonProperty(Order = 2)]
        public virtual string Agreement { get; set; }

        [JsonProperty(Order = 3)]
        public virtual MealPlan MealPlan { get; set; }

        [JsonProperty(Order = 4)]
        public virtual FareDetails Details { get; set; }

        [JsonProperty(Order = 5)]
        public virtual BankerRate BankerRate { get; set; }

        [JsonProperty(Order = 6)]
        public virtual Taxes Taxes { get; set; }

        [JsonProperty(Order = 7)]
        public virtual Fines CancellationFines { get; set; }

        [JsonProperty(Order = 8)]
        public virtual string Remarks { get; set; }

        [JsonProperty(Order = 9)]
        public virtual Value RentalCost { get; set; }

        [JsonProperty(Order = 10)]
        public virtual Value AverageDaily { get; set; }

        [JsonProperty(Order = 11)]
        public virtual Value Total { get; set; }
        #endregion
    }
}
