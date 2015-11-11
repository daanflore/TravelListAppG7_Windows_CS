using Microsoft.WindowsAzure.Mobile.Service;
using System.Collections.Generic;

namespace TravelListAppG7Service.DataObjects
{
    public class Categorie : EntityData
    {
        public string name { get; set; }
        public ICollection<PackingItem> packingItems { get; set; }
    }
}