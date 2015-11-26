using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TravelListAppG7.DataModel
{
    public class TravelList
    {
        public string Id { get; set; }
        [JsonProperty(PropertyName = "destination")]

        public string Destination { get; set; }
        [JsonProperty(PropertyName = "season")]

        public string Season { get; set; }
        [JsonProperty(PropertyName = "year")]

        public int Year { get; set; }
        [JsonProperty(PropertyName = "userId")]
        public string UserId { get; set; }

    }
}
