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
    public class DoctorGetByIdController : Controller
    {
        private readonly IDoctorRepository _doctorRepository;
        public DoctorGetByIdController(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        [HttpGet]
        [Route("Doctor/{id}")]
        public ActionResult<Doctor> Details(int id){
            var doctor = _doctorRepository.GetById(id);
            if(doctor == null)
            {
                return NotFound();
            }
            return Ok(doctor);
        }
    }
}