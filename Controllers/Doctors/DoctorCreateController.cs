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
    public class DoctorCreateController : Controller
    {
        private readonly IDoctorRepository _doctorRepository;
        public DoctorCreateController(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        [HttpPost]
        [Route("Doctor/Create")]
        public IActionResult Create([FromBody] Doctor doctor)
        {
            _doctorRepository.Add(doctor);
            return Ok();
        }
    }
}