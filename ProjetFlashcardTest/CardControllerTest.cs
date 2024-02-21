using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ProjetFlashcard.Application.DTOs;
using ProjetFlashcard.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetFlashcardTest
{
    public class CardControllerTest
    {
        private Mock<ICardRepository> _cardRepositoryMock;
        private Mock<ICardService> _cardServiceMock;
        private CardsController _controller;

        [SetUp]
        public void Setup()
        {
            _cardRepositoryMock = new Mock<ICardRepository>();
            _cardServiceMock = new Mock<ICardService>();
            _controller = new CardsController(_cardServiceMock.Object);
        }

        [Test]
        public void GetAllCardsTest()
        {
            List<Card> cards = new();
            _cardRepositoryMock.Setup(x => x.GetAll()).Returns(cards);
            _cardServiceMock.Setup(x => x.GetAllCards(new())).Returns(cards);

            var result = _controller.GetAllCards(new());

            Assert.IsNotNull(result);
            Assert.IsInstanceOf<OkObjectResult>(result);
        }

        [Test]
        public void CreateNewCardTest()
        {
            CardPostDTO cardDTO = new();
            Card card = new();
            _cardServiceMock.Setup(x => x.AddCard(card)).Returns(1);

            var result = _controller.CreateNewCard(cardDTO);

            Assert.IsNotNull(result);
            Assert.IsInstanceOf<CreatedResult>(result);
        }

        [Test]
        public void CreateNewCardWithBadRequestTest()
        {
            CardPostDTO cardDTO = new();
            Card card = new();
            _cardServiceMock.Setup(x => x.AddCard(card)).Returns(0);

            var result = _controller.CreateNewCard(cardDTO);

            Assert.IsNotNull(result);
            Assert.IsInstanceOf<BadRequestResult>(result);
        }

        [Test]
        public void QuizzTest()
        {
            DateOnly date = new();
            List<CardGetDTO> cards = new();
            _cardServiceMock.Setup(x => x.GetCardsToAnswerForDateAsDTO(date)).Returns(cards);

            var result = _controller.Quizz(date);

            Assert.IsNotNull(result);
            Assert.IsInstanceOf<OkObjectResult>(result);
        }

        [Test]
        public void AnswerCardTest()
        {
            string cardId = "1";
            AnswerDTO answer = new();
            Card card = new();
            _cardServiceMock.Setup(x => x.AnswerCard(cardId, answer.IsValid)).Returns(card);

            var result = _controller.AnswerCard(cardId, answer);

            Assert.IsNotNull(result);
            Assert.IsInstanceOf<NoContentResult>(result);
        }

        [Test]
        public void AnswerCardWithBadRequestTest()
        {
            string cardId = "1";
            AnswerDTO answer = new();
            Card card = null;
            _cardServiceMock.Setup(x => x.AnswerCard(cardId, answer.IsValid)).Returns(card);

            var result = _controller.AnswerCard(cardId, answer);

            Assert.IsNotNull(result);
            Assert.IsInstanceOf<BadRequestResult>(result);
        }
    }

}
