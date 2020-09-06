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
        [Route("GetDistrictByKeyword")]
        public IActionResult GetDistricts(string keyword)
        {
            List<DistrictModel> districtModel = _getDistrictRepository.GetDistricts(keyword);
            return Ok(districtModel);
        }
        [HttpPost]
        [Route("insertDistrict")]
        public IActionResult InsertDistrict([FromBody] DistrictModel districtModel)
        {
            _getDistrictRepository.InsertDistrict(districtModel.DistrictName,districtModel.DistrictCode,districtModel.CountryId);
            return Ok();
        }
        [HttpPost]
        [Route("updateDistrict")]
        public IActionResult UpdateDistrict([FromBody] DistrictModel districtModel)
        {
            _getDistrictRepository.UpdateDistrict(districtModel.DistrictId, districtModel.DistrictName, districtModel.DistrictCode, districtModel.CountryId);
            return Ok();
        }
        [HttpDelete]
        [Route("deleteDistrict")]
        public IActionResult DeleteDistrict([FromBody] DistrictModel districtModel)
        {
            _getDistrictRepository.DeleteDistrict(districtModel.DistrictId, districtModel.CountryId);
                return Ok();
        }
    }
}

