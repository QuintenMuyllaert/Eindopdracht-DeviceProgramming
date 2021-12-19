using RS3.Repositories;
using RS3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RS3.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage(Item item)
        {
            InitializeComponent();
            this.Title = item.Name;
            render(item);
        }

        public async void render(Item item)
        {
            //listItemsInCategory.ItemsSource = item.Items;
            var transactions = await RuneScapeRepository.GetTransactionByItemId(item.Id);
            listPrices.ItemsSource = transactions.Tran;

        }

        private void listPrices_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (listPrices.SelectedItem == null)
            {
                return;
            }
            listPrices.SelectedItem = null;

            var tran = (Tran)listPrices.SelectedItem;
            if(!tran.HasLink)
            {
                return;
            }
            _ = Navigation.PushModalAsync(new NavigationPage(new ItemScreenshotPage(tran)) as NavigationPage);

        }
    }
}