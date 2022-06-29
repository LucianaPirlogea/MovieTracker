using MovieTracker.Entities;
using MovieTracker.Models.Entities;
using MovieTracker.Repositories.GenericRepository;

namespace MovieTracker.Repositories.UserFollowingRepository
{
    public interface IUserFollowingRepository : IGenericRepository<UserFollowing>
    {
        Task<UserFollowing> GetUserFollowingByIds(int userId1, int userId2);
        List<User> GetFollowingUsersByUser(string userEmail);
        List<User> GetFollowersByUser(string userEmail);  
    }
}
