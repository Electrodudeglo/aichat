namespace aichat.Services
{
    using aichat.Models;

    public interface IChatStateService
    {
        List<MessageModel> Messages { get; }
        bool IsThinking { get; set; }
    }
}
