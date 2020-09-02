using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConferencePlanner.Abstraction.Model;
using ConferencePlanner.Abstraction.Repository;
using ConferencePlanner.Repository.Ef.Entities;
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
        [Route("/GetCountry")]
        public IActionResult GetCountry()
        {
            List<CountryModel> countryModel = _getCountryRepository.GetCountry();
            return Ok(countryModel);
        }
        [HttpGet]
        [Route("/GetCountryByKeyword")]
        public IActionResult GetCountry(string keyword)
        {
            List<CountryModel> countryModel = _getCountryRepository.GetCountry(keyword);
            return Ok(countryModel);
        }

        [HttpPost]
        [Route("/InsertCountry")]
        public IActionResult InsertCountry([FromBody]DictionaryCountry countryModel)
        {
            _getCountryRepository.InsertCountry(countryModel.DictionaryCountryName, countryModel.DictionaryCountryCode, countryModel.DictionaryCountryNationality);
            return Ok();
        }

        [HttpPost]
        [Route("/UpdateCountry")]
        public IActionResult UpdateCountry([FromBody] DictionaryCountry countryModel)
        {
            _getCountryRepository.UpdateCountry(countryModel.DictionaryCountryId, countryModel.DictionaryCountryName, countryModel.DictionaryCountryCode, countryModel.DictionaryCountryNationality);
            return Ok();
        }

        [HttpDelete]
        [Route("/DeleteCountry")]
        public IActionResult DeleteCountry([FromBody] DictionaryCountry countryModel)
        {
            _getCountryRepository.DeleteCountry(countryModel.DictionaryCountryId);
            return Ok();
        }
    }
}
