using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace RS3.Models
{
    public class ItemList
    {
        [JsonProperty("items")]
        public List<Item> Items { get; set; }

        [JsonProperty("found")]
        public int Found { get; set; }

        [JsonProperty("total")]
        public int Total { get; set; }

        [JsonProperty("search")]
        public string Search { get; set; }
    }
}
