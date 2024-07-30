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
    public class SpecialtyGetByIdController : Controller
    {
        private readonly ISpecialtyRepository _specialtyRepository;
        public SpecialtyGetByIdController(ISpecialtyRepository specialtyRepository)
        {
            _specialtyRepository = specialtyRepository;
        }

        [HttpGet]
        [Route("Specialties/{id}")]
        public ActionResult<Specialty> Details(int id){
            var specialty = _specialtyRepository.GetById(id);
            if(specialty == null)
            {
                return NotFound();
            }
            return Ok(specialty);
        }
    }
}