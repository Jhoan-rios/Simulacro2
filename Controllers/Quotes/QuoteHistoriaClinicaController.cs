using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Clinica.Models;
using Clinica.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Clinica.Controllers
{
    public class QuoteHistoriaClinicaController : Controller
    {
        private readonly IQuotesRepostory _quoteRepository;
        public QuoteHistoriaClinicaController(IQuotesRepostory quoteRepository)
        {
            _quoteRepository = quoteRepository;
        }

        [HttpGet]
        [Route("HistorialClinico/{id}")]
        public IEnumerable<Quote> GetHistoriaClinica(int id){
            return _quoteRepository.GetHistoriaClinica(id);
        }
    }
}