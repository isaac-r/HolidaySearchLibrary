using HolidaySearchLibrary.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidaySearchLibrary.Repositories
{
    public class FlightRepository : IFlightRepository
    {
        private List<Flight> flights;
        public List<Flight> GetFlights(string departureAirport, string destinationAirport, string departureDate)
        {
            LoadFlightData();
            var flightResults = flights.FindAll(f => f.DepartureAirport == departureAirport)
                .FindAll(f => f.DestinationAirport == destinationAirport)
                .FindAll(f => f.DepartureDate == departureDate);
            return flightResults;
        }

        public List<Flight> LoadFlightData()
        {
            var filename = File.ReadAllText((Directory.GetCurrentDirectory() + @"\Data\FlightData.json"));
            flights = JsonConvert.DeserializeObject<List<Flight>>(filename) ?? new List<Flight>();      
            return flights;
        }
    }
}
