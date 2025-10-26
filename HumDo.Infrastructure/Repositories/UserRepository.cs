using HumDo.Domain.Entities;
using HumDo.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace HumDo.Infrastructure.Repositories
{
    public class UserRepository : Repository<user>
    {
        private readonly HumDo.Infrastructure.Data.AppDbContext _context;

        public UserRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        // Custom user-specific queries
        public async Task<user?> GetUserWithProfileAsync(Guid userId)
        {
            return await _context.users
                .Include(u => u.user_profile)
                .FirstOrDefaultAsync(u => u.user_id == userId);
        }
    }
}
