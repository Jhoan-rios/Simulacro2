using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Clinica.Services;

namespace Clinica.Controllers
{
    public class QuoteActivarController : Controller
    {
        private readonly IQuotesRepostory _quoteRepository;
        public QuoteActivarController(IQuotesRepostory quoteRepository)
        {
            _quoteRepository = quoteRepository;
        }

        [HttpPatch]
        [Route("Quotes/{id}/Active")]
        public IActionResult Activar(int id){
            try
            {
                _quoteRepository.Activar(id);
                return Ok(new { message = "Book marked as inactive" });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }
        }
    }
}