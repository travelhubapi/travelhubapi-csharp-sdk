﻿using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace TravelHubApi.Sdk.Hotel.Models
{
    [Serializable]
    public class Availabilities
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
        public List<Availability> Items { get; set; }
    }
}
