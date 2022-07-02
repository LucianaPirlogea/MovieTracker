using Xunit;
using MovieTracker.Entities;

namespace MovieTracker.UnitTests
{
    public class ReviewControllerTest
    {
        [Fact]
        public void NewReviewHasNoNumberOfStars()
        {
            Review review = new Review();
            int stars = review.NumberOfStars;
            Assert.Equal(0, stars);
        }

        [Fact]
        public void NewReviewHasNoComment()
        {
            Review review = new Review();
            string comment = review.Comment;
            Assert.Null(comment);
        }

        [Fact]
        public void NewReviewHasNoDate()
        {
            Review review = new Review();
            DateTime date = review.Date;
            Assert.Equal("01.01.0001 00:00:00", date.ToString());
        }
    }
}
