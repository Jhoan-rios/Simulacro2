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
    public class PatientCreateController : Controller
    {
        private readonly IPatientRepository _patientRepository;
        public PatientCreateController(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        [HttpPost]
        [Route("Patients/Create")]
        public IActionResult Create([FromBody] Patient patient)
        {
            _patientRepository.Add(patient);
            return Ok();
        }
    }
}