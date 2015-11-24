using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TravelListAppG7.DataModel
{
    public class User
    {
        private MobileServiceCollection<TravelList, TravelList> users;
        private IMobileServiceTable<TravelList> userTable = App.MobileService.GetTable<TravelList>();
        public string Id { get; set; }
        [JsonProperty(PropertyName = "username")]
        public string Username { get; set; }
        [JsonProperty(PropertyName = "password")]
        public string Password { get; set; }
        
        
        
        
    }
}
