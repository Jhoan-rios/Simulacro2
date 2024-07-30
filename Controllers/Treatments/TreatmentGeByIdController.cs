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
    public class TreatmentGeByIdController : Controller
    {
        private readonly ITreatmentRepository _treatmentRepository;
        public TreatmentGeByIdController(ITreatmentRepository treatmentRepository)
        {
            _treatmentRepository = treatmentRepository;
        }

        
        [HttpGet]
        [Route("Treatments/{id}")]
        public ActionResult<Treatment> Details(int id){
            var treatment = _treatmentRepository.GetById(id);
            if(treatment == null)
            {
                return NotFound();
            }
            return Ok(treatment);
        }
    }
}