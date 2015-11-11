using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace TravelListAppG7
{
    public class TodoItem
    {
        private string Id { get; set; }

        [JsonProperty(PropertyName = "text")]
        public string Text { get; set; }

        [JsonProperty(PropertyName = "complete")]
        public bool Complete { get; set; }
    }
}
