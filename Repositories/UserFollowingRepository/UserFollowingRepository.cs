using Microsoft.EntityFrameworkCore;
using MovieTracker.Data;
using MovieTracker.Entities;
using MovieTracker.Models.Entities;
using MovieTracker.Repositories.GenericRepository;

namespace MovieTracker.Repositories.UserFollowingRepository
{
    public class UserFollowingRepository : GenericRepository<UserFollowing>, IUserFollowingRepository
    {
        public UserFollowingRepository(MovieTrackerContext context) : base(context) { }

        public async Task<UserFollowing> GetUserFollowingByIds(int userId1, int userId2)
        {
            return await _context.UserFollowing.Where(a => a.UserId.Equals(userId1) && a.FollowingPersonId.Equals(userId2)).FirstOrDefaultAsync();
        }

        public List<User> GetFollowingUsersByUser(string userEmail)
        {
            var usersFollowing = (from a in _context.Users
                          join b in _context.UserFollowing on a.Id equals b.FollowingPersonId
                                  join c in _context.Users on b.UserId equals c.Id
                          where c.UserName == userEmail
                          select new
                          {
                              a.FirstName,
                              a.LastName,
                              a.UserName
                          });
            var usersFollowingToReturn = new List<User>();
            foreach (var user in usersFollowing)
            {
                User newUsersFollowing = new User();
                newUsersFollowing.FirstName = user.FirstName;
                newUsersFollowing.LastName = user.LastName;
                newUsersFollowing.UserName = user.UserName;
                usersFollowingToReturn.Add(newUsersFollowing);
            }
            return usersFollowingToReturn;
        }

        public List<User> GetFollowersByUser(string userEmail)
        {
            var userFollowers = (from a in _context.Users
                                  join b in _context.UserFollowing on a.Id equals b.UserId
                                  join c in _context.Users on b.FollowingPersonId equals c.Id
                                  where c.UserName == userEmail
                                  select new
                                  {
                                      a.FirstName,
                                      a.LastName,
                                      a.UserName
                                  });
            var userFollowersToReturn = new List<User>();
            foreach (var user in userFollowers)
            {
                User newUserFollowers = new User();
                newUserFollowers.FirstName = user.FirstName;
                newUserFollowers.LastName = user.LastName;
                newUserFollowers.UserName = user.UserName;
                userFollowersToReturn.Add(newUserFollowers);
            }
            return userFollowersToReturn;
        }
    }
}
