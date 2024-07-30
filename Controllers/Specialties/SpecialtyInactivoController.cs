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
    public class SpecialtyInactivoController : Controller
    {
        private readonly ISpecialtyRepository _specialtyRepository;
        public SpecialtyInactivoController(ISpecialtyRepository specialtyRepository)
        {
            _specialtyRepository = specialtyRepository;
        }

        [HttpGet]
        [Route("SpecialtiesInactivo")]
        public IEnumerable<Specialty> GetSpecialtiesInactivo(){
            return _specialtyRepository.GetAllInactivo();
        }
    }
}