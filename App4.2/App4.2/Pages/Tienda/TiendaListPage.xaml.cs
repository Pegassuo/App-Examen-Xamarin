using App4_2.Models;
using App4_2.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App4._2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TiendaListPage : ContentPage
    {
        List<Tienda> tiendas = new List<Tienda>();

        public TiendaListPage()
        {
            InitializeComponent();

            listView.RefreshCommand = new Command(async () => await LoadData());
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            await LoadData();
        }

        private async Task LoadData()
        {
            Service service = new Service();

            tiendas = await service.TiendaQueryAsync();
            listView.ItemsSource = tiendas;

            listView.IsRefreshing = false;
        }

        private void addButton_Clicked(object sender, EventArgs e)
        {                 
            this.Navigation.PushAsync(new TiendaPage());
        }

        private async void OnDelete(object sender, EventArgs e)
        {
            var menuItem = ((MenuItem)sender);

            var item = menuItem.CommandParameter as Tienda;

            if (item != null)
            {
                Service service = new Service();

                var data = await service.TiendaDeleteAsync(item);

                await LoadData();
            }
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            listView.ItemsSource = tiendas.Where(p => p.Nombre.Contains(e.NewTextValue)).ToList();
        }

        private async void listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as Tienda;

            if (item != null)
            {
                Service service = new Service();

                var data  = await service.TiendaGetAsync(item.IdTienda);

                if (data != null)
                {
                    var page = new TiendaPage();
                    page.LoadData(data);

                    await this.Navigation.PushAsync(page);
                }
            }
        }
    }
}