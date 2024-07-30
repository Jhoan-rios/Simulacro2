using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clinica.Data;
using Clinica.Models;
using Clinica.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Clinica.Services
{
    public class QuotesRepository : IQuotesRepostory
    {
        private readonly ClinicaContext _context;
        private readonly EmailsRepository _emailRepository;
        private readonly IDoctorRepository _doctorRepository;
        private readonly IPatientRepository _patientRepository;

        public QuotesRepository(ClinicaContext context, EmailsRepository emailsRepository, IDoctorRepository doctorRepository, IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
            _doctorRepository = doctorRepository;
            _emailRepository = emailsRepository;
            _context = context;
        }

        public void Activar(int id)
        {
            var quote = _context.Quotes.Find(id);
            if (quote != null)
            {
                quote.State = "Activo";
                _context.Quotes.Attach(quote);
                _context.Entry(quote).Property(b => b.State).IsModified = true;
                _context.SaveChanges();
            }
            else
            {
                throw new KeyNotFoundException("Book not found");
            }
        }

        /* public async Task<Quote> Create(Quote quote)
        {
            var id = _context.Quotes.Find(quote.Id);
            if(id!= null){
                return null;
            }

            _context.Quotes.Add(quote);
            await _context.SaveChangesAsync();

            //Get the pet's owner email
            var pet = await _patientRepository.GetPetOwner(quote.PetId);
            if(pet ==  null){
                throw new Exception("Could not find the owner");
            }
            var patient = await _patientRepository.GetOwnerEmail(pet);

            //Send the email to the owner with the confirmation quote
            var from = "trial-3vz9dle7w074kj50.mlsender.net";
            var fromName ="";
            var to = new List<string>{o.Email};
            var toName = new List<string>{owner.Names};
            var subject = "New Quote";
            var text =$"Hi {owner.Names}, your quote has been confirm for {quote.Date}";
            var html = $"<p>Hi {owner.Names},</p><br/><p>your quote has been confirm for{quote.Date}</p>";

            await _emailsServices.SendEmailAsync(from, fromName, to, toName, subject, text, html);
        } */

        public IEnumerable<Quote> GetAll()
        {
            return _context.Quotes.Where(s => s.State=="Activo").Include(c => c.Patients).Include(c => c.Doctors).Include(c => c.Doctors.Specialties).ToList();
        }

        public IEnumerable<Quote> GetAllByDay(string day)
        { 
            DateTime date = DateTime.Parse(day);
            yield return _context.Quotes.Where(s => s.State == "Activo").Include(c => c.Patients).Include(c => c.Doctors).Include(c => c.Doctors.Specialties).FirstOrDefault(s => s.DateQuote == date);
        }

        public IEnumerable<Quote> GetAllByDoctor(int id, string day)
        {
            DateTime date = DateTime.Parse(day);
            yield return _context.Quotes.Where(s => s.State == "Activo").Include(c => c.Patients).Include(c => c.Doctors).Include(c => c.Doctors.Specialties).FirstOrDefault(c => c.Id == id && c.DateQuote == date);
        }

        public IEnumerable<Quote> GetAllInactivo()
        {
            return _context.Quotes.Where(s => s.State=="Inactivo").Include(c => c.Patients).Include(c => c.Doctors).ToList();
        }

        public IEnumerable<Quote> GetQuotePatient(int id)
        {
            return _context.Quotes.Where(s => s.State=="Activo").Where(c => c.PatientId == id).ToList();
        }

        public Quote? GetById(int id)
        {
            return _context.Quotes.Where(s => s.State=="Activo").Include(c => c.Patients).Include(c => c.Doctors).FirstOrDefault(s => s.Id == id);
        }

        public IEnumerable<Quote> GetHistoriaClinica(int id)
        {
            var quotes = _context.Quotes.Where(s => s.State=="Activo" && s.PatientId == id).Include(c => c.Patients).Include(s => s.Doctors).ThenInclude(s => s.Specialties).ToList();
            var quoteIds = quotes.Select(q => q.Id).ToList();

            var treatments = _context.Treatments
                .Where(t => quoteIds.Contains(t.QuoteId))
                .ToList();

            // Asignar tratamientos a cada cita
            foreach (var quote in quotes)
            {
                quote.Treatments = treatments.Where(t => t.QuoteId == quote.Id).ToList();
            }
            return quotes;
        }

        public void Remove(int id)
        {
            var quote = _context.Quotes.Find(id);
            if (quote != null)
            {
                quote.State = "Inactivo";
                _context.Quotes.Attach(quote);
                _context.Entry(quote).Property(b => b.State).IsModified = true;
                _context.SaveChanges();
            }
            else
            {
                throw new KeyNotFoundException("Book not found");
            }
        }

        public void Update(Quote quote)
        {
            var existingQuote = _context.Quotes.Find(quote.Id);
            if (existingQuote != null)
            {
                existingQuote.Id = quote.Id;
                existingQuote.DateQuote = quote.DateQuote;
                existingQuote.State = quote.State;
                existingQuote.DoctorId = quote.DoctorId;
                existingQuote.PatientId = quote.PatientId;
                
                _context.Quotes.Update(existingQuote);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Book not found");
            }
        }
    

        public IEnumerable<Quote> GetPatientByDoctor(int id)
        {
            return _context.Quotes
                .Where(s => s.State == "Activo" && s.DoctorId == id)
                .Include(s => s.Doctors)
                .Include(s => s.Patients)
                .ToList();
        }
    }
}