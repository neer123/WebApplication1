using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        private readonly IEmployeeMgr _employeeMgr;
        private readonly ILogger<EmployeeController> _logger;
        public EmployeeController(ILogger<EmployeeController> logger, IEmployeeMgr employeeMgr)
        {
            _logger = logger;
            _employeeMgr = employeeMgr;
        }

        [HttpGet("GetEmployee")]
        public IActionResult GetEmployee()
        {
            return Ok(_employeeMgr.GetAll());
        }


    }
}