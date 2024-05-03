namespace Domain;

public class Flight
{
    public string FlightNumber { get; set; }
    public string Carrier { get; set; }
    public DateTime DepartureDate { get; set; }
    public DateTime ArrivalDate { get; set; }
    public string OriginAirport { get; set; }
    public string DestinationAirport { get; set; }
    public double FarePrice { get; set; }

    public static Flight ParseLatamToFlight(Latam latam)
    {
        var result = new Flight();
        result.Carrier = latam.Airline;
        result.FlightNumber = latam.FlightID;
        result.FarePrice = latam.TotalFare;
        result.ArrivalDate = latam.FlightEnd;
        result.DepartureDate = latam.FlightStart;
        result.OriginAirport = latam.DepartureAirport;
        result.DestinationAirport = latam.ArrivalAirport;
        return result;
    }
}
