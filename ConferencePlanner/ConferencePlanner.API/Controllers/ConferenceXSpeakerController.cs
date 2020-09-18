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
    public class ConferenceXSpeakerController : Controller
    {
        private readonly IConferenceXSpeakerRepository _conferenceXSpeakerRepository;
        public ConferenceXSpeakerController(IConferenceXSpeakerRepository conferenceXSpeakerRepository)
        {

            _conferenceXSpeakerRepository = conferenceXSpeakerRepository;

        }

        [HttpPost]
        [Route("AddSpeakerInConference")]
        public IActionResult postConferenceXSpeaker([FromBody] ConferenceXSpeakerModel conferenceXspeaker)
        {
            _conferenceXSpeakerRepository.AddSpeaker(conferenceXspeaker.conferenceId, conferenceXspeaker.speakerId, conferenceXspeaker.isMain);
            return Ok();
        }

    }
}
