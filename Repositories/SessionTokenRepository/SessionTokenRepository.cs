using MovieTracker.Models;
using MovieTracker.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieTracker.Repositories.GenericRepository;
using MovieTracker.Data;

namespace MovieTracker.Repositories
{
    public class SessionTokenRepository : GenericRepository<SessionToken>, ISessionTokenRepository
    {
        public SessionTokenRepository(MovieTrackerContext context) : base(context) { }

        public async Task<SessionToken> GetByJTI(string jti)
        {
            return await _context.SessionTokens
                .FirstOrDefaultAsync(t => t.Jti.Equals(jti));
        }
    }
}
