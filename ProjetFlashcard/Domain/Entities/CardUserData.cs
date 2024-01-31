namespace ProjetFlashcard.Domain.Entities
{
    public class CardUserData
    {
        public string Id { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        /// <summary>
        /// ça fait un truc
        /// </summary>
        /// <param name="question"></param>
        /// <param name="answer"></param>
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
