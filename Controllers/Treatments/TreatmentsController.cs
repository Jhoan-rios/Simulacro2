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
    public class TreatmentsController : Controller
    {
        private readonly ITreatmentRepository _treatmentRepository;
        public TreatmentsController(ITreatmentRepository treatmentRepository)
        {
            _treatmentRepository = treatmentRepository;
        }

        [HttpGet]
        [Route("Treatments")]
        public IEnumerable<Treatment> GetTreatments(){
            return _treatmentRepository.GetAll();
        }
    }
}