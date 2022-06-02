using rskpBlazor.Data.Models;
namespace rskpBlazor.Services
{
    public interface IAppointmentProvider
    {
        Task<List<Appointment>> GetAll();
        Task<Appointment> GetOne(int id);
        Task<bool> Add(Appointment item);
        Task<Appointment> Edit(Appointment item);
        Task<bool> Remove(int id);
    }
}
