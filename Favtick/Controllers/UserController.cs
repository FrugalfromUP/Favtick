using Favtick.Core.Entities;
using Favtick.Core.Entities.Login;
using Favtick.Core.Repositories.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Favtick.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class UserController : ControllerBase
    {
        public readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            return Ok(await _userRepository.Get(id));
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task<IActionResult> CreateUser(User user)
        {
            return Ok(await _userRepository.Create(user).ConfigureAwait(false));
        }


        // GET: api/<UserController>
        [HttpGet]
        public async Task<IActionResult> GetAllUser()
        {
            return Ok(await _userRepository.GetAll());
        }

        // PUT api/<UserController>/5
        [HttpPut]
        public async Task<IActionResult> Put(User user)
        {
            var data = await _userRepository.Get(user.Id).ConfigureAwait(false);

            if (data != null)
            {
                return Ok(_userRepository.Update(user));
            }

            return NotFound();
        }

        //// DELETE api/<UserController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
