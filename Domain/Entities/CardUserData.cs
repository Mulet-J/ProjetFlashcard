using System.ComponentModel.DataAnnotations;

namespace ProjetFlashcard.Domain.Entities
{
    public class CardUserData
    {
        [Key]
        public string Id { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }

        #pragma warning disable CS8618
        public CardUserData() { }

        public CardUserData(string question, string answer)
        {
            Id = Guid.NewGuid().ToString();
            Question = question;
            Answer = answer;
        }

        public CardUserData(string id, string question, string answer) : this(question, answer)
        {
            Id = id;
        }
    }
}
