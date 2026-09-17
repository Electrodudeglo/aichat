namespace aichat.Models
{

    using aichat.Enums;
    public class MessageModel
    {
        public ChatRoleEnum Role { get; set; }
        public string Content { get; set; } = string.Empty;
        public DateTime Timestamp { get; set; } = DateTime.Now;
        public bool Liked { get; set; }
        public TokenUsageModel? TokenUsage { get; set; }
    }
}
