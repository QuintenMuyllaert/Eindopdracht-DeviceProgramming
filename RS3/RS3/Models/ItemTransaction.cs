using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace RS3.Models
{ 
    public class Tran
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("qty")]
        public int Qty { get; set; }

        [JsonProperty("price")]
        public string Price { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("link")]
        public string Link { get; set; }

        [JsonProperty("time")]
        public string Time { get; set; }

        public string PricePretty { get { return String.Format("{0:n0}", Int64.Parse(this.Price)) + " gp"; } }
        public bool HasLink { get { return this.Link != null && this.Link != ""; } }

        public string Color { get { return this.HasLink ? "#2196F3" : "#000000"; } } 
    }

    public class PostPutTran : Tran
    {
        public string ItemId { get; set; }
        public string ItemName { get; set; }
        public string PricePretty { get; set; }
    }

    public class Ge
    {
        [JsonProperty("price")]
        public object Price { get; set; }

        [JsonProperty("limit")]
        public string Limit { get; set; }

        [JsonProperty("today")]
        public object Today { get; set; }

        [JsonProperty("day30")]
        public object Day30 { get; set; }

        [JsonProperty("day90")]
        public object Day90 { get; set; }
    }
    class ItemTransaction : Item
    {
        [JsonProperty("updateGE")]
        public string UpdateGE { get; set; }

        [JsonProperty("cat")]
        public string Cat { get; set; }

        [JsonProperty("offset")]
        public object Offset { get; set; }

        [JsonProperty("tran")]
        public List<Tran> Tran { get; set; }

        [JsonProperty("alt")]
        public List<object> Alt { get; set; }

        [JsonProperty("ge")]
        public Ge Ge { get; set; }

        [JsonProperty("lastUpdateGE")]
        public string LastUpdateGE { get; set; }
    }

}
