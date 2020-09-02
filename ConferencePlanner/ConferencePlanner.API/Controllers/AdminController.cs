using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using ConferencePlanner.Abstraction.Model;
using ConferencePlanner.Abstraction.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ConferencePlanner.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAdminRepository _getAdminRepository;
        public AdminController(ILogger<HomeController> logger, IAdminRepository getAdminRepository)
        {
            _logger = logger;
            _getAdminRepository = getAdminRepository;
        }

        [HttpGet]
        public IActionResult GetAdmins()
        {
            List<AdminModel> adminModel = _getAdminRepository.GetAdmins();
            return Ok(adminModel);
        }
    }
}
