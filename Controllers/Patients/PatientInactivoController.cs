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
    public class PatientInactivoController : Controller
    {
        private readonly IPatientRepository _patientRepository;
        public PatientInactivoController(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        [HttpGet]
        [Route("PatientsInactivo")]
        public IEnumerable<Patient> GetPatietsInactivo(){
            return _patientRepository.GetAllInactivo();
        }
    }
}