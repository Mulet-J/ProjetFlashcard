using Domain.Entities;

namespace Application.Interfaces
{
    public interface ICardService
    {
        public int AddCard(Card card);
        public List<Card> GetAllCards(List<string> tags);
        public List<Card> GetCardsToAnswerForDate(DateOnly date);
        public Card AnswerCard(string cardId, bool isValid);
    }
}
