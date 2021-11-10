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
            console.log("--GetCategories--");
            var categories = await RuneScapeRepository.GetCategories();
            foreach(var category in categories)
            {
                console.log(category.Name);
            }

            console.log("--GetCategoryById--");
            var cat = await RuneScapeRepository.GetCategoryById(1);
            console.log(cat.Name);
            foreach(var item in cat.Items)
            {
                console.log(item.Name);
            }

            console.log("--GetItemsByQuerry--");
            var querry = await RuneScapeRepository.GetItemsByQuerry("fractured");
            foreach(var item in querry)
            {
                console.log(item.Name);
            }

            console.log("");
            var transactionDetail = await RuneScapeRepository.GetTransactionByItemId(51776); //51776 (Fractured Armadyl Symbol)
            foreach(var tran in transactionDetail.Tran)
            {
                console.log(tran.Id + " " + tran.Price);
            }
        }
    }
}
