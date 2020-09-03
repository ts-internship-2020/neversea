using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConferencePlanner.Abstraction.Model;
using ConferencePlanner.Abstraction.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConferencePlanner.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConferenceTypeController : Controller
    {
        private readonly IConferenceTypeRepository _conferenceTypeRepository;
        public ConferenceTypeController(IConferenceTypeRepository conferenceTypeRepository)
        {
            _conferenceTypeRepository = conferenceTypeRepository;


        }


        [HttpGet]
        [Route("GetAllTypes")]
        public IActionResult getConferenceTypes()
        {
            List<ConferenceTypeModel> conferenceTypeModels = _conferenceTypeRepository.getConferenceTypes();
            return Ok(conferenceTypeModels);
        }

        
        [HttpGet]
        [Route("GetTypesByKeyword")]
        public IActionResult getConferenceTypes(string keyword)
        {
            List<ConferenceTypeModel> conferenceTypeModels = _conferenceTypeRepository.getConferenceTypes(keyword);
            return Ok(conferenceTypeModels);
        }

        [HttpPost]
        [Route("PostConferenceType")]
        public IActionResult insertConferenceType(string keyword)
        {
            _conferenceTypeRepository.InsertConferenceType(keyword);
            
            return Ok();
        }

        [HttpDelete]
        [Route("DeleteConferenceType")]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult deleteConferenceType(int id)
        {
            _conferenceTypeRepository.DeleteConferenceType(id);
            return Ok();
        }

        [HttpPut]
        [Route("UpdateConferenceType")]
        public IActionResult updateConferenceType(int conferenceTypeId, string conferenceTypeName)
        {
            _conferenceTypeRepository.UpdateConferenceType(conferenceTypeId, conferenceTypeName);
            return Ok();
        }
    }
}
