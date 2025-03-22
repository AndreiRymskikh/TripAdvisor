using System.Text.Json;

namespace TripAdvisorATF.Utils
{
    public static class ConfigManager
    {
        private const string ConfigFileName = "config.json";
        private static readonly string ConfigFilePath = Path.Combine(Directory.GetCurrentDirectory(), ConfigFileName);
        private static ConfigData _config;

        static ConfigManager()
        {
            _config = LoadConfig();
        }

        public static string ApiKey => _config.ApiKey;
        public static string BaseUrl => _config.BaseUrl;
        public static string ApiHost => _config.ApiHost;

        private static ConfigData LoadConfig()
        {
            if (!File.Exists(ConfigFilePath))
                throw new FileNotFoundException($"Configuration file '{ConfigFileName}' was not found by path: {ConfigFilePath}");

            try
            {
                string json = File.ReadAllText(ConfigFilePath);
                return JsonSerializer.Deserialize<ConfigData>(json)
                    ?? throw new JsonException($"Failed to parse '{ConfigFileName}'.");
            }
            catch (Exception ex)
            {
                throw new Exception($"Error loading configuration: {ex.Message}");
            }
        }
    }

    public class ConfigData
    {
        public required string ApiKey { get; set; }
        public required string BaseUrl { get; set; }
        public required string ApiHost { get; set; }
    }
}