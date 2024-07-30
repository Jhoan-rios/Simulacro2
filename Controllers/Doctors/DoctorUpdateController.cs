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
    public class DoctorUpdateController : Controller
    {
        private readonly IDoctorRepository _doctorRepository;
        public DoctorUpdateController(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        [HttpPut]
        [Route("Doctor/{id}/Update")]
        public IActionResult Update([FromBody] Doctor doctor){
            _doctorRepository.Update(doctor);
            return Ok();
        }
    }
}