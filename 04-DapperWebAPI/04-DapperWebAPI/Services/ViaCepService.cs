using _04_DapperWebAPI.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace _04_DapperWebAPI.Services
{
    public class ViaCepService
    {
        static HttpClient client = new HttpClient();

        public ViaCepService()
        {
            client.BaseAddress = new Uri("https://viacep.com.br/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }
        
        public async Task<IEnumerable<CepAdress>> GetAdress(string cep)
        {
            IEnumerable<CepAdress> adress = null;
            HttpResponseMessage response = await client.GetAsync("ws/{cep}/json/");
            if (response.IsSuccessStatusCode)
            {                
                adress = await JsonSerializer.DeserializeAsync<IEnumerable<CepAdress>>(await response.Content.ReadAsStreamAsync());
            }
            return adress;
        }
        
    }
}
