using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieTracker.Entities;
using MovieTracker.Models.DTOs;
using MovieTracker.Repositories.ActorRepository;

namespace MovieTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorController : ControllerBase
    {
        private readonly IActorRepository _repositoryActor;

        public ActorController(IActorRepository repositoryActor)
        {
            _repositoryActor = repositoryActor;

        }

        // READ toti actorii
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllActors()
        {
            var actors = await _repositoryActor.GetAllActors();

            var actorsToReturn = new List<ActorDTO>();

            foreach (var actor in actors)
            {
                var auxActor = new ActorDTO(actor);

                actorsToReturn.Add(auxActor);
            }

            return Ok(actorsToReturn);
        }

        [HttpGet("{name}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetActorByName(string name)
        {
            var actor = await _repositoryActor.GetActorByName(name);
            if (actor == null)
            {
                return BadRequest("The actor you search cannot be found!");
            }
            var actorToReturn = new ActorDTO(actor);

            return Ok(actorToReturn);

        }

        [HttpGet("Movie/{movie}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetActorsByMovie(string movie)
        {
            var actors = _repositoryActor.GetActorsByMovie(movie);
            if (!actors.Any())
            {
                return BadRequest("There are no actors for this movie");
            }
            var actorsToReturn = new List<ActorDTO>();

            foreach (var actor in actors)
            {
                var auxActor = new ActorDTO(actor);

                actorsToReturn.Add(auxActor);
            }

            return Ok(actorsToReturn);

        }

        [HttpPost("AddActor")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([FromBody] ActorDTO actor)
        {
            var newActor = new Actor
            {
                Id = actor.Id,
                Name = actor.Name,
                Image = actor.Image
            };

            _repositoryActor.Create(newActor);
            await _repositoryActor.SaveAsync();
            return Ok();
        }

        [HttpPut("UpdateActor")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update([FromBody] ActorDTO actor)
        {
            var actorUpdated = await _repositoryActor.GetActorByName(actor.Name);
            actorUpdated.Image = actor.Image;
            _repositoryActor.Update(actorUpdated);
            await _repositoryActor.SaveAsync();
            return Ok();
        }

        [HttpDelete("DeleteActor{name}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete([FromRoute] string name)
        {

            var actorDeleted = await _repositoryActor.GetActorByName(name);
            _repositoryActor.Delete(actorDeleted);
            await _repositoryActor.SaveAsync();
            return Ok();
        }
    }
}
