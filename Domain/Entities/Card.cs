using Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Card
    {
        [Key]
        public string Id { get; set; }
        public DateOnly LastAnswerDate { get; set; }
        public Category Category { get; set; }
        public CardUserData CardUserData { get; set; }

        //Empty constructor for EntityFramework
#pragma warning disable CS8618
        public Card() { }
#pragma warning restore CS8618

        public Card(CardUserData cardUserData)
        {
            Id = Guid.NewGuid().ToString();
            LastAnswerDate = DateOnly.FromDateTime(DateTime.Now.AddDays(-1));
            Category = Category.FIRST;
            CardUserData = cardUserData;
        }
    }
}
