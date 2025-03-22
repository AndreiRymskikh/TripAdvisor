using System.Text.Json.Serialization;

namespace TripAdvisorATF.Responses
{
    public class CruiseResponse
    {
        [JsonPropertyName("data")]
        public CruiseData Data { get; set; }
    }

    public class CruiseData
    {
        [JsonPropertyName("list")]
        public List<CruiseDetails> List { get; set; }
    }

    public class CruiseDetails
    {
        [JsonPropertyName("ship")]
        public ShipInfo Ship { get; set; }
    }

    public class ShipInfo
    {
        private int? _crew;

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("crew")]
        public int? Crew {
            get => _crew ?? 0;
            set => _crew = value;
        }
    }
}
