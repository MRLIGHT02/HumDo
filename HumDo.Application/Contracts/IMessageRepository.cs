using HumDo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumDo.Application.Contracts
{
    public interface IMessageRepository : IRepository<message>
    {
        Task<IEnumerable<message>> GetConversationAsync(Guid userAId, Guid userBId, int page = 1, int pageSize = 50);
        Task<IEnumerable<message>> GetUnreadMessagesAsync(Guid userId);
    }

}
