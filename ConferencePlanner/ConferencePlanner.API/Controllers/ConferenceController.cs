﻿using System;
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
    public class ConferenceController : Controller
    {
        private readonly IConferenceRepository conferenceRepository;

        public ConferenceController(IConferenceRepository _conferenceRepository)
        {
            conferenceRepository = _conferenceRepository;
        }

        [HttpGet]
        [Route("conferences/")]
        public IActionResult GetDemo([FromRoute] string spectatorEmail, DateTime startDate, DateTime endDate, List<ConferenceAttendanceModel> conferenceAttendanceModels)
        {
            List<ConferenceModel> conferenceModels = conferenceRepository.GetConference(spectatorEmail, startDate, endDate, conferenceAttendanceModels);
            return Ok(conferenceModels);
        }
    }
}
