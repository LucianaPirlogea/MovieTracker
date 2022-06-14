using Microsoft.AspNetCore.Mvc;
using MovieTracker.Entities;
using MovieTracker.Repositories.CategoryOfMoviesRepository;
using MovieTracker.Repositories.CategoryRepository;
using MovieTracker.Repositories.MovieRepository;

namespace MovieTracker.Controllers
{
    public class CategoryOfMoviesController : ControllerBase
    {
        private readonly ICategoryOfMoviesRepository _repositoryCategoryOfMovies;
        private readonly IMovieRepository _repositoryMovie;
        private readonly ICategoryRepository _repositoryCategory;

        public CategoryOfMoviesController(ICategoryOfMoviesRepository repositoryCategoryOfMovies, IMovieRepository repositoryMovie, ICategoryRepository repositoryCategory)
        {
            _repositoryCategoryOfMovies = repositoryCategoryOfMovies;
            _repositoryMovie = repositoryMovie;
            _repositoryCategory = repositoryCategory;
        }

        //CREATE CategoryOfMovie
        [HttpPost("AddCategoryOfMovie/{movieTitle}_{categoryName}")]
        public async Task<IActionResult> Create(string movieTitle, string categoryName)
        {
            var movie = await _repositoryMovie.GetMovieByName(movieTitle);
            if (movie == null)
            {
                return BadRequest("The movie cannot be found!");
            }

            var category = await _repositoryCategory.GetCategoryByName(categoryName);
            if (category == null)
            {
                return BadRequest("The category cannot be found!");
            }

            var categoryOfMovie = await _repositoryCategoryOfMovies.GetCategoryOfMovieByIds(movie.Id, category.Id);

            if (categoryOfMovie != null)
            {
                return BadRequest("This category is already associated with this movie.");
            }

            var newCategoryOfMovie = new CategoryOfMovie
            {
                IdMovie = movie.Id,
                IdCategory = category.Id
            };

            _repositoryCategoryOfMovies.Create(newCategoryOfMovie);
            await _repositoryCategoryOfMovies.SaveAsync();
            return Ok();
        }

        //DELETE CategoryOfMovie
        [HttpDelete("DeleteCategoryOfMovie/{movieTitle}_{categoryName}")]
        public async Task<IActionResult> Delete(string movieTitle, string categoryName)
        {

            var movie = await _repositoryMovie.GetMovieByName(movieTitle);
            if (movie == null)
            {
                return BadRequest("The movie cannot be found!");
            }

            var category = await _repositoryCategory.GetCategoryByName(categoryName);
            if (category == null)
            {
                return BadRequest("The category cannot be found!");
            }

            var categoryOfMovieDeleted = await _repositoryCategoryOfMovies.GetCategoryOfMovieByIds(movie.Id, category.Id);

            if (categoryOfMovieDeleted == null)
            {
                return BadRequest("This category is not associated with this movie.");
            }
            _repositoryCategoryOfMovies.Delete(categoryOfMovieDeleted);
            await _repositoryCategoryOfMovies.SaveAsync();
            return Ok();
        }
    }
}
