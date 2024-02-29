using Application.Exceptions;
using Application.Services;
using Domain.Enums;
using Domain.Repositories;
using Infrastructure.ExternalServices;

namespace ProjetFlashcardTest
{
    public class CardServiceTest
    {
        private Mock<ICardRepository> mockCardRepository;
        private CardService cardService;
        private List<Card> cards = [];

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

            var result = cardService.GetAllCards([]);

            Assert.That(result, Is.EqualTo(cards));
        }

        [Test]
        public void GetAllCardReturnEmptyListTest()
        {
            mockCardRepository.Setup(mockCardRepository => mockCardRepository.GetAll()).Returns([]);

            var result = cardService.GetAllCards([]);

            Assert.That(result, Is.EqualTo(new List<Card>()));
        }

        [Test]
        public void GetAllCardWithTagsTest()
        {
            const string Tag = "geography";
            List<Card> filteredCards = cards.FindAll(x => x.CardUserData.Tag.Contains(Tag));
            mockCardRepository.Setup(x => x.GetCardsByTags(It.IsAny<List<string>>())).Returns(filteredCards);

            var result = cardService.GetAllCards([Tag]);

            Assert.That(result, Is.EqualTo(filteredCards));
        }

        [Test]
        public void GetAllCardsWithForeignTagTest()
        {
            const string Tag = "thistagdoesnotexist";

            List<Card> filteredCards = cards.FindAll(x => x.CardUserData.Tag.Contains(Tag));
            mockCardRepository.Setup(x => x.GetCardsByTags(It.IsAny<List<string>>())).Returns(filteredCards);

            var result = cardService.GetAllCards([Tag]);

            Assert.That(result, Is.EqualTo(filteredCards));
        }

        [Test]
        public void GetAllCardsAsDTOWithNoTagsTest()
        {
            mockCardRepository.Setup(x => x.GetAll()).Returns(cards);

            var result = cardService.GetAllCards([]);

            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<List<Card>>());
        }

        [Test]
        public void GetAllCardsAsDTOWithTagsTest()
        {
            const string Tag = "geography";
            List<Card> filteredCards = cards.FindAll(x => x.CardUserData.Tag.Contains(Tag));
            mockCardRepository.Setup(x => x.GetCardsByTags(It.IsAny<List<string>>())).Returns(filteredCards);

            var result = cardService.GetAllCards([Tag]);

            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<List<Card>>());
        }

        [Test]
        public void GetAllCardsAsDTOWithForeignTagTest()
        {
            const string Tag = "thistagdoesnotexist";
            List<Card> filteredCards = cards.FindAll(x => x.CardUserData.Tag.Contains(Tag));
            mockCardRepository.Setup(x => x.GetCardsByTags(It.IsAny<List<string>>())).Returns(filteredCards);

            var result = cardService.GetAllCards([Tag]);

            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<List<Card>>());
        }

        [Test]
        public void GetCardsToAnswerForDateAsDTOTest()
        {
            DateOnly date = new(2024, 2, 19);
            const Category category = Category.FIRST;
            var expectedCards = cards.FindAll(card => card.LastAnswerDate <= date && card.Category == category);
            mockCardRepository.Setup(r => r.GetCardsToAnswerForDate(date, It.IsAny<Category>())).Returns([]);
            mockCardRepository.Setup(r => r.GetCardsToAnswerForDate(date, category)).Returns(expectedCards);

            var result = cardService.GetCardsToAnswerForDate(date);

            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<List<Card>>());
            Assert.That(result, Has.Count.EqualTo(expectedCards.Count));
        }

        [Test]
        public void GetCardsToAnswerForDateAsDTOWithNoCardsTest()
        {
            DateOnly date = new(2024, 2, 19);
            mockCardRepository.Setup(r => r.GetCardsToAnswerForDate(date, It.IsAny<Category>())).Returns([]);

            var result = cardService.GetCardsToAnswerForDate(date);

            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<List<Card>>());
            Assert.That(result, Has.Count.EqualTo(0));
        }

        [Test]
        public void GetCardsToAnswerInAFewMonthsTest()
        {
            DateOnly date = new(2024, 9, 28);
            List<Card> totalExpectedCards = [];
            foreach (Category cat in Enum.GetValues(typeof(Category)))
            {
                if (cat == Category.DONE)
                {
                    continue;
                }
                var categoryExpectedCards = cards.FindAll(card => card.LastAnswerDate <= date && card.Category == cat);
                totalExpectedCards.AddRange(categoryExpectedCards);
                mockCardRepository.Setup(r => r.GetCardsToAnswerForDate(date, cat)).Returns(categoryExpectedCards);
            }

            var result = cardService.GetCardsToAnswerForDate(date);

            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<List<Card>>());
            Assert.That(result, Has.Count.EqualTo(totalExpectedCards.Count));
        }

        [Test]
        public void AnswerCardTest()
        {
            var card = cards[0];
            card.Category = Category.FIRST;
            var cardId = card.Id;
            const bool isValid = true;
            mockCardRepository.Setup(r => r.GetById(cardId)).Returns(card);

            cardService.AnswerCard(cardId, isValid);

            mockCardRepository.Verify(r => r.Update(card), Times.Once);
            Assert.That(card.Category, Is.EqualTo(Category.SECOND));
        }

        [Test]
        public void AnswerCardWithInvalidCardIdTest()
        {
            const string CardId = "invalidId";
            const bool IsValid = true;
            mockCardRepository.Setup(r => r.GetById(CardId)).Returns((Card?)null);

            Assert.Throws<CardNotFoundException>(() => cardService.AnswerCard(CardId, IsValid));
        }

        [Test]
        public void AnswerCardWithInvalidIsValidTest()
        {
            const bool IsValid = false;
            Card card = cards[0];
            string cardId = card.Id;
            mockCardRepository.Setup(r => r.GetById(cardId)).Returns(card);

            cardService.AnswerCard(cardId, IsValid);

            mockCardRepository.Verify(r => r.Update(card), Times.Once);
            Assert.That(card.Category, Is.EqualTo(Category.FIRST));
        }
    }
}
