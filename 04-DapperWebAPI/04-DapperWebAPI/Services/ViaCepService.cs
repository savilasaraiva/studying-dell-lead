using _04_DapperWebAPI.Models;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace _04_DapperWebAPI.Services
{
    public class ViaCepService
    {
        private readonly HttpClient _client;

        public ViaCepService(HttpClient client)
        {
            _client = client;
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }
        
        public async Task<CepAdress> GetAdress(string cep)
        {
            CepAdress adress = null;
            HttpResponseMessage response = await _client.GetAsync($"{cep}/json/");

            response.EnsureSuccessStatusCode();

            if (response.IsSuccessStatusCode)
            {
                //adress = JsonConvert.DeserializeObject<CepAdress>(await response.Content.ReadAsStringAsync());
                adress = JsonSerializer.Deserialize<CepAdress>(await response.Content.ReadAsStringAsync());
            }

            return adress;
        }
        
    }
}
