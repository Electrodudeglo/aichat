namespace aichat.Models
{
    public enum ChatRole
    {
        User,
        Assistant
    }

    public class MessageModel
    {
        public ChatRole Role { get; set; }
        public string Content { get; set; } = string.Empty;
        public DateTime Timestamp { get; set; } = DateTime.Now;
    }
}
