﻿using Microsoft.WindowsAzure.Mobile.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;

namespace TravelListAppG7Service.DataObjects
{
    public class User : EntityData
    {
        public virtual ICollection<TravelList> travelDestinations { get; set; }
        public string username { get; set; }
        public string password { get; set; }

        
    }
}
