using TripAdvisorATF.Clients;

namespace TripAdvisorATF.Tests
{
    public class CruisesTests
    {
        private readonly CruisesClient _cruisesClient;

        public CruisesTests()
        {
            _cruisesClient = new CruisesClient();
        }

        [Fact]
        public async Task GetCaribbeanCruisesSortAndPrintTest()
        {
            int destinationId = await _cruisesClient.GetDestinationIdAsync("Caribbean");
            //It can be needed when getLocation endpoint is down. So, I better leave it here
            //int destinationId = 147237;

            var cruises = await _cruisesClient.GetCruisesByDestinationAsync(destinationId);
            var sortedCruises = cruises
                .DistinctBy(c => c.Ship.Name)
                .OrderByDescending(c => c.Ship.Crew)
                .ToList();

            Assert.NotEmpty(sortedCruises);

            Console.WriteLine("\nCaribbean Cruises (sorted by Crew Count):");
            foreach (var cruise in sortedCruises)
            {
                Console.WriteLine($"Ship: {cruise.Ship.Name}");
            }
        }
    }
}
