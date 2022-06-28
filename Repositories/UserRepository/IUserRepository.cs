using MovieTracker.Entities;
using MovieTracker.Models.Entities;
using MovieTracker.Repositories;
using MovieTracker.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieTracker.Repositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<List<User>> GetAllUsers();
        Task<User> GetUsersByEmail(string email);
        Task<User> GetByIdWithRoles(int id);
    }
}
