using Microsoft.WindowsAzure.Mobile.Service;
using System.Collections.Generic;

namespace TravelListAppG7Service.DataObjects
{
    public class TravelList : EntityData
    {
        public string Destination { get; set; }
        public string Season { get; set; }
        public int Year { get; set; }
        public ICollection<Categorie> PackingList { get; set; }
    }
}