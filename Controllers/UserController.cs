using MovieTracker.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UserController : ControllerBase
    {
        private readonly IRepositoryWrapper _repository;
        private readonly IUserRepository _userRepository;

        public UserController(IRepositoryWrapper repository, IUserRepository userRepository)
        {
            _repository = repository;
            _userRepository = userRepository;
        }

        [HttpGet("{email}")]
        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> GetUserByEmail(string email)
        {
            var user = await _repository.User.GetUsersByEmail(email);

            if(user == null)
            {
                return BadRequest("There is no user with this username");
            }

            return Ok(user);
        }


        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _repository.User.GetAllUsers();

            return Ok(new { users });
        }


        [HttpDelete("DeleteProfile{email}")]
        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> Delete([FromRoute] string email)
        {

            var profileDeleted = await _repository.User.GetUsersByEmail(email);
            _userRepository.Delete(profileDeleted);
            await _userRepository.SaveAsync();
            return Ok();
        }


    }
}
