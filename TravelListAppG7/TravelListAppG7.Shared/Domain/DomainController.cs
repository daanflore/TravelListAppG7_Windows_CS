using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using TravelListAppG7.DataModel;

namespace TravelListAppG7.Domain
{
    public class DomainController
    {
        private MobileServiceCollection<User, User> users;
        private IMobileServiceTable<User> userTable = App.MobileService.GetTable<User>();

        private static DomainController instance;
        public User user { get; set; }
        private DomainController() { }

        public static DomainController Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DomainController();
                }
                return instance;
            }
        }
        public async void Register(User user)
        {
            try
            {
                await userTable.InsertAsync(user);
                this.user = user;
                
            }
            catch (Exception ex) {
                var mes = ex.Message;
            }
            
        }
        public async void Login(string Username, string password) {
            try
            {
                var user = await App.MobileService.InvokeApiAsync<User>("tables/Users/login?userName=daan&Password=daan");
                
            }
            catch (Exception ex) {
                var str= ex.Message;
            }

        }
    }

}
