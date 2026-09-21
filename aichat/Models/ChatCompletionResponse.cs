namespace aichat.Models
{
    using System.Text.Json.Serialization;

    public class ChatCompletionResponse
    {
        [JsonPropertyName("choices")]
        public List<ChatCompletionChoice> Choices { get; set; } = new();

        [JsonPropertyName("usage")]
        public ChatCompletionUsage? Usage { get; set; }
    }

    public class ChatCompletionChoice
    {
        [JsonPropertyName("message")]
        public ChatCompletionMessage Message { get; set; } = new();
    }

    public class ChatCompletionMessage
    {
        [JsonPropertyName("role")]
        public string Role { get; set; } = string.Empty;

        [JsonPropertyName("content")]
        public string Content { get; set; } = string.Empty;
    }

    public class ChatCompletionUsage
    {
        [JsonPropertyName("prompt_tokens")]
        public int PromptTokens { get; set; }

        [JsonPropertyName("completion_tokens")]
        public int CompletionTokens { get; set; }

        [JsonPropertyName("total_tokens")]
        public int TotalTokens { get; set; }
    }
}
