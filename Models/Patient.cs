using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Clinica.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string? Names { get; set; }
        public string? LastName { get; set; }
        public DateOnly? DateBirth { get; set; }
        [Required(ErrorMessage = "El campo Email no puede ser nulo")]
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        [Required(ErrorMessage = "El campo state no puede ser nulo")]
        public string? State { get; set; }
        [JsonIgnore]
        public List<Quote>? Quotes { get; set; }
    }
}