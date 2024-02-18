

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ProjetFlashcard.Domain.Entities;
using ProjetFlashcard.Infrastructure.ExternalServices;

namespace ProjetFlashcard.Infrastructure.DatabaseContext
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
            if (isCreated)
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

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //    modelBuilder.Entity<Card>().HasData(DataInitializer.GetInitialData().ToArray());
        //}
    }
}
