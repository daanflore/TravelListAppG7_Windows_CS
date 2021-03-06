﻿using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TravelListAppG7.DataModel;

namespace TravelListAppG7.Domain
{
    public class DomainController
    {
        private IMobileServiceTable<User> userTable = App.MobileService.GetTable<User>();
        private MobileServiceCollection<User, User> userList;

        private static DomainController instance;
        public User user { get; set; }
        public TravelList destination { get; set; }
        public Categorie categorie { get; set; }
        private DomainController() { }
        public TravelList destinationFriend { get; set; }
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
        public async Task<bool> Register(User user)
        {
            if (user.Username == null || user.Username.Trim().Equals("") || user.Password == null || user.Password.Trim().Equals(""))
            {
                throw new ArgumentException("fill in al the field");
            }
            await userTable.InsertAsync(user);
            this.user = user;
            return true;


        }

        public async Task<MobileServiceCollection<PackingItem, PackingItem>> GetCategoriePacking()
        {
            return await categorie.getPackingItems();
        }
        public async Task<MobileServiceCollection<PackingItem, PackingItem>> getTravelListPacking()
        {
            return await destination.getPackingList();
        }

        public async Task<bool> Login(string username, string password)
        {
            if (username == null || username.Trim().Equals("") || password == null || password.Trim().Equals(""))
            {
                throw new ArgumentException("fill in al the field");
            }
            User user = await App.MobileService.InvokeApiAsync<User>("tables/Users/login?userName=" + username.Trim() + "&Password=" + password.Trim());
            if (user == null)
            {
                throw new ArgumentException("could not find a user with the given credentials");
            }
            this.user = user;
            return true;

        }
        public async Task<MobileServiceCollection<TravelList, TravelList>> GetUserDestinations()
        {
            return await user.getDestinations();

        }
        public void addTravelDestination(TravelList travelList)
        {
            user.addTravelList(travelList);
        }
        public async Task<MobileServiceCollection<Categorie, Categorie>> GetTravelListCategorie()
        {
            return await destination.getTravelLists();

        }

        public async void addPackingItem(PackingItem packingItem)
        {
            await categorie.addPackingItem(packingItem);
            Debug.WriteLine(categorie.Amount);
            destination.updateCategorie(categorie);
        }

        public void addCategorie(Categorie categorie)
        {
            destination.addCategorie(categorie);
        }

        public async void updatePackingItem(PackingItem item)
        {
            Debug.WriteLine(categorie.Amount);
            await categorie.updatePackingItem(item);
            Debug.WriteLine(categorie.AmountCompleted);
            destination.updateCategorie(categorie);
        }
        public void removeTravelList(TravelList travelList)
        {
            user.removeTravelList(travelList);
        }
        public void removeCategorie(Categorie categorie)
        {
            destination.removeCategorie(categorie);
        }
        public async void removePackingItem(PackingItem packingItem)
        {
            await categorie.removePackingItem(packingItem);
            Debug.WriteLine(categorie.AmountCompleted);
            destination.updateCategorie(categorie);
        }
        public async Task<MobileServiceCollection<TravelList, TravelList>> findFriend(String name)
        {
            
                User user = await App.MobileService.InvokeApiAsync<User>("tables/Users/user?userName="+name);
            if (user == null) {
                throw new ArgumentException("can't find user with name: " + name);
            }
            return await user.getDestinations();
           
        }
        public async Task<MobileServiceCollection<PackingItem, PackingItem>> getFriendPAckingItems() {
            return await destinationFriend.getPackingList();
        }

    }
}
