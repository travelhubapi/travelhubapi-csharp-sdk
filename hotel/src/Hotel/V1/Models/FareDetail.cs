using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace TravelHubApi.Sdk.Hotel.V1.Models
{
    [Serializable]
    public class FareDetail
    {
        #region Propriedades | Campos | Membros
        /// <summary>
        /// Obtém ou define o id da tarifa.
        /// </summary>
        [JsonProperty(Order = 0)]
        public virtual string Id { get; set; }

        /// <summary>
        /// Obtém ou define a data de aplicação da tarifa.
        /// </summary>
        [JsonProperty(Order = 1)]
        public virtual DateTime? ApplicationDate { get; set; }

        /// <summary>
        /// Obtém ou define o valor de diária.
        /// </summary>
        [JsonProperty(Order = 2)]
        public virtual Value Daily { get; set; }
        #endregion
    }
}
