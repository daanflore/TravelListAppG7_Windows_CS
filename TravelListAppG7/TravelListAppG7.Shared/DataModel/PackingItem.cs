using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TravelListAppG7.DataModel
{
    public class PackingItem
    {
        private String name;
        private int amount;
        public string Id { get; set; }
        [JsonProperty(PropertyName = "categorieId")]
        public string CategorieId { get; set; }
        [JsonProperty(PropertyName = "travelListId")]
        public string TravelListId { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string Name {
            get
            {
                return name;
            }
            set
            {
                if (value == null || value.Equals(""))
                {
                    throw new ArgumentException("Name of an item can not be empty");
                }
                else {
                    name = value;
                }
            }
        }
        [JsonProperty(PropertyName = "amount")]
        public int Amount {
            get
            {
                return amount;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Amount cannot be less than 1");
                }
                else
                {
                    this.amount = value;
                }
            }
        }
        [JsonProperty(PropertyName = "packed")]
        public bool Packed { get; set; }

    }
}
