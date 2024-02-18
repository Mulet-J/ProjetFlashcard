using ProjetFlashcard.Application.Interfaces;
using ProjetFlashcard.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetFlashcard.Infrastructure.Persistence;
using ProjetFlashcard.Domain.Repositories;
using ProjetFlashcard.Application.DTOs;
using ProjetFlashcard.Application.Mappers;
using ProjetFlashcard.Domain.Enums;
using ProjetFlashcard.Domain.Helpers;

namespace ProjetFlashcard.Application.Services
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
            if(tags.Count == 0)
            {
                return this._cardRepository.GetAll();
            }
            else
            {
                return this._cardRepository.GetCardsByTags(tags);
            }
        }

        public List<CardGetDTO> GetAllCardsAsDTO(List<string> tags)
        {
            var cards = this.GetAllCards(tags);
            return cards.Select(CardDTOMapper.MapToGetDTO).ToList();
        }

        public List<CardGetDTO> GetCardsToAnswerForDateAsDTO(DateOnly date)
        {
            if(date.ToString() == "01/01/0001")
            {
                date = DateOnly.FromDateTime(DateTime.Now);
            }
            List<Card> cards = new();
            foreach (Category value in Enum.GetValues(typeof(Category)))
            {
                if(value == Category.DONE)
                {
                    continue;
                }
                cards.AddRange(_cardRepository.GetCardsToAnswerForDate(date, value));
            }
            return CardDTOMapper.MapToGetDTO(cards);
        }

        public int AnswerCard(string cardId, bool isValid)
        {
            Card card = this._cardRepository.GetById(cardId);
            if(isValid)
            {
                _cardRepository.UpdateCategory(card);
            }
            else
            {
                _cardRepository.ResetCategory(card);
            }
            return 204;
        }
    }
}
