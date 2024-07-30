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
    public class QuoteByPatientController : Controller
    {
        private readonly IQuotesRepostory _quoteRepository;
        public QuoteByPatientController(IQuotesRepostory quoteRepository)
        {
            _quoteRepository = quoteRepository;
        }

        [HttpGet]
        [Route("QuoteByPatient/{id}")]
        public IEnumerable<Quote> GetQuotePatient(int id){
            return _quoteRepository.GetQuotePatient(id);
        }
    }
}