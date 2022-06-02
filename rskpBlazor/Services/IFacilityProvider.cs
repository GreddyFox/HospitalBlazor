using rskpBlazor.Data.Models;
namespace rskpBlazor.Services
{
    public interface IFacilityProvider
    {
        Task<List<Facility>> GetAll();
        Task<Facility> GetOne(int id);
        Task<bool> Add(Facility item);
        Task<Facility> Edit(Facility item);
        Task<bool> Remove(int id);
    }
}
