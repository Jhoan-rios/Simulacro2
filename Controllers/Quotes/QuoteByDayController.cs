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
    public class QuoteByDayController : Controller
    {
        private readonly IQuotesRepostory _quoteRepository;
        public QuoteByDayController(IQuotesRepostory quoteRepository)
        {
            _quoteRepository = quoteRepository;
        }

        [HttpGet]
        [Route("QuoteByDay/{day}")]
        public IEnumerable<Quote> GetAllByDay(string day){
            return _quoteRepository.GetAllByDay(day);
        }
    }
}