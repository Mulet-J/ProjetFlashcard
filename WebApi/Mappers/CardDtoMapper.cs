using Domain.Entities;
using WebApi.DTOs;

namespace WebApi.Mappers
{
    public static class CardDtoMapper
    {
        public static CardGetDto MapToGetDTO(Card card)
        {
            return new CardGetDto(card.Id, card.Category, card.CardUserData.Question, card.CardUserData.Answer, card.CardUserData.Tag);
        }

        public static List<CardGetDto> MapToGetDTO(List<Card> cards)
        {
            return cards.ConvertAll(MapToGetDTO);
        }
    }
}
