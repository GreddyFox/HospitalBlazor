using rskpBlazor.Data.Models;
namespace rskpBlazor.Services
{
    public interface IMedicalFileProvider
    {
        Task<List<MedicalFile>> GetAll();
        Task<MedicalFile> GetOne(int id);
        Task<bool> Add(MedicalFile item);
        Task<MedicalFile> Edit(MedicalFile item);
        Task<bool> Remove(int id);
    }
}
