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
    public partial class ItemCreatePage : ContentPage
    {
        Tran GlobalTran;
        Item GlobalItem;
        public ItemCreatePage(Item item,Tran tran)
        {
            InitializeComponent();
            GlobalItem = item;
            GlobalTran = tran;
            render(item,tran);
        }

        public async void render(Item item,Tran tran)
        {
            EntryName.Text = item.Name;
            EntryLink.Text = tran.Link;
            EntryPrice.Text = tran.Price;
            EntryType.Text = tran.Type;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        { 
            var data = new PostPutTran();                
            data.Id = GlobalTran.Id;
            data.Link = EntryLink.Text;
            data.Type = EntryType.Text;
            data.ItemName = EntryName.Text;
            data.Price = EntryPrice.Text;
            data.ItemId = ""+GlobalItem.Id;
            
            if (GlobalTran.Id != null)
            {
                //put
                _ = await HTTP.Put("http://192.168.137.1/", data);
            }
            else
            {
                //post
                _ = HTTP.Post("http://192.168.137.1/", data);
            }
            

            _ = Navigation.PushModalAsync(new NavigationPage(new MainPage()) as NavigationPage);
        }
    }
}