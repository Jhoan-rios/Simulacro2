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
    public class TreatmentCreateController : Controller
    {
        private readonly ITreatmentRepository _treatmentRepository;
        public TreatmentCreateController(ITreatmentRepository treatmentRepository)
        {
            _treatmentRepository = treatmentRepository;
        }

        [HttpPost]
        [Route("Treatment/Create")]
        public IActionResult Create([FromBody] Treatment treatment)
        {
            _treatmentRepository.Add(treatment);
            return Ok();
        }
    }
}