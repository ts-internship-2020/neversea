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
    public class ConferenceController : Controller
    {
        private readonly IConferenceRepository conferenceRepository;

        public ConferenceController(IConferenceRepository _conferenceRepository)
        {
            conferenceRepository = _conferenceRepository;
        }

        [HttpGet]
        [Route("all/{spectatorEmail}")]
        public IActionResult GetConferences([FromRoute] string spectatorEmail, DateTime startDate, DateTime endDate)
        {
            List<ConferenceModel> conferenceModels = conferenceRepository.GetConference(spectatorEmail, startDate, endDate);
            return Ok(conferenceModels);
        }

        [HttpGet]
        [Route("organized/all/{organizerEmail}")]
        public IActionResult GetConferenceBetweenDates([FromRoute] string organizerEmail, DateTime startDate, DateTime endDate)
        {
            List<ConferenceModel> conferenceModels = conferenceRepository.GetConferenceBetweenDates(organizerEmail, startDate, endDate);
            return Ok(conferenceModels);
        }

        [HttpPost]
        [Route("new")]
        public IActionResult InsertConference([FromBody] Conference conference)
        {
            string conferenceName = conference.ConferenceName;
            DateTime startDate = conference.StartDate;
            DateTime endDate = conference.EndDate;
            string organiserEmail = conference.OrganiserEmail;
            int locationId = conference.LocationId;
            int conferenceTypeId = conference.DictionaryConferenceTypeId;
            int conferenceCategoryId = conference.DictionaryConferenceCategoryId;

            conferenceRepository.InsertConference(conferenceName, startDate, endDate, organiserEmail, locationId, conferenceTypeId, conferenceCategoryId);
            return Ok();
        }

        [HttpPost]
        [Route("/Participant/new")]
        public IActionResult InsertParticipant([FromBody] ConferenceAttendance conferenceAttendance)
        {
            int conferenceId = conferenceAttendance.ConferenceId;
            string spectatorEmail = conferenceAttendance.ParticipantEmailAddress;
            int spectatorCode = 0;

            conferenceRepository.InsertParticipant(conferenceId, spectatorEmail, spectatorCode);
            return Ok();
        }

        [HttpPost]
        [Route("speaker/new")]
        public IActionResult InsertConferenceXSpeaker([FromBody] ConferenceXspeaker conferenceXSpeaker)
        {
            int conferenceId = conferenceXSpeaker.ConferenceId;
            int speakerId = conferenceXSpeaker.DictionarySpeakerId;

            conferenceRepository.InsertConferenceXSpeaker(conferenceId, speakerId);
            return Ok();
        }

        [HttpPost]
        [Route("join")]
        public IActionResult ModifySpectatorStatusJoin([FromBody] ConferenceAttendance conferenceAttendance)
        {
            string spectatorEmail = conferenceAttendance.ParticipantEmailAddress;
            int conferenceId = conferenceAttendance.ConferenceId;

            conferenceRepository.ModifySpectatorStatusJoin(spectatorEmail, conferenceId);
            return Ok();
        }

        [HttpPost]
        [Route("withdraw")]
        public IActionResult ModifySpectatorStatusWithdraw([FromBody] ConferenceAttendance conferenceAttendance)
        {
            string spectatorEmail = conferenceAttendance.ParticipantEmailAddress;
            int conferenceId = conferenceAttendance.ConferenceId;

            conferenceRepository.ModifySpectatorStatusWithdraw(spectatorEmail, conferenceId);
            return Ok();
        }


    }
}
