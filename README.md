# TripAdvisor API Automation testing Framework

This is C# + RestSharp + xUnit automation testing framework.  The test fetchs and sorts cruise data from the TripAdvisor cruises endpoints.

## Preconditions

- .NET 8
- Take API Key from your account subscription on TripAdvisor - https://rapidapi.com/DataCrawler/api/tripadvisor16/. 
- Add your API key to config.json file
   {
       "ApiKey": "your-api-key-here"
   }

## Setup Instructions

Clone the repo:
    git clone https://github.com/AndreiRymskikh/TripAdvisor.git

Navigate to project folder:
    cd TripAdvisorAutomation

Install dependencies:
    dotnet restore

Run tests:
    dotnet test


## Other details

This project includes a GitHub Actions pipeline (.github/workflows/dotnet.yml) 
