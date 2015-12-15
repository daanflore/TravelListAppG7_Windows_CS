using Microsoft.WindowsAzure.Mobile.Service;
using System;
using System.Collections.Generic;

namespace TravelListAppG7Service.DataObjects
{
    public class TravelList : EntityData
    {
        public string UserId { get; set; }
        public string Destination { get; set; }
        public DateTime Day { get; set; }
    }
}