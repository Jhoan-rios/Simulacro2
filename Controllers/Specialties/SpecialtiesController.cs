using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Clinica.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Clinica.Services;

namespace Clinica.Controllers
{
    public class SpecialtiesController : Controller
    {
        private readonly ISpecialtyRepository _specialtyRepository;
        public SpecialtiesController(ISpecialtyRepository specialtyRepository)
        {
            _specialtyRepository = specialtyRepository;
        }

        [HttpGet]
        [Route("Specialties")]
        public IEnumerable<Specialty> GetSpecialties(){
            return _specialtyRepository.GetALL();
        }
    }
}