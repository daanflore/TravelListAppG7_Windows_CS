using System;
using System.Collections.Generic;
using System.Text;

namespace TravelListAppG7.DataModel
{
    public class Categorie
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<PackingItem> packingItems { get; set; }
        

    }
}
