using Microsoft.AspNetCore.Mvc;
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
        [HttpGet]
        //[Authorize(Roles = "User")]
        // READ toti actorii
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

    }
}
