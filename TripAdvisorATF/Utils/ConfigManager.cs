using System.Text.Json;

namespace TripAdvisorATF.Utils
{
    public static class ConfigManager
    {
        public static string ApiKey { get; private set; }
        public static string BaseUrl { get; private set; }
        public static string ApiHost { get; private set; }
        public static string DefaultOrder { get; private set; }
        public static string DefaultCurrency { get; private set; }

        private const string ConfigFileName = "config.json";
        private static readonly string ConfigFilePath = Path.Combine(Directory.GetCurrentDirectory(), ConfigFileName);
        private static ConfigData _config;

        static ConfigManager()
        {
            LoadConfig();
            ApiKey = _config.ApiKey;
            BaseUrl = _config.BaseUrl;
            ApiHost = _config.ApiHost;
            DefaultOrder = _config.DefaultOrder;
            DefaultCurrency = _config.DefaultCurrency;
        }

        private static void LoadConfig()
        {
            if (!File.Exists(ConfigFilePath))
                throw new FileNotFoundException($"'{ConfigFileName}' file was not found at path: {ConfigFilePath}");

            string json = File.ReadAllText(ConfigFilePath);
            _config = JsonSerializer.Deserialize<ConfigData>(json) ?? throw new JsonException($"Failed to parse {ConfigFileName}");
        }
    }

    public class ConfigData
    {
        public required string ApiKey { get; set; }
        public required string BaseUrl { get; set; }
        public required string ApiHost { get; set; }
        public required string DefaultOrder { get; set; }
        public required string DefaultCurrency { get; set; }
    }

}