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
    public class DoctorInactivoController : Controller
    {
        private readonly IDoctorRepository _doctorRepository;
        public DoctorInactivoController(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        [HttpGet]
        [Route("DoctorInactivo")]
        public IEnumerable<Doctor> GetDoctorsInactivo(){
            return _doctorRepository.GetAllInactivo();
        }
    }
}