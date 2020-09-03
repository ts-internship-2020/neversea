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
    public class ConferenceAttendanceController : Controller
    {

        private readonly IConferenceAttendanceRepository _conferenceAttendanceRepository;
        public ConferenceAttendanceController(IConferenceAttendanceRepository conferenceAttendanceRepository)
        {

            _conferenceAttendanceRepository = conferenceAttendanceRepository;

        }

        [HttpGet]
        [Route("GetConferenceAttendance")]
        public IActionResult getConferenceAttendance()
        {
            List<ConferenceAttendanceModel> conferenceAttendanceModels = _conferenceAttendanceRepository.GetConferenceAttendance();

            return Ok(conferenceAttendanceModels);
        }

        [HttpGet]
        [Route("GetIsWithdrawn")]
        public IActionResult isWithdrawn(string email, int id)
        {
           bool isWithdrawn = _conferenceAttendanceRepository.isWithdrawn(email, id);

            return Ok(isWithdrawn);
        }


        [HttpGet]
        [Route("GetIsParticipating")]
        public IActionResult isParticipating(string email, int id)
        {
            bool isParticipating = _conferenceAttendanceRepository.isParticipating(email, id);

            return Ok(isParticipating);
        }

        

    }
}
