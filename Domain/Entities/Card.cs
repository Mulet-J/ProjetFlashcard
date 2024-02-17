using System.ComponentModel.DataAnnotations;

namespace ProjetFlashcard.Domain.Entities
{
    public class Card
    {
        [Key]
        public string Id { get; set; }
        public CardUserData CardUserData { get; set; }
        public string Tag { get; set; }
        public int Category { get; set; }

        #pragma warning disable CS8618
        public Card() { }

        public Card(CardUserData cardUserData, string tag, int category) 
        {
            this.Id = Guid.NewGuid().ToString();
            this.CardUserData = cardUserData;
            this.Tag = tag;
            this.Category = category;
        }   
    }
}
