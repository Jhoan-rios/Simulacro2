using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Clinica.Services
{
    public class SpecialtyDeleteController : Controller
    {
        private readonly ISpecialtyRepository _specialtyRepository;
        public SpecialtyDeleteController(ISpecialtyRepository specialtyRepository)
        {
            _specialtyRepository = specialtyRepository;
        }

        [HttpDelete]
        [Route("Specialty/{id}/Delete")]
        public IActionResult Remove(int id){
            try
            {
                _specialtyRepository.Remove(id);
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