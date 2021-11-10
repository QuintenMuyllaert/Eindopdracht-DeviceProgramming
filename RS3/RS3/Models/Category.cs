using Newtonsoft.Json;
using System;

namespace RS3.Repositories
{
    public class Category
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }


        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty("count")]
        private string count { get; set; }
        public int Count { get { return Int32.Parse(count); } set { count = value.ToString(); } }

        public Category()
        {

        }

        public override string ToString()
        {
            return Name;
        }
    }
}