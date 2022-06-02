using rskpBlazor.Data.Models;
namespace rskpBlazor.Services
{
    public interface IPatientProvider
    {
        Task<List<Patient>> GetAll();
        Task<Patient> GetOne(int id);
        Task<bool> Add(Patient item);
        Task<Patient> Edit(Patient item);
        Task<bool> Remove(int id);
    }
}
