using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clinica.Data;
using Clinica.Models;

namespace Clinica.Services
{
    public class PatientRepository : IPatientRepository
    {
        private readonly ClinicaContext _context;
        public PatientRepository(ClinicaContext context)
        {
            _context = context;
        }

        public void Activar(int id)
        {
            var patient = _context.Patients.Find(id);
            if (patient != null)
            {
                patient.State = "Activo";
                _context.Patients.Attach(patient);
                _context.Entry(patient).Property(b => b.State).IsModified = true;
                _context.SaveChanges();
            }
            else
            {
                throw new KeyNotFoundException("Book not found");
            }
        }

        public void Add(Patient patient)
        {
            _context.Add(patient);
            _context.SaveChanges();
        }

        public IEnumerable<Patient> GetAll()
        {
            return _context.Patients.Where(s => s.State=="Activo").ToList();
        }

        public IEnumerable<Patient> GetAllInactivo()
        {
            return _context.Patients.Where(s => s.State=="Inactivo").ToList();
        }

        public Patient? GetById(int id)
        {
            return _context.Patients.Where(s => s.State=="Activo").FirstOrDefault(c => c.Id == id);
        }

        public void Remove(int id)
        {
            /* Aqui busco el id que quiero cambiar de estado */
            var patient = _context.Patients.Find(id);
            if (patient != null) /* Verifico que no sea nyll */
            {
                patient.State = "Inactivo"; /* Asigno el cambio de estado */
                _context.Patients.Attach(patient); /* Lo añado a la tabla Patients */
                _context.Entry(patient).Property(b => b.State).IsModified = true;
                _context.SaveChanges(); /* Guardo los cambios */
            }
            else
            {
                throw new KeyNotFoundException("Book not found");
            }
        }

        public void Update(Patient patient)
        {
            var existingPatient = _context.Patients.Find(patient.Id);
            if (existingPatient != null)
            {
                existingPatient.Id = patient.Id;
                existingPatient.Names = patient.Names;
                existingPatient.LastName = patient.LastName;
                existingPatient.DateBirth = patient.DateBirth;
                existingPatient.Email = patient.Email;
                existingPatient.Phone = patient.Phone;
                existingPatient.Address = patient.Address;
                existingPatient.State = patient.State;
                
                _context.Patients.Update(existingPatient);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Book not found");
            }
        }
    }
}