namespace MovieTracker.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<CategoryOfMovie> CategoryOfMovies { get; set; }

    }
}
