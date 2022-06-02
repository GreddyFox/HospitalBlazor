using rskpBlazor.Data.Models;
namespace rskpBlazor.Data.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public Patient AppPatient { get; set; }
        public Doctor AppDoc { get; set; }
        public Facility Facility { get; set; }
    }
}
