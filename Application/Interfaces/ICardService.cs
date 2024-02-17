using ProjetFlashcard.Domain.Entities;

namespace ProjetFlashcard.Application.Interfaces
{
    public interface ICardService
    {
        public List<Card> GetAllCards(List<string>? tags = null);
        public int AddCard(Card card);
    }
}
