﻿using Microsoft.AspNetCore.Mvc;
using MovieTracker.Entities;
using MovieTracker.Models.DTOs;
using MovieTracker.Repositories.ActorRepository;
using MovieTracker.Repositories.CastRepository;
using MovieTracker.Repositories.MovieRepository;

namespace MovieTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CastController : ControllerBase
    {
        private readonly ICastRepository _repositoryCast;
        private readonly IMovieRepository _repositoryMovie;
        private readonly IActorRepository _repositoryActor;

        public CastController(ICastRepository repositoryCast, IMovieRepository repositoryMovie, IActorRepository repositoryActor)
        {
            _repositoryCast = repositoryCast;
            _repositoryMovie = repositoryMovie;
            _repositoryActor = repositoryActor;

        }

        //CREATE cast
        [HttpPost("AddCast/{movieTitle}_{actorName}")]
        public async Task<IActionResult> Create(string movieTitle, string actorName)
        {
            var movie = await _repositoryMovie.GetMovieByName(movieTitle);
            if (movie == null)
            {
                return BadRequest("The movie cannot be found!");
            }

            var actor = await _repositoryActor.GetActorByName(actorName);
            if (actor == null)
            {
                return BadRequest("The actor cannot be found!");
            }

            var newCast = new Cast
            {
                IdMovie = movie.Id,
                IdActor = actor.Id
            };

            _repositoryCast.Create(newCast);
            await _repositoryCast.SaveAsync();
            return Ok();
        }
    }
}
