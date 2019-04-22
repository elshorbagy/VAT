using System;
using Newtonsoft.Json;

namespace VAT.Data
{
    public class Period
    {
        [JsonProperty("effective_from")]
        public DateTimeOffset EffectiveFrom { get; set; }

        [JsonProperty("rates")]
        public Rates Rates { get; set; }

    }
}
