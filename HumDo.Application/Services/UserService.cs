using HumDo.Application.Contracts;
using HumDo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumDo.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<user> _userRepository;

        public UserService(IRepository<user> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<user>> GetAllAsync()
        {
            return await _userRepository.GetAllAsync();
        }

        public async Task<user?> GetByIdAsync(Guid id)
        {
            return await _userRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(user user)
        {
            
            if (await _userRepository.ExistsAsync(u => u.email == user.email))
                throw new InvalidOperationException("Email already exists");

            await _userRepository.AddAsync(user);
        }

        public async Task UpdateAsync(user user)
        {
            await _userRepository.UpdateAsync(user);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _userRepository.DeleteAsync(id);
        }
    }
}
