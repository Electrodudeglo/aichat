namespace aichat.Services
{
    using System.Net.Http.Headers;
    using System.Net.Http.Json;
    using System.Text.Json;
    using aichat.Models;
    using aichat.Enums;

    public class ChatService
    {
        private const string ChatModel = "gpt-4-turbo";

        private readonly HttpClient _httpClient;

        public ChatService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ChatCompletionResponse?> SendChatAsync(string apiKey, IEnumerable<MessageModel> messages)
        {
            var body = new
            {
                model = ChatModel,
                messages = messages.TakeLast(10).Select(m => new ChatCompletionMessage
                {
                    Role = m.Role == ChatRoleEnum.User ? "user" : "assistant",
                    Content = m.Content
                })
            };

            using var request = new HttpRequestMessage(HttpMethod.Post, "https://api.openai.com/v1/chat/completions")
            {
                Content = JsonContent.Create(body)
            };
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);

            try
            {
                var response = await _httpClient.SendAsync(request);

                if (!response.IsSuccessStatusCode)
                {
                    return null;
                }

                return await response.Content.ReadFromJsonAsync<ChatCompletionResponse>();
            }
            catch (Exception ex) when (ex is HttpRequestException or JsonException or TaskCanceledException)
            {
                return null;
            }
        }

        public async Task<bool> IsApiKeyValidAsync(string apiKey)
        {
            if (string.IsNullOrWhiteSpace(apiKey))
            {
                return false;
            }

            using var request = new HttpRequestMessage(HttpMethod.Get, "https://api.openai.com/v1/models");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);

            try
            {
                var response = await _httpClient.SendAsync(request);
                return response.IsSuccessStatusCode;
            }
            catch (HttpRequestException)
            {
                return false;
            }
        }

    }

}
