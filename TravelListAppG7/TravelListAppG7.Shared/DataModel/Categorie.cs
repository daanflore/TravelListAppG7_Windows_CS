using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TravelListAppG7.DataModel
{
    public class Categorie
    {
        private MobileServiceCollection<PackingItem, PackingItem> packingList;
        private IMobileServiceTable<PackingItem> PackingTable = App.MobileService.GetTable<PackingItem>();
        public string Id { get; set; }
        [JsonProperty(PropertyName = "travelListId")]
        public string TravelListId { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        public string CompletedPercentage {
            get {
                return "hallo";
            } }
        

    }
}
