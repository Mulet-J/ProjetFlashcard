using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DatabaseContext
{
    public interface IAppDbContext : IDisposable
    {
        public int SaveChanges();
        public Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        public DbSet<Card> Cards { get; set; }
        public DbSet<CardUserData> CardUserDatas { get; set; }
    }
}
