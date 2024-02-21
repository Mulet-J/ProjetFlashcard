using Microsoft.AspNetCore.Mvc;
using ProjetFlashcard.Application.DTOs;
using ProjetFlashcard.Application.Interfaces;
using ProjetFlashcard.Application.Mappers;
using ProjetFlashcard.Domain.Entities;
using System.Runtime.Serialization;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("cards")]
    public class CardsController(ICardService cardService) : ControllerBase
    {
        private readonly ICardService _cardService = cardService;

        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(typeof(CardGetDTO), StatusCodes.Status200OK)]
        public IActionResult Index([FromQuery(Name = "tags")]List<string> tags)
        {
            var cards = _cardService.GetAllCardsAsDTO(tags);
            return Ok(cards);
        }

        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType(typeof(CardGetDTO),StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(void),StatusCodes.Status400BadRequest)]
        public IActionResult CreateNewCard([FromBody] CardPostDTO cardDTO)
        {
            CardUserData cardUserData = new(cardDTO.Question, cardDTO.Answer, cardDTO.Tag);
            Card card = new(cardUserData);
            _cardService.AddCard(card);
            
            return Ok(CardDTOMapper.MapToGetDTO(card));
        }

        [HttpGet("quizz")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(List<CardGetDTO>),StatusCodes.Status200OK)]
        public IActionResult Quizz([FromQuery] DateOnly date)
        {
            return Ok(_cardService.GetCardsToAnswerForDateAsDTO(date));
        }

        [HttpPatch("{cardId}/answer")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(void),StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(void),StatusCodes.Status404NotFound)]
        public IActionResult AnswerCard([FromRoute] string cardId, [FromBody] AnswerDTO answer)
        {
            _cardService.AnswerCard(cardId, answer.IsValid);
            return NotFound(null);
        }
    }
}
