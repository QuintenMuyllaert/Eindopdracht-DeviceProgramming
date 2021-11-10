using Newtonsoft.Json;
using RS3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RS3.Repositories
{
    internal class RuneScapeRepository
    {
        public static string url = "http://172.30.248.55/";
        public static async Task<List<Category>> GetCategories()
        {
            var resp = await HTTP.Get(url + "cats");
            var categoriesAll = JsonConvert.DeserializeObject<List<Category>>(resp);
            var categoriesData = new List<Category>();

            foreach (var category in categoriesAll)
            {
                if (category.Count > 0)
                {
                    console.log("Added " + category.Name);
                    categoriesData.Add(category);
                }
            }
            return categoriesData.OrderBy(p => p.Name).ToList();
        }
    }
}
