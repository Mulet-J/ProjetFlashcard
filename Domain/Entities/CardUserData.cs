using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class CardUserData
    {
        [Key]
        public string Id { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public string Tag { get; set; }

        //Empty constructor for EntityFramework
#pragma warning disable CS8618
        public CardUserData() { }
#pragma warning restore CS8618

        public CardUserData(string question, string answer, string tag)
        {
            Id = Guid.NewGuid().ToString();
            Question = question;
            Answer = answer;
            Tag = tag;
        }
    }
}
