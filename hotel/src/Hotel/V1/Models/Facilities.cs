using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace TravelHubApi.Sdk.Hotel.V1.Models
{
    [Serializable]
    public class Facilities 
    {
        [JsonProperty(Order = 0)]
        public int Count 
        { 
            get 
            { 
                return Items != null ? Items.Count : 0; 
            } 
        }

        [JsonProperty(Order = 1)]
        public List<Facility> Items { get; set; }    
    }
}
