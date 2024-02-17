using ProjetFlashcard.Application.Interfaces;
using ProjetFlashcard.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetFlashcard.Infrastructure.Persistence;
using ProjetFlashcard.Domain.Repositories;

namespace ProjetFlashcard.Application.Services
{
    public class CardService : ICardService
    {
        private IRepository<Card> _cardRepository;
        public CardService(IRepository<Card> cardRepository)
        {
            _cardRepository = cardRepository;
        }
        public int AddCard(Card card)
        {
            return this._cardRepository.Add(card);
            
        }

        public List<Card> GetAllCards(List<string>? tags = null)
        {
            if(tags == null)
            {
                return this._cardRepository.GetAll();
            }
            else
            {
                return this._cardRepository.GetAll().Where(card => tags.Contains(card.Tag)).ToList();
            }
        }
    }
}
