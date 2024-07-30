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
    public class PatientGetByIdController : Controller
    {
        private readonly IPatientRepository _patientRepository;
        public PatientGetByIdController(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        [HttpGet]
        [Route("Patients/{id}")]
        public ActionResult<Patient> Details(int id){
            var patient = _patientRepository.GetById(id);
            if(patient == null)
            {
                return NotFound();
            }
            return Ok(patient);
        }
    }
}