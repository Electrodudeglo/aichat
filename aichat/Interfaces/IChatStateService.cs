namespace aichat.Interfaces
{
    using aichat.Models;

    public interface IChatStateService
    {
        List<MessageModel> Messages { get; }
        List<TokenUsageModel> Tokens { get; }
        bool IsThinking { get; set; }
    }
}
