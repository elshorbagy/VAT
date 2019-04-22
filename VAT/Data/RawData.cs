using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace VAT.Data
{
    public class RawData
    {
        [JsonProperty("details")]
        public Uri Details { get; set; }

        [JsonProperty("version")]
        public object Version { get; set; }

        [JsonProperty("rates")]        
        public List<Rate> Rates { get; set; }
    }
}
