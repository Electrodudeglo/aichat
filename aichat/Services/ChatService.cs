namespace aichat.Services
{
    using System.Net.Http.Headers;
    using System.Net.Http.Json;
    using aichat.Models;

    public class ChatService
    {
        private readonly HttpClient _httpClient;

        public ChatService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ChatCompletionResponse?> OpenAiAsync(string apiKey, IEnumerable<MessageModel> messages)
        {
            var body = new
            {
                model = "gpt-4-turbo",
                messages = messages.Select(m => new ChatCompletionMessage
                {
                    Role = m.Role == ChatRole.User ? "user" : "assistant",
                    Content = m.Content
                })
            };

            using var request = new HttpRequestMessage(HttpMethod.Post, "https://api.openai.com/v1/chat/completions")
            {
                Content = JsonContent.Create(body)
            };
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);

            var response = await _httpClient.SendAsync(request);

            return await response.Content.ReadFromJsonAsync<ChatCompletionResponse>();
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
