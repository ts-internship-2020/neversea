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
        [Route("all/spectator/{email}")]
        public IActionResult getConference([FromRoute] string email, string startDateStr, string endDateStr)
        {
            DateTime startDate = Convert.ToDateTime(startDateStr);
            DateTime endDate = Convert.ToDateTime(endDateStr);

            List<ConferenceModel> conferenceModels = conferenceRepository.GetConference(email, startDate, endDate);
            return Ok(conferenceModels);
        }

        [HttpGet]
        [Route("all/organizer/{email}")]
        public IActionResult getConferenceBetweenDates([FromRoute] string email, string startDateStr, string endDateStr)
        {
            DateTime startDate = Convert.ToDateTime(startDateStr);
            DateTime endDate = Convert.ToDateTime(endDateStr);

            List<ConferenceModel> conferenceModels = conferenceRepository.GetConferenceBetweenDates(email, startDate, endDate);
            return Ok(conferenceModels);
        }

        [HttpPost]
        [Route("new")]
        public IActionResult postConference([FromBody] Conference conference)
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
        public IActionResult postParticipant([FromBody] ConferenceAttendance conferenceAttendance)
        {
            int conferenceId = conferenceAttendance.ConferenceId;
            string spectatorEmail = conferenceAttendance.ParticipantEmailAddress;
            int spectatorCode = 0;

            conferenceRepository.InsertParticipant(conferenceId, spectatorEmail, spectatorCode);
            return Ok();
        }

        [HttpPost]
        [Route("speaker/new")]
        public IActionResult postConferenceXSpeaker([FromBody] ConferenceXspeaker conferenceXSpeaker)
        {
            int conferenceId = conferenceXSpeaker.ConferenceId;
            int speakerId = conferenceXSpeaker.DictionarySpeakerId;

            conferenceRepository.InsertConferenceXSpeaker(conferenceId, speakerId);
            return Ok();
        }

        [HttpPut]
        [Route("join")]
        public IActionResult putParticipantStatusJoin([FromBody] ConferenceAttendance conferenceAttendance)
        {
            string spectatorEmail = conferenceAttendance.ParticipantEmailAddress;
            int conferenceId = conferenceAttendance.ConferenceId;

            conferenceRepository.ModifySpectatorStatusJoin(spectatorEmail, conferenceId);
            return Ok();
        }

        [HttpPut]
        [Route("withdraw")]
        public IActionResult putParticipantStatusWithdraw([FromBody] ConferenceAttendanceModel conferenceAttendance)
        {
            string spectatorEmail = conferenceAttendance.ParticipantEmailAddress;
            int conferenceId = conferenceAttendance.ConferenceId;

            conferenceRepository.ModifySpectatorStatusWithdraw(spectatorEmail, conferenceId);
            return Ok();
        }

        [HttpPut]
        [Route("attend")]
        public IActionResult putParticipantStatusAttend([FromBody] ConferenceAttendanceModel conferenceAttendance)
        {
            string spectatorEmail = conferenceAttendance.ParticipantEmailAddress;
            int conferenceId = conferenceAttendance.ConferenceId;

            conferenceRepository.ModifySpectatorStatusAttend(spectatorEmail, conferenceId);
            return Ok();
        }


    }
}
