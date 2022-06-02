using rskpBlazor.Data.Models;
namespace rskpBlazor.Services
{
    public interface IDoctorProvider
    {
        Task<List<Doctor>> GetAll();
        Task<Doctor> GetOne(int id);
        Task<bool> Add(Doctor item);
        Task<Doctor> Edit(Doctor item);
        Task<bool> Remove(int id);

    }
}
