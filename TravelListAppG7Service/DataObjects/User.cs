using Microsoft.WindowsAzure.Mobile.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelListAppG7Service.DataObjects
{
    public class User : EntityData
    {
        public ICollection<TravelList> travelDestinations { get; set; }
        public string username { get; set; }
    }
}
