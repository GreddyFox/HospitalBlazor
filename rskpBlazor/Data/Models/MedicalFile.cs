using rskpBlazor.Data.Models;
namespace rskpBlazor.Data.Models
{
    public class MedicalFile
    {
        public int Id { get; set; }
        public Patient Patient { get; set; }
        public DateTime StartDate { get; set; }
    }
}
