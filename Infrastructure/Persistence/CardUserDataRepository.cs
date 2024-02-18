using ProjetFlashcard.Infrastructure.DatabaseContext;
using ProjetFlashcard.Domain.Entities;
using ProjetFlashcard.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public class CardUserDataRepository(IAppDbContext context) : ICardUserDataRepository
    {
        private readonly IAppDbContext _context = context;

        public int Add(CardUserData entity)
        {
            _context.CardUserDatas.Add(entity);
            _context.SaveChanges();
            return 1;
        }

        public void Delete(CardUserData entity)
        {
            _context.CardUserDatas.Remove(entity);
        }

        public List<CardUserData> GetAll()
        {
            return _context.CardUserDatas.ToList();
        }

        public CardUserData GetById(string id)
        {
            return _context.CardUserDatas.First(_context => _context.Id == id);
        }

        public void Update(CardUserData entity)
        {
            _context.CardUserDatas.Remove(entity);
        }
    }
}
