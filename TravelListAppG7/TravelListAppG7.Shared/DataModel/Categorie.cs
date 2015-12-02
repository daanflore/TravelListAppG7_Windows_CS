using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace TravelListAppG7.DataModel
{
    public class Categorie
    {
        private MobileServiceCollection<PackingItem, PackingItem> packingList;
        private IMobileServiceTable<PackingItem> PackingTable = App.MobileService.GetTable<PackingItem>();
        
        private String name;
        public string Id { get; set; }
        [JsonProperty(PropertyName = "travelListId")]
        public string TravelListId { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string Name {
            get
            {
                return name;
            }
            set
            {
                if (value == null || value.Equals(""))
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                else {
                    name = value;
                }
            }
        }

        public Double CompletedPercentage {
            get {
                if (Amount == 0) {
                    return 0;
                }
                return AmountCompleted / Amount * 100;
                
            }
        }
        [JsonProperty(PropertyName = "amount")]
        public int Amount { get; set; }
        [JsonProperty(PropertyName = "completed")]
        public int AmountCompleted { get; set; }

        public async Task<MobileServiceCollection<PackingItem, PackingItem>> getPackingItems()
        {
            packingList = await PackingTable.Where(i => i.CategorieId == this.Id).ToCollectionAsync();
            return packingList;
        }

        public async void updatePackingItem(PackingItem item)
        {
            if (item.Packed == true)
            {
                AmountCompleted++;
            }
            else
            {
                AmountCompleted--;
            }
            
            await PackingTable.UpdateAsync(item);
        }

        public async void addPackingItem(PackingItem packingItem)
        {
            packingItem.CategorieId= this.Id;
            await PackingTable.InsertAsync(packingItem);
            packingList.Add(packingItem);
            Amount++;
        }
      
 }
}
