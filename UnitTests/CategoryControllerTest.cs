using Xunit;
using MovieTracker.Entities;

namespace MovieTracker.UnitTests
{
    public class CategoryControllerTest
    {
        [Fact]
        public void NewCategoryHasNoName()
        {
            Category category = new Category();
            string name = category.Name;
            Assert.Null(name);
        }
    }
}
