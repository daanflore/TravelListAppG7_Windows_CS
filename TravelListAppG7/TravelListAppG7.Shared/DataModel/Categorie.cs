using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TravelListAppG7.DataModel
{
    public class Categorie
    {
        public string Id { get; set; }
        [JsonProperty(PropertyName = "travelListId")]
        public string TravelListId { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        

    }
}
