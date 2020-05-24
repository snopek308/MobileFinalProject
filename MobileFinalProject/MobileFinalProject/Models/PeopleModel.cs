using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileFinalProject.Models
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class PeopleModel
    {
        [JsonProperty(PropertyName = "name")]
        public string name { get; set; }
        [JsonProperty(PropertyName = "birth_year")]
        public string birth_year { get; set; }
        [JsonProperty(PropertyName ="gender")]
        public string gender { get; set; }
        [JsonProperty(PropertyName ="homeworld")]
        public string homeworld { get; set; }
    }
}
