

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ProjetFlashcard.Domain.Entities;

namespace Infrastructure.DatabaseContext
{
    public class PostgresDbContext : DbContext, IAppDbContext
    {

        private readonly IConfiguration _configuration;

        public PostgresDbContext()
        {
            _configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            Database.EnsureCreated();
        }

        public DbSet<Card> Cards { get; set; }
        public DbSet<CardUserData> CardUserDatas { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder
                .UseNpgsql(_configuration.GetSection("ConnectionStrings:WebApiDatabase").Value);
    }
}
