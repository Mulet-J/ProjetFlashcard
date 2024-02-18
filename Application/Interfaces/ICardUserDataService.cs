using ProjetFlashcard.Domain.Entities;
using ProjetFlashcard.Domain.Repositories;

namespace ProjetFlashcard.Application.Interfaces
{
    public interface ICardUserDataService
    {
        List<CardUserData> GetAllCards();

        void AddCardUserData(CardUserData cardUserData);


    }
}
