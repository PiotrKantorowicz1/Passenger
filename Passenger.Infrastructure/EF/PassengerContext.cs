using Microsoft.EntityFrameworkCore;
using Passenger.Core.Domain;

namespace Passenger.Infrastructure.EF
{
    public class PassengerContext : DbContext
    {
        private readonly SqlSettings _settings;
        public DbSet<User> Users {get; set;}

        public PassengerContext(DbContextOptions<PassengerContext> options, SqlSettings settings) 
            : base(options)
        {
            _settings = settings;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
             if(_settings.InMemory)
            {
                optionsBuilder.UseInMemoryDatabase();

                return;    
            }
            optionsBuilder.UseSqlServer(_settings.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var userBuilder = modelBuilder.Entity<User>();
            userBuilder.HasKey(x => x.Id);                                 
        }
    }
}