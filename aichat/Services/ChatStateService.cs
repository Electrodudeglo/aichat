namespace aichat.Services
{
    using aichat.Interfaces;
    using aichat.Models;

    public class ChatStateService : IChatStateService
    {
        public List<MessageModel> Messages { get; } = new();
        public bool IsThinking { get; set; }
    }
}
