using ProjetFlashcard.Domain.Enums;
using System.Text.Json.Serialization;

namespace ProjetFlashcard.Application.DTOs
{
    public class CardGetDTO
    {
        public string Id { get; set; }
        public string Category { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public string Tag { get; set; }

        public CardGetDTO(string id, Category category, string question, string answer, string tag)
        {
            Id = id;
            Category = Enum.GetName(typeof(Category), category);
            Question = question;
            Answer = answer;
            Tag = tag;
        }

        #pragma warning disable CS8618
        CardGetDTO() { }
        #pragma warning restore CS8618
    }
}
