using ProjetFlashcard.Domain.Repositories;
using ProjetFlashcard.Application.Services;
using ProjetFlashcard.Domain.Enums;
using ProjetFlashcard.Infrastructure.ExternalServices;
using ProjetFlashcard.Application.DTOs;
using ProjetFlashcard.Application.Interfaces;

namespace ProjetFlashcardTest
{
    public class CardServiceTest
    {
        private Mock<ICardRepository> mockCardRepository;
        private CardService cardService;
        private List<Card> cards = new();

        [SetUp]
        public void Setup()
        {
            mockCardRepository = new Mock<ICardRepository>();
            cardService = new CardService(mockCardRepository.Object);
            cards = Dataset.GetInitialData();
        }

        [Test]
        public void GetAllCardTest()
        {
            mockCardRepository.Setup(x => x.GetAll()).Returns(cards);

            var result = cardService.GetAllCards(new());

            Assert.That(result, Is.EqualTo(cards));
        }

        [Test]
        public void GetAllCardWithTagsTest()
        {
            const string TAG = "geography";
            List<Card> filteredCards = cards.FindAll(x => x.CardUserData.Tag.Contains(TAG));
            mockCardRepository.Setup(x => x.GetCardsByTags(It.IsAny<List<string>>())).Returns(filteredCards);

            var result = cardService.GetAllCards(new() { TAG });

            Assert.That(result, Is.EqualTo(filteredCards));
        }

        [Test]
        public void GetAllCardsWithForeignTagTest()
        {
            const string TAG = "thistagdoesnotexist";
            
            List<Card> filteredCards = cards.FindAll(x => x.CardUserData.Tag.Contains(TAG));
            mockCardRepository.Setup(x => x.GetCardsByTags(It.IsAny<List<string>>())).Returns(filteredCards);

            var result = cardService.GetAllCards(new() { TAG });

            Assert.That(result, Is.EqualTo(filteredCards));
        }

        [Test]
        public void GetAllCardsAsDTOWithNoTagsTest()
        {
            mockCardRepository.Setup(x => x.GetAll()).Returns(cards);

            var result = cardService.GetAllCardsAsDTO(new());

            Assert.IsNotNull(result);
            Assert.IsInstanceOf<List<CardGetDTO>>(result);
        }

        [Test]
        public void GetAllCardsAsDTOWithTagsTest()
        {
            const string TAG = "geography";
            List<Card> filteredCards = cards.FindAll(x => x.CardUserData.Tag.Contains(TAG));
            mockCardRepository.Setup(x => x.GetCardsByTags(It.IsAny<List<string>>())).Returns(filteredCards);

            var result = cardService.GetAllCardsAsDTO(new() { TAG });

            Assert.IsNotNull(result);
            Assert.IsInstanceOf<List<CardGetDTO>>(result);
        }

        [Test]
        public void GetCardsToAnswerForDateAsDTOTest()
        {
            var date = new DateOnly(2024, 2, 19);
            var category = Category.FIRST;
            var expectedCards = cards.FindAll(card => card.LastAnswerDate <= date && card.Category == category);
            mockCardRepository.Setup(r => r.GetCardsToAnswerForDate(date, It.IsAny<Category>())).Returns(new List<Card>());
            mockCardRepository.Setup(r => r.GetCardsToAnswerForDate(date, category)).Returns(expectedCards);

            // Act
            var result = cardService.GetCardsToAnswerForDateAsDTO(date);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<List<CardGetDTO>>(result);
            Assert.That(result.Count, Is.EqualTo(expectedCards.Count));

        }

        [Test]
        public void AnswerCardTest()
        {
            var card = cards[0];
            card.Category = Category.FIRST;
            var cardId = card.Id;
            var isValid = true;
            mockCardRepository.Setup(r => r.GetById(cardId)).Returns(card);

            // Act
            cardService.AnswerCard(cardId, isValid);

            // Assert
            mockCardRepository.Verify(r => r.Update(card), Times.Once);
            Assert.That(card.Category, Is.EqualTo(Category.SECOND));
        }
    }
}
