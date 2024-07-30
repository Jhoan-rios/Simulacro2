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
    public class PatientsController : Controller
    {
        private readonly IPatientRepository _patientRepository;
        public PatientsController(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        [HttpGet]
        [Route("Patients")]
        public IEnumerable<Patient> GetPatients(){
            return _patientRepository.GetAll();
        }
    }
}