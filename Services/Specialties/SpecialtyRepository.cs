using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clinica.Services;
using Clinica.Data;
using Clinica.Models;

namespace Clinica.Services
{
    public class SpecialtyRepository : ISpecialtyRepository
    {
        private readonly ClinicaContext _context;
        public SpecialtyRepository(ClinicaContext context)
        {
            _context = context;
        }

        public void Activar(int id)
        {
            var specialty = _context.Specialties.Find(id);
            if (specialty != null)
            {
                specialty.State = "Activo";
                _context.Specialties.Attach(specialty);
                _context.Entry(specialty).Property(b => b.State).IsModified = true;
                _context.SaveChanges();
            }
            else
            {
                throw new KeyNotFoundException("Book not found");
            }
        }

        public void Add(Specialty specialty)
        {
            _context.Add(specialty);
            _context.SaveChanges();
        }

        public IEnumerable<Specialty> GetALL()
        {
            return _context.Specialties.Where(s => s.State=="Activo").ToList();
        }

        public IEnumerable<Specialty> GetAllInactivo()
        {
            return _context.Specialties.Where(s => s.State=="Inactivo").ToList();
        }

        public Specialty? GetById(int id)
        {
            return _context.Specialties.Where(s => s.State=="Activo").FirstOrDefault(c => c.Id == id);
        }

        public void Remove(int id)
        {
            var specialty = _context.Specialties.Find(id);
            if (specialty != null)
            {
                specialty.State = "Inactivo";
                _context.Specialties.Attach(specialty);
                _context.Entry(specialty).Property(b => b.State).IsModified = true;
                _context.SaveChanges();
            }
            else
            {
                throw new KeyNotFoundException("Book not found");
            }
        }

        public void Update(Specialty specialty)
        {
            var existingSpecialty = _context.Specialties.Find(specialty.Id);
            if (existingSpecialty != null)
            {
                existingSpecialty.Id = specialty.Id;
                existingSpecialty.Name = specialty.Name;
                existingSpecialty.Description = specialty.Description;
                existingSpecialty.State = specialty.State;
                
                _context.Specialties.Update(existingSpecialty);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Book not found");
            }
        }
    }
}