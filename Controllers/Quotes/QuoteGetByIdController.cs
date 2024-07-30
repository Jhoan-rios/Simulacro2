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
    public class QuoteGetByIdController : Controller
    {
        private readonly IQuotesRepostory _quoteRepository;
        public QuoteGetByIdController(IQuotesRepostory quoteRepository)
        {
            _quoteRepository = quoteRepository;
        }

        [HttpGet]
        [Route("Quotes/{id}")]
        public ActionResult<Quote> Details(int id){
            var quote = _quoteRepository.GetById(id);
            if(quote == null)
            {
                return NotFound();
            }
            return Ok(quote);
        }
    }
}