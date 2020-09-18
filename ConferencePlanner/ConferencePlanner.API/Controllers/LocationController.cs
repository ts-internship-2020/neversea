using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConferencePlanner.Abstraction.Model;
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
        public IActionResult InsertConference([FromBody] LocationModel location)
        {
            int cityId = location.CityId;
            string address = location.Address;

            conferenceLocationRepository.InsertLocation(cityId, address);
            return Ok();
        }

     


        [HttpGet]
        [Route("/location/getid")]
        public IActionResult GetId(int cityId, string address)
        {
            int locationId = conferenceLocationRepository.GetLocationId(cityId, address);

            return Ok(locationId);
        }
        [HttpPost]
        [Route("/location/update")]
        public IActionResult updateLocation([FromBody] Location newLocation)
        {
            conferenceLocationRepository.updateLocation(newLocation.LocationId, newLocation.DictionaryCityId, newLocation.LocationAddress);
            return Ok();
        }

        [HttpPut]
        [Route("/location/updateLocation")]
        public IActionResult UpdateLocation(int cityId, string address, int newCityId, string newAddress)
        {
            conferenceLocationRepository.UpdateLocation(cityId, address, newCityId, newAddress);

            return Ok();
        }


    }
}
