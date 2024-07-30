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
    public class TreatmentUpdateController : Controller
    {
        private readonly ITreatmentRepository _treatmentRepository;
        public TreatmentUpdateController(ITreatmentRepository treatmentRepository)
        {
            _treatmentRepository = treatmentRepository;
        }

        [HttpPut]
        [Route("Treatment/{id}/Update")]
        public IActionResult Update([FromBody] Treatment treatment){
            _treatmentRepository.Update(treatment);
            return Ok();
        }
    }
}