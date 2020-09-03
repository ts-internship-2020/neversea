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
    public class SpeakerController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConferenceSpeakerRepository _getSpeakerRepository;
        public SpeakerController(ILogger<HomeController> logger, IConferenceSpeakerRepository getSpeakerRepository)
        {
            _logger = logger;
            _getSpeakerRepository = getSpeakerRepository;
        }

        [HttpGet]
        [Route("/GetConferenceSpeakers")]
        public IActionResult GetConferenceSpeakers()
        {
            List<SpeakerModel> speakerModel = _getSpeakerRepository.GetConferenceSpeakers();
            return Ok(speakerModel);
        }
        [HttpGet]
        [Route("/GetConferenceSpeakersByKeyword")]
        public IActionResult GetConferenceSpeakers(string keyword)
        {
            List<SpeakerModel> speakerModel = _getSpeakerRepository.GetConferenceSpeakers(keyword);
            return Ok(speakerModel);
        }
        [HttpPost]
        [Route("/InsertSpeaker")]
        public IActionResult InsertSpeaker([FromBody] SpeakerModel speakerModel)
        {
            _getSpeakerRepository.InsertSpeaker(speakerModel.DictionarySpeakerName, speakerModel.DictionarySpeakerNationality, speakerModel.DictionarySpeakerRating, speakerModel.DictionarySpeakerImage);
            return Ok();
        }
        [HttpPost]
        [Route("/UpdateSpeaker")]
        public IActionResult UpdateSpeaker([FromBody] SpeakerModel speakerModel)
        {
            _getSpeakerRepository.UpdateSpeaker(speakerModel.DictionarySpeakerId, speakerModel.DictionarySpeakerName, speakerModel.DictionarySpeakerNationality, speakerModel.DictionarySpeakerRating, speakerModel.DictionarySpeakerImage);
            return Ok();
        }
        [HttpDelete]
        [Route("/DeleteSpeaker")]
        public IActionResult DeleteSpeaker([FromBody] SpeakerModel speakerModel)
        {
            _getSpeakerRepository.DeleteSpeaker(speakerModel.DictionarySpeakerId);
            return Ok();
        }
    }
}
