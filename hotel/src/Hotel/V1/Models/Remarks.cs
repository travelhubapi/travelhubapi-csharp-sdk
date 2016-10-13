using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelHubApi.Sdk.Hotel.V1.Models
{
    public class Remarks
    {
        #region Proerties

        [JsonProperty(Order = 0)]
        public int Count { get { return Items != null ? Items.Count : 0; } set { } }

        [JsonProperty(Order = 1)]
        public List<Remark> Items { get; set; }

        #endregion
    }
}
