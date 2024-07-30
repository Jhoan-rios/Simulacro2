using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Clinica.Services;
using Clinica.Models;

namespace Clinica.Controllers
{
    public class SpecialtyCreateController : Controller
    {
        private readonly ISpecialtyRepository _specialtyRepository;
        public SpecialtyCreateController(ISpecialtyRepository specialtyRepository)
        {
            _specialtyRepository = specialtyRepository;
        }

        [HttpPost]
        [Route("Specialty/Create")]
        public IActionResult Create([FromBody] Specialty specialty)
        {
            _specialtyRepository.Add(specialty);
            return Ok();
        }
    }
}