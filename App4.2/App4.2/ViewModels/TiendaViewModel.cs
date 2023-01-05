using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace App4._2.ViewModels
{
    public class TiendaViewModel : BindableObject
    {
        int idtienda; public int IdTienda { get { return idtienda; } set { idtienda = value; OnPropertyChanged("IdTienda"); } }
        string nombre; public string Nombre { get { return nombre; } set { nombre = value; OnPropertyChanged("Nombre"); } }
        string direccion; public string Direccion { get { return direccion; } set { direccion = value; OnPropertyChanged("Direccion"); } }
        string telefono; public string Telefono { get { return telefono; } set { telefono = value; OnPropertyChanged("Telefono"); } }
        double? latitud; public double? Latitud { get { return latitud; } set { latitud = value; OnPropertyChanged("Latitud"); } }
        double? longitud; public double? Longitud { get { return longitud; } set { longitud = value; OnPropertyChanged("Longitud"); } }

    }
}
