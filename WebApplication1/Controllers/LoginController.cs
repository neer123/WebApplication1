using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IConfiguration _config;
        public LoginController(IConfiguration config)
        {
            _config = config;
        }


        public IActionResult Login(string UserName, string Password)
        {
            UserModel objUM = new UserModel();
            objUM.UserName = UserName;
            objUM.Password = Password;
            IActionResult response = Unauthorized();
            var user = Authenticateuser(objUM);

            if (user != null)
            {
                var tokenresponse = GenerateJSONWebToken(user);
                response = Ok(tokenresponse);
            }
            return response;

        }

        private string GenerateJSONWebToken(UserModel UM)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
                {
                new Claim(JwtRegisteredClaimNames.Sub, UM.UserName),
            new Claim(JwtRegisteredClaimNames.Email, UM.EmailAddress),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Issuer"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials
          );
            var encodetoken = new JwtSecurityTokenHandler().WriteToken(token);
            return encodetoken;
        }

        private UserModel Authenticateuser(UserModel UM)
        {
            if (UM.UserName == "Test1" && UM.Password == "1234")
            {
                UM.EmailAddress = "Test1@gmail.com";
                return UM;
            }
            else
            {
                return null;
            }
            
        }
        [Authorize]
        [HttpPost("Post")]
        public string Post()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            IList<Claim> claim = identity.Claims.ToList();
            string UName = claim[0].Value;

            return "User Name is ->" +UName;
        }
        [Authorize]
        [HttpGet("GetValue")]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "Value1", "Value2", "Value3" };
        }




    }
}