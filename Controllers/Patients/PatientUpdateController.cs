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
    public class PatientUpdateController : Controller
    {
        private readonly IPatientRepository _patientRepository;
        public PatientUpdateController(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        [HttpPut]
        [Route("Patients/{id}/Update")]
        public IActionResult Update([FromBody] Patient patient){
            _patientRepository.Update(patient);
            return Ok();
        }
    }
}