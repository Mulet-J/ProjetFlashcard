using Application.Exceptions;
using Application.Interfaces;
using Domain.Entities;
using Domain.Enums;
using Domain.Helpers;
using Domain.Repositories;

namespace Application.Services
{
    public class CardService(ICardRepository cardRepository) : ICardService
    {
        private readonly ICardRepository _cardRepository = cardRepository;

        public int AddCard(Card card)
        {
            return this._cardRepository.Add(card);
        }

        public List<Card> GetAllCards(List<string> tags)
        {
            if (tags.Count == 0)
            {
                return this._cardRepository.GetAll();
            }
            else
            {
                return this._cardRepository.GetCardsByTags(tags);
            }
        }

        public List<Card> GetCardsToAnswerForDate(DateOnly date)
        {
            if (date.ToString() == "01/01/0001")
            {
                date = DateOnly.FromDateTime(DateTime.Now);
            }
            List<Card> cards = [];
            foreach (Category value in Enum.GetValues(typeof(Category)))
            {
                if (value == Category.DONE)
                {
                    continue;
                }
                cards.AddRange(_cardRepository.GetCardsToAnswerForDate(date, value));
            }
            return cards;
        }

        public Card AnswerCard(string cardId, bool isValid)
        {
            Card card = _cardRepository.GetById(cardId) ?? throw new CardNotFoundException("Card not found");
            if (isValid)
            {
                card.Category = CategoryHelpers.GetNextCategory(card.Category);
            }
            else
            {
                card.Category = CategoryHelpers.GetFirstCategory();
            }
            card.LastAnswerDate = DateOnly.FromDateTime(DateTime.Now);
            _cardRepository.Update(card);
            return card;
        }
    }
}
