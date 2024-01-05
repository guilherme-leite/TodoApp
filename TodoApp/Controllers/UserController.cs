using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoApp.Models;
using TodoApp.Repository.Interfaces;

namespace TodoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAllUsers()
        {
            List<User> users = await _userRepository.FindAll();
            return Ok(users);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<User>> GetUser([FromRoute] int id)
        {
            User user = await _userRepository.FindById(id);
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<User>> CreateUser([FromBody] User user)
        {
            User newUser = await _userRepository.Add(user);
            
            return Ok(newUser);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult<User>> Update([FromBody] User user, int id)
        {
            user.Id = id;

            User UpdatedUser = await _userRepository.Update(user, id);

            return Ok(user);
        }

    }
}
