using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clinica.Data;
using Clinica.Models;
using Clinica.Services;
using Microsoft.EntityFrameworkCore;

namespace Clinica.Services
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly ClinicaContext _context;
        public DoctorRepository(ClinicaContext context)
        {
            _context = context;
        }

        public void Activar(int id)
        {
            var doctor = _context.Doctors.Find(id);
            if (doctor != null)
            {
                doctor.State = "Activo";
                _context.Doctors.Attach(doctor);
                _context.Entry(doctor).Property(b => b.State).IsModified = true;
                _context.SaveChanges();
            }
            else
            {
                throw new KeyNotFoundException("Book not found");
            }
        }

        public void Add(Doctor doctor)
        {
            _context.Add(doctor);
            _context.SaveChanges();
        }

        public IEnumerable<Doctor> GetAll()
        {
            return _context.Doctors.Where(s => s.State=="Activo").Include(c => c.Specialties).ToList();
        }

        public IEnumerable<Doctor> GetAllInactivo()
        {
            return _context.Doctors.Where(s => s.State=="Inactivo").Include(c => c.Specialties).ToList();
        }

        public Doctor? GetById(int id)
        {
            return _context.Doctors.Include(a => a.Specialties).FirstOrDefault(c => c.Id == id);
        }

        public void Remove(int id)
        {
            var doctor = _context.Doctors.Find(id);
            if (doctor != null)
            {
                doctor.State = "Inactivo";
                _context.Doctors.Attach(doctor);
                _context.Entry(doctor).Property(b => b.State).IsModified = true;
                _context.SaveChanges();
            }
            else
            {
                throw new KeyNotFoundException("Book not found");
            }
        }

        public void Update(Doctor doctor)
        {
            var existingDoctor = _context.Doctors.Find(doctor.Id);
            if (existingDoctor != null)
            {
                existingDoctor.Id = doctor.Id;
                existingDoctor.FullName = doctor.FullName;
                existingDoctor.Email = doctor.Email;
                existingDoctor.Phone = doctor.Phone;
                existingDoctor.State = doctor.State;
                existingDoctor.SpecialtiesId = doctor.SpecialtiesId;
                
                _context.Doctors.Update(existingDoctor);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Book not found");
            }
        }
    }
}