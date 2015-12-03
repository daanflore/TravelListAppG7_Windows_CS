using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.WindowsAzure.MobileServices;
using System.Threading.Tasks;
using System.Diagnostics;

namespace TravelListAppG7.DataModel
{
    public class TravelList
    {
        private MobileServiceCollection<Categorie, Categorie> categorieList;
        private IMobileServiceTable<Categorie> categorieTable = App.MobileService.GetTable<Categorie>();
        private String destination;
        private DateTime day; 
        public string Id { get; set; }

        [JsonProperty(PropertyName = "destination")]
        public string Destination {
            get {
                return destination;
            }
            set {
                if (value == null || value.Equals(""))
                {
                    throw new ArgumentException("A destiantion cannot be empty");
                }
                else {
                    this.destination = value;
                }
            }
        }
        
        [JsonProperty(PropertyName = "day")]
        public DateTime Day { get{
                return day.Date; 
                } set {
                if (value.Date < new DateTime().Date)
                {
                    throw new ArgumentException("Travel date can't be in the past");
                }
                else {
                    day = value;
                }
            }
        }

        [JsonProperty(PropertyName = "userId")]
        public string UserId { get; set; }

        public async Task<MobileServiceCollection<Categorie, Categorie>> getTravelLists()
        {
            categorieList = await categorieTable.Where(i=>i.TravelListId==this.Id).ToCollectionAsync();
            return categorieList;
        }

        public async void addCategorie(Categorie categorie)
        {
            categorie.TravelListId = this.Id;
            await categorieTable.InsertAsync(categorie);
            categorieList.Add(categorie);
        }

        public async void updateCategorie(Categorie categorie)
        {
            Debug.WriteLine(categorie.Amount);
             await categorieTable.UpdateAsync(categorie);
        }
    }
}
