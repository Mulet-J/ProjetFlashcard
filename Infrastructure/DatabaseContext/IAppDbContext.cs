using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using ProjetFlashcard.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetFlashcard.Infrastructure.DatabaseContext
{
    public interface IAppDbContext : IDisposable
    {
        public int SaveChanges();
        public Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        public DbSet<Card> Cards { get; set; }
        public DbSet<CardUserData> CardUserDatas { get; set; }
    }
}
