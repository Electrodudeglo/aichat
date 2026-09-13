namespace aichat.Services
{
    using aichat.Interfaces;
    using aichat.Models;

    public class ChatStateService : IChatStateService
    {
        public List<MessageModel> Messages { get; } = new();
        public List<TokenUsageModel> Tokens { get; } = new();
        public bool IsThinking { get; set; }

    }
}
