using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Clinica.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Clinica.Controllers
{
    public class QuoteDeleteController : Controller
    {
        private readonly IQuotesRepostory _quoteRepository;
        public QuoteDeleteController(IQuotesRepostory quoteRepository)
        {
            _quoteRepository = quoteRepository;
        }

        [HttpDelete]
        [Route("Quotes/{id}/Delete")]
        public IActionResult Remove(int id){
            try
            {
                _quoteRepository.Remove(id);
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