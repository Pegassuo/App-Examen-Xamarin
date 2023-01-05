using App4_2.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace App4_2.Services
{
    public class Service
    {
        HttpClient client;

        string url = "http://zeus.apolosoftware.com.ec/Test/";
        public Service()
        {
            HttpClientHandler insecureHandler = GetInsecureHandler();
            client = new HttpClient(insecureHandler); 
        }

        public HttpClientHandler GetInsecureHandler()
        {
            HttpClientHandler handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) =>
            {
                if (cert.Issuer.Equals("CN=localhost"))
                    return true;
                return errors == System.Net.Security.SslPolicyErrors.None;
            };
            return handler;
        }

        public async Task<List<Tienda>> TiendaQueryAsync()
        {
            Uri uri = new Uri(url + "api/Tienda/Query");

            HttpResponseMessage response = await client.GetAsync(uri);

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();

                var options = new JsonSerializerOptions { WriteIndented = true };

                return JsonSerializer.Deserialize<List<Tienda>>(content, options);
            }

            return new List<Tienda>();
        }

        public async Task<Tienda> TiendaGetAsync(int IdTienda)
        {
            Uri uri = new Uri(url + "api/Tienda/Get?IdTienda=" + IdTienda);
            HttpResponseMessage response = await client.GetAsync(uri);

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();

                var options = new JsonSerializerOptions { WriteIndented = true };

                return JsonSerializer.Deserialize<Tienda>(content, options);
            }

            return null;
        }

        public async Task<bool> TiendaInsertAsync(Tienda model)
        {
            Uri uri = new Uri(url + "api/Tienda/Insert");

            string json = JsonSerializer.Serialize(model);

            StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync(uri, httpContent);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }

        public async Task<bool> TiendaUpdateAsync(Tienda model)
        {
            Uri uri = new Uri(url + "api/Tienda/Update");

            string json = JsonSerializer.Serialize(model);

            StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync(uri, httpContent);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }

        public async Task<bool> TiendaDeleteAsync(Tienda model)
        {
            Uri uri = new Uri(url + "api/Tienda/Delete");

            string json = JsonSerializer.Serialize(model);

            StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync(uri, httpContent);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }
    }
}
