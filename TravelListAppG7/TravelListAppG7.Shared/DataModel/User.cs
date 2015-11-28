using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TravelListAppG7.DataModel
{
    public class User
    {
        private MobileServiceCollection<TravelList, TravelList> travelList;
        private IMobileServiceTable<TravelList> userTable = App.MobileService.GetTable<TravelList>();
        public string Id { get; set; }
        [JsonProperty(PropertyName = "username")]
        public string Username { get; set; }
        [JsonProperty(PropertyName = "password")]
        public string Password { get; set; }
        public async Task<MobileServiceCollection<TravelList, TravelList>> getDestinations()
        {
            travelList = await userTable.Where(u => u.UserId == Id).ToCollectionAsync();
            DateTime day = DateTime.Today;
            return travelList;
        }
        public async void addTravelList(TravelList travelList) {
            await userTable.InsertAsync(travelList);
            this.travelList.Add(travelList);
        }




    }
}
