using RestSharp;
using System.Text.Json;
using TripAdvisorATF.Utils;


namespace TripAdvisorATF.Clients
{
    public class BaseClient
    {
        private readonly RestClient _client;

        public BaseClient()
        {
            _client = new RestClient(ConfigManager.BaseUrl);
        }

        protected async Task<T> SendRequestAsync<T>(RestRequest request) where T : class
        {
            request.AddHeader("X-RapidAPI-Key", ConfigManager.ApiKey);
            request.AddHeader("X-RapidAPI-Host", ConfigManager.ApiHost);

            var response = await _client.ExecuteAsync(request);

            if (!response.IsSuccessful || string.IsNullOrWhiteSpace(response.Content))
            {
                throw new Exception($"Error calling API: {response.StatusCode} - {response.Content}");
            }

            var deserializedResponse = JsonSerializer.Deserialize<T>(response.Content)
                ?? throw new Exception($"Failed to parse response from API endpoint: {request.Resource}");

            return deserializedResponse;
        }
    }
}
