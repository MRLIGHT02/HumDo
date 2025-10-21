using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HumDo.Application.Contracts
{
    public interface IReadRepository<T> where T : class
    {
        Task<T?> GetByIdAsync(Guid id);
        Task<IEnumerable<T>> ListAsync(Expression<Func<T, bool>>? predicate = null);
    }
}
