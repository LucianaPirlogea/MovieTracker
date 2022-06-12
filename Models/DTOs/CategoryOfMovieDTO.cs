using MovieTracker.Entities;

namespace MovieTracker.Models.DTOs
{
    public class CategoryOfMovieDTO
    {
        public int IdMovie { get; set; }
        public int IdCategory { get; set; }
        
        public CategoryOfMovieDTO(CategoryOfMovie categoryOfMovie)
        {
            this.IdMovie = categoryOfMovie.IdMovie;
            this.IdCategory = categoryOfMovie.IdCategory;
        }
    }
}
