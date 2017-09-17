using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Passenger.Core.Domain;
using Passenger.Core.Repositories;

namespace Passenger.Infrastructure.Repositories
{
    public class InMemoryDriverRepository : IDriverRepository
    {
        private static readonly ISet<Driver> Drivers = new HashSet<Driver>();

        public async Task<Driver> GetAsync(Guid userId)
            => await Task.FromResult(Drivers.SingleOrDefault(x => x.UserId == userId));

        public IEnumerable<Driver> GetAll() => Drivers;

        public async Task<IEnumerable<Driver>> GetAllAsync()
            => await Task.FromResult(Drivers);

        public async Task AddAsync(Driver driver)
        {
            Drivers.Add(driver);
            await Task.CompletedTask;
        }

        public async Task UpdateAsync(Driver driver)
        {
            await Task.CompletedTask;
        }
    }
}
