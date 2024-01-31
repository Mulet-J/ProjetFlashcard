using ProjetFlashcard.Domain.Entities;

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
            CardUserData cardUser = new CardUserData("azezae", "aeazez");
            CardUserData cardUserData = new CardUserData(Guid.NewGuid().ToString(), "azezae", "ajhkgh");
            Assert.Pass();
        }
    }
}