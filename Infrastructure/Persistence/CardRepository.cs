using Infrastructure.DatabaseContext;
using ProjetFlashcard.Domain.Entities;
using ProjetFlashcard.Domain.Repositories;

namespace ProjetFlashcard.Infrastructure.Persistence
{
    public class CardRepository : IRepository<Card>
    {
        private readonly IAppDbContext _context;

        public CardRepository(IAppDbContext context)
        {
            _context = context;
        }

        public int Add(Card entity)
        {
            _context.Cards.Add(entity);
            _context.SaveChanges();
            return 1;
        }

        public void Delete(Card entity)
        {
            _context.Cards.Remove(entity);
        }

        public List<Card> GetAll()
        {
            return _context.Cards.ToList();
        }

        public Card GetById(string id)
        {
            return _context.Cards.First(_context => _context.Id == id);
        }

        public void Update(Card entity)
        {
            _context.Cards.Update(entity);
        }
    }
}
