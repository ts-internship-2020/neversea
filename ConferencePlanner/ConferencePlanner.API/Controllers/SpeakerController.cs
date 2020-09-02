using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConferencePlanner.Abstraction.Model;
using ConferencePlanner.Abstraction.Repository;
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

        [HttpGet("~/[controller]")]
        public IActionResult GetConferenceSpeakers()
        {
            List<SpeakerModel> speakerModel = _getSpeakerRepository.GetConferenceSpeakers();
            return Ok(speakerModel);
        }
        [HttpGet("~/[controller]/keyword")]
        public IActionResult GetConferenceSpeakers(string keyword)
        {
            List<SpeakerModel> speakerModel = _getSpeakerRepository.GetConferenceSpeakers(keyword);
            return Ok(speakerModel);
        }
    }
}
