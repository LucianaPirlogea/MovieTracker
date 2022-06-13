using Microsoft.AspNetCore.Mvc;
using MovieTracker.Models.DTOs;
using MovieTracker.Repositories.CategoryRepository;

namespace MovieTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _repositoryCategory;

        public CategoryController(ICategoryRepository repositoryCategory)
        {
            _repositoryCategory = repositoryCategory;

        }
        [HttpGet]
        //[Authorize(Roles = "User")]
        // READ toate categoriile
        public async Task<IActionResult> GetAllCategories()
        {
            var categories = await _repositoryCategory.GetAllCategories();

            var categoriesToReturn = new List<CategoryDTO>();

            foreach (var category in categories)
            {
                var auxCategory = new CategoryDTO(category);

                categoriesToReturn.Add(auxCategory);
            }

            return Ok(categoriesToReturn);
        }
    }
}
