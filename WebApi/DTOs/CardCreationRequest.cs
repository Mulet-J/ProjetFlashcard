namespace WebApi.DTOs
{
    public class CardCreationRequest
    {
        public string Question { get; set; }
        public string Answer { get; set; }
        public string Tag { get; set; }

#pragma warning disable CS8618
        public CardCreationRequest() { }
#pragma warning restore CS8618
    }
}
