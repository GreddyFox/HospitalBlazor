using System.Net;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using rskpBlazor.Data.Models;
using rskpBlazor.Services;

namespace rskpBlazor.Services
{
    public class PatientsProvider : IPatientProvider

    {
        private HttpClient _client;
        public PatientsProvider(HttpClient client)
        {
            _client = client;
        }

        public async Task<List<Patient>> GetAll()
        {
            return await _client.GetFromJsonAsync<List<Patient>>("/api/patient");
        }

        public async Task<Patient> GetOne(int id)
        {
            return await _client.GetFromJsonAsync<Patient>($"/api/patient/{id}");
        }

        public async Task<bool> Add(Patient item)
        {
            string data = JsonConvert.SerializeObject(item);
            StringContent httpContent = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            var responce = await _client.PostAsync($"/api/patient", httpContent);
            return await Task.FromResult(responce.IsSuccessStatusCode);
        }

        public async Task<Patient> Edit(Patient item)
        {
            string data = JsonConvert.SerializeObject(item);
            StringContent httpContent = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            var responce = await _client.PutAsync($"/api/patient", httpContent);
            Patient patient = JsonConvert.DeserializeObject<Patient>(responce.Content.ReadAsStringAsync().Result);
            return await Task.FromResult(patient);
        }

        public async Task<bool> Remove(int id)
        {
            var delete = await _client.DeleteAsync($"/api/patient/{id}");

            return await Task.FromResult(delete.IsSuccessStatusCode);
        }

    }
}
