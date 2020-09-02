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
    public class CityController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConferenceCityRepository _getCityRepository;
        public CityController(ILogger<HomeController> logger, IConferenceCityRepository getCityRepository)
        {
            _logger = logger;
            _getCityRepository = getCityRepository;
        }

        [HttpGet]
        public IActionResult GetConferenceCities(int districtId)
        {
            List<ConferenceCityModel> cityModel = _getCityRepository.GetConferenceCities(districtId);
            return Ok(cityModel);
        }
    }
}
