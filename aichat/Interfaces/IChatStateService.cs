namespace aichat.Interfaces
{
    using aichat.Models;

    public interface IChatStateService
    {
        List<MessageModel> Messages { get; }
        bool IsThinking { get; set; }
        int Version { get; }
        bool? IsApiKeyValid { get; set; }
        string? ValidatedKey { get; set; }

        event Action? OnChange;
        void NotifyStateChanged();
        void Reset();
    }
}
