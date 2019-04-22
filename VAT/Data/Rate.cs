using System.Collections.Generic;
using Newtonsoft.Json;

namespace VAT.Data
{
    public class Rate
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("country_code")]
        public string CountryCode { get; set; }

        [JsonProperty("periods")]        
        public List<Period> Periods { get; set; }
    }
}
