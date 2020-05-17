
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileFinalProject.Models
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class ShipModel
    {
        [JsonProperty(PropertyName = "name")]
        public string name { get; set; }
        [JsonProperty(PropertyName = "manufacturer")]
        public string manufacturer { get; set; }
        [JsonProperty(PropertyName = "costInCredits")]
        public string costInCredits { get; set; }
        [JsonProperty(PropertyName = "crew")]
        public string crew { get; set; }
        [JsonProperty(PropertyName = "passengers")]
        public string passengers { get; set; }
        [JsonProperty(PropertyName = "starshipClass")]
        public string starshipClass { get; set; }

    }
}
