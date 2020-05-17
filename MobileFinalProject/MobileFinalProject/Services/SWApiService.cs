using MobileFinalProject.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MobileFinalProject.Services
{
    class SWApiService
    {
        private HttpClient httpClient;
        string baseUrl = "https://swapi.dev/api/";

        public SWApiService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
            this.httpClient.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<List<ShipModel>> GetShips(string path)
        {
            var response = await this.httpClient.GetAsync(this.baseUrl + path);
            response.EnsureSuccessStatusCode();
            var resp = await response.Content.ReadAsStringAsync();
            SwJsonResponse swJsonResponse = JsonConvert.DeserializeObject<SwJsonResponse>(resp);
            return swJsonResponse.results;
        }

        
    }
}
