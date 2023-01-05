using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Forms;

namespace App4_2.Models
{
    public class Tienda
    {
        public int IdTienda { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public double? Latitud { get; set; }
        public double? Longitud { get; set; }
    
    }
}
