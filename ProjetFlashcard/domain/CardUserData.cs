namespace ProjetFlashcard.domain
{
    public class CardUserData
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public CardUserData(int id, string question, string answer)
        {
            Id = id;
            Question = question;
            Answer = answer;
        }
    }
}
