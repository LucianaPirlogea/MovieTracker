using Xunit;
using MovieTracker.Entities;

namespace MovieTracker.UnitTests
{
    public class ActorControllerTest
    {

        [Fact]
        public void NewActorHasNoName()
        {
            Actor actor = new Actor();
            string name = actor.Name;
            Assert.Null(name);
        }

        [Fact]
        public void NewActorHasNoImage()
        {
            Actor actor = new Actor();
            byte[] image = actor.Image;
            Assert.Null(image);
        }
    }
}