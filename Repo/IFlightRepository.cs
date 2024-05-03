using Domain;

namespace Repo
{
    public interface IFlightRepository
    {
        Task<IEnumerable<Flight>> GetFlights();
        Task<IEnumerable<Latam>> GetLATAMFlights();
        Task<IEnumerable<Gol>> GetGOLFlights();
    }
}
