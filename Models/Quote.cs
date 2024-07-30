using System.Text.Json.Serialization;

namespace Clinica.Models
{
    public class Quote
    {
        public int Id { get; set; } 
        public DateTime DateQuote { get; set; }
        public string? State { get; set; }
        public int DoctorId { get; set; }
        public Doctor? Doctors { get; set; }
        public int PatientId { get; set; }
        public Patient? Patients { get; set; }
        [JsonIgnore]
        public List<Treatment>? Treatments { get; set; }
    }
}