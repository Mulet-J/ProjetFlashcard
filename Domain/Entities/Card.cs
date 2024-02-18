using ProjetFlashcard.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace ProjetFlashcard.Domain.Entities
{
    public class Card
    {
        [Key]
        public string Id { get; set; }
        public DateOnly LastAnswerDate { get; set; }
        public Category Category { get; set; }
        public CardUserData CardUserData { get; set; }

        #pragma warning disable CS8618
        public Card() { }
        #pragma warning restore CS8618

        public Card(CardUserData cardUserData)
        {
            Id = Guid.NewGuid().ToString();
            //TODO adapter la date
            LastAnswerDate = DateOnly.FromDateTime(DateTime.Now.AddDays(-1));
            Category = Category.FIRST;
            CardUserData = cardUserData;
        }

        public Card(CardUserData cardUserData, Category category, DateOnly time) 
        {
            Id = Guid.NewGuid().ToString();
            LastAnswerDate = time;
            CardUserData = cardUserData;
            Category = category;
        }

        //public Card(string idCardUserData, string question, string answer, string tag, string idCard, Category category, DateOnly time)
        //{
        //    Id = idCard;
        //    LastAnswerDate = time;
        //    Category = category;
        //    CardUserData = new CardUserData(idCardUserData, question, answer, tag);
        //}
    }
}
