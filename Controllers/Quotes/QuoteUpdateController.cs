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
    public class QuoteUpdateController : Controller
    {
        private readonly IQuotesRepostory _quoteRepository;
        public QuoteUpdateController(IQuotesRepostory quoteRepository)
        {
            _quoteRepository = quoteRepository;
        }

        [HttpPut]
        [Route("Quotes/{id}/Update")]
        public IActionResult Update([FromBody] Quote quote){
            _quoteRepository.Update(quote);
            return Ok();
        }
    }
}