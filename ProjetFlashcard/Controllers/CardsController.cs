using Microsoft.AspNetCore.Mvc;
using ProjetFlashcard.Application.Interfaces;
using ProjetFlashcard.Domain.Entities;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("cards")]
    public class CardsController(ICardService cardService, ICardUserDataService cardUserDataService) : ControllerBase
    {
        private readonly ICardService _cardService = cardService;
        private readonly ICardUserDataService _cardUserDataService = cardUserDataService;

        [HttpGet]
        public string Index([FromQuery(Name = "tags")]string tags)
        {
            _cardUserDataService.getAllCards();
            return "zedsgfhj";
        }

        [HttpPost]
        public string CreateNewCard()
        {
            CardUserData cardUserData = new()
            {
                Answer = "answer",
                Question = "question",
                Id = Guid.NewGuid().ToString()
            };
            _cardUserDataService.AddCardUserData(cardUserData);
            
            return "a";
        }

        [HttpGet("quizz")]
        public string Quizz()
        {
            return "quizz";
        }

        [HttpPatch("{cardUID}/answer")]
        public string AnswerCard(string cardUID)
        {
            return "wow" + cardUID;
        }
    }
}
