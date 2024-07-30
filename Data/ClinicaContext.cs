using Clinica.Models;
using Microsoft.EntityFrameworkCore;

namespace Clinica.Data
{
    public class ClinicaContext(DbContextOptions<ClinicaContext> options) : DbContext(options)
    {
        
        public DbSet<Quote> Quotes { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Specialty> Specialties { get; set; }
        public DbSet<Treatment> Treatments { get; set; }

    }
}