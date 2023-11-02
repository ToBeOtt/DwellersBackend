namespace Dwellers.Chat.Application
{
    public class ChatServiceResponse<T>
    {
        public T? Data { get; set; }
        public Guid? ConversationID { get; set; }
        public bool IsSuccess { get; set; }
        public string? ErrorMessage { get; set; }
        public string? ValidationMessage { get; set; }
    }
}
