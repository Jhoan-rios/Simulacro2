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
    public class QuotePatientByDoctorController : Controller
    {
        private readonly IQuotesRepostory _quoteRepository;
        public QuotePatientByDoctorController(IQuotesRepostory quoteRepository)
        {
            _quoteRepository = quoteRepository;
        }

        [HttpGet]
        [Route("PacienteByDoctor/{id}")]
        public ActionResult<Quote> GetPatientByDoctor(int id)
        {
            var result = _quoteRepository.GetPatientByDoctor(id);

            var Select = result.Select(b => new
            {
                b.Id,
                Doctor = b.Doctors!= null ? b.Doctors.FullName : null,
                Patient = b.Patients!=null ? b.Patients.Names : null,b.Patients.LastName
            });
            return Ok(Select);
        }
    }
}