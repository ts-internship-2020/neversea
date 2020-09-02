using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using ConferencePlanner.Abstraction.Model;
using ConferencePlanner.Abstraction.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.CodeAnalysis.CSharp.Syntax;

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
        [Route("getDistrictsFiltered")]
        public IActionResult GetDistricts(string keyword)
        {
            List<DistrictModel> districtModel = _getDistrictRepository.GetDistricts(keyword);
            return Ok(districtModel);
        }
        [HttpPost]
        [Route("insertDistrict")]
        public IActionResult InsertDistrict(string districtName, string districtCode, int countryId)
        {
            _getDistrictRepository.InsertDistrict(districtName,districtCode,countryId);
            return Ok();
        }
        [HttpPut]
        [Route("updateDistrict")]
        public IActionResult UpdateDistrict(int districtId, string districtName, string districtCode, int countryId)
        {
            _getDistrictRepository.UpdateDistrict(districtId,districtName, districtCode, countryId);
            return Ok();
        }
        [HttpDelete]
        [Route("deleteDistrict")]
        public IActionResult DeleteDistrict(int districtId, int countryId)
        {
            _getDistrictRepository.DeleteDistrict(districtId, countryId);
                return Ok();
        }
    }
}

