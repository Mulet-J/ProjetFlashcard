global using Moq;

namespace ProjetFlashcardTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void Test1()
        {
            Mock<ICardService> cardServiceStub = new Mock<ICardService>();

            //cardServiceStub
            //    .Setup(x => x.GetAllCards(null))
            //    .Returns()



            Assert.Pass();
        }
    }
}