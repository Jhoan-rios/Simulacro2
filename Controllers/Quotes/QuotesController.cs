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
    public class QuotesController : Controller
    {
        private readonly IQuotesRepostory _quoteRepository;
        public QuotesController(IQuotesRepostory quoteRepository)
        {
            _quoteRepository = quoteRepository;
        }

        [HttpGet]
        [Route("Quotes")]
        public IEnumerable<Quote> GetQuotes(){
            return _quoteRepository.GetAll();
        }
    }
}