using RestSharp;
using TripAdvisorATF.Responses;
using TripAdvisorATF.Utils;

namespace TripAdvisorATF.Clients
{
    public class CruisesClient : BaseClient
    {
        public async Task<int> GetDestinationIdAsync(string destinationName)
        {
            var request = new RestRequest("/cruises/getLocation", Method.Get);
            var locationResponse = await SendRequestAsync<LocationResponse>(request);

            if (locationResponse.Data == null || locationResponse.Data.Count == 0)
            {
                throw new Exception("No destinations found in the GetLocation response.");
            }

            var destination = locationResponse.Data.FirstOrDefault(d => d.Name.Contains(destinationName, StringComparison.OrdinalIgnoreCase));

            return destination?.DestinationId
                ?? throw new Exception($"Destination '{destinationName}' not found in the API response.");
        }

        public async Task<List<CruiseDetails>> GetCruisesByDestinationAsync(int destinationId)
        {
            var request = new RestRequest("/cruises/searchCruises", Method.Get);
            request.AddQueryParameter("destinationId", destinationId.ToString());
            request.AddQueryParameter("order", ConfigManager.DefaultOrder);
            request.AddQueryParameter("currencyCode", ConfigManager.DefaultCurrency);

            var cruiseResponse = await SendRequestAsync<CruiseResponse>(request);

            if (cruiseResponse.Data == null || cruiseResponse.Data.List == null)
            {
                throw new Exception($"No cruise data found for destinationId: {destinationId}");
            }

            return cruiseResponse.Data.List;
        }
    }
}
