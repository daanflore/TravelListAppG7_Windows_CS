﻿using Microsoft.WindowsAzure.Mobile.Service;
using System.Collections.Generic;

namespace TravelListAppG7Service.DataObjects
{
    public class Categorie : EntityData
    {
        public string TravelListId { get; set; }
        public string name { get; set; }
        public int Amount { get; set; }
        public int AmountCompleted { get; set; }
    }
}