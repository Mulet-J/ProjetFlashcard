using ProjetFlashcard.Domain.Entities;
using ProjetFlashcard.Domain.Enums;
using ProjetFlashcard.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetFlashcard.Domain.Repositories
{
    public interface ICardRepository : IRepository<Card>
    {
        List<Card> GetCardsByTags(List<string> tags);
        List<Card> GetCardsToAnswerForDate(DateOnly date, Category category);
        void UpdateCategory(Card card);
        void ResetCategory(Card card);
    }
}
