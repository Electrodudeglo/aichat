namespace aichat.Interfaces
{
    using aichat.Models;

    public interface IChatStateService
    {
        List<MessageModel> Messages { get; }
        List<ChatCompletionUsage> Usage { get; }
        bool IsThinking { get; set; }
    }
}
