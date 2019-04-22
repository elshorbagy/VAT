using Newtonsoft.Json;

namespace VAT.Data
{
    public class Rates
    {
        [JsonProperty("super_reduced", NullValueHandling = NullValueHandling.Ignore)]
        public double? SuperReduced { get; set; }

        [JsonProperty("reduced", NullValueHandling = NullValueHandling.Ignore)]
        public double? Reduced { get; set; }

        [JsonProperty("standard")]
        public double Standard { get; set; }

        [JsonProperty("reduced1", NullValueHandling = NullValueHandling.Ignore)]
        public double? Reduced1 { get; set; }

        [JsonProperty("reduced2", NullValueHandling = NullValueHandling.Ignore)]
        public double? Reduced2 { get; set; }

        [JsonProperty("parking", NullValueHandling = NullValueHandling.Ignore)]
        public double? Parking { get; set; }
    }
}
