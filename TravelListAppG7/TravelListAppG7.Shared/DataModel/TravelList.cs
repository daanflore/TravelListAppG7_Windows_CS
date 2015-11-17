using System;
using System.Collections.Generic;
using System.Text;

namespace TravelListAppG7.DataModel
{
    public class TravelList
    {
        public string Id { get; set; }
        private string Destination;
        private string Season;
        private int Year;
        private ICollection<Categorie> PackingList;
    }
}
