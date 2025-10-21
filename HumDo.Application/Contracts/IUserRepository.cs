using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HumDo.Domain.Entities;


namespace HumDo.Application.Contracts
{
    public interface IUserRepository : IRepository<user>
    {
        Task<user?> GetByEmailAsync(string email);
        Task<user?> GetByUsernameAsync(string username);
        Task<IEnumerable<user>> SearchAsync(string query, int limit = 50);
        Task IncrementLoginAttemptsAsync(Guid userId);
    }

}
