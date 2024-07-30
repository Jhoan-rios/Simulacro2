using System.Text.Json.Serialization;

namespace Clinica.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? State { get; set; }
        public int? SpecialtiesId { get; set; }
        public Specialty? Specialties { get; set; }
        [JsonIgnore]
        public List<Quote>? Quotes { get; set; }
    }
}