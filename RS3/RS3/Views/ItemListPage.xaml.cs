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
    public partial class ItemListPage : ContentPage
    {
        public ItemListPage(Category category)
        {
            InitializeComponent();
            this.Title = category.Name; 
            listItemsInCategory.ItemsSource = category.Items;
        }

        private async void listItemsInCategory_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (listItemsInCategory.SelectedItem == null)
            {
                return;
            }
            listItemsInCategory.SelectedItem = null;

            var item = (Item)listItemsInCategory.SelectedItem;
            var detailedItem = await RuneScapeRepository.GetItemById(item.Id);
            _ = Navigation.PushModalAsync(new NavigationPage(new ItemDetailPage(detailedItem)) as NavigationPage);
            
        }
    }
}