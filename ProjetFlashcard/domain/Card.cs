using System.Numerics;

namespace ProjetFlashcard.domain
{
    public class Card
    {
        public CardUserData CardUserData { get; set; }
        public string Tag { get; set; }
        public int Category { get; set; }
        public Card(CardUserData cardUserData, string tag, int category) 
        {
            this.CardUserData = cardUserData;
            this.Tag = tag;
            this.Category = category;
        }   
    }
}
