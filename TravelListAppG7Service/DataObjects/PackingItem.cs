using Microsoft.WindowsAzure.Mobile.Service;

namespace TravelListAppG7Service.DataObjects
{
    public class PackingItem : EntityData
    {   
        public string CategorieId { get; set; }
        public string name { get; set; }
        public int amount { get; set; }
    }
}