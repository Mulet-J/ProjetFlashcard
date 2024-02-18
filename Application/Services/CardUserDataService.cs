using ProjetFlashcard.Application.Interfaces;
using ProjetFlashcard.Domain.Entities;
using ProjetFlashcard.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetFlashcard.Application.Services
{
    public class CardUserDataService(ICardUserDataRepository cardUserDataRepository) : ICardUserDataService
    {
        private readonly ICardUserDataRepository _cardUserDataRepository = cardUserDataRepository;

        public List<CardUserData> GetAllCards()
        {
            return this._cardUserDataRepository.GetAll();
        }

        public void AddCardUserData(CardUserData cardUserData)
        {
            this._cardUserDataRepository.Add(cardUserData);
        }
    }
}
