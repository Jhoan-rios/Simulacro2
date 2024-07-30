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
    public class QuoteGetInactivoController : Controller
    {
        private readonly IQuotesRepostory _quoteRepository;
        public QuoteGetInactivoController(IQuotesRepostory quoteRepository)
        {
            _quoteRepository = quoteRepository;
        }

        [HttpGet]
        [Route("QuotesInactivo")]
        public IEnumerable<Quote> GetQuotesInactivo(){
            return _quoteRepository.GetAllInactivo();
        }
    }
}