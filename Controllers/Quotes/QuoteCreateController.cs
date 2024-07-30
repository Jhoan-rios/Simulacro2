using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clinica.Models;
using Clinica.Services;
using Microsoft.AspNetCore.Mvc;

namespace Clinica.Controllers
{
    public class QuoteCreateController : Controller
    {
        private readonly IQuotesRepostory _quoteRepository;
        public QuoteCreateController(IQuotesRepostory quoteRepository)
        {
            _quoteRepository = quoteRepository;
        }
        
        /* [HttpPost]
        [Route("Quotes/Create")]
        public IActionResult Create([FromBody] Quote quote)
        {
            _quoteRepository.Add(quote);
            return Ok();
        } */
    }
}