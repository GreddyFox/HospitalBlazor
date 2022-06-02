using System.Net;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using rskpBlazor.Data.Models;
using rskpBlazor.Services;

namespace rskpBlazor.Services
{
    public class AppointmentsProvider : IAppointmentProvider

    {
        private HttpClient _client;
        public AppointmentsProvider(HttpClient client)
        {
            _client = client;
        }

        public async Task<List<Appointment>> GetAll()
        {
            return await _client.GetFromJsonAsync<List<Appointment>>("/api/appointment");
        }

        public async Task<Appointment> GetOne(int id)
        {
            return await _client.GetFromJsonAsync<Appointment>($"/api/appointment/{id}");
        }

        public async Task<bool> Add(Appointment item)
        {
            string data = JsonConvert.SerializeObject(item);
            StringContent httpContent = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            var responce = await _client.PostAsync($"/api/appointment", httpContent);
            return await Task.FromResult(responce.IsSuccessStatusCode);
        }

        public async Task<Appointment> Edit(Appointment item)
        {
            string data = JsonConvert.SerializeObject(item);
            StringContent httpContent = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            var responce = await _client.PutAsync($"/api/appointment", httpContent);
            Appointment appointment = JsonConvert.DeserializeObject<Appointment>(responce.Content.ReadAsStringAsync().Result);
            return await Task.FromResult(appointment);
        }

        public async Task<bool> Remove(int id)
        {
            var delete = await _client.DeleteAsync($"/api/appointment/{id}");

            return await Task.FromResult(delete.IsSuccessStatusCode);
        }

    }
}
