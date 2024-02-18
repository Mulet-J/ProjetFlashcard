using ProjetFlashcard.Application.DTOs;
using ProjetFlashcard.Domain.Entities;

namespace ProjetFlashcard.Application.Mappers
{
    public class CardDTOMapper
    {
        public static CardGetDTO MapToGetDTO(Card card)
        {
            return new CardGetDTO(card.Id, card.Category, card.CardUserData.Question, card.CardUserData.Answer, card.CardUserData.Tag);
        }

        public static List<CardGetDTO> MapToGetDTO(List<Card> cards)
        {
            return cards.Select(MapToGetDTO).ToList();
        }
    }
}
