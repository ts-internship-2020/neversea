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
    public class ConferenceCategoryController : Controller
    {

        private readonly IConferenceCategoryRepository _conferenceCategoryRepository;
        public ConferenceCategoryController(IConferenceCategoryRepository conferenceCategoryRepository)
        {

            _conferenceCategoryRepository = conferenceCategoryRepository;

        }

        [HttpGet]
        [Route("GetAllCategories")]
        public IActionResult getConferenceCategories()
        {
            List<ConferenceCategoryModel> conferenceCategoryModels = _conferenceCategoryRepository.GetConferenceCategories();
            return Ok(conferenceCategoryModels);
        }


        [HttpGet]
        [Route("GetFiltredCategories")]
        public IActionResult getConferenceCategories(string keyword)
        {
            List<ConferenceCategoryModel> conferenceCategoryModels = _conferenceCategoryRepository.GetConferenceCategories(keyword);
            return Ok(conferenceCategoryModels);
        }

        [HttpPost]
        [Route("InsertCategory")]
        public IActionResult postConferenceCategories([FromBody]ConferenceCategoryModel model)
        {
            _conferenceCategoryRepository.InsertConferenceCategory(model.conferenceCategoryName);
            return Ok();
        }


        [HttpPut]
        [Route("UpdateCategory")]
        public IActionResult putConferenceCategories(int conferenceTypeId, string conferenceTypeName)
        {
            _conferenceCategoryRepository.UpdateConferenceCategory(conferenceTypeId, conferenceTypeName);
            return Ok();
        }

        [HttpDelete]
        [Route("DeleteCategory")]
        public IActionResult deleteConferenceCategories(int conferenceTypeId)
        {
            _conferenceCategoryRepository.DeleteConferenceCategory(conferenceTypeId);
            return Ok();
        }
    }
}
