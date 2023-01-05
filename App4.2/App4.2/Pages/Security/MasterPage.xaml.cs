using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.IO;
using Xamarin.Essentials;
using App4_2.Models;

namespace App4._2
{
    public partial class MasterPage : ContentPage
    {
        public ListView ListView { get { return listView; } }
        
        public MasterPage()
        {
            InitializeComponent();  
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            this.UserName.Text = "Carlos Bermeo";
            this.OrganizationName.Text = "ECOTEC";

            await ApplicationOptions();
        }

        private async Task ApplicationOptions()
        {
            var masterPageItems = new List<MasterPageItem>();

            masterPageItems.Add(new MasterPageItem
            {
                Title = "Tiendas",
                IconSource = "cart.png",
                Name = "Tiendas",
                TargetType = typeof(TiendaListPage)
            });

            listView.ItemsSource = masterPageItems;
        }
    }
}
