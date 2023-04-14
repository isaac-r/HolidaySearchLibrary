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
        public List<Flight> GetFlights(string[] departureAirports, string destinationAirport, string departureDate, List<Flight> allFlights)
        {
            List<Flight> flightResults = new();
            if (departureAirports.Length == 1)
            {
                flightResults = allFlights
                    .FindAll(f => f.DepartureAirport == departureAirports[0])
                    .FindAll(f => f.DestinationAirport == destinationAirport)
                    .FindAll(f => f.DepartureDate == departureDate);
            } else
            {
                var tempFlightsList = new List<Flight>();
                foreach (var airport in departureAirports)
                {
                    var filteredFlights = new List<Flight>();
                    filteredFlights = allFlights.FindAll(f => f.DepartureAirport == airport);
                    tempFlightsList.AddRange(filteredFlights);
                }
                flightResults = tempFlightsList.ToList()
                    .FindAll(f => f.DestinationAirport == destinationAirport)
                    .FindAll(f => f.DepartureDate == departureDate); ;
            }

            return flightResults;
        }

        public List<Flight> LoadData(string path, bool isFile)
        {
            if (string.IsNullOrEmpty(path))
            {
                path = Directory.GetCurrentDirectory() + @"\Data\FlightData.json";
            }
            string? flightData;
            if (isFile)
            {
                flightData = path;
            }
            else
            {
                flightData = File.ReadAllText(path);
            }

            return JsonConvert.DeserializeObject<List<Flight>>(flightData) ?? new List<Flight>();
        }
    }
}
