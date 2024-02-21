using ProjetFlashcard.Infrastructure.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using ProjetFlashcard.Domain.Entities;
using ProjetFlashcard.Domain.Enums;
using ProjetFlashcard.Domain.Repositories;
using ProjetFlashcard.Domain.Helpers;

namespace ProjetFlashcard.Infrastructure.Persistence
{
    public class CardRepository(IAppDbContext context) : ICardRepository
    {
        private readonly IAppDbContext _context = context;

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
            return _context.Cards
                .Include(card => card.CardUserData).ToList();
        }

        public Card GetById(string id)
        {
            return _context.Cards
                .Include(card => card.CardUserData)
                .First(_context => _context.Id == id);
        }

        public List<Card> GetCardsByTags(List<string> tags)
        {
            return _context.Cards
                .Where(card => tags.Contains(card.CardUserData.Tag))
                .Include(card => card.CardUserData)
                .ToList();
        }

        public List<Card> GetCardsToAnswerForDate(DateOnly date, Category category)
        {
            return _context.Cards
                .Where(card => card.Category == category)
                .Where(card => card.LastAnswerDate <= date.AddDays((-(int)category)))
                .Include(card => card.CardUserData)
                .ToList();
        }

        public void Update(Card entity)
        {
            _context.Cards.Update(entity);
            _context.SaveChanges();
        }
    }
}
