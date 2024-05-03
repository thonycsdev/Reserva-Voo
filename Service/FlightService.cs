using Domain;
using Repo;

namespace Service
{
    public class FlightService : IFlightService
    {
        private readonly IFlightRepository _repo;

        public FlightService(IFlightRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<Flight>> OrganizeFlights()
        {
            var flights = await _repo.GetFlights();
            return flights.OrderByDescending(x => x.FarePrice).Reverse().ToList();
        }
    }
}
