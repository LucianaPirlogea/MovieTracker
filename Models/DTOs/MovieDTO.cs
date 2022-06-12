using MovieTracker.Entities;

namespace MovieTracker.Models.DTOs
{
    public class MovieDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public byte[] Poster { get; set; }

        public MovieDTO(Movie movie)
        {
            this.Id = movie.Id;
            this.Title = movie.Title;
            this.ReleaseDate = movie.ReleaseDate;
            this.Description = movie.Description;
            this.Duration = movie.Duration;
            this.Poster = movie.Poster;
        }
    }
}
