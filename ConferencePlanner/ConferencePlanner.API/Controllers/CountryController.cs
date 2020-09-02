using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConferencePlanner.Abstraction.Model;
using ConferencePlanner.Abstraction.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ConferencePlanner.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICountryRepository _getCountryRepository;
        public CountryController(ILogger<HomeController> logger, ICountryRepository getCountryRepository)
        {
            _logger = logger;
            _getCountryRepository = getCountryRepository;
        }

        [HttpGet]
        public IActionResult GetCountry()
        {
            List<CountryModel> countryModel = _getCountryRepository.GetCountry();
            return Ok(countryModel);
        }
    }
}
