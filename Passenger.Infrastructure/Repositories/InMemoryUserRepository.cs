using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Passenger.Core.Domain;
using Passenger.Core.Repositories;

namespace Passenger.Infrastructure.Repositories
{
    public class InMemoryUserRepository : IUserRepository
    {
        private static readonly ISet<User> Users = new HashSet<User>
        {
            new User("user1@gmail.com", "user1", "secret", "User", "salt"),
            new User("user2@gmail.com", "user2", "secret", "User", "salt"),
            new User("user3@gmail.com", "user3", "secret", "User", "salt"),
        };

        public async Task<User> GetAsync(Guid id) =>
            await Task.FromResult(Users.Single(x => x.Id == id));

        public async Task<User> GetAsync(string email) =>
            await Task.FromResult(Users.SingleOrDefault(x => x.Email == email.ToLowerInvariant()));

        public async Task<IEnumerable<User>> GetAllAsync() => await Task.FromResult(Users);

        public async Task AddAsync(User user)
        {
            Users.Add(user);
            await Task.CompletedTask;
        }

        public async Task RemoveAsync(Guid id)
        {
            var user =await GetAsync(id);
            Users.Remove(user);
            await Task.CompletedTask;
        }

        public async Task UpdateAsync(User user)
        {
            await Task.CompletedTask;
        }
}
}
