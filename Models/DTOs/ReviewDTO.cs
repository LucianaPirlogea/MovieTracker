using MovieTracker.Entities;

namespace MovieTracker.Models.DTOs
{
    public class ReviewDTO
    {
        public int Id { get; set; }
        public int NumberOfStars { get; set; }
        public string Comment { get; set; }

        public ReviewDTO() { }
        public ReviewDTO(Review review)
        {
            this.Id = review.Id;
            this.NumberOfStars = review.NumberOfStars;
            this.Comment = review.Comment;
        }
    }
}
