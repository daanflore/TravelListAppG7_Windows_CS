using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TravelListAppG7.DataModel
{
    public class PackingItem
    {
        public string Id { get; set; }
        [JsonProperty(PropertyName = "categorieId")]
        public string CategorieId { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "amount")]
        public int Amount { get; set; }
        [JsonProperty(PropertyName = "packed")]
        public bool Packed { get; set; }

    }
}
