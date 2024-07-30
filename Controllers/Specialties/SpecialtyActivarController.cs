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
    public class SpecialtyActivarController : Controller
    {
        private readonly ISpecialtyRepository _specialtyRepository;
        public SpecialtyActivarController(ISpecialtyRepository specialtyRepository)
        {
            _specialtyRepository = specialtyRepository;
        }

        [HttpPatch]
        [Route("Specialty/{id}/Active/")]
        public IActionResult Activar(int id){
            try
            {
                _specialtyRepository.Activar(id);
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