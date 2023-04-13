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
        public List<Flight> GetFlights(string[] departureAirports, string destinationAirport, string departureDate)
        {
            LoadFlightData();
            List<Flight> flightResults = new();
            if (departureAirports.Length == 1)
            {
                flightResults = flights
                    .FindAll(f => f.DepartureAirport == departureAirports[0])
                    .FindAll(f => f.DestinationAirport == destinationAirport)
                    .FindAll(f => f.DepartureDate == departureDate);
            } else
            {
                var tempFlightsList = new List<Flight>();
                foreach (var airport in departureAirports)
                {
                    var filteredFlights = new List<Flight>();
                    filteredFlights = flights.FindAll(f => f.DepartureAirport == airport);
                    tempFlightsList.AddRange(filteredFlights);
                }
                flightResults = tempFlightsList.ToList()
                    .FindAll(f => f.DestinationAirport == destinationAirport)
                    .FindAll(f => f.DepartureDate == departureDate); ;
            }

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
