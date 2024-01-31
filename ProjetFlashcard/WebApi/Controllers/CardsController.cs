using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProjetFlashcard.WebApi.Controllers
{
    [ApiController]
    [Route("cards")]
    public class CardsController : ControllerBase
    {
        [HttpGet]
        public string Index()
        {
            return "zedsgfhj";
        }

        [HttpPost]
        public string CreateNewCard()
        {
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
