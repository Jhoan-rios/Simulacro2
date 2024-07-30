using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clinica.Models;
using Microsoft.AspNetCore.Mvc;

namespace Clinica.Services
{
    public interface IQuotesRepostory
    {
        IEnumerable<Quote> GetAll();
        IEnumerable<Quote> GetAllInactivo();
        IEnumerable<Quote> GetQuotePatient(int id);
        IEnumerable<Quote> GetAllByDay(string day);
        IEnumerable<Quote> GetAllByDoctor(int id, string day);
        IEnumerable<Quote> GetHistoriaClinica(int id);
        IEnumerable<Quote> GetPatientByDoctor(int id);
        Quote? GetById(int id);
        /* Task<Quote> Create(Quote quote); */
        void Remove(int id);
        void Activar(int id);
        void Update(Quote quote);
    }
}