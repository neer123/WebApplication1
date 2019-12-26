using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeAPIController : ControllerBase
    {

       public LoginModel Login(LoginModel LM)
        {
            
            if(LM.UserName=="Test1" && LM.Password == "123")
            {
                LM.Email = "Test1@gmail.com";
             
            }
            return LM;

        }
        

    }
}