using System;
using System.Collections.Generic;
using System.Text;

namespace TravelListAppG7.DataModel
{
    public class User
    {
        public string Id { get; set; }
        public List<TravelList> travelDestinations;
        public string username { get; set; }
        public string salt
 { get; set; }
        
        
    }
}
