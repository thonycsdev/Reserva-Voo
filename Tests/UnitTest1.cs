using System.Text.Json;
using AutoFixture;
using Domain;
using FluentAssertions;
using Repo;
using Service;

namespace Tests;

public class TicketTest
{
    private readonly Fixture _fixture;

    public TicketTest()
    {
        _fixture = new Fixture();
    }

    [Fact]
    public async void ShouldReturnResponseFromAPIGOL()
    {
        var repo = new FlightRepository();
        var result = await repo.GetFlights();

        result.Count().Should().BeGreaterThan(5);
    }

    [Fact]
    public async void ShouldParseLatamToFlight()
    {
        var latam = _fixture.Create<Latam>();

        var result = Flight.ParseLatamToFlight(latam);

        result.Carrier.Should().Be(latam.Airline);
        result.FlightNumber.Should().Be(latam.FlightID);
        result.ArrivalDate.Should().Be(latam.FlightEnd);
        result.FarePrice.Should().Be(latam.TotalFare);
        result.DepartureDate.Should().Be(latam.FlightStart);
        result.OriginAirport.Should().Be(latam.DepartureAirport);
        result.DestinationAirport.Should().Be(latam.ArrivalAirport);
    }

    [Fact]
    public async void ShouldReturnTheListOfFlightOrganized()
    {
        var repo = new FlightRepository();
        var serv = new FlightService(repo);
        var result = await serv.OrganizeFlights();
        var r = JsonSerializer.Serialize(result);
        Console.WriteLine(r);
    }
}
