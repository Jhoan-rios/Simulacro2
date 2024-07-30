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
    public class SpecialtyUpdateController : Controller
    {
        private readonly ISpecialtyRepository _specialtyRepository;
        public SpecialtyUpdateController(ISpecialtyRepository specialtyRepository)
        {
            _specialtyRepository = specialtyRepository;
        }

        [HttpPut]
        [Route("Specialty/{id}/Update")]
        public IActionResult Update([FromBody] Specialty specialty){
            _specialtyRepository.Update(specialty);
            return Ok();
        }
    }
}