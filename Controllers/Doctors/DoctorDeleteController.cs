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
    public class BookDeleteController : Controller
    {
        private readonly IDoctorRepository _doctorRepository;
        public BookDeleteController(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        [HttpDelete]
        [Route("Doctor/{id}/Delete")]
        public IActionResult Remove(int id){
            try
            {
                _doctorRepository.Remove(id);
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