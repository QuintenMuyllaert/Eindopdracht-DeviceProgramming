using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace RS3.Models
{
    public class Item
    {
        [JsonProperty("id")]
        private string id { get; set; }
        public int Id { get { return Int32.Parse(id); } set { id = value.ToString(); } }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("count")]
        public string Count { get; set; }

        [JsonProperty("price")]
        public string Price { get; set; }
    }
}
