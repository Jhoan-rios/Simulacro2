using System.Text.Json.Serialization;

namespace Clinica.Models
{
    public class Specialty
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? State { get; set; }
        [JsonIgnore]
        public List<Doctor>? Doctors { get; set; }
    }
}