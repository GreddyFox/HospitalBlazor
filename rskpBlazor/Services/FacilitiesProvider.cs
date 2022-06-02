using System.Net;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using rskpBlazor.Data.Models;
using rskpBlazor.Services;

namespace rskpBlazor.Services
{
    public class FacilitiesProvider : IFacilityProvider
    {
        private HttpClient _client;
        public FacilitiesProvider(HttpClient client)
        {
            _client = client;
        }

        public async Task<List<Facility>> GetAll()
        {
            return await _client.GetFromJsonAsync<List<Facility>>("/api/facility");
        }

        public async Task<Facility> GetOne(int id) { 
            return await _client.GetFromJsonAsync<Facility>($"/api/facility/{id}");
        }

        public async Task<bool> Add(Facility item)
        {
            string data = JsonConvert.SerializeObject(item);
            StringContent httpContent = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            var responce = await _client.PostAsync($"/api/facility", httpContent);
            return await Task.FromResult(responce.IsSuccessStatusCode);
        }

        public async Task<Facility> Edit(Facility item)
        {
            string data = JsonConvert.SerializeObject(item);
            StringContent httpContent = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            var responce = await _client.PutAsync($"/api/facility", httpContent);
            Facility facility = JsonConvert.DeserializeObject<Facility>(responce.Content.ReadAsStringAsync().Result);
            return await Task.FromResult(facility);
        }

        public async Task<bool> Remove(int id)
        {
            var delete = await _client.DeleteAsync($"/api/facility/{id}");

            return await Task.FromResult(delete.IsSuccessStatusCode);
        }

    }
}

