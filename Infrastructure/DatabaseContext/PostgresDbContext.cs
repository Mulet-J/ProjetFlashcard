using Domain.Entities;
using Infrastructure.ExternalServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.DatabaseContext
{
    public class PostgresDbContext : DbContext, IAppDbContext
    {
        private readonly IConfiguration _configuration;
        public DbSet<Card> Cards { get; set; }
        public DbSet<CardUserData> CardUserDatas { get; set; }

        public PostgresDbContext()
        {
            _configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var isCreated = Database.EnsureCreated();
            if (isCreated && Cards is not null)
            {
                Cards.AddRange(DataInitializer.GetInitialData());
                this.SaveChanges();
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseNpgsql(_configuration.GetSection("ConnectionStrings:WebApiDatabase").Value);
        }
    }
}
