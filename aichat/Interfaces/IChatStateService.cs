namespace aichat.Interfaces
{
    using aichat.Models;

    public interface IChatStateService
    {
        List<MessageModel> Messages { get; }
        bool IsThinking { get; set; }
        int Version { get; }

        event Action? OnChange;
        void NotifyStateChanged();
        void Reset();
    }
}
