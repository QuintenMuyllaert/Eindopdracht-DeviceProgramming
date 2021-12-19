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
    public partial class ItemScreenshotPage : ContentPage
    {
        public Tran GlobalTran;
        public Item GlobalItem;
        public ItemScreenshotPage(Item item,Tran transaction)
        {
            InitializeComponent();
            GlobalTran = transaction;
            GlobalItem = item;
            render(transaction);
        }

        public async void render(Tran transaction)
        {

            TransactionImage.Source = transaction.Link;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            _ = Navigation.PushModalAsync(new NavigationPage(new ItemCreatePage(GlobalItem, GlobalTran)) as NavigationPage);
        }
    }
}