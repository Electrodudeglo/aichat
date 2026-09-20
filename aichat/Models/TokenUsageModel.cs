namespace aichat.Models
{
    public class TokenUsageModel
    {
        public int PromptTokens { get; set; }
        public int CompletionTokens { get; set; }
        public int TotalTokens { get; set; }

    }
}
