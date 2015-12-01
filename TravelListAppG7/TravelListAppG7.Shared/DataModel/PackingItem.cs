using System;
using System.Collections.Generic;
using System.Text;

namespace TravelListAppG7.DataModel
{
    public class PackingItem
    {
        public string Id { get; set; }
        public string CategorieId { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public bool Packed { get; set; }

    }
}
