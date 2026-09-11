namespace aichat.Services
{
    using System.Net.Http.Headers;
    using System.Net.Http.Json;
    using System.Web;
    using aichat.Models;

    public class ChatService
    {

        public async Task<ChatCompletionResponse?> OpenAiAsync(string apiKey, IEnumerable<MessageModel> messages)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);

            var body = new
            {
                model = "gpt-4-turbo",
                messages = messages.Select(m => new ChatCompletionMessage
                {
                    Role = m.Role == ChatRole.User ? "user" : "assistant",
                    Content = m.Content
                })
            };

            var response = await client.PostAsJsonAsync("https://api.openai.com/v1/chat/completions",body);
           
            return await response.Content.ReadFromJsonAsync<ChatCompletionResponse>();
        }


        public async Task<bool> IsApiKeyValidAsync(string apiKey)
        {
            if (string.IsNullOrWhiteSpace(apiKey))
            {
                return false;
            }

            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);

            try
            {
                var response = await client.GetAsync("https://api.openai.com/v1/models");
                return response.IsSuccessStatusCode;
            }
            catch (HttpRequestException)
            {
                return false;
            }
        }

    }

}

