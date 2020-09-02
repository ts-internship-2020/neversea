using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using ConferencePlanner.Abstraction.Model;
using ConferencePlanner.Abstraction.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ConferencePlanner.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistrictController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IDistrictRepository _getDistrictRepository;
        public DistrictController(ILogger<HomeController> logger, IDistrictRepository getDistrictRepository)
        {
            _logger = logger;
            _getDistrictRepository = getDistrictRepository;
        }

        [HttpGet]
        public IActionResult GetDistricts()
        {
            List<DistrictModel> districtModel = _getDistrictRepository.GetDistricts();
            return Ok(districtModel);
        }
        [HttpGet]
        [Route("getDistrictsFiltred")]
        public IActionResult GetDistricts(string keyword)
        {
            List<DistrictModel> districtModel = _getDistrictRepository.GetDistricts(keyword);
            return Ok(districtModel);
        }
    }
}

