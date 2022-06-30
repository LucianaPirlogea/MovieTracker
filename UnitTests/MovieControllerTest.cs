using Xunit;
using MovieTracker.Entities;

namespace MovieTracker.UnitTests
{
    public class MovieControllerTest
    {
        /*
        private readonly IMovieRepository _repositoryMovie;
        private readonly IUserRepository _repositoryUser;
        private readonly IUserFollowingRepository _repositoryUserFollowing;

        */

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
            Assert.Equal("01/01/0001 00:00:00", releaseDate.ToString());
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

        /*
        [Fact]
        public void GetMovieByNameReturnsBadRequest()
        {
            MovieController controller = new MovieController(_repositoryMovie, _repositoryUser, _repositoryUserFollowing);
            var response = controller.GetMovieByName("Movie that doesn't exist");

            Assert.Equal("The movie you search cannot be found!", response.ToString());
        }
        */
    }
}