using Microsoft.WindowsAzure.Mobile.Service;

namespace TravelListAppG7Service.DataObjects
{
    public class PackingItem : EntityData
    {   
        public string CategorieId { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public bool Packed { get; set; }
    }
}