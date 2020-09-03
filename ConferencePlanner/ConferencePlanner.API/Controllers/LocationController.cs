using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConferencePlanner.Abstraction.Repository;
using ConferencePlanner.Repository.Ef.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConferencePlanner.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : Controller
    {
        private readonly IConferenceLocationRepository conferenceLocationRepository;

        public LocationController(IConferenceLocationRepository _conferenceLocationRepository)
        {
            conferenceLocationRepository = _conferenceLocationRepository;
        }

        [HttpPost]
        [Route("/location/new")]
        public IActionResult InsertConference([FromBody] Location location)
        {
            int cityId = location.DictionaryCityId;
            string address = location.LocationAddress;

            conferenceLocationRepository.InsertLocation(cityId, address);
            return Ok();
        }


    }
}
