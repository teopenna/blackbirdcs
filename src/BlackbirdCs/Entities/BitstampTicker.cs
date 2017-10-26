using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlackbirdCs.Entities
{
    public class BitstampTicker
    {
        [JsonProperty(PropertyName = "last")]
        public decimal Last { get; set; }

        [JsonProperty(PropertyName = "high")]
        public decimal High { get; set; }

        [JsonProperty(PropertyName = "low")]
        public decimal Low { get; set; }
    }
}
