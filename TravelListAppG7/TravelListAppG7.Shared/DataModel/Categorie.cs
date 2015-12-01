using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

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

        public async Task<MobileServiceCollection<PackingItem, PackingItem>> getPackingItems()
        {
            packingList = await PackingTable.Where(i => i.CategorieId == this.Id).ToCollectionAsync();
            return packingList;
        }
    }
}
