﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endeksa.Core.Models
{
    [JsonObject("Root")]
    public class NeighborhoodRootObject
    {
        [JsonProperty("features")]    
        public List<LandFeature> Features { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("crs")]
        public Crs Crs { get; set; }
    }
}
