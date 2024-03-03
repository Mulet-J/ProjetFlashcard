using Domain.Entities;
using WebApi.DTOs;

namespace WebApi.Mappers
{
    public static class CardDtoMapper
    {
        public static CardResponse MapToGetDTO(Card card)
        {
            return new CardResponse(card.Id, card.Category, card.CardUserData.Question, card.CardUserData.Answer, card.CardUserData.Tag);
        }

        public static List<CardResponse> MapToGetDTO(List<Card> cards)
        {
            return cards.ConvertAll(MapToGetDTO);
        }
    }
}
