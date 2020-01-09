using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BL;
using DL;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
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

        [HttpPost("SaveEmployee")]
        public void SaveEmployee(Employee emp)
        {
            try
            {
                _employeeMgr.Add(emp);
               
            }
            catch(Exception ex)
            {
               
            }
        }


    }
}