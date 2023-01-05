using App4._2.ViewModels;
using App4_2.Models;
using App4_2.Services;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App4._2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TiendaPage : ContentPage
    {
        TiendaViewModel CurrentViewModel { get { return (TiendaViewModel)this.BindingContext; } }

        public TiendaPage()
        {
            InitializeComponent();

            BindingContext = new ViewModels.TiendaViewModel();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
        }


        public void LoadData(Tienda tienda)
        {
            CurrentViewModel.IdTienda = tienda.IdTienda;
            CurrentViewModel.Nombre = tienda.Nombre;
            CurrentViewModel.Direccion = tienda.Direccion;
            CurrentViewModel.Telefono = tienda.Telefono;
            CurrentViewModel.Latitud = tienda.Latitud;
            CurrentViewModel.Longitud = tienda.Longitud;
        }

        private  async void saveButton_Clicked(object sender, EventArgs e)
        {
            Tienda tienda = new Tienda();

            tienda.IdTienda = CurrentViewModel.IdTienda;
            tienda.Nombre = CurrentViewModel.Nombre;
            tienda.Direccion = CurrentViewModel.Direccion;
            tienda.Telefono = CurrentViewModel.Telefono;
            tienda.Latitud = CurrentViewModel.Latitud;
            tienda.Longitud = CurrentViewModel.Longitud;

            Service service = new Service();

            bool result = false;

            if(tienda.IdTienda == 0)
                result = await service.TiendaInsertAsync(tienda);
            else
                result = await service.TiendaUpdateAsync(tienda);

            if (result)
            {
                await this.Navigation.PopAsync();
            }
        }

        
    }
}