using RS3.Models;
using RS3.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RS3
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            Test();
        }

        async public void Test()
        {
            console.log("Hello World!");
            var categories = await RuneScapeRepository.GetCategories();
            foreach(var category in categories)
            {
                console.log(category.Name);
            }


            var cat = await RuneScapeRepository.GetCategoryById(1);
            console.log(cat.Name);
            foreach(var item in cat.Items)
            {
                console.log(item.Name);
            }
        }
    }
}
