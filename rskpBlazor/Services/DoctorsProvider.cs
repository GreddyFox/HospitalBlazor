using System.Net;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using rskpBlazor.Data.Models;
using rskpBlazor.Services;

namespace rskpBlazor.Services
{
    public class DoctorsProvider : IDoctorProvider

    {
        private HttpClient _client;
        public DoctorsProvider(HttpClient client)
        {
            _client = client;
        }

        public async Task<List<Doctor>> GetAll()
        {
            return await _client.GetFromJsonAsync<List<Doctor>>("/api/doctor");
        }

        public async Task<Doctor> GetOne(int id)
        {
            return await _client.GetFromJsonAsync<Doctor>($"/api/doctor/{id}");
        }

        public async Task<bool> Add(Doctor item)
        {
            string data = JsonConvert.SerializeObject(item);
            StringContent httpContent = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            var responce = await _client.PostAsync($"/api/doctor", httpContent);
            return await Task.FromResult(responce.IsSuccessStatusCode);
        }

        public async Task<Doctor> Edit(Doctor item)
        {
            string data = JsonConvert.SerializeObject(item);
            StringContent httpContent = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            var responce = await _client.PutAsync($"/api/doctor", httpContent);
            Doctor doctor = JsonConvert.DeserializeObject<Doctor>(responce.Content.ReadAsStringAsync().Result);
            return await Task.FromResult(doctor);
        }

        public async Task<bool> Remove(int id)
        {
            var delete = await _client.DeleteAsync($"/api/doctor/{id}");

            return await Task.FromResult(delete.IsSuccessStatusCode);
        }

    }
}
