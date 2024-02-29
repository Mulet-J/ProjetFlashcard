namespace WebApi.DTOs
{
    public class CardPostDto
    {
        public string Question { get; set; }
        public string Answer { get; set; }
        public string Tag { get; set; }

#pragma warning disable CS8618
        public CardPostDto() { }
#pragma warning restore CS8618
    }
}
