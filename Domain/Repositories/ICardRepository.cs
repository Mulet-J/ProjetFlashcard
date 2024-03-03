using Domain.Entities;
using Domain.Enums;

namespace Domain.Repositories
{
    public interface ICardRepository : IRepository<Card>
    {
        List<Card> GetCardsByTags(List<string> tags);
        List<Card> GetCardsToAnswerForDate(DateOnly date, Category category);
    }
}
