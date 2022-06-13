using Microsoft.AspNetCore.Mvc;
using MovieTracker.Entities;
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

        [HttpPost("AddMovie")]
        //CREATE category
        public async Task<IActionResult> Create([FromBody] CategoryDTO category)
        {
            var newCategory = new Category
            {
               Name = category.Name
            };

            _repositoryCategory.Create(newCategory);
            await _repositoryCategory.SaveAsync();
            return Ok();
        }
    }
}
