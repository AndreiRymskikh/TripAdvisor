
using System.Text.Json.Serialization;

namespace TripAdvisorATF.Responses
{
    public class LocationResponse
    {
        [JsonPropertyName("status")]
        public bool Status { get; set; }

        [JsonPropertyName("message")]
        public string Message { get; set; }

        [JsonPropertyName("timestamp")]
        public long Timestamp { get; set; }

        [JsonPropertyName("data")]
        public List<LocationData> Data { get; set; }
    }

    public class LocationData
    {
        [JsonPropertyName("destinationId")]
        public int DestinationId { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}
