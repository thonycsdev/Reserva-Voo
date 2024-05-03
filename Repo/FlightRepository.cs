using System.Text.Json;
using Domain;

namespace Repo
{
    public class FlightRepository : IFlightRepository
    {
        private readonly HttpClient _client;

        public FlightRepository()
        {
            _client = new HttpClient();
        }

        public async Task<IEnumerable<Flight>> GetFlights()
        {
            var latams = await GetLATAMFlights();
            var flights = latams.Select(x => Flight.ParseLatamToFlight(x));
            var gols = await GetGOLFlights();
            return flights.Concat(gols);
        }

        public async Task<IEnumerable<Gol>> GetGOLFlights()
        {
            var responseString = await _client.GetStringAsync(
                "https://dev.reserve.com.br/airapi/gol/getavailability?origin=Rio%20de%20Janeiro&destination=São%20Paulo&date=2024-06-20"
            );

            var result = JsonSerializer.Deserialize<List<Gol>>(responseString);
            return result;
        }

        public async Task<IEnumerable<Latam>> GetLATAMFlights()
        {
            var responseString = await _client.GetStringAsync(
                "https://dev.reserve.com.br/airapi/latam/flights?departureCity=Rio%20de%20Janeiro&arrivalCity=São%20Paulo&departureDate=2024-06-20"
            );

            var result = JsonSerializer.Deserialize<List<Latam>>(responseString);
            return result;
        }
    }
}
