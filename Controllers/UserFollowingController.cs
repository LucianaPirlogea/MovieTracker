using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieTracker.Models.DTOs;
using MovieTracker.Models.Entities;
using MovieTracker.Repositories;
using MovieTracker.Repositories.UserFollowingRepository;

namespace MovieTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserFollowingController : ControllerBase
    {
        private readonly IUserRepository _repositoryUser;
        private readonly IUserFollowingRepository _repositoryUserFollowing;

        public UserFollowingController(IUserRepository repositoryUser, IUserFollowingRepository repositoryUserFollowing)
        {
            _repositoryUserFollowing = repositoryUserFollowing;
            _repositoryUser = repositoryUser;
        }

        //CREATE UserFollowing
        [HttpPost("AddUserFollowing/{userEmail1}_{userEmail2}")]
        [Authorize(Roles = "User,Admin")]
        public async Task<IActionResult> Create(string userEmail1, string userEmail2)
        {
            var user1 = await _repositoryUser.GetUsersByEmail(userEmail1);
            if (user1 == null)
            {
                return BadRequest("The user cannot be found!");
            }

            var user2 = await _repositoryUser.GetUsersByEmail(userEmail2);
            if (user2 == null)
            {
                return BadRequest("The person you want to follow cannot be found!");
            }

            var userFollowing = await _repositoryUserFollowing.GetUserFollowingByIds(user1.Id, user2.Id);

            if (userFollowing != null)
            {
                return BadRequest("You have already followed this user.");
            }

            var newUserFollowing = new UserFollowing
            {
                UserId = user1.Id,
                FollowingPersonId = user2.Id
            };

            _repositoryUserFollowing.Create(newUserFollowing);
            await _repositoryUserFollowing.SaveAsync();
            return Ok();
        }

        //DELETE UserFollowing
        [HttpDelete("DeleteUserFollowing/{userEmail1}_{userEmail2}")]
        [Authorize(Roles = "User,Admin")]
        public async Task<IActionResult> Delete(string userEmail1, string userEmail2)
        {

            var user1 = await _repositoryUser.GetUsersByEmail(userEmail1);
            if (user1 == null)
            {
                return BadRequest("The user cannot be found!");
            }

            var user2 = await _repositoryUser.GetUsersByEmail(userEmail2);
            if (user2 == null)
            {
                return BadRequest("The person you want to unfollow cannot be found!");
            }

            var userFollowing = await _repositoryUserFollowing.GetUserFollowingByIds(user1.Id, user2.Id);

            if (userFollowing == null)
            {
                return BadRequest("You didn't follow this user.");
            }

            _repositoryUserFollowing.Delete(userFollowing);
            await _repositoryUserFollowing.SaveAsync();
            return Ok();
        }

        //READ pe cine urmaresti
        [HttpGet("UserFollowing/{userEmail}")]
        [Authorize(Roles = "User,Admin")]
        public async Task<IActionResult> GetFollowingUsers(string userEmail)
        {
            var userAux = await _repositoryUser.GetUsersByEmail(userEmail);
            if (userAux == null)
            {
                return BadRequest("The user cannot be found!");
            }

            var users = _repositoryUserFollowing.GetFollowingUsersByUser(userEmail);
            if (!users.Any())
            {
                return BadRequest("There are no users that you follow");
            }
            var usersToReturn = new List<UserDTO>();

            foreach (var user in users)
            {
                var auxUser = new UserDTO(user);

                usersToReturn.Add(auxUser);
            }

            return Ok(usersToReturn);

        }

        //READ cine te urmareste
        [HttpGet("UserFollowers/{userEmail}")]
        [Authorize(Roles = "User,Admin")]
        public async Task<IActionResult> GetFollowersUsers(string userEmail)
        {
            var userAux = await _repositoryUser.GetUsersByEmail(userEmail);
            if (userAux == null)
            {
                return BadRequest("The user cannot be found!");
            }

            var users = _repositoryUserFollowing.GetFollowersByUser(userEmail);
            if (!users.Any())
            {
                return BadRequest("You have no followers");
            }
            var usersToReturn = new List<UserDTO>();

            foreach (var user in users)
            {
                var auxUser = new UserDTO(user);

                usersToReturn.Add(auxUser);
            }

            return Ok(usersToReturn);

        }
    }
}
