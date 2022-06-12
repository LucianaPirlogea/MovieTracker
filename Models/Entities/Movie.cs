namespace MovieTracker.Entities
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public byte[] Poster { get; set; }
        public ICollection<Watched> Watcheds { get; set; }
        public ICollection<Cast> Casts { get; set; }
        public ICollection<CategoryOfMovie> CategoryOfMovies { get; set; }

    }
}
