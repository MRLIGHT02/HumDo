using HumDo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumDo.Application.Contracts
{
    public interface IUserService
    {
        Task<IEnumerable<user>> GetAllAsync();
        Task<user?> GetByIdAsync(Guid id);
        Task AddAsync(user user);
        Task UpdateAsync(user user);
        Task DeleteAsync(Guid id);
    }
}
