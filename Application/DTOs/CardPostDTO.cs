using ProjetFlashcard.Domain.Enums;
using System.Text.Json.Serialization;

namespace ProjetFlashcard.Application.DTOs
{
    public class CardPostDTO
    {
        public string Question { get; set; }
        public string Answer { get; set; }
        public string Tag { get; set; }

        public CardPostDTO(string question, string answer, string tag)
        {
            Question = question;
            Answer = answer;
            Tag = tag;
        }

        #pragma warning disable CS8618
        public CardPostDTO() { }
        #pragma warning restore CS8618
    }
}
