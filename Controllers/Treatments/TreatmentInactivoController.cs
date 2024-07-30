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
    public class TreatmentInactivoController : Controller
    {
        private readonly ITreatmentRepository _treatmentRepository;
        public TreatmentInactivoController(ITreatmentRepository treatmentRepository)
        {
            _treatmentRepository = treatmentRepository;
        }

        [HttpGet]
        [Route("TreatmentsInactivo")]
        public IEnumerable<Treatment> GetTreatmentsInactivo(){
            return _treatmentRepository.GetAllInactivo();
        }
    }
}