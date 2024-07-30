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
    public class QuoteGetByDoctorController : Controller
    {
        private readonly IQuotesRepostory _quoteRepository;
        public QuoteGetByDoctorController(IQuotesRepostory quoteRepository)
        {
            _quoteRepository = quoteRepository;
        }

        [HttpGet]
        [Route("QuoteByDay/{id}/{day}")]
        public IEnumerable<Quote> GetAllByDoctor(int id, string day) {
            return _quoteRepository.GetAllByDoctor(id, day);
        }
    }
}