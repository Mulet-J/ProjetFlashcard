using ProjetFlashcard.Application.DTOs;
using ProjetFlashcard.Domain.Entities;

namespace ProjetFlashcard.Application.Interfaces
{
    public interface ICardService
    {
        public List<Card> GetAllCards(List<string> tags);
        public int AddCard(Card card);
        public List<CardGetDTO> GetAllCardsAsDTO(List<string> tags);
        public List<CardGetDTO> GetCardsToAnswerForDateAsDTO(DateOnly date);
        public int AnswerCard(string cardId, bool isValid);
    }
}
