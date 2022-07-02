using Xunit;
using MovieTracker.Entities;

namespace MovieTracker.UnitTests
{
    public class MovieControllerTest
    {

        [Fact]
        public void NewMovieHasNoTitle()
        {
            Movie movie = new Movie();
            string title = movie.Title;
            Assert.Null(title);
        }

        [Fact]
        public void NewMovieHasNoReleaseDate()
        {
            Movie movie = new Movie();
            DateTime releaseDate = movie.ReleaseDate;
            Assert.Equal("01.01.0001 00:00:00", releaseDate.ToString());
        }

        [Fact]
        public void NewMovieHasNoDescription()
        {
            Movie movie = new Movie();
            string description = movie.Description;
            Assert.Null(description);
        }

        [Fact]
        public void NewMovieHasNoPoster()
        {
            Movie movie = new Movie();
            byte[] poster = movie.Poster;
            Assert.Null(poster);
        }

    }
}