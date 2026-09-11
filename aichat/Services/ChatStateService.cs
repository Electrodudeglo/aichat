namespace aichat.Services
{
    using aichat.Models;

    public class ChatStateService
    {
        public List<MessageModel> Messages { get; } = new();
        public bool IsThinking { get; set; }
    }
}
