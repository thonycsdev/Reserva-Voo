using Domain;

namespace Service
{
    public interface IFlightService
    {
        Task<IEnumerable<Flight>> OrganizeFlights();
    }
}
