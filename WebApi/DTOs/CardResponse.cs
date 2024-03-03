using Domain.Enums;
using Domain.Helpers;

namespace WebApi.DTOs
{
    public class CardResponse
    {
        public string Id { get; set; }
        public string Category { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public string Tag { get; set; }

        public CardResponse(string id, Category category, string question, string answer, string tag)
        {
            Id = id;
            Category = CategoryHelpers.GetCategoryName(category);
            Question = question;
            Answer = answer;
            Tag = tag;
        }
    }
}
