using RS3.Models;
using RS3.Repositories;
using RS3.Views;
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
            //Test();
            NavigationPage.SetHasNavigationBar(this, false);
            Render();
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

            console.log("--GetTransactions--");
            var transactionDetail = await RuneScapeRepository.GetTransactionByItemId(51776); //51776 (Fractured Armadyl Symbol)
            foreach(var tran in transactionDetail.Tran)
            {
                console.log(tran.Id + " " + tran.Price);
            }

            console.log("--GetItems--");
            var items = await RuneScapeRepository.GetItems();
            foreach(var item in items)
            {
                console.log(item.Id + " " +item.Name);
            }
        }
        async public void Render()
        {
            console.log("Connected to backend.");
            var categories = await RuneScapeRepository.GetCategories();
            listCategories.ItemsSource = categories;
        }
        private async void listCategories_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (listCategories.SelectedItem == null)
            {
                return;
            }
            listCategories.SelectedItem = null;

            var category = (Category)listCategories.SelectedItem;
            var detailedCategory = await RuneScapeRepository.GetCategoryById(category.Id);
            _ = Navigation.PushModalAsync(new NavigationPage(new ItemListPage(detailedCategory)) as NavigationPage);
        }

        private async void SearchBar_SearchButtonPressed(object sender, EventArgs e)
        {

            SearchBar searchBar = (SearchBar)sender;
            var items = await RuneScapeRepository.GetItemsByQuerry(searchBar.Text);
            var category = new Category();
            category.Name = searchBar.Text;
            category.Items = items;
            _ = Navigation.PushModalAsync(new NavigationPage(new ItemListPage(category)) as NavigationPage);
        }
    }
}
