using MovieTracker.Entities;

namespace MovieTracker.Models.DTOs
{
    public class CategoryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CategoryDTO(Category category)
        {
            this.Id = category.Id;
            this.Name = category.Name;
        }
    }
}
