using HumDo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HumDo.Application.Contracts
{
    public interface IMatchRepository : IRepository<match>
    {
        Task<IEnumerable<match>> GetMatchesForUserAsync(Guid userId, int page = 1, int pageSize = 50);
        Task<match?> GetByUsersAsync(Guid aId, Guid bId);
    }
}
