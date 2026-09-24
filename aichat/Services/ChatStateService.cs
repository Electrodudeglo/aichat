namespace aichat.Services
{
    using aichat.Interfaces;
    using aichat.Models;

    public class ChatStateService : IChatStateService
    {
        public List<MessageModel> Messages { get; } = new();
        public bool IsThinking { get; set; }
        public int Version { get; private set; }
        public bool? IsApiKeyValid { get; set; }
        public string? ValidatedKey { get; set; }

        public event Action? OnChange;

        public void NotifyStateChanged() => OnChange?.Invoke();

        public void Reset()
        {
            Messages.Clear();
            IsThinking = false;
            Version++;
            NotifyStateChanged();
        }
    }
}
