using Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using WebApi.DTOs;

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
            List<Card> cards = [];
            _cardRepositoryMock.Setup(x => x.GetAll()).Returns(cards);
            _cardServiceMock.Setup(x => x.GetAllCards(new())).Returns(cards);

            var result = _controller.GetAllCards([]);

            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<OkObjectResult>());
        }

        [Test]
        public void CreateNewCardTest()
        {
            CardCreationRequest cardDTO = new()
            {
                Answer = "answer",
                Question = "question",
                Tag = "tag"
            };
            Card card = new();
            _cardServiceMock.Setup(x => x.AddCard(card)).Returns(1);

            var result = _controller.CreateNewCard(cardDTO);

            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<CreatedResult>());
        }

        [Test]
        public void CreateNewCardWithBadRequestTest()
        {
            CardCreationRequest cardDTO = new();
            _cardServiceMock.Setup(x => x.AddCard(It.IsAny<Card>())).Returns(0);

            var result = _controller.CreateNewCard(cardDTO);

            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<BadRequestResult>());
        }

        [Test]
        public void QuizzTest()
        {
            DateOnly date = new();
            List<Card> cards = [];
            _cardServiceMock.Setup(x => x.GetCardsToAnswerForDate(It.IsAny<DateOnly>())).Returns(cards);

            var result = _controller.Quizz(date);

            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<OkObjectResult>());
        }

        [Test]
        public void AnswerCardTest()
        {
            const string cardId = "1";
            AnwerResponse answer = new() { IsValid = false };
            Card card = new();
            _cardServiceMock.Setup(x => x.AnswerCard(It.IsAny<string>(), It.IsAny<bool>())).Returns(card);

            var result = _controller.AnswerCard(cardId, answer);

            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<NoContentResult>());
        }

        [Test]
        public void AnswerCardWithBadRequestTest()
        {
            const string cardId = "1";
            AnwerResponse answer = new();
            Card card = new();
            _cardServiceMock.Setup(x => x.AnswerCard(It.IsAny<string>(), It.IsAny<bool>())).Returns(card);

            var result = _controller.AnswerCard(cardId, answer);

            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<BadRequestResult>());
        }
    }
}
