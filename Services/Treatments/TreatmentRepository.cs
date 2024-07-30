using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clinica.Data;
using Clinica.Models;
using Microsoft.EntityFrameworkCore;

namespace Clinica.Services
{
    public class TreatmentRepository : ITreatmentRepository
    {
        private readonly ClinicaContext _context;
        public TreatmentRepository(ClinicaContext context)
        {
            _context = context;
        }

        public void Add(Treatment treatment)
        {
            _context.Add(treatment);
            _context.SaveChanges();
        }

        public IEnumerable<Treatment> GetAll()
        {
            return _context.Treatments.Where(s => s.State=="Activo").Include(c => c.Quotes).Include(c => c.Quotes.Patients).Include(c => c.Quotes.Doctors).ToList();
        }

        public IEnumerable<Treatment> GetAllInactivo()
        {
            return _context.Treatments.Where(s => s.State=="Inativo").Include(c => c.Quotes).Include(c => c.Quotes.Patients).Include(c => c.Quotes.Doctors).ToList();
        }

        public Treatment? GetById(int id)
        {
            return _context.Treatments.Where(s => s.State=="Activo").Include(c => c.Quotes).Include(c => c.Quotes.Patients).Include(c => c.Quotes.Doctors).FirstOrDefault(s => s.Id == id);
        }

        public void Remove(int id)
        {
            var treatment = _context.Treatments.Find(id);
            _context.Treatments.Remove(treatment);
            _context.SaveChanges();
            
        }

        public void Update(Treatment treatment)
        {
            var existingTreatment = _context.Treatments.Find(treatment.Id);
            if (existingTreatment != null)
            {
                existingTreatment.Id = treatment.Id;
                existingTreatment.Description = treatment.Description;
                existingTreatment.State = treatment.State;
                existingTreatment.QuoteId = treatment.QuoteId;
                
                _context.Treatments.Update(existingTreatment);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Book not found");
            }
        }
    }
}