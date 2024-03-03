using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using WebApi.DTOs;
using WebApi.Mappers;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("cards")]
    public class CardsController(ICardService cardService) : ControllerBase
    {
        private readonly ICardService _cardService = cardService;

        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(typeof(CardResponse), StatusCodes.Status200OK)]
        public IActionResult GetAllCards([FromQuery(Name = "tags")] List<string> tags)
        {
            List<Card> cards = _cardService.GetAllCards(tags);
            List<CardResponse> cardsGetDto = CardDtoMapper.MapToGetDTO(cards);
            return Ok(cardsGetDto);
        }

        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType(typeof(CardResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(void), StatusCodes.Status400BadRequest)]
        public IActionResult CreateNewCard([FromBody] CardCreationRequest cardDTO)
        {
            if (cardDTO.Question == null || cardDTO.Answer == null || cardDTO.Tag == null)
            {
                return BadRequest();
            }
            CardUserData cardUserData = new(cardDTO.Question, cardDTO.Answer, cardDTO.Tag);
            Card card = new(cardUserData);
            _cardService.AddCard(card);
            CardResponse cardGetDTO = CardDtoMapper.MapToGetDTO(card);

            return Created("", cardGetDTO);
        }

        [HttpGet("quizz")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(List<CardResponse>), StatusCodes.Status200OK)]
        public IActionResult Quizz([FromQuery] DateOnly date)
        {
            List<Card> cards = _cardService.GetCardsToAnswerForDate(date);
            List<CardResponse> cardsGetDto = CardDtoMapper.MapToGetDTO(cards);
            return Ok(cardsGetDto);
        }

        [HttpPatch("{cardId}/answer")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(void), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
        public IActionResult AnswerCard([FromRoute] string cardId, [FromBody] AnwerResponse answer)
        {
            if (answer.IsValid == null)
            {
                return BadRequest();
            }
            try { _cardService.AnswerCard(cardId, (bool)answer.IsValid); }
            catch (Exception) { return NotFound(); }
            return NoContent();
        }
    }
}
