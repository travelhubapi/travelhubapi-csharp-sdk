using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace TravelHubApi.Sdk.Hotel.V1.Models.Returns
{
    [Serializable]
    public class CancellationPoliciesReturn
    {
        #region Propriedades | Campos | Membros
        [JsonProperty(Order = 0)]
        public virtual string Description { get; set; }

        [JsonProperty(Order = 1)]
        public virtual Fines CancellationFines { get; set; }

        #endregion
    }
}
