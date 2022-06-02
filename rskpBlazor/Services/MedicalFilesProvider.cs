using System.Net;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using rskpBlazor.Data.Models;
using rskpBlazor.Services;

namespace rskpBlazor.Services
{
    public class MedicalFilesProvider : IMedicalFileProvider
    {
    
            private HttpClient _client;
            public MedicalFilesProvider(HttpClient client)
            {
                _client = client;
            }

            public async Task<List<MedicalFile>> GetAll()
            {
                return await _client.GetFromJsonAsync<List<MedicalFile>>("/api/medicalFile");
            }

            public async Task<MedicalFile> GetOne(int id)
            {
                return await _client.GetFromJsonAsync<MedicalFile>($"/api/medicalFile/{id}");
            }

            public async Task<bool> Add(MedicalFile item)
            {
                string data = JsonConvert.SerializeObject(item);
                StringContent httpContent = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
                var responce = await _client.PostAsync($"/api/medicalFile", httpContent);
                return await Task.FromResult(responce.IsSuccessStatusCode);
            }

            public async Task<MedicalFile> Edit(MedicalFile item)
            {
                string data = JsonConvert.SerializeObject(item);
                StringContent httpContent = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
                var responce = await _client.PutAsync($"/api/patient", httpContent);
            MedicalFile medicalFile = JsonConvert.DeserializeObject<MedicalFile>(responce.Content.ReadAsStringAsync().Result);
                return await Task.FromResult(medicalFile);
            }

            public async Task<bool> Remove(int id)
            {
                var delete = await _client.DeleteAsync($"/api/medicalFile/{id}");

                return await Task.FromResult(delete.IsSuccessStatusCode);
            }

        }
  
}
