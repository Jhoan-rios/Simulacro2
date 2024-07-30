using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Clinica.Services
{
    public class PatientDeleteController : Controller
    {
        private readonly IPatientRepository _patientRepository;
        public PatientDeleteController(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        [HttpDelete]
        [Route("Patients/{id}/Delete")]
        public IActionResult Remove(int id){
            try
            {
                _patientRepository.Remove(id);
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