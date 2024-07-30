namespace Clinica.Models
{
    public class Treatment
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public string? State { get; set; }
        public int QuoteId { get; set; }
        public Quote? Quotes { get; set; }
    }
}