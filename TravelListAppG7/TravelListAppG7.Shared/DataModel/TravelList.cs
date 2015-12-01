using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.WindowsAzure.MobileServices;
using System.Threading.Tasks;

namespace TravelListAppG7.DataModel
{
    public class TravelList
    {
        private MobileServiceCollection<Categorie, Categorie> categorieList;
        private IMobileServiceTable<Categorie> categorieTable = App.MobileService.GetTable<Categorie>();
        public string Id { get; set; }

        [JsonProperty(PropertyName = "destination")]
        public string Destination { get; set; }
        
        [JsonProperty(PropertyName = "day")]
        public DateTime Day { get; set; }

        [JsonProperty(PropertyName = "userId")]
        public string UserId { get; set; }

        public async Task<MobileServiceCollection<Categorie, Categorie>> getTravelLists()
        {
            categorieList = await categorieTable.Where(i=>i.TravelListId==this.Id).ToCollectionAsync();
            return categorieList;
        }
    }
}
