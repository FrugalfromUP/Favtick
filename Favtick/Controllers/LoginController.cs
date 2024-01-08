using Favtick.Core.Entities.Login;
using Favtick.Core.Repositories.Users;
using Favtick.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using NuGet.Protocol.Plugins;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Favtick.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IConfiguration _configuration;
        private readonly IUserRepository _userRepository;
        public LoginController(IConfiguration configuration,IUserRepository userRepository)
        {
            _configuration = configuration;
            _userRepository = userRepository;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login(LoginDto loginuser)
        {
            IActionResult response = Unauthorized();
            var user = AuthenticateUserAsync(loginuser);
            if (user != null)
            {
                var tokenString = GenerateJSONWebToken();
                response = Ok(new { token = tokenString });
            }

            return response;
        }

        private string GenerateJSONWebToken()
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey , SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"], _configuration["Jwt:Issuer"],
                null,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
                
        }

        private async Task<User> AuthenticateUserAsync(LoginDto login)
        {
            if(login == null){
                return null;
            }
            var user = await _userRepository.GetUserByUserName(login.UserName).ConfigureAwait(false);
            if(user.UserName == login.UserName && user.Password == login.Password)
            {
                return user;
            }else
            {
                return null;
            }    
        }
    }
}
